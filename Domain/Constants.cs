using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace Domain
{
    public static class Constants
    {
        public const int DefaultQueryRowLimit = 100;

        public static readonly List<string> SAP_RELATED_ITEMS = new List<string>
        {
            "Offering Cluster",
            "Offering Module",
            "Offering Name",
            "Product Unit"
        };

        public static class Root
        {
            public static class Lists
            {
                public static class AllProducts
                {
                    public const string TITLE = "All Products";
                    public const string ROOT_FOLDER = "AllProducts";
                }

                public static class AllVersions
                {
                    public const string TITLE = "All Versions";
                    public const string ROOT_FOLDER_NAME = "AllVersions";
                }

                public static class Lookups
                {
                    public const string TITLE = "Lookups";
                    public const string ROOT_FOLDER_NAME = "Lookups";
                }
            }

            public static class Fields
            {
                public const string ACTIVE_STATUS = "Active_x0020_Status";
                public const string BSS_RELEASE_ASSIGNMENT = "BSS_x0020_Release_x0020_Assignme";
                public const string CLASSIFICATION = "Classification";
                public const string DD_RELEASE_ASSIGNMENT = "DD_x0020_Release_x0020_Assignmen";
                public const string FULL_VERSION_ID = "Full_x0020_Version_x0020_ID";
                public const string LONG_DESCRIPTION = "Long_x0020_Description";
                public const string OFFERING_TYPE = "OMItemOfferingType";
                public const string OFFERING_MODULE = "Offering_x0020_Module";
                public const string OFFERING_MODULE_ID = "Offering_x0020_Module_x0020_ID";
                public const string OFFERING_NAME = "Offering_x0020_Name";
                public const string OLM_PHASE_VERSION = "OLM_x0020_Phase_x0020_Version";
                public const string OSS_RELEASE_ASSIGNMENT = "OSS_x0020_Release_x0020_Assignme";
                public const string OMITEMID = "Product_x0020_ID";
                public const string OMITEMVERSION_COMMENT = "OMItemVersionComment";
                public const string PIMSIDOMITEM = "PIMSIDOMItem";
                public const string PIMSIDALLVERSION = "PIMSIDAllVersion";
                public const string PORTFOLIOUNIT = "Product_x0020_Unit";
                public const string PRODUCT_ALIAS = "Product_x0020_Alias";
                public const string PRODUCT_ID = "Product_x0020_ID";
                public const string PRODUCT_MANAGER = "Product_x0020_Manager";
                public const string PRODUCT_NAME = "Product_x0020_Name";
                public const string PRODUCTNUMBER = "ProductNumber";
                public const string PLM_DATE = "PLM_x0020_Date";
                public const string PLM_PHASE = "PLM_x0020_Phase";
                public const string PLM_PHASE_PLANNED = "PLM_x0020_phase_x0020_planned_x0";
                public const string SHORT_DESCRIPTION = "Short_x0020_Description";
                public const string VERSION_NAME = "Version_x0020_Name";
                public const string VERSION_STATUS = "Version_x0020_Status";
                public const string VERSIONNUMBER = "VersionNumber";
                public const string TITLE = "Title";
                public const string CHOICE_LIST = "ChoiceList";
                public const string SORT_INDEX = "SortIndex";
                public const string VALID_FROM = "ValidFrom";
                public const string VALID_TO = "ValidTo";
                public const string IS_DEFAULT = "IsDefault";
                public const string MAIN_CHOICE = "MainChoice";
                public const string MAIN_CHOICE_VALUE = "MainChoiceValue";
                public const string SECONDARY_CHOICE = "SecondaryChoice";
                public const string SECONDARY_CHOICE_VALUE = "SecondaryValue";
                public const string VALUE = "Value";
                public const string MODIFIED = "Modified";
                public const string CREATED = "Created";
                public const string CREATED_BY = "CreatedBy";
                public const string MODIFIED_BY = "ModifiedBy";
            }
        }

        public static class Product
        {
            public static class Lists
            {
                public static class ProductRecord
                {
                    public const string TITLE = "Product Record";
                    public const string ROOT_FOLDER_NAME = "ProductRecord";
                }

                public static class OlmPhases
                {
                    public const string TITLE = "PLM Phase";
                    public const string ROOT_FOLDER_NAME = "PLMPhase";
                }

                public static class Milestones
                {
                    public const string TITLE = "Milestones";
                    public const string ROOT_FOLDER_NAME = "Milestones";
                }

                public static class Versions
                {
                    public const string TITLE = "Versions";
                    public const string ROOT_FOLDER_NAME = "Versions";
                }


                public static class Team
                {
                    public const string TITLE = "Team";
                    public const string ROOT_FOLDER_NAME = "Team";
                }

                public static class Documents
                {
                    public const string TITLE = "Product Documents";
                    public const string ROOT_FOLDER_NAME = "Documents";
                }

                public static class RelatedOMItems
                {
                    public const string TITLE = "Related Products";
                    public const string ROOT_FOLDER_NAME = "RelatedProducts";
                }
            }

            public static class Fields
            {
                public const string ACTIVE_STATUS = "Active_x0020_Status";
                public const string OMITEMVERSION_COMMENT = "OMItemVersionComment";
                public const string COMMENT = "Comment1";
                public const string CONFIDENTIALITY_CLASS = "Confidentiality_x0020_Class";
                public const string CURRENT_PHASE = "Current_x0020_Phase";
                public const string DATE_ACTUAL = "Date_x0020_Actual";
                public const string DATE_BASIC_PLAN = "Date_x0020_Basic_x0020_Plan";
                public const string DATE_PLAN = "Date_x0020_Plan";
                public const string DEFAULT = "Default";
                public const string LONG_DESCRIPTION = "Long_x0020_Description";
                public const string MILESTONE_NAME = "MST_Name";
                public const string MILESTONE_TYPE = "MST_Type";
                public const string OFFERING_CLUSTER = "Offering_x0020_Cluster";
                public const string OFFERING_MODULE = "Offering_x0020_Module";
                public const string OFFERING_MODULE_ID = "Offering_x0020_Module_x0020_ID";
                public const string OFFERING_NAME = "Offering_x0020_Name";
                public const string OFFERING_TYPE = "Classification";
                public const string PIMSIDOMITEM = "PIMSIDOMItem";
                public const string PLM_DATE = "PLM_x0020_Date";
                public const string PLM_PHASE = "PLM_x0020_Phase";
                public const string PLM_PHASE_PLANNED = "PLM_x0020_phase_x0020_planned_x0";
                public const string PRODUCT_ALIAS = "Product_x0020_Alias";
                public const string PRODUCT_ID = "Product_x0020_ID";
                public const string PRODUCT_MANAGER = "Product_x0020_Manager";
                public const string PRODUCT_NAME = "Product_x0020_Name";
                public const string PRODUCT_UNIT = "Product_x0020_Unit";
                public const string SHORT_DESCRIPTION = "Short_x0020_Description";
                public const string PHASE_START_APPROVAL_DATE = "Phase_x0020_Start_x0020_Approval";
                public const string PHASE_START_DATE = "Phase_x0020_Start_x0020_Date";
                public const string PHASE_PLANNED_END_DATE = "Phase_x0020_Planned_x0020_End_x0";
                public const string PHASE_DURATION = "Phase_x0020_Duration";
                public const string ARTICLE_NUMBER = "Article_x0020_Number";
                public const string BSS_BUDGET_APPROVED = "BSS_x0020_Budget_x0020_Approved";
                public const string BSS_BUDGET_CAPEX_PLAN = "BSS_x0020_Budget_x0020_Capex_x00";
                public const string BSS_BUDGET_OPEX_PLAN = "BSS_x0020_Budget_x0020_Opex_x002";
                public const string BSS_RELEASE_ASSIGNMENT = "BSS_x0020_Release_x0020_Assignme";
                public const string CLASSIFICATION = "Classification";
                public const string CREATED = "Created";
                public const string DD_RELEASE_ASSIGNMENT = "DD_x0020_Release_x0020_Assignmen";
                public const string F_E_BUDGET_APPROVED = "F_x0026_E_x0020_Budget_x0020_App";
                public const string F_E_BUDGET_CAPEX_PLAN = "F_x0026_E_x0020_Budget_x0020_Cap";
                public const string F_E_BUDGET_OPEX_PLAN = "F_x0026_E_x0020_Budget_x0020_Ope";
                public const string FULL_VERSION_ID = "Full_x0020_Version_x0020_ID";
                public const string MODIFIED = "Modified";
                public const string ONBOARDING_DUE_DATE = "Onboarding_x0020_Due_x0020_Date";
                public const string OSS_BUDGET_APPROVED = "OSS_x0020_Budget_x0020_Approved";
                public const string OSS_BUDGET_CAPEX_PLAN = "OSS_x0020_Budget_x0020_Capex_x00";
                public const string OSS_BUDGET_OPEX_PLAN = "OSS_x0020_Budget_x0020_Opex_x002";
                public const string OSS_RELEASE_ASSIGNMENT = "OSS_x0020_Release_x0020_Assignme";
                public const string REQUESTED_ONBOARDING = "Planned_x0020_Onboarding";
                public const string VERSION_ALIAS = "Version_x0020_Alias";
                public const string VERSION_ID = "Version_x0020_ID";
                public const string VERSION_MANAGER = "Version_x0020_Manager";
                public const string VERSION_NAME = "Version_x0020_Name";
                public const string VERSION_STATUS = "Version_x0020_Status";
                public const string CREATED_BY = "Author";
                public const string MODIFIED_BY = "Editor";
                public const string OLM_PHASE_VERSION = "OLM_x0020_Phase_x0020_Version";
                public const string TSIPORTFOLIOVERSION = "TSIPortfolioVersion";
                public const string CUSTOMERVALUESALESBENEFITLONG = "CustomerValueSalesBenefitLong";
                public const string CUSTOMERVALUESALESBENEFITSHORT = "CustomerValueSalesBenefitShort";
                public const string DTAGINNOVATIONBMSTRUCTURE = "DTAGInnovationBMStructure";
                public const string DTAGINNOVATIONCATEGORY = "DTAGInnovationCategory";
                public const string FOCUSOFMEASURE = "FocusofMeasure";
                public const string INIPF = "IniPF";
                public const string INNOVATIONTOPIC = "InnovationTopic";
                public const string INPIB = "InPIB";
                public const string ID = "ID";
                public const string INTERNATIONALRELEVANCE = "InternationalRelevance";
                public const string PRIMARYFUNDING = "PrimaryFunding";
                public const string RISKMITIGATION = "RiskMitigation";
                public const string SECONDARYFUNDING = "SecondaryFunding";
                public const string SUPPORTEDMARKETINGMEASURE = "SupportedMarketingMeasure";
                public const string TARGETAUDIENCE = "TargetAudience";
                public const string MEASUREPRIORITY = "MeasurePriority";
                public const string MEASURESTATUS = "MeasureStatus";
                public const string URLLINK = "UrlLink";
                public const string QIDXBASIC = "QIdxBasic";
                public const string QIDXBUDGET = "QIdxBudget";
                public const string QIDXMILESTONES = "QIdxMilestones";
                public const string QIDXMEASURES = "QIdxMeasures";
                public const string QIDXOVERALL = "QIdxOverall";
                public const string LASTIDXUPDATE = "LastIdxUpdate";
                public const string VERSION_PIMSID = "PIMSIDAllVersion";
                public const string USEDINTSIFORCE = "AllowUsageInTSIForce";
                public const string YEAR = "Year";
                public const string DELTAREVENUEPLAN = "Delta_x0020_Revenue_x0020_Plan";
                public const string DELTAOEPLAN = "Delta_x0020_OE_x0020_Plan";
                public const string BSSBUDGETOPEXPLAN = "BSS_x0020_Budget_x0020_Opex_x002";
                public const string BSSBUDGETCAPEXPLAN = "BSS_x0020_Budget_x0020_Capex_x00";
                public const string BSSBUDGETOPEXAPPROVED = "BSS_x0020_Budget_x0020_Opex_x0020";
                public const string BSSBUDGETCAPEXAPPROVED = "BSS_x0020_Budget_x0020_Capex_x000";
                public const string OSSBUDGETOPEXPLAN = "OSS_x0020_Budget_x0020_Opex_x002";
                public const string OSSBUDGETCAPEXPLAN = "OSS_x0020_Budget_x0020_Capex_x00";
                public const string OSSBUDGETOPEXAPPROVED = "OSS_x0020_Budget_x0020_Opex_x0020";
                public const string OSSBUDGETCAPEXAPPROVED = "OSS_x0020_Budget_x0020_Capex_x000";
                public const string OTHERBUDGETOPEXPLAN = "Other_x0020_Budget_x0020_Opex_x0";
                public const string OTHERBUDGETCAPEXPLAN = "Other_x0020_Budget_x0020_Capex_x";
                public const string OTHERBUDGETOPEXAPPROVED = "Other_x0020_Budget_x0020_Opex_x00";
                public const string OTHERBUDGETCAPEXAPPROVED = "Other_x0020_Budget_x0020_Capex_x0";
                public const string RNDBUDGETOPEXPLAN = "R_x0026_D_x0020_Budget_x0020_Ope";
                public const string RNDBUDGETCAPEXPLAN = "R_x0026_D_x0020_Budget_x0020_Cap";
                public const string RNDBUDGETOPEXAPPROVED = "R_x0026_D_x0020_Budget_x0020_Ope0";
                public const string RNDBUDGETCAPEXAPPROVED = "R_x0026_D_x0020_Budget_x0020_Cap0";
                public const string SIGNATURE_NAME = "SignatureName";
                public const string OM_ITEM_VERSION = "OM_x0020_Item_x0020_Version";
                public const string REQUESTOR = "Requestor";
                public const string COSIGN_DATE = "Co_x0020_Sign_x0020_Date";
                public const string COSIGN_DUE_DATE = "Co_x0020_Sign_x0020_Due_x0020_Da";
                public const string OLM_PHASE = "OLM_x0020_Phase";
                public const string OLM_MILESTONE = "OLM_x0020_Milestone";
                public const string COSIGN_STATUS = "Co_x0020_Sign_x0020_Status";
                public const string COSIGNER_LIST = "Co_x0020_Signer_x0020_List";
                public const string TOPIC = "Topic";
                public const string REMARK = "Remark";
                public const string COSIGN_SUBMITTED_DATE = "Co_x0020_Sign_x0020_Submitted_x0";
                public const string COSIGN_RESULT_DATE = "Co_x0020_Sign_x0020_Result_x0020";
                public const string COSIGNATURE_RESULT = "Co_x0020_Signature_x0020_Result";
                public const string IS_SUBMITTED = "isSubmitted";
                public const string IS_CANCELLED = "isCancelled";
                public const string IS_DONE = "isDone";
                public const string COSIGN_VOTES = "CoSignVotes";
                public const string TOTAL_COSIGN_VOTES = "TotalCoSignVotes";
                public const string COSIGNATURE_ID = "CoSignatureID";
                public const string VALID_FROM = "Valid_x0020_From";
                public const string VALID_TO = "Valid_x0020_To";
                public const string TEAM_ROLE = "Team_x0020_Role";
                public const string ROLE_COMMENT = "RoleComment";
                public const string MEMBER1 = "Member1";
                public const string DEPUTY_OF = "Deputy_x0020_Of";
                public const string ISCOSIGNER = "Co_x002d_Signer";
                public const string ROLECOMMENT = "RoleComment";
                public const string DOCUMENT_CATEGORY = "Document_x0020_Category";
                public const string DOCUMENT_OWNER = "Document_x0020_Owner";
                public const string DOCUMENT_TAGGING = "Document_x0020_Tagging";
                public const string CHECKOUT_TO = "CheckoutUser";
                public const string NAME = "FileLeafRef";
                public const string EVENT = "Title";
                public const string DATE_AND_TIME_OF_CHANGE = "Date_x0020_and_x0020_time_x0020_";
                public const string USER = "Executor";
                public const string TYPE_OF_CHANGE = "TypeOfChange";
                public const string CHANGE_SECTION = "ChangeSection";
                public const string COSIGNERDATE = "Co_x0020_Signer_x0020_Date";
                public const string COSIGNERRESULT = "Co_x0020_Signer_x0020_Result";
                public const string COSIGNDEPUTY = "CoSignDeputy";
                public const string COSIGNEDBY = "CoSignedBy";
                public const string UPDATED = "Updated";
                public const string LINKTYPE = "Link_x0020_Typ";
                public const string PIMSLINK = "PimsLink";
                public const string COSIGNSUBMITTEDDATE = "Co_x0020_Sign_x0020_Submitted_x0";
                public const string COSIGNRESULTDATE = "Co_x0020_Sign_x0020_Result_x0020";
                public const string QIDX_COSIGN = "QIdxCoSign";
                public const string QIDX_COSIGN_UPDATED = "QIdxCoSignUpdated";
                public const string OVERSIONBUDGETCOMMENT = "OMIVersionBudgetComment";
            }
        }

        public static class Version
        {
            public static class Lists
            {
                public static class ProductVersion
                {
                    public const string TITLE = "Product Version";
                    public const string ROOT_FOLDER_NAME = "ProductVersion";
                }

                public static class VersionBudget
                {
                    public const string TITLE = "Version Budgets";
                    public const string ROOT_FOLDER_NAME = "VersionBudgets";
                }

                public static class VersionTeam
                {
                    public const string TITLE = "Team";
                    public const string ROOT_FOLDER_NAME = "Team";
                }

                public static class CoSignaturesList
                {
                    public const string TITLE = "Co Signatures List";
                    public const string ROOT_FOLDER_NAME = "CoSignaturesList";
                }

                public static class CoSignatureWorkflow
                {
                    public const string TITLE = "CoSignatureWorkflow";
                    public const string ROOT_FOLDER_NAME = "CoSignatureWorkflow";
                }

                public static class VersionDocument
                {
                    public const string TITLE = "Version Documents";
                    public const string ROOT_FOLDER_NAME = "VersionDocuments";
                }

                public static class VersionChangeLog
                {
                    public const string TITLE = "ChangeLog";
                    public const string ROOT_FOLDER_NAME = "ChangeLog";
                }

                public static class VersionMilestone
                {
                    public const string TITLE = "Milestones";
                    public const string ROOT_FOLDER_NAME = "Milestones";
                }

                public static class CoSigners
                {
                    public const string TITLE = "Co Signers List";
                    public const string ROOT_FOLDER_NAME = "CoSignersList";
                }

                public static class CoSignatureDocuments
                {
                    public const string TITLE = "Co Signature Documents";
                    public const string ROOT_FOLDER_NAME = "CoSignatureDocuments";
                }
            }
        }
    }
}