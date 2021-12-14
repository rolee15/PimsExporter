using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Domain.Entities;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;

namespace SharePoint
{
    public class SharePointAdapterBase
    {
        protected readonly Mapper mapper;
        protected ClientContext _ctx;

        protected SharePointAdapterBase(Uri sharepointSiteUrl, NetworkCredential credentials)
        {
            SharepointSiteUrl = sharepointSiteUrl;
            Credentials = credentials;
            mapper = new Mapper();
        }

        public Uri SharepointSiteUrl { get; }
        public NetworkCredential Credentials { get; }

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
                    rowLimit: Constants.DEFAULT_QUERY_ROW_LIMIT)
            };
        }

        protected ListItem GetFirstItem(List list)
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