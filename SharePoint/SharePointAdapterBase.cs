using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CSV.Logging;
using Domain;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;
using SharePoint.Extensions;

namespace SharePoint
{
    public class SharePointAdapterBase
    {
        private protected readonly Mapper Mapper = new Mapper();
        private ClientContext _ctx;

        private static Uri SharepointSiteUrl { get; set; }
        private static NetworkCredential Credentials { get; set; }

        private readonly Dictionary<string, string> _ensuredEmails = new Dictionary<string, string>();
        private readonly IPimsLogger _logger;


        protected SharePointAdapterBase(IPimsLogger logger)
        {
            _logger = logger;
        }
        
        protected static void SetUrlAndCredentials(Uri uri, NetworkCredential credentials)
        {
            SharepointSiteUrl = uri ?? throw new ArgumentNullException(nameof(uri));
            Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
        }

        protected IEnumerable<T> GetAllEntities<T>(string title, Func<ListItem, T> map)
        {
            using (_ctx = new ClientContext(SharepointSiteUrl))
            {
                _ctx.Credentials = Credentials ?? throw new ArgumentNullException(nameof(Credentials));
                var list = GetList(title);
                var items = GetAllItems(list);
                return items.Select(x => SetEmailAndMap(x, map));
            }
        }

        protected IEnumerable<T> GetAllDocEntities<T>(string title, Func<ListItem, T> map)
        {
            using (_ctx = new ClientContext(SharepointSiteUrl))
            {
                _ctx.Credentials = Credentials ?? throw new ArgumentNullException(nameof(Credentials));
                var list = GetList(title);
                var items = GetAllDocs(list);

                return items.Select(x => SetEmailAndMap(x, map));
            }
        }

        protected T GetFirstEntity<T>(string title, Func<ListItem, T> map)
        {
            using (_ctx = new ClientContext(SharepointSiteUrl))
            {
                _ctx.Credentials = Credentials ?? throw new ArgumentNullException(nameof(Credentials));
                var list = GetList(title);
                var item = GetFirstItem(list);
                EnsureEmail(item);
                return map(item);
            }
        }

        private IEnumerable<ListItem> GetAllItems(List list)
        {
            var query = DefaultQuery();
            var result = new List<ListItem>();

            ListItemCollectionPosition position = null;
            do
            {
                query.ListItemCollectionPosition = position;

                var items = list.GetItems(query);
                _ctx.Load(items);
                _ctx.ExecuteQuery();
                foreach (var item in items) result.Add(item);

                position = items.ListItemCollectionPosition;
            } while (position != null);

            return result;
        }

        private ListItemCollection GetAllDocs(List list)
        {
            var query = CamlQuery.CreateAllItemsQuery(); ;
            var items = list.GetItems(query);
            _ctx.Load(items);
            _ctx.ExecuteQuery();

            return items;
        }

        private ListItem GetFirstItem(List list)
        {
            var query = new CamlQuery
            {
                ViewXml = CAML.ViewQuery(
                    ViewScope.DefaultValue,
                    rowLimit: 1)
            };
            var items = list.GetItems(query);
            _ctx.Load(items);
            _ctx.ExecuteQuery();
            return items[0];
        }

        private static CamlQuery DefaultQuery()
        {
            return new CamlQuery
            {
                ViewXml = CAML.ViewQuery(
                    ViewScope.DefaultValue,
                    rowLimit: Constants.DefaultQueryRowLimit)
            };
        }

        private List GetList(string title)
        {
            var web = _ctx.Web;
            var list = web.Lists.GetByTitle(title);
            _ctx.Load(list);
            _ctx.ExecuteQuery();
            return list;
        }

        private T SetEmailAndMap<T>(ListItem item, Func<ListItem, T> map)
        {
            EnsureEmail(item);
            return map(item);
        }

        private void EnsureEmail(ListItem item)
        {
            var userFields = item.FieldValues
                .Where(value => value.Value as FieldUserValue != null)
                .Select(value => value.Value as FieldUserValue);

            foreach (var fieldUserValue in userFields)
            {
                var username = fieldUserValue.LookupValue;
                if (_ensuredEmails.ContainsKey(username))
                {
                    fieldUserValue.SetEmail(_ensuredEmails[username]);
                    continue;
                }
                
                QueryEmail(fieldUserValue, username);
                _ensuredEmails.Add(username, fieldUserValue.Email);
            }
        }

        private void QueryEmail(FieldUserValue fieldUserValue, string username)
        {
            try
            {
                var user = _ctx.Web.EnsureUser(username);
                _ctx.Load(user);
                _ctx.ExecuteQuery();

                var email = user.Email;
                if (!string.IsNullOrEmpty(email))
                {
                    fieldUserValue.SetEmail(email);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load user {username}: {ex.Message}");
                _logger.LogError($"Failed to load user {username}: {ex.Message}");
                
            }
        }
    }
}