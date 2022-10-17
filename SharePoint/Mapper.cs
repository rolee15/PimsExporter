using System;
using System.Globalization;
using Domain.Entities;
using Microsoft.SharePoint.Client;
using ProductFields = Domain.Constants.Product.Fields;
using RootFields = Domain.Constants.Root.Fields;
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
            var allOmItem = new AllOmItem
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

            return allOmItem;
        }

        public Lookup MapLookupToEntity(ListItem item)
        {
            var lookup = new Lookup
            {
                ChoiceList = Convert.ToString(item[RootFields.CHOICE_LIST]),
                Title = Convert.ToString(item[RootFields.TITLE]),
                ValidFrom = Convert.ToDateTime(item[RootFields.VALID_FROM]),
                ValidTo = Convert.ToDateTime(item[RootFields.VALID_TO]),
                Value = Convert.ToString(item[RootFields.VALUE])
            };

            return lookup;
        }

        internal VersionTeam MapVersionTeamsToEntity(ListItem item)
        {
            var versionTeam = new VersionTeam
            {
                ValidFrom = item[ProductFields.VALID_FROM] as DateTime?,
                ValidTo = item[ProductFields.VALID_TO] as DateTime?,
                TeamRole = Convert.ToString(item[ProductFields.TEAM_ROLE]),
                RoleComment = Convert.ToString(item[ProductFields.ROLE_COMMENT]),
                Member = MapToUser(item[ProductFields.MEMBER1]),
                DeputyOf = MapToUser(item[ProductFields.DEPUTY_OF]),
                CoSigner = Convert.ToBoolean(item[ProductFields.ISCOSIGNER])
            };

            return versionTeam;
        }

        internal VersionDocument MapVersionDocumentsToEntity(ListItem item)
        {
            var versionDocument = new VersionDocument
            {
                Name = Convert.ToString(item[ProductFields.NAME]),
                ConfidentialityClass = Convert.ToString(item[ProductFields.CONFIDENTIALITY_CLASS]),
                DocumentCategory = Convert.ToString(item[ProductFields.DOCUMENT_CATEGORY]),
                DocumentTagging = TaxonomyHelper.MapTaxonomy(item[ProductFields.DOCUMENT_TAGGING]),
                DocumentOwner = MapToUser(item[ProductFields.DOCUMENT_OWNER]),
                OlmPhase = Convert.ToString(item[ProductFields.PLM_PHASE]),
                Updated = item[ProductFields.UPDATED] as DateTime?
            };

            return versionDocument;
        }

        internal VersionChangeLog MapVersionChangeLogToEntity(ListItem item)
        {
            var versionChangeLog = new VersionChangeLog
            {
                Event = Convert.ToString(item[ProductFields.EVENT]),
                DateAndTimeOfChange = item[ProductFields.DATE_AND_TIME_OF_CHANGE] as DateTime?,
                User = MapToUser(item[ProductFields.USER]),
                TypeOfChange = Convert.ToString(item[ProductFields.TYPE_OF_CHANGE]),
                ChangeSection = Convert.ToString(item[ProductFields.CHANGE_SECTION])
            };

            return versionChangeLog;
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
                OfferingModuleId = Convert.ToString(item[ProductFields.OFFERING_MODULE_ID]),
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
                OlmPhase = Convert.ToString(item[ProductFields.PLM_PHASE]),
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
            var versionBudget = new VersionBudget
            {
                Year = Convert.ToInt32(item[ProductFields.YEAR]),
                DeltaRevenuePlan = ConvertNullableDouble(item[ProductFields.DELTAREVENUEPLAN]),
                DeltaOePlan = ConvertNullableDouble(item[ProductFields.DELTAOEPLAN]),
                BssBudgetOpexPlan = ConvertNullableDouble(item[ProductFields.BSSBUDGETOPEXPLAN]),
                BssBudgetCapexPlan = ConvertNullableDouble(item[ProductFields.BSSBUDGETCAPEXPLAN]),
                BssBudgetOpexApproved = ConvertNullableDouble(item[ProductFields.BSSBUDGETOPEXAPPROVED]),
                BssBudgetCapexApproved = ConvertNullableDouble(item[ProductFields.BSSBUDGETCAPEXAPPROVED]),
                OssBudgetOpexPlan = ConvertNullableDouble(item[ProductFields.OSSBUDGETOPEXPLAN]),
                OssBudgetCapexPlan = ConvertNullableDouble(item[ProductFields.OSSBUDGETCAPEXPLAN]),
                OssBudgetOpexApproved = ConvertNullableDouble(item[ProductFields.OSSBUDGETOPEXAPPROVED]),
                OssBudgetCapexApproved = ConvertNullableDouble(item[ProductFields.OSSBUDGETCAPEXAPPROVED]),
                OtherBudgetOpexPlan = ConvertNullableDouble(item[ProductFields.OTHERBUDGETOPEXPLAN]),
                OtherBudgetCapexPlan = ConvertNullableDouble(item[ProductFields.OTHERBUDGETCAPEXPLAN]),
                OtherBudgetOpexApproved = ConvertNullableDouble(item[ProductFields.OTHERBUDGETOPEXAPPROVED]),
                OtherBudgetCapexApproved = ConvertNullableDouble(item[ProductFields.OTHERBUDGETCAPEXAPPROVED]),
                RnDBudgetOpexPlan = ConvertNullableDouble(item[ProductFields.RNDBUDGETOPEXPLAN]),
                RnDBudgetCapexPlan = ConvertNullableDouble(item[ProductFields.RNDBUDGETCAPEXPLAN]),
                RnDBudgetOpexApproved = ConvertNullableDouble(item[ProductFields.RNDBUDGETOPEXAPPROVED]),
                RnDBudgetCapexApproved = ConvertNullableDouble(item[ProductFields.RNDBUDGETCAPEXAPPROVED]),
                Comment = Convert.ToString(item[ProductFields.OVERSIONBUDGETCOMMENT])
            };
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
                LongCustomerSalesBenefit = Convert.ToString(item[ProductFields.CUSTOMERVALUESALESBENEFITLONG]),
                TargetAudience = Convert.ToString(item[ProductFields.TARGETAUDIENCE]),
                RiskAndMitigation = Convert.ToString(item[ProductFields.RISKMITIGATION])
            };
        }

        internal Team MapTeamsToEntity(ListItem item)
        {
            var team = new Team
            {
                ValidFrom = item[ProductFields.VALID_FROM] as DateTime?,
                ValidTo = item[ProductFields.VALID_TO] as DateTime?,
                TeamRole = Convert.ToString(item[ProductFields.TEAM_ROLE]),
                RoleComment = Convert.ToString(item[ProductFields.ROLE_COMMENT]),
                Member = MapToUser(item[ProductFields.MEMBER1]),
                DeputyOf = MapToUser(item[ProductFields.DEPUTY_OF]),
                CoSigner = Convert.ToBoolean(item[ProductFields.ISCOSIGNER])
            };


            return team;
        }

        internal CoSignatureHeader MapCoSignaturesListToEntity(ListItem item)
        {
            var header = new CoSignatureHeader
            {
                CoSignatureId = Convert.ToInt32(item[ProductFields.ID]),
                Requestor = MapToUser(item[ProductFields.REQUESTOR]),
                Topic = Convert.ToString(item[ProductFields.TOPIC]),
                OmItemName = Convert.ToString(item[ProductFields.PRODUCT_NAME]),
                PortfolioUnit = Convert.ToString(item[ProductFields.PRODUCT_UNIT]),
                OmItemVersion = Convert.ToString(item[ProductFields.OM_ITEM_VERSION]),
                ConfidentialityClass = Convert.ToString(item[ProductFields.CONFIDENTIALITY_CLASS]),
                OlmPhase = Convert.ToString(item[ProductFields.OLM_PHASE]),
                OlmMilestone = Convert.ToString(item[ProductFields.OLM_MILESTONE]),
                CoSignatureDate = item[ProductFields.COSIGN_DATE] as DateTime?,
                CoSignatureDueDate = item[ProductFields.COSIGN_DUE_DATE] as DateTime?,
                Status = Convert.ToString(item[ProductFields.COSIGN_STATUS]),
                Result = Convert.ToString(item[ProductFields.COSIGNATURE_RESULT]),
                Remark = Convert.ToString(item[ProductFields.REMARK]),
                CoSignatureSubmittedDate = item[ProductFields.COSIGNSUBMITTEDDATE] as DateTime?,
                CoSignatureResultDate = item[ProductFields.COSIGNRESULTDATE] as DateTime?,
                QualityIndex = Convert.ToDouble(item[ProductFields.QIDX_COSIGN]),
                QualityIndexUpdated = item[ProductFields.QIDX_COSIGN_UPDATED] as DateTime?
            };
            
            return header;
        }

        internal CoSignatureCoSigner MapCoSignatureCoSignersListToEntity(ListItem item)
        {
            var cosigner = new CoSignatureCoSigner
            {
                CoSignatureId = Convert.ToInt32(item[ProductFields.COSIGNATURE_ID]),
                Member = MapToUser(item[ProductFields.MEMBER1]),
                Deputy = MapToUser(item[ProductFields.COSIGNDEPUTY]),
                TeamRole = Convert.ToString(item[ProductFields.TEAM_ROLE]),
                CoSignedBy = MapToUser(item[ProductFields.COSIGNEDBY]),
                RoleComment = Convert.ToString(item[ProductFields.ROLE_COMMENT]),
                CoSignerDate = item[ProductFields.COSIGNERDATE] as DateTime?,
                CoSignerResult = Convert.ToString(item[ProductFields.COSIGNERRESULT])
            };

            cosigner.CoSignedBy = MapToUser(item[ProductFields.COSIGNEDBY]);
            cosigner.Remark = Convert.ToString(item[ProductFields.REMARK]);


            return cosigner;
        }

        internal CoSignatureDocument MapCoSignatureDocumentsListToEntity(ListItem item)
        {
            var document = new CoSignatureDocument
            {
                CoSignatureId = Convert.ToInt32(item[ProductFields.COSIGNATURE_ID]),
                Name = Convert.ToString(item[ProductFields.NAME]),
                ConfidentialityClass = Convert.ToString(item[ProductFields.CONFIDENTIALITY_CLASS]),
                DocumentCategory = Convert.ToString(item[ProductFields.DOCUMENT_CATEGORY]),
                DocumentTagging = TaxonomyHelper.MapTaxonomy(item[ProductFields.DOCUMENT_TAGGING]),
                DocumentOwner = MapToUser(item[ProductFields.DOCUMENT_OWNER]),
                OlmPhase = Convert.ToString(item[ProductFields.PLM_PHASE]),
                Updated = item[ProductFields.UPDATED] as DateTime?
            };
            return document;
        }

        internal OmItemDocument MapDocumentsToEntity(ListItem item)
        {
            var document = new OmItemDocument
            {
                Name = Convert.ToString(item[ProductFields.NAME]),
                ConfidentialityClass = Convert.ToString(item[ProductFields.CONFIDENTIALITY_CLASS]),
                DocumentCategory = Convert.ToString(item[ProductFields.DOCUMENT_CATEGORY]),
                DocumentTagging = TaxonomyHelper.MapTaxonomy(item[ProductFields.DOCUMENT_TAGGING]),
                DocumentOwner = MapToUser(item[ProductFields.DOCUMENT_OWNER]),
                OlmPhase = Convert.ToString(item[ProductFields.PLM_PHASE]),
                Updated = item[ProductFields.UPDATED] as DateTime?
            };
            return document;
        }

        internal RelatedOmItem MapRelatedOmItemsToEntity(ListItem item)
        {
            var relatedOmItem = new RelatedOmItem
            {
                LinkType = Convert.ToString(item[ProductFields.LINKTYPE]),
                ShortDescription = Convert.ToString(item[ProductFields.SHORT_DESCRIPTION]),
                PimsLink = MapToUrl(item[ProductFields.PIMSLINK])
            };
            return relatedOmItem;
        }
        
        internal VersionRelatedOmItem MapVersionRelatedOmItemsToEntity(ListItem item)
        {
            var relatedOmItem = new VersionRelatedOmItem
            {
                LinkType = Convert.ToString(item[ProductFields.LINKTYPE]),
                ShortDescription = Convert.ToString(item[ProductFields.SHORT_DESCRIPTION]),
                PimsLink = MapToUrl(item[ProductFields.PIMSLINK])
            };
            return relatedOmItem;
        }

        private static User MapToUser(object input)
        {
            if (!(input is FieldUserValue fieldUserValue))
                return null;

            return new User(fieldUserValue.LookupValue, fieldUserValue.Email);
        }

        private static string MapToUrl(object input)
        {
            if (!(input is FieldUrlValue fieldUrlValue))
                return null;

            return fieldUrlValue.Url;
        }

        private static double? ConvertNullableDouble(object value)
        {
            double? result = null;
            if (value != null) result = Convert.ToDouble(value, CultureInfo.InvariantCulture);
            return result;
        }
    }
}