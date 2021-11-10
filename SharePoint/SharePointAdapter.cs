using Domain.Entities;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using ProductFields = SharePoint.Constants.Product.Fields;
using VersionFields = SharePoint.Constants.Version.Fields;
using RootFields = SharePoint.Constants.Root.Fields;
using User = Domain.Entities.User;
using System.Globalization;

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

        public List<OlmPhase> OlmPhase()
        {
            using (ClientContext context = new ClientContext(SharepointSiteUrl))
            {
                context.Credentials = Credentials;
                var list = GetList(context, Constants.Product.Lists.OlmPhases.TITLE);
                return GetOlmPhase(context, list);
            }
        }

        private List<OlmPhase> GetOlmPhase(ClientContext ctx, List list)
        {
            var olmPhases = new List<OlmPhase>();

            CamlQuery query = new CamlQuery
            {
                ViewXml = CAML.ViewQuery(
                    ViewScope.DefaultValue,
                    rowLimit: 1)
            };

            ListItemCollectionPosition position = null;
            do
            {
                query.ListItemCollectionPosition = position;
                ListItemCollection items = list.GetItems(query);
                ctx.Load(items);
                ctx.ExecuteQuery();


                foreach (var item in items)
                    olmPhases.Add(MapOlmPhasesToEntity(item));

                position = items.ListItemCollectionPosition;

            } while (position != null);

            return olmPhases;
        }

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
                    rowLimit: Constants.DEFAULT_QUERY_ROW_LIMIT)
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

        public List<Milestone> Milestones()
        {
            using (ClientContext context = new ClientContext(SharepointSiteUrl))
            {
                context.Credentials = Credentials;
                var list = GetList(context, Constants.Product.Lists.Milestones.TITLE);
                return GetMilestones(context, list);
            }
        }

        private List<Milestone> GetMilestones(ClientContext ctx, List list)
        {
            var milestones = new List<Milestone>();

            CamlQuery query = new CamlQuery
            {
                ViewXml = CAML.ViewQuery(
                    ViewScope.DefaultValue,
                    rowLimit: Constants.DEFAULT_QUERY_ROW_LIMIT)
            };

            ListItemCollectionPosition position = null;
            do
            {
                query.ListItemCollectionPosition = position;
                ListItemCollection items = list.GetItems(query);
                ctx.Load(items);
                ctx.ExecuteQuery();


                foreach (var item in items)
                    milestones.Add(MapMilestoneToEntity(item));

                position = items.ListItemCollectionPosition;

            } while (position != null);

            return milestones;
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
                OfferingManager = MapToUser(item[RootFields.PRODUCT_MANAGER]),
                OmItemAlias = Convert.ToString(item[RootFields.PRODUCT_ALIAS]),
                OmItemId = Convert.ToString(item[RootFields.OMITEMID]),
                OlmCurrentPhase = Convert.ToString(item[RootFields.PLM_PHASE]),
                OlmPhaseStart = Convert.ToString(item[RootFields.PLM_DATE]),
                OlmPhaseEnd = Convert.ToString(item[RootFields.PLM_PHASE_PLANNED]),
                OmItemNumber = Convert.ToInt32(item[RootFields.PRODUCTNUMBER])
            };
        }

        private User MapToUser(object input)
        {
            if (!(input is FieldUserValue fieldUserValue))
                return null;

            return new User(fieldUserValue.LookupValue, fieldUserValue.Email);
        }

        private OmItemHeader MapProductRecordToEntity(ListItem item)
        {
            var header = new OmItemHeader
            {
                OmItemName = Convert.ToString(item[ProductFields.PRODUCT_NAME]),
                OmItemAlias = Convert.ToString(item[ProductFields.PRODUCT_ALIAS]),
                OmItemId = Convert.ToString(item[ProductFields.PRODUCT_ID]),
                OfferingManager = MapToUser(item[ProductFields.PRODUCT_MANAGER]),
                PortfolioUnit = Convert.ToString(item[ProductFields.PRODUCT_UNIT]),
                PimsId = Convert.ToString(item[ProductFields.PIMSIDOMITEM]),
                OfferingName = Convert.ToString(item[ProductFields.OFFERING_NAME]),
                OfferingModule = Convert.ToString(item[ProductFields.OFFERING_MODULE]),
                ActiveStatus = Convert.ToString(item[ProductFields.ACTIVE_STATUS]),
                OlmCurrentPhase = Convert.ToString(item[ProductFields.PLM_PHASE]),
                ConfidentialityClass = Convert.ToString(item[ProductFields.CONFIDENTIALITY_CLASS]),
                OfferingType = Convert.ToString(item[ProductFields.OFFERING_TYPE]),
                CurrentStart = item[ProductFields.PLM_DATE] as DateTime?,
                CurrentEnd = item[ProductFields.PLM_PHASE_PLANNED] as DateTime?,
                OfferingCluster = Convert.ToString(item[ProductFields.OFFERING_CLUSTER]),
                ShortDescription = Convert.ToString(item[ProductFields.SHORT_DESCRIPTION]),
                LongDescription = Convert.ToString(item[ProductFields.LONG_DESCRIPTION])
            };

            return header;
        }

        private OlmPhase MapOlmPhasesToEntity(ListItem item)
        {
            var olmPhase = new OlmPhase
            {
                OlmPhaseName = Convert.ToString(item[ProductFields.PLM_PHASE]),
                CurrentPhase = Convert.ToString(item[ProductFields.CURRENT_PHASE]),
                PhaseStartApprovalDate = Convert.ToString(item[ProductFields.PHASE_START_APPROVAL_DATE]),
                PhaseStartDate = item[ProductFields.PHASE_START_DATE] as DateTime?,
                PhasePlannedEndDate = item[ProductFields.PHASE_PLANNED_END_DATE] as DateTime?,
                PhaseDuration = Convert.ToString(item[ProductFields.PHASE_DURATION]),
                ShortDescription = Convert.ToString(item[ProductFields.SHORT_DESCRIPTION]),
                LongDescription = Convert.ToString(item[ProductFields.LONG_DESCRIPTION])
            };

            return olmPhase;
        }

        private Milestone MapMilestoneToEntity(ListItem item)
        {
            var milestone = new Milestone
            {
                MilestoneName = Convert.ToString(item[ProductFields.MILESTONE_NAME]),
                DateBasicPlan = item[ProductFields.DATE_BASIC_PLAN] as DateTime?,
                DatePlan = item[ProductFields.DATE_PLAN] as DateTime?,
                DateActual = item[ProductFields.DATE_ACTUAL] as DateTime?,
                MilestoneType = Convert.ToString(item[ProductFields.MILESTONE_TYPE]),
                OLMPhase = Convert.ToString(item[ProductFields.PLM_PHASE]),
                Default = Convert.ToString(item[ProductFields.DEFAULT]),
                ShortDescription = Convert.ToString(item[ProductFields.SHORT_DESCRIPTION]),
                LongDescription = Convert.ToString(item[ProductFields.COMMENT]),
            };
            return milestone;
        }

        private VersionBudget MapVerionBudgetToEntity(ListItem item)
        {
            var versionBudget = new VersionBudget();
            versionBudget.Year = Convert.ToInt32(item[VersionFields.YEAR]);
            versionBudget.DeltaRevenuePlan = ConvertNullableDouble(item[VersionFields.DELTAREVENUEPLAN]);
            versionBudget.DeltaOEPlan = ConvertNullableDouble(item[VersionFields.DELTAOEPLAN]);
            versionBudget.BSSBudgetOpexPlan = ConvertNullableDouble(item[VersionFields.BSSBUDGETOPEXPLAN]);
            versionBudget.BSSBudgetCapexPlan = ConvertNullableDouble(item[VersionFields.BSSBUDGETCAPEXPLAN]);
            versionBudget.BSSBudgetOpexApproved = ConvertNullableDouble(item[VersionFields.BSSBUDGETOPEXAPPROVED]);
            versionBudget.BSSBudgetCapexApproved = ConvertNullableDouble(item[VersionFields.BSSBUDGETCAPEXAPPROVED]);
            versionBudget.OSSBudgetOpexPlan = ConvertNullableDouble(item[VersionFields.OSSBUDGETOPEXPLAN]);
            versionBudget.OSSBudgetCapexPlan = ConvertNullableDouble(item[VersionFields.OSSBUDGETCAPEXPLAN]);
            versionBudget.OSSBudgetOpexApproved = ConvertNullableDouble(item[VersionFields.OSSBUDGETOPEXAPPROVED]);
            versionBudget.OSSBudgetCapexApproved = ConvertNullableDouble(item[VersionFields.OSSBUDGETCAPEXAPPROVED]);
            versionBudget.OtherBudgetOpexPlan = ConvertNullableDouble(item[VersionFields.OTHERBUDGETOPEXPLAN]);
            versionBudget.OtherBudgetCapexPlan = ConvertNullableDouble(item[VersionFields.OTHERBUDGETCAPEXPLAN]);
            versionBudget.OtherBudgetOpexApproved = ConvertNullableDouble(item[VersionFields.OTHERBUDGETOPEXAPPROVED]);
            versionBudget.OtherBudgetCapexApproved = ConvertNullableDouble(item[VersionFields.OTHERBUDGETCAPEXAPPROVED]);
            versionBudget.RnDBudgetOpexPlan = ConvertNullableDouble(item[VersionFields.RNDBUDGETOPEXPLAN]);
            versionBudget.RnDBudgetCapexPlan = ConvertNullableDouble(item[VersionFields.RNDBUDGETCAPEXPLAN]);
            versionBudget.RnDBudgetOpexApproved = ConvertNullableDouble(item[VersionFields.RNDBUDGETOPEXAPPROVED]);
            versionBudget.RnDBudgetCapexApproved = ConvertNullableDouble(item[VersionFields.RNDBUDGETCAPEXAPPROVED]);
            return versionBudget;
        }

        private IEnumerable<T> GetAllItems<T>(ClientContext ctx, List list, Func<ListItem, T> map)
        {
            var result = new List<T>();

            CamlQuery query = new CamlQuery
            {
                ViewXml = CAML.ViewQuery(
                    ViewScope.DefaultValue,
                    rowLimit: Constants.DEFAULT_QUERY_ROW_LIMIT)
            };

            ListItemCollectionPosition position = null;
            do
            {
                query.ListItemCollectionPosition = position;
                ListItemCollection items = list.GetItems(query);
                ctx.Load(items);
                ctx.ExecuteQuery();


                foreach (var item in items)
                    result.Add(map(item));

                position = items.ListItemCollectionPosition;

            } while (position != null);

            return result;
        }

        public double? ConvertNullableDouble(object value)
        {
            double? result = null;
            if (value != null)
            {
                result = Convert.ToDouble(value, CultureInfo.InvariantCulture);
            }
            return result;
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
                    rowLimit: Constants.DEFAULT_QUERY_ROW_LIMIT)
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

        public VersionHeader ProductVersion()
        {
            using (var context = new ClientContext(SharepointSiteUrl))
            {
                context.Credentials = Credentials;
                var list = GetList(context, Constants.Version.Lists.ProductVersion.TITLE);
                return GetProductVersion(context, list);
            }
        }

        private VersionHeader GetProductVersion(ClientContext ctx, List list)
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

            return MapProductVersionToEntity(item);
        }

        private VersionHeader MapProductVersionToEntity(ListItem item)
        {
            return new VersionHeader
            {
                VersionName = Convert.ToString(item[ProductFields.VERSION_NAME]),
                VersionAlias = Convert.ToString(item[ProductFields.VERSION_ALIAS]),
                FullVersionId = Convert.ToString(item[ProductFields.FULL_VERSION_ID]),
                VersionManager = MapToUser(item[ProductFields.VERSION_MANAGER]),
                CurrentOlmPhase = Convert.ToString(item[ProductFields.OLM_PHASE_VERSION]),
                PimsId = Convert.ToString(item[ProductFields.VERSION_PIMSID]),
                ArticleNumber = Convert.ToString(item[ProductFields.ARTICLE_NUMBER]),
                VersionStatus = Convert.ToString(item[ProductFields.VERSION_STATUS]),
                ActiveStatus = Convert.ToBoolean(item[ProductFields.ACTIVE_STATUS]),
                AllowUsageInTsiForce = Convert.ToBoolean(item[ProductFields.USEDINTSIFORCE]),
                OfferingType = Convert.ToString(item[ProductFields.OFFERING_TYPE]),
                PuReleaseAssignment = Convert.ToString(item[ProductFields.DD_RELEASE_ASSIGNMENT]),
                TsiPortfolioVersion = Convert.ToString(item[ProductFields.TSIPORTFOLIOVERSION]),
                BssReleaseAssignment = Convert.ToString(item[ProductFields.BSS_RELEASE_ASSIGNMENT]),
                OssReleaseAssignment = Convert.ToString(item[ProductFields.OSS_RELEASE_ASSIGNMENT]),
                RequestedOnboarding = item[ProductFields.REQUESTED_ONBOARDING] as DateTime?,
                OnboardingDueDate = item[ProductFields.ONBOARDING_DUE_DATE] as DateTime?,
                ShortDescription = Convert.ToString(item[ProductFields.SHORT_DESCRIPTION]),
                LongDescription = Convert.ToString(item[ProductFields.LONG_DESCRIPTION]),
                Comment = Convert.ToString(item[ProductFields.OMITEMVERSION_COMMENT]),
                FocusOfMeasure = Convert.ToString(item[ProductFields.FOCUSOFMEASURE]),
                PrimaryFunding = Convert.ToString(item[ProductFields.PRIMARYFUNDING]),
                SecondaryFunding = Convert.ToString(item[ProductFields.SECONDARYFUNDING]),
                InnovationTopic = Convert.ToString(item[ProductFields.INNOVATIONTOPIC]),
                InIpf = Convert.ToString(item[ProductFields.INIPF]),
                InPib = Convert.ToString(item[ProductFields.INPIB]),
                InnovationStructure = Convert.ToString(item[ProductFields.DTAGINNOVATIONBMSTRUCTURE]),
                InnovationCategory = Convert.ToString(item[ProductFields.DTAGINNOVATIONCATEGORY]),
                InternationalRelevance = Convert.ToString(item[ProductFields.INTERNATIONALRELEVANCE]),
                SupportedMarketingUmbrellaMeasure = Convert.ToString(item[ProductFields.SUPPORTEDMARKETINGMEASURE]),
                MeasurePriority = Convert.ToString(item[ProductFields.MEASUREPRIORITY]),
                MeasureStatus = Convert.ToString(item[ProductFields.MEASURESTATUS]),
                ShortCustomerSalesBenefit = Convert.ToString(item[ProductFields.CUSTOMERVALUESALESBENEFITSHORT]),
                LongCustomerSalesBenefit = Convert.ToString(item[ProductFields.CUSTOMERVALUESALESBENEFITSHORT]),
                TargetAudience = Convert.ToString(item[ProductFields.TARGETAUDIENCE]),
                RiskAndMitigation = Convert.ToString(item[ProductFields.RISKMITIGATION])
            };
        }

        public List<int> VersionNumbers()
        {
            using (var context = new ClientContext(SharepointSiteUrl))
            {
                context.Credentials = Credentials;
                var list = GetList(context, Constants.Product.Lists.Versions.TITLE);
                return GetVersionNumbers(context, list);
            }
        }

        private List<int> GetVersionNumbers(ClientContext ctx, List list)
        {
            var versionNumbers = new List<int>();
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
                ListItemCollection items = list.GetItems(query);
                ctx.Load(items);
                ctx.ExecuteQuery();


                foreach (var item in items)
                    versionNumbers.Add(Convert.ToInt32(item[ProductFields.ID]));

                position = items.ListItemCollectionPosition;

            } while (position != null);

            return versionNumbers;
        }

        public IEnumerable<VersionBudget> VersionBudgets()
        {
            using (var context = new ClientContext(SharepointSiteUrl))
            {
                context.Credentials = Credentials;
                var list = GetList(context, Constants.Version.Lists.VersionBudget.TITLE);
                return GetAllItems(context, list, (item => MapVerionBudgetToEntity(item)));
            }
        }
    }

    public interface ISharePointAdapter
    {
        List<AllOmItem> AllOmItems();
        List<AllVersion> AllVersions();
        OmItemHeader ProductRecord();
        List<OlmPhase> OlmPhase();
        List<Milestone> Milestones();
        VersionHeader ProductVersion();
        List<int> VersionNumbers();
        IEnumerable<VersionBudget> VersionBudgets();
    }
}
