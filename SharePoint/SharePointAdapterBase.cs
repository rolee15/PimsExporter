using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;

namespace SharePoint
{
    public class SharePointAdapterBase
    {
        protected SharePointAdapterBase(Uri sharepointSiteUrl, NetworkCredential credentials)
        {
            SharepointSiteUrl = sharepointSiteUrl;
            Credentials = credentials;
        }

        public Uri SharepointSiteUrl { get; }
        public NetworkCredential Credentials { get; }

        protected IEnumerable<T> GetAllEntities<T>(string title, Func<ListItem, T> map)
        {
            using (var context = new ClientContext(SharepointSiteUrl))
            {
                context.Credentials = Credentials;
                var list = GetList(context, title);
                return GetAllItems(context, list, map);
            }
        }

        protected T GetEntity<T>(string title, Func<ListItem, T> map)
        {
            using (var context = new ClientContext(SharepointSiteUrl))
            {
                context.Credentials = Credentials;
                var list = GetList(context, title);
                return GetItem(context, list, map);
            }
        }

        private IEnumerable<T> GetAllItems<T>(ClientContext ctx, List list, Func<ListItem, T> map)
        {
            var result = new List<T>();

            var query = new CamlQuery
            {
                ViewXml = CAML.ViewQuery(
                    ViewScope.DefaultValue,
                    rowLimit: Constants.DEFAULT_QUERY_ROW_LIMIT)
            };

            ListItemCollectionPosition position = null;
            do
            {
                query.ListItemCollectionPosition = position;
                var items = list.GetItems(query);
                ctx.Load(items);
                ctx.ExecuteQuery();


                foreach (var item in items)
                    result.Add(map(item));

                position = items.ListItemCollectionPosition;

            } while (position != null);

            return result;
        }

        private T GetItem<T>(ClientContext ctx, List list, Func<ListItem, T> map)
        {
            var query = new CamlQuery
            {
                ViewXml = CAML.ViewQuery(
                    ViewScope.DefaultValue,
                    rowLimit: 1)
            };

            var items = list.GetItems(query);
            ctx.Load(items);
            ctx.ExecuteQuery();
            var item = items[0];

            return map(item);
        }

        private List GetList(ClientContext ctx, string title)
        {
            var web = ctx.Web;
            var list = web.Lists.GetByTitle(title);
            ctx.Load(list);
            ctx.ExecuteQuery();
            return list;
        }
    }
}