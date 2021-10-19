using Domain;
using Domain.Entities;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;
using PimsExporter.Entities;
using System;
using System.Collections.Generic;
using System.Net;

using RootFields = Domain.Constants.Root.Fields;
using ProductFields = Domain.Constants.Product.Fields;

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
                PortfolioUnit = Convert.ToString(item[RootFields.PORTFOLIOUNIT]),
                OmItemName = Convert.ToString(item[RootFields.PRODUCT_NAME]),
                OmItemId = Convert.ToString(item[RootFields.PRODUCT_ID]),
                PimsId = Convert.ToString(item[RootFields.PIMSIDALLVERSION]),
                VersionName = Convert.ToString(item[RootFields.VERSION_NAME]),
                FullVersionId = Convert.ToString(item[RootFields.FULL_VERSION_ID]),
                VersionOfferingType = Convert.ToString(item[RootFields.CLASSIFICATION]),
                CurrentOlmPhase = Convert.ToString(item[RootFields.OLM_PHASE_VERSION]),
                PuReleaseAssignment = Convert.ToString(item[RootFields.DD_RELEASE_ASSIGNMENT]),
                BssReleaseAssignment = Convert.ToString(item[RootFields.BSS_RELEASE_ASSIGNMENT]),
                OssReleaseAssignment = Convert.ToString(item[RootFields.OSS_RELEASE_ASSIGNMENT]),
                Comment = Convert.ToString(item[RootFields.OMITEMVERSION_COMMENT]),
                OmItemNumber = Convert.ToInt32(item[RootFields.PRODUCTNUMBER]),
                VersionNumber = Convert.ToInt32(item[RootFields.VERSIONNUMBER])
            };
        }

        private AllOmItem MapAllOmItemToEntity(ListItem item)
        {
            return new AllOmItem
            {
                PortfolioUnit = Convert.ToString(item[RootFields.PORTFOLIOUNIT]),
                OfferingName = Convert.ToString(item[RootFields.OFFERING_NAME]),
                OfferingModule = Convert.ToString(item[RootFields.OFFERING_MODULE]),
                OfferingModuleId = Convert.ToString(item[RootFields.OFFERING_MODULE_ID]),
                PimsId = Convert.ToString(item[RootFields.PIMSIDOMITEM]),
                OmItemName = Convert.ToString(item[RootFields.PRODUCT_NAME]),
                OfferingType = Convert.ToString(item[RootFields.OFFERING_TYPE]),
                OfferingManager = Convert.ToString(item[RootFields.PRODUCT_MANAGER]),
                OmItemAlias = Convert.ToString(item[RootFields.PRODUCT_ALIAS]),
                OmItemId = Convert.ToString(item[RootFields.OMITEMID]),
                OlmCurrentPhase = Convert.ToString(item[RootFields.PLM_PHASE]),
                OlmPhaseStart = Convert.ToString(item[RootFields.PLM_DATE]),
                OlmPhaseEnd = Convert.ToString(item[RootFields.PLM_PHASE_PLANNED]),
                OmItemNumber = Convert.ToInt32(item[RootFields.PRODUCTNUMBER])
            };
        }

        private OmItemHeader MapProductRecordToEntity(ListItem item)
        {
            var header = new OmItemHeader
            {
                OmItemName = Convert.ToString(item[ProductFields.PRODUCT_NAME]),
                OmItemAlias = Convert.ToString(item[ProductFields.PRODUCT_ALIAS]),
                OmItemId = Convert.ToString(item[ProductFields.PRODUCT_ID]),
                OfferingManager = Convert.ToString(item[ProductFields.PRODUCT_MANAGER]),
                PortfolioUnit = Convert.ToString(item[ProductFields.PRODUCT_UNIT]),
                PimsId = Convert.ToString(item[ProductFields.PIMSIDOMITEM]),
                OfferingName = Convert.ToString(item[ProductFields.OFFERING_NAME]),
                OfferingModule = Convert.ToString(item[ProductFields.OFFERING_MODULE]),
                ActiveStatus = Convert.ToString(item[ProductFields.ACTIVE_STATUS]),
                OlmCurrentPhase = Convert.ToString(item[ProductFields.PLM_PHASE]),
                ConfidentialityClass = Convert.ToString(item[ProductFields.CONFIDENTIALITY_CLASS]),
                OfferingType = Convert.ToString(item[ProductFields.OFFERING_TYPE]),
                CurrentStart = Convert.ToString(item[ProductFields.PLM_DATE]),
                CurrentEnd = Convert.ToString(item[ProductFields.PLM_PHASE_PLANNED]),
                //header.OfferingCluster = Convert.ToString(item[ProductFields.OFFERING_CLUSTER]),
                ShortDescription = Convert.ToString(item[ProductFields.SHORT_DESCRIPTION]),
                LongDescription = Convert.ToString(item[ProductFields.LONG_DESCRIPTION])
            };

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
            var query = new CamlQuery
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
            using (var context = new ClientContext(SharepointSiteUrl))
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
        OmItemHeader ProductRecord();
    }
}
