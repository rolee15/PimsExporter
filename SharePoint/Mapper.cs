using System;
using System.Globalization;
using Domain.Entities;
using Microsoft.SharePoint.Client;
using ProductFields = SharePoint.Constants.Product.Fields;
using RootFields = SharePoint.Constants.Root.Fields;
using User = Domain.Entities.User;

namespace SharePoint
{
    internal class Mapper
    {
        internal AllVersion MapAllVersionToEntity(ListItem item)
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

        internal AllOmItem MapAllOmItemToEntity(ListItem item)
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

        internal VersionTeam MapVersionTeamsToEntity(ListItem item)
        {
            var versionTeam = new VersionTeam();

            versionTeam.ValidFrom = item[ProductFields.VALID_FROM] as DateTime?;
            versionTeam.ValidTo = item[ProductFields.VALID_TO] as DateTime?;
            versionTeam.TeamRole = Convert.ToString(item[ProductFields.TEAM_ROLE]);
            versionTeam.RoleComment = Convert.ToString(item[ProductFields.ROLE_COMMENT]);
            versionTeam.Member = MapToUser(item[ProductFields.MEMBER1]);
            versionTeam.DeputyOf = MapToUser(item[ProductFields.DEPUTY_OF]);
            versionTeam.CoSigner = Convert.ToBoolean(item[ProductFields.ISCOSIGNER]);

            return versionTeam;
        }

        internal OmItemHeader MapProductRecordToEntity(ListItem item)
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

        internal OlmPhase MapOlmPhasesToEntity(ListItem item)
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

        internal Milestone MapMilestoneToEntity(ListItem item)
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
                LongDescription = Convert.ToString(item[ProductFields.COMMENT])
            };
            return milestone;
        }

        internal int MapVersionToInt(ListItem item)
        {
            return Convert.ToInt32(item[ProductFields.ID]);
        }

        internal VersionBudget MapVersionBudgetToEntity(ListItem item)
        {
            var versionBudget = new VersionBudget();
            versionBudget.Year = Convert.ToInt32(item[ProductFields.YEAR]);
            versionBudget.DeltaRevenuePlan = ConvertNullableDouble(item[ProductFields.DELTAREVENUEPLAN]);
            versionBudget.DeltaOEPlan = ConvertNullableDouble(item[ProductFields.DELTAOEPLAN]);
            versionBudget.BSSBudgetOpexPlan = ConvertNullableDouble(item[ProductFields.BSSBUDGETOPEXPLAN]);
            versionBudget.BSSBudgetCapexPlan = ConvertNullableDouble(item[ProductFields.BSSBUDGETCAPEXPLAN]);
            versionBudget.BSSBudgetOpexApproved = ConvertNullableDouble(item[ProductFields.BSSBUDGETOPEXAPPROVED]);
            versionBudget.BSSBudgetCapexApproved = ConvertNullableDouble(item[ProductFields.BSSBUDGETCAPEXAPPROVED]);
            versionBudget.OSSBudgetOpexPlan = ConvertNullableDouble(item[ProductFields.OSSBUDGETOPEXPLAN]);
            versionBudget.OSSBudgetCapexPlan = ConvertNullableDouble(item[ProductFields.OSSBUDGETCAPEXPLAN]);
            versionBudget.OSSBudgetOpexApproved = ConvertNullableDouble(item[ProductFields.OSSBUDGETOPEXAPPROVED]);
            versionBudget.OSSBudgetCapexApproved = ConvertNullableDouble(item[ProductFields.OSSBUDGETCAPEXAPPROVED]);
            versionBudget.OtherBudgetOpexPlan = ConvertNullableDouble(item[ProductFields.OTHERBUDGETOPEXPLAN]);
            versionBudget.OtherBudgetCapexPlan = ConvertNullableDouble(item[ProductFields.OTHERBUDGETCAPEXPLAN]);
            versionBudget.OtherBudgetOpexApproved = ConvertNullableDouble(item[ProductFields.OTHERBUDGETOPEXAPPROVED]);
            versionBudget.OtherBudgetCapexApproved =
                ConvertNullableDouble(item[ProductFields.OTHERBUDGETCAPEXAPPROVED]);
            versionBudget.RnDBudgetOpexPlan = ConvertNullableDouble(item[ProductFields.RNDBUDGETOPEXPLAN]);
            versionBudget.RnDBudgetCapexPlan = ConvertNullableDouble(item[ProductFields.RNDBUDGETCAPEXPLAN]);
            versionBudget.RnDBudgetOpexApproved = ConvertNullableDouble(item[ProductFields.RNDBUDGETOPEXAPPROVED]);
            versionBudget.RnDBudgetCapexApproved = ConvertNullableDouble(item[ProductFields.RNDBUDGETCAPEXAPPROVED]);
            return versionBudget;
        }

        internal VersionHeader MapProductVersionToEntity(ListItem item)
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

        internal Team MapTeamsToEntity(ListItem item)
        {
            var team = new Team();

            team.ValidFrom = item[ProductFields.VALID_FROM] as DateTime?;
            team.ValidTo = item[ProductFields.VALID_TO] as DateTime?;
            team.TeamRole = Convert.ToString(item[ProductFields.TEAM_ROLE]);
            team.RoleComment = Convert.ToString(item[ProductFields.ROLE_COMMENT]);
            team.Member = MapToUser(item[ProductFields.MEMBER1]);
            team.DeputyOf = MapToUser(item[ProductFields.DEPUTY_OF]);
            team.CoSigner = Convert.ToBoolean(item[ProductFields.ISCOSIGNER]);


            return team;
        }

        private User MapToUser(object input)
        {
            if (!(input is FieldUserValue fieldUserValue))
                return null;

            return new User(fieldUserValue.LookupValue, fieldUserValue.Email);
        }

        public double? ConvertNullableDouble(object value)
        {
            double? result = null;
            if (value != null) result = Convert.ToDouble(value, CultureInfo.InvariantCulture);
            return result;
        }
    }
}