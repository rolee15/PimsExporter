using Domain;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;
using PimsExporter.Entities;
using System;
using System.Collections.Generic;
using System.Net;

using Fields = Domain.Constants.Root.Fields;

namespace SharePoint
{
    public class SharePointAdapter : ISharePointAdapter
    {
        public SharePointAdapter(Uri sharepointSiteUrl, NetworkCredential credentials)
        {
            SharepointSiteUrl = sharepointSiteUrl;
            Credentials = credentials;
        }

        public Uri SharepointSiteUrl { get; }
        public NetworkCredential Credentials { get; }

        public List<AllVersion> AllVersions()
        {
            using (ClientContext context = new ClientContext(SharepointSiteUrl))
            {
                context.Credentials = Credentials;
                var list = GetList(context, Constants.Root.Lists.AllVersions.TITLE);
                return GetAllVersions(context, list);
            }
        }

        private List<AllVersion> GetAllVersions(ClientContext ctx, List list)
        {
            var versions = new List<AllVersion>();
            CamlQuery query = new CamlQuery
            {
                ViewXml = CAML.ViewQuery(
                    ViewScope.DefaultValue, 
                    rowLimit: Constants.SharePoint.DEFAULT_QUERY_ROW_LIMIT)
            };

            ListItemCollectionPosition position = null;
            do
            {
                query.ListItemCollectionPosition = position;
                ListItemCollection items = list.GetItems(query);
                ctx.Load(items);
                ctx.ExecuteQuery();


                foreach (var item in items)
                    versions.Add(MapToEntity(item));

                position = items.ListItemCollectionPosition;

            } while (position != null);

            return versions;
        }

        private AllVersion MapToEntity(ListItem item)
        {
            return new AllVersion()
            {
                PortfolioUnit = item[Fields.PORTFOLIOUNIT].ToString(),
                OmItemName = item[Fields.PRODUCT_NAME].ToString(),
                OmItemId = item[Fields.PRODUCT_ID].ToString(),
                PimsId = item[Fields.PIMSIDALLVERSION].ToString(),
                VersionName = item[Fields.VERSION_NAME].ToString(),
                FullVersionId = item[Fields.FULL_VERSION_ID].ToString(),
                VersionOfferingType = item[Fields.CLASSIFICATION].ToString(),
                CurrentOlmPhase = item[Fields.OLM_PHASE_VERSION].ToString(),
                PuReleaseAssignment = item[Fields.DD_RELEASE_ASSIGNMENT].ToString(),
                BssReleaseAssignment = item[Fields.BSS_RELEASE_ASSIGNMENT].ToString(),
                OssReleaseAssignment = item[Fields.OSS_RELEASE_ASSIGNMENT].ToString(),
                Comment = item[Fields.OMITEMVERSION_COMMENT].ToString(),
                OmItemNumber = Convert.ToInt32(item[Fields.PRODUCTNUMBER]),
                VersionNumber = Convert.ToInt32(item[Fields.VERSIONNUMBER])
            };
        }

        private List GetList(ClientContext ctx, string title)
        {
            Web web = ctx.Web;
            var list = web.Lists.GetByTitle(title);
            ctx.Load(list);
            ctx.ExecuteQuery();
            return list;
        }
    }

    public interface ISharePointAdapter
    {
        List<AllVersion> AllVersions();
    }
}
