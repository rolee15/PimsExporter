using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Domain.Entities;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Taxonomy;
using ProductFields = SharePoint.Constants.Product.Fields;
using RootFields = SharePoint.Constants.Root.Fields;
using User = Domain.Entities.User;

namespace SharePoint
{
    public class Mapper
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

        internal VersionDocument MapVersionDocumentsToEntity(ListItem item)
        {
            var versionDocument = new VersionDocument();

            versionDocument.Name = Convert.ToString(item[ProductFields.NAME]);
            versionDocument.ConfidentialityClass = Convert.ToString(item[ProductFields.CONFIDENTIALITY_CLASS]);
            versionDocument.DocumentCategory = Convert.ToString(item[ProductFields.DOCUMENT_CATEGORY]);
            versionDocument.DocumentTagging = TaxonomyHelper.MapTaxonomy(item[ProductFields.DOCUMENT_TAGGING]);
            versionDocument.DocumentOwner = MapToUser(item[ProductFields.DOCUMENT_OWNER]);
            versionDocument.CheckoutTo = MapToUser(item[ProductFields.CHECKOUT_TO]);
            
            return versionDocument;
        }

        internal VersionChangeLog MapVersionChangeLogToEntity(ListItem item)
        {
            var versionChangeLog = new VersionChangeLog();

            versionChangeLog.Event = Convert.ToString(item[ProductFields.EVENT]);
            versionChangeLog.DateAndTimeOfChange = item[ProductFields.DATE_AND_TIME_OF_CHANGE] as DateTime?;
            versionChangeLog.User = MapToUser(item[ProductFields.USER]);
            versionChangeLog.TypeOfChange = Convert.ToString(item[ProductFields.TYPE_OF_CHANGE]);
            versionChangeLog.ChangeSection = Convert.ToString(item[ProductFields.CHANGE_SECTION]);

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

        internal int MapCoSignatureToInt(ListItem item)
        {
            return Convert.ToInt32(item[ProductFields.COSIGNATURE_ID]);
        }

        internal CoSignatureHeader MapCoSignaturesListToEntity(ListItem item)
        {
            var header = new CoSignatureHeader();

            header.CoSignatureId = Convert.ToInt32(item[ProductFields.ID]);
            header.Requestor = MapToUser(item[ProductFields.REQUESTOR]);
            header.Topic = Convert.ToString(item[ProductFields.TOPIC]);
            header.OmItemName = Convert.ToString(item[ProductFields.PRODUCT_NAME]);
            header.PortfolioUnit = Convert.ToString(item[ProductFields.PRODUCT_UNIT]);
            header.OmItemVersion = Convert.ToString(item[ProductFields.OM_ITEM_VERSION]);
            header.OfferingCluster = Convert.ToString(item[ProductFields.OFFERING_CLUSTER]);
            header.ConfidentialityClass = Convert.ToString(item[ProductFields.CONFIDENTIALITY_CLASS]);
            header.OlmPhase = Convert.ToString(item[ProductFields.OLM_PHASE]);
            header.OlmMilestone = Convert.ToString(item[ProductFields.OLM_MILESTONE]);
            header.CoSignatureDate = item[ProductFields.COSIGN_DATE] as DateTime?;
            header.CoSignatureDueDate = item[ProductFields.COSIGN_DUE_DATE] as DateTime?;
            header.Status = Convert.ToString(item[ProductFields.COSIGN_STATUS]);
            header.Result = Convert.ToString(item[ProductFields.COSIGNATURE_RESULT]);
            header.Remark = Convert.ToString(item[ProductFields.REMARK]);

            return header;
        }

        internal CoSignatureCoSigner MapCoSignatureCoSignersListToEntity(ListItem item)
        {
            var cosigner = new CoSignatureCoSigner();

            cosigner.CoSignatureId = Convert.ToInt32(item[ProductFields.COSIGNATURE_ID]);
            cosigner.Member = MapToUser(item[ProductFields.MEMBER1]);
            cosigner.Deputy = MapToUser(item[ProductFields.COSIGNDEPUTY]);
            cosigner.TeamRole = Convert.ToString(item[ProductFields.TEAM_ROLE]);
            cosigner.CoSignedBy = MapToUser(item[ProductFields.COSIGNEDBY]);
            cosigner.RoleComment = Convert.ToString(item[ProductFields.ROLE_COMMENT]);
            cosigner.CoSignerDate = item[ProductFields.COSIGNERDATE] as DateTime?;
            cosigner.CoSignerResult = Convert.ToString(item[ProductFields.COSIGNERRESULT]);
            cosigner.CoSignedBy =  MapToUser(item[ProductFields.COSIGNEDBY]);
            cosigner.Remark = Convert.ToString(item[ProductFields.REMARK]);


            return cosigner;
        }

        internal CoSignatureDocument MapCoSignatureDocumentsListToEntity(ListItem item)
        {
            var document = new CoSignatureDocument();
            document.Name = Convert.ToString(item[ProductFields.NAME]);
            document.ConfidentialityClass = Convert.ToString(item[ProductFields.CONFIDENTIALITY_CLASS]);
            document.DocumentCategory = Convert.ToString(item[ProductFields.DOCUMENT_CATEGORY]);
            document.DocumentTagging = TaxonomyHelper.MapTaxonomy(item[ProductFields.DOCUMENT_TAGGING]);
            document.DocumentOwner = MapToUser(item[ProductFields.DOCUMENT_OWNER]);
            document.CheckoutTo = MapToUser(item[ProductFields.CHECKOUT_TO]);
            return document;
        }

        internal CoSignatureHeader MapCoSignatureWorkflowToEntity(ListItem item)
        {
            var header = new CoSignatureHeader();

            header.CoSignatureId = Convert.ToInt32(item[ProductFields.COSIGNATURE_ID]);
            header.Topic = Convert.ToString(item[ProductFields.SIGNATURE_NAME]);
            header.OmItemName = Convert.ToString(item[ProductFields.PRODUCT_NAME]);
            header.PortfolioUnit = Convert.ToString(item[ProductFields.PRODUCT_UNIT]);
            header.OmItemVersion = Convert.ToString(item[ProductFields.OM_ITEM_VERSION]);
            header.OfferingCluster = Convert.ToString(item[ProductFields.OFFERING_CLUSTER]);
            header.ConfidentialityClass = Convert.ToString(item[ProductFields.CONFIDENTIALITY_CLASS]);
            header.OlmPhase = Convert.ToString(item[ProductFields.OLM_PHASE]);
            header.OlmMilestone = Convert.ToString(item[ProductFields.OLM_MILESTONE]);
            header.CoSignatureDate = item[ProductFields.COSIGN_DATE] as DateTime?;
            header.CoSignatureDueDate = item[ProductFields.COSIGN_DUE_DATE] as DateTime?;
            header.Status = Convert.ToString(item[ProductFields.COSIGN_STATUS]);
            header.Result = Convert.ToString(item[ProductFields.COSIGNATURE_RESULT]);
            header.Remark = Convert.ToString(item[ProductFields.REMARK]);

            return header;
        }        
        
        internal Document MapDocumentsToEntity(ListItem item)
        {
            var document = new Document();
            document.Name = Convert.ToString(item[ProductFields.NAME]);
            document.ConfidentialityClass = Convert.ToString(item[ProductFields.CONFIDENTIALITY_CLASS]);
            document.DocumentCategory = Convert.ToString(item[ProductFields.DOCUMENT_CATEGORY]);
            document.DocumentTagging = TaxonomyHelper.MapTaxonomy(item[ProductFields.DOCUMENT_TAGGING]);
            document.DocumentOwner = MapToUser(item[ProductFields.DOCUMENT_OWNER]);
            document.CheckoutTo = MapToUser(item[ProductFields.CHECKOUT_TO]);
            return document;
        }

        internal CoSignatureHeader JoinCoSignatures(CoSignatureHeader coSignature,
            CoSignatureHeader coSignatureWorkflow)
        {
            var header = new CoSignatureHeader();

            header.CoSignatureId = coSignature.CoSignatureId;
            header.Topic = coSignature.Topic;
            header.Requestor = coSignature.Requestor;
            header.PortfolioUnit = coSignature.PortfolioUnit;
            header.OmItemVersion = coSignature.OmItemVersion;
            header.OfferingCluster = coSignature.OfferingCluster;
            header.ConfidentialityClass = coSignature.ConfidentialityClass;
            header.OlmPhase = coSignature.OlmPhase;
            header.OlmMilestone = coSignature.OlmMilestone;
            header.CoSignatureDate = coSignature.CoSignatureDate;
            header.CoSignatureDueDate = coSignature.CoSignatureDueDate;
            header.Status = coSignature.Status;
            header.Result = coSignature.Result;
            header.Remark = coSignature.Remark;

            return header;
        }

        private User MapToUser(object input)
        {
            if (!(input is FieldUserValue fieldUserValue))
                return null;

            return new User(fieldUserValue.LookupValue, fieldUserValue.Email);
        }

        private User[] MapToUsers(object input)
        {
            if (!(input is FieldUserValue[] fieldUserValues))
                return null;
            if (fieldUserValues.Length == 0)
                return null;
            List<User> users = new List<User>();
            foreach (var u in fieldUserValues)
                users.Add(new User(u.LookupValue, u.Email));
            return users.ToArray();
        }

        private double? ConvertNullableDouble(object value)
        {
            double? result = null;
            if (value != null) result = Convert.ToDouble(value, CultureInfo.InvariantCulture);
            return result;
        }
    }
}