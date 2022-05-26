using System;
using System.Collections.Generic;
using System.Net;
using Domain;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;

namespace SharePoint
{
    public class SharePointAdapterBase
    {
        private protected readonly Mapper Mapper;
        private ClientContext _ctx;

        protected SharePointAdapterBase(Uri sharepointSiteUrl, NetworkCredential credentials)
        {
            SharepointSiteUrl = sharepointSiteUrl;
            Credentials = credentials;
            Mapper = new Mapper();
        }

        private Uri SharepointSiteUrl { get; }
        private NetworkCredential Credentials { get; }

        protected IEnumerable<T> GetAllEntities<T>(string title, Func<ListItem, T> map)
        {
            using (_ctx = new ClientContext(SharepointSiteUrl))
            {
                _ctx.Credentials = Credentials;
                var list = GetList(title);
                var items = GetAllItems(list);
                foreach (var item in items) yield return map(item);
            }
        }

        protected T GetFirstEntity<T>(string title, Func<ListItem, T> map)
        {
            using (_ctx = new ClientContext(SharepointSiteUrl))
            {
                _ctx.Credentials = Credentials;
                var list = GetList(title);
                var item = GetFirstItem(list);
                return map(item);
            }
        }

        private IEnumerable<ListItem> GetAllItems(List list)
        {
            var query = DefaultQuery();
            ListItemCollectionPosition position = null;
            do
            {
                query.ListItemCollectionPosition = position;

                var items = list.GetItems(query);
                _ctx.Load(items);
                _ctx.ExecuteQuery();
                foreach (var item in items) yield return item;

                position = items.ListItemCollectionPosition;
            } while (position != null);
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

        private List GetList(string title)
        {
            var web = _ctx.Web;
            var list = web.Lists.GetByTitle(title);
            _ctx.Load(list);
            _ctx.ExecuteQuery();
            return list;
        }
    }
}