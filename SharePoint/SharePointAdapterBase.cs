using Domain.Entities;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SharePoint
{
    public class SharePointAdapterBase
    {
        protected ClientContext _ctx;
        protected readonly Mapper mapper;

        protected SharePointAdapterBase(Uri sharepointSiteUrl, NetworkCredential credentials)
        {
            SharepointSiteUrl = sharepointSiteUrl;
            Credentials = credentials;
            this.mapper = new Mapper();
        }

        public Uri SharepointSiteUrl { get; }
        public NetworkCredential Credentials { get; }

        protected IEnumerable<CoSignatureHeader> GetAllCoSignatureEntities()
        {
            using (_ctx = new ClientContext(SharepointSiteUrl))
            {
                _ctx.Credentials = Credentials;

                var coSignatures = GetCoSignatures();
                var workflows = GetWorkflows();

                foreach (var coSignature in coSignatures)
                {
                    var workflow = workflows.FirstOrDefault(w => w.CoSignatureId == coSignature.CoSignatureId);
                    if (workflow == null) continue;

                    yield return mapper.JoinCoSignatures(coSignature, workflow);
                }
            }
        }

        private IEnumerable<CoSignatureHeader> GetWorkflows()
        {
            var list = GetList(Constants.Version.Lists.CoSignatureWorkflow.TITLE);
            var listItems = GetAllItems(list);
            foreach (var item in listItems)
                yield return mapper.MapCoSignatureWorkflowToEntity(item);
        }

        private IEnumerable<CoSignatureHeader> GetCoSignatures()
        {
            var list = GetList(Constants.Version.Lists.CoSignaturesList.TITLE);
            var listItems = GetAllItems(list);
            foreach (var item in listItems)
                yield return mapper.MapCoSignaturesListToEntity(item);
        }

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