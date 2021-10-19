using Domain;
using Domain.Entities;
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

        public OmItemHeader ProductRecord()
        {
            using (ClientContext context = new ClientContext(SharepointSiteUrl))
            {
                context.Credentials = Credentials;
                var list = GetList(context, Constants.Product.Lists.ProductRecord.TITLE);
                return GetProductRecord(context, list);
            }
        }

        private OmItemHeader GetProductRecord(ClientContext ctx, List list)
        {
            CamlQuery query = new CamlQuery
            {
                ViewXml = CAML.ViewQuery(
                    ViewScope.DefaultValue,
                    rowLimit: 1)
            };

            ListItemCollection items = list.GetItems(query);
            ctx.Load(items);
            ctx.ExecuteQuery();
            var item = items[0];

            return MapProductRecordToEntity(item);
        }

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
                    versions.Add(MapAllVersionToEntity(item));

                position = items.ListItemCollectionPosition;

            } while (position != null);

            return versions;
        }

        private AllVersion MapAllVersionToEntity(ListItem item)
        {
            return new AllVersion
            {
                PortfolioUnit = Convert.ToString(item[Fields.PORTFOLIOUNIT]),
                OmItemName = Convert.ToString(item[Fields.PRODUCT_NAME]),
                OmItemId = Convert.ToString(item[Fields.PRODUCT_ID]),
                PimsId = Convert.ToString(item[Fields.PIMSIDALLVERSION]),
                VersionName = Convert.ToString(item[Fields.VERSION_NAME]),
                FullVersionId = Convert.ToString(item[Fields.FULL_VERSION_ID]),
                VersionOfferingType = Convert.ToString(item[Fields.CLASSIFICATION]),
                CurrentOlmPhase = Convert.ToString(item[Fields.OLM_PHASE_VERSION]),
                PuReleaseAssignment = Convert.ToString(item[Fields.DD_RELEASE_ASSIGNMENT]),
                BssReleaseAssignment = Convert.ToString(item[Fields.BSS_RELEASE_ASSIGNMENT]),
                OssReleaseAssignment = Convert.ToString(item[Fields.OSS_RELEASE_ASSIGNMENT]),
                Comment = Convert.ToString(item[Fields.OMITEMVERSION_COMMENT]),
                OmItemNumber = Convert.ToInt32(item[Fields.PRODUCTNUMBER]),
                VersionNumber = Convert.ToInt32(item[Fields.VERSIONNUMBER])
            };
        }

        private AllOmItem MapAllOmItemToEntity(ListItem item)
        {
            var omItem = new AllOmItem();


            omItem.PortfolioUnit = Convert.ToString(item[Fields.PORTFOLIOUNIT]);
            omItem.OfferingName = Convert.ToString(item[Fields.OFFERING_NAME]);
            omItem.OfferingModule = Convert.ToString(item[Fields.OFFERING_MODULE]);
            omItem.OfferingModuleId = Convert.ToString(item[Fields.OFFERING_MODULE_ID]);
            //omItem.PimsId = Convert.ToString(item[Fields.PIMSIDALLOMITEM]);
            omItem.OmItemName = Convert.ToString(item[Fields.PRODUCT_NAME]);
            omItem.OfferingType = Convert.ToString(item[Fields.OFFERING_TYPE]);
            omItem.OfferingManager = Convert.ToString(item[Fields.PRODUCT_MANAGER]);
            omItem.OmItemAlias = Convert.ToString(item[Fields.PRODUCT_ALIAS]);
            omItem.OmItemId = Convert.ToString(item[Fields.OMITEMID]);
            omItem.OlmCurrentPhase = Convert.ToString(item[Fields.PLM_PHASE]);
            omItem.OlmPhaseStart = Convert.ToString(item[Fields.PLM_DATE]);
            omItem.OlmPhaseEnd = Convert.ToString(item[Fields.PLM_PHASE_PLANNED]);
            omItem.OmItemNumber = Convert.ToInt32(item[Fields.PRODUCTNUMBER]);
            

            return omItem;
        }

        private OmItemHeader MapProductRecordToEntity(ListItem item)
        {
            var header = new OmItemHeader();

            return header;
        }

        private List GetList(ClientContext ctx, string title)
        {
            Web web = ctx.Web;
            var list = web.Lists.GetByTitle(title);
            ctx.Load(list);
            ctx.ExecuteQuery();
            return list;
        }

        public List<AllOmItem> GetAllOmItems(ClientContext ctx, List list)
        {
            var omItems = new List<AllOmItem>();
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
                    omItems.Add(MapAllOmItemToEntity(item));

                position = items.ListItemCollectionPosition;

            } while (position != null);

            return omItems;
        }

        public List<AllOmItem> AllOmItems()
        {
            using (ClientContext context = new ClientContext(SharepointSiteUrl))
            {
                context.Credentials = Credentials;
                var list = GetList(context, Constants.Root.Lists.AllProducts.TITLE);
                return GetAllOmItems(context, list);
            }
        }
    }

    public interface ISharePointAdapter
    {
        List<AllOmItem> AllOmItems();
        List<AllVersion> AllVersions();
    }
}
