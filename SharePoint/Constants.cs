namespace SharePoint
{
    public static class Constants
    {
        public const int DEFAULT_QUERY_ROW_LIMIT = 100;

        public static class Root
        {
            public static class Lists
            {
                public static class AllProducts
                {
                    public static readonly string TITLE = "All Products";
                    public static readonly string ROOT_FOLDER = "AllProducts";
                }

                public static class AllVersions
                {
                    public static readonly string TITLE = "All Versions";
                    public static readonly string ROOT_FOLDER_NAME = "AllVersions";
                }
            }

            public static class Fields
            {
                public static readonly string ACTIVE_STATUS = "Active_x0020_Status";
                public static readonly string BSS_RELEASE_ASSIGNMENT = "BSS_x0020_Release_x0020_Assignme";
                public static readonly string CLASSIFICATION = "Classification";
                public static readonly string DD_RELEASE_ASSIGNMENT = "DD_x0020_Release_x0020_Assignmen";
                public static readonly string FULL_VERSION_ID = "Full_x0020_Version_x0020_ID";
                public static readonly string LONG_DESCRIPTION = "Long_x0020_Description";
                public static readonly string OFFERING_TYPE = "OMItemOfferingType";
                public static readonly string OFFERING_MODULE = "Offering_x0020_Module";
                public static readonly string OFFERING_MODULE_ID = "Offering_x0020_Module_x0020_ID";
                public static readonly string OFFERING_NAME = "Offering_x0020_Name";
                public static readonly string OLM_PHASE_VERSION = "OLM_x0020_Phase_x0020_Version";
                public static readonly string OSS_RELEASE_ASSIGNMENT = "OSS_x0020_Release_x0020_Assignme";
                public static readonly string OMITEMID = "Product_x0020_ID";
                public static readonly string OMITEMVERSION_COMMENT = "OMItemVersionComment";
                public static readonly string PIMSIDOMITEM = "PIMSIDOMItem";
                public static readonly string PIMSIDALLVERSION = "PIMSIDAllVersion";
                public static readonly string PORTFOLIOUNIT = "Product_x0020_Unit";
                public static readonly string PRODUCT_ALIAS = "Product_x0020_Alias";
                public static readonly string PRODUCT_ID = "Product_x0020_ID";
                public static readonly string PRODUCT_MANAGER = "Product_x0020_Manager";
                public static readonly string PRODUCT_NAME = "Product_x0020_Name";
                public static readonly string PRODUCTNUMBER = "ProductNumber";
                public static readonly string PLM_DATE = "PLM_x0020_Date";
                public static readonly string PLM_PHASE = "PLM_x0020_Phase";
                public static readonly string PLM_PHASE_PLANNED = "PLM_x0020_phase_x0020_planned_x0";
                public static readonly string SHORT_DESCRIPTION = "Short_x0020_Description";
                public static readonly string VERSION_NAME = "Version_x0020_Name";
                public static readonly string VERSION_STATUS = "Version_x0020_Status";
                public static readonly string VERSIONNUMBER = "VersionNumber";
            }
        }

        public static class Product
        {
            public static class Lists
            {
                public static class ProductRecord
                {
                    public static readonly string TITLE = "Product Record";
                    public static readonly string ROOT_FOLDER_NAME = "ProductRecord";
                }

                public static class OlmPhases
                {
                    public static readonly string TITLE = "PLM Phase";
                    public static readonly string ROOT_FOLDER_NAME = "PLMPhase";
                }

                public static class Milestones
                {
                    public static readonly string TITLE = "Milestones";
                    public static readonly string ROOT_FOLDER_NAME = "Milestones";
                }

                public static class Versions
                {
                    public static readonly string TITLE = "Versions";
                    public static readonly string ROOT_FOLDER_NAME = "Versions";
                }


                public static class Team
                {
                    public static readonly string TITLE = "Team";
                    public static readonly string ROOT_FOLDER_NAME = "Team";
                }
            }

            public static class Fields
            {
                public static readonly string ACTIVE_STATUS = "Active_x0020_Status";
                public static readonly string OMITEMVERSION_COMMENT = "OMItemVersionComment";
                public static readonly string COMMENT = "Comment1";
                public static readonly string CONFIDENTIALITY_CLASS = "Confidentiality_x0020_Class";
                public static readonly string CURRENT_PHASE = "Current_x0020_Phase";
                public static readonly string DATE_ACTUAL = "Date_x0020_Actual";
                public static readonly string DATE_BASIC_PLAN = "Date_x0020_Basic_x0020_Plan";
                public static readonly string DATE_PLAN = "Date_x0020_Plan";
                public static readonly string DEFAULT = "Default";
                public static readonly string LONG_DESCRIPTION = "Long_x0020_Description";
                public static readonly string MILESTONE_NAME = "MST_Name";
                public static readonly string MILESTONE_TYPE = "MST_Type";
                public static readonly string OFFERING_CLUSTER = "Offering_x0020_Cluster";
                public static readonly string OFFERING_MODULE = "Offering_x0020_Module";
                public static readonly string OFFERING_NAME = "Offering_x0020_Name";
                public static readonly string OFFERING_TYPE = "Classification";
                public static readonly string PIMSIDOMITEM = "PIMSIDOMItem";
                public static readonly string PLM_DATE = "PLM_x0020_Date";
                public static readonly string PLM_PHASE = "PLM_x0020_Phase";
                public static readonly string PLM_PHASE_PLANNED = "PLM_x0020_phase_x0020_planned_x0";
                public static readonly string PRODUCT_ALIAS = "Product_x0020_Alias";
                public static readonly string PRODUCT_ID = "Product_x0020_ID";
                public static readonly string PRODUCT_MANAGER = "Product_x0020_Manager";
                public static readonly string PRODUCT_NAME = "Product_x0020_Name";
                public static readonly string PRODUCT_UNIT = "Product_x0020_Unit";
                public static readonly string SHORT_DESCRIPTION = "Short_x0020_Description";
                public static readonly string PHASE_START_APPROVAL_DATE = "Phase_x0020_Start_x0020_Approval";
                public static readonly string PHASE_START_DATE = "Phase_x0020_Start_x0020_Date";
                public static readonly string PHASE_PLANNED_END_DATE = "Phase_x0020_Planned_x0020_End_x0";
                public static readonly string PHASE_DURATION = "Phase_x0020_Duration";
                public static readonly string ARTICLE_NUMBER = "Article_x0020_Number";
                public static readonly string BSS_BUDGET_APPROVED = "BSS_x0020_Budget_x0020_Approved";
                public static readonly string BSS_BUDGET_CAPEX_PLAN = "BSS_x0020_Budget_x0020_Capex_x00";
                public static readonly string BSS_BUDGET_OPEX_PLAN = "BSS_x0020_Budget_x0020_Opex_x002";
                public static readonly string BSS_RELEASE_ASSIGNMENT = "BSS_x0020_Release_x0020_Assignme";
                public static readonly string CLASSIFICATION = "Classification";
                public static readonly string CREATED = "Created";
                public static readonly string DD_RELEASE_ASSIGNMENT = "DD_x0020_Release_x0020_Assignmen";
                public static readonly string F_E_BUDGET_APPROVED = "F_x0026_E_x0020_Budget_x0020_App";
                public static readonly string F_E_BUDGET_CAPEX_PLAN = "F_x0026_E_x0020_Budget_x0020_Cap";
                public static readonly string F_E_BUDGET_OPEX_PLAN = "F_x0026_E_x0020_Budget_x0020_Ope";
                public static readonly string FULL_VERSION_ID = "Full_x0020_Version_x0020_ID";
                public static readonly string MODIFIED = "Modified";
                public static readonly string ONBOARDING_DUE_DATE = "Onboarding_x0020_Due_x0020_Date";
                public static readonly string OSS_BUDGET_APPROVED = "OSS_x0020_Budget_x0020_Approved";
                public static readonly string OSS_BUDGET_CAPEX_PLAN = "OSS_x0020_Budget_x0020_Capex_x00";
                public static readonly string OSS_BUDGET_OPEX_PLAN = "OSS_x0020_Budget_x0020_Opex_x002";
                public static readonly string OSS_RELEASE_ASSIGNMENT = "OSS_x0020_Release_x0020_Assignme";
                public static readonly string REQUESTED_ONBOARDING = "Planned_x0020_Onboarding";
                public static readonly string VERSION_ALIAS = "Version_x0020_Alias";
                public static readonly string VERSION_ID = "Version_x0020_ID";
                public static readonly string VERSION_MANAGER = "Version_x0020_Manager";
                public static readonly string VERSION_NAME = "Version_x0020_Name";
                public static readonly string VERSION_STATUS = "Version_x0020_Status";
                public static readonly string CREATED_BY = "Author";
                public static readonly string MODIFIED_BY = "Editor";
                public static readonly string OLM_PHASE_VERSION = "OLM_x0020_Phase_x0020_Version";
                public static readonly string TSIPORTFOLIOVERSION = "TSIPortfolioVersion";
                public static readonly string CUSTOMERVALUESALESBENEFITLONG = "CustomerValueSalesBenefitLong";
                public static readonly string CUSTOMERVALUESALESBENEFITSHORT = "CustomerValueSalesBenefitShort";
                public static readonly string DTAGINNOVATIONBMSTRUCTURE = "DTAGInnovationBMStructure";
                public static readonly string DTAGINNOVATIONCATEGORY = "DTAGInnovationCategory";
                public static readonly string FOCUSOFMEASURE = "FocusofMeasure";
                public static readonly string INIPF = "IniPF";
                public static readonly string INNOVATIONTOPIC = "InnovationTopic";
                public static readonly string INPIB = "InPIB";
                public static readonly string ID = "ID";
                public static readonly string INTERNATIONALRELEVANCE = "InternationalRelevance";
                public static readonly string PRIMARYFUNDING = "PrimaryFunding";
                public static readonly string RISKMITIGATION = "RiskMitigation";
                public static readonly string SECONDARYFUNDING = "SecondaryFunding";
                public static readonly string SUPPORTEDMARKETINGMEASURE = "SupportedMarketingMeasure";
                public static readonly string TARGETAUDIENCE = "TargetAudience";
                public static readonly string MEASUREPRIORITY = "MeasurePriority";
                public static readonly string MEASURESTATUS = "MeasureStatus";
                public static readonly string URLLINK = "UrlLink";
                public static readonly string QIDXBASIC = "QIdxBasic";
                public static readonly string QIDXBUDGET = "QIdxBudget";
                public static readonly string QIDXMILESTONES = "QIdxMilestones";
                public static readonly string QIDXMEASURES = "QIdxMeasures";
                public static readonly string QIDXOVERALL = "QIdxOverall";
                public static readonly string LASTIDXUPDATE = "LastIdxUpdate";
                public static readonly string VERSION_PIMSID = "PIMSIDAllVersion";
                public static readonly string USEDINTSIFORCE = "AllowUsageInTSIForce";
                public static readonly string YEAR = "Year";
                public static readonly string DELTAREVENUEPLAN = "Delta_x0020_Revenue_x0020_Plan";
                public static readonly string DELTAOEPLAN = "Delta_x0020_OE_x0020_Plan";
                public static readonly string BSSBUDGETOPEXPLAN = "BSS_x0020_Budget_x0020_Opex_x002";
                public static readonly string BSSBUDGETCAPEXPLAN = "BSS_x0020_Budget_x0020_Capex_x00";
                public static readonly string BSSBUDGETOPEXAPPROVED = "BSS_x0020_Budget_x0020_Opex_x0020";
                public static readonly string BSSBUDGETCAPEXAPPROVED = "BSS_x0020_Budget_x0020_Capex_x000";
                public static readonly string OSSBUDGETOPEXPLAN = "OSS_x0020_Budget_x0020_Opex_x002";
                public static readonly string OSSBUDGETCAPEXPLAN = "OSS_x0020_Budget_x0020_Capex_x00";
                public static readonly string OSSBUDGETOPEXAPPROVED = "OSS_x0020_Budget_x0020_Opex_x0020";
                public static readonly string OSSBUDGETCAPEXAPPROVED = "OSS_x0020_Budget_x0020_Capex_x000";
                public static readonly string OTHERBUDGETOPEXPLAN = "Other_x0020_Budget_x0020_Opex_x0";
                public static readonly string OTHERBUDGETCAPEXPLAN = "Other_x0020_Budget_x0020_Capex_x";
                public static readonly string OTHERBUDGETOPEXAPPROVED = "Other_x0020_Budget_x0020_Opex_x00";
                public static readonly string OTHERBUDGETCAPEXAPPROVED = "Other_x0020_Budget_x0020_Capex_x0";
                public static readonly string RNDBUDGETOPEXPLAN = "R_x0026_D_x0020_Budget_x0020_Ope";
                public static readonly string RNDBUDGETCAPEXPLAN = "R_x0026_D_x0020_Budget_x0020_Cap";
                public static readonly string RNDBUDGETOPEXAPPROVED = "R_x0026_D_x0020_Budget_x0020_Ope0";
                public static readonly string RNDBUDGETCAPEXAPPROVED = "R_x0026_D_x0020_Budget_x0020_Cap0";
                public static readonly string SIGNATURE_NAME = "SignatureName";
                public static readonly string OM_ITEM_VERSION = "OM_x0020_Item_x0020_Version";
                public static readonly string REQUESTOR = "Requestor";
                public static readonly string COSIGN_DATE = "Co_x0020_Sign_x0020_Date";
                public static readonly string COSIGN_DUE_DATE = "Co_x0020_Sign_x0020_Due_x0020_Da";
                public static readonly string OLM_PHASE = "OLM_x0020_Phase";
                public static readonly string OLM_MILESTONE = "OLM_x0020_Milestone";
                public static readonly string COSIGN_STATUS = "Co_x0020_Sign_x0020_Status";
                public static readonly string COSIGNER_LIST = "Co_x0020_Signer_x0020_List";
                public static readonly string TOPIC = "Topic";
                public static readonly string REMARK = "Remark";
                public static readonly string COSIGN_SUBMITTED_DATE = "Co_x0020_Sign_x0020_Submitted_x0";
                public static readonly string COSIGN_RESULT_DATE = "Co_x0020_Sign_x0020_Result_x0020";
                public static readonly string COSIGNATURE_RESULT = "Co_x0020_Signature_x0020_Result";
                public static readonly string IS_SUBMITTED = "isSubmitted";
                public static readonly string IS_CANCELLED = "isCancelled";
                public static readonly string IS_DONE = "isDone";
                public static readonly string COSIGN_VOTES = "CoSignVotes";
                public static readonly string TOTAL_COSIGN_VOTES = "TotalCoSignVotes";
                public static readonly string COSIGNATURE_ID = "CoSignatureID";
                public static readonly string VALID_FROM = "Valid_x0020_From";
                public static readonly string VALID_TO = "Valid_x0020_To";
                public static readonly string TEAM_ROLE = "Team_x0020_Role";
                public static readonly string ROLE_COMMENT = "RoleComment";
                public static readonly string MEMBER1 = "Member1";
                public static readonly string DEPUTY_OF = "Deputy_x0020_Of";
                public static readonly string ISCOSIGNER = "Co_x002d_Signer";
                public static readonly string ROLECOMMENT = "RoleComment";
                public static readonly string DOCUMENT_CATEGORY = "Document_x0020_Category";
                public static readonly string DOCUMENT_OWNER = "Document_x0020_Owner";
                public static readonly string DOCUMENT_TAGGING = "Document_x0020_Tagging";
                public static readonly string CHECKOUT_TO = "CheckoutUser";
                public static readonly string NAME = "FileLeafRef";
                public static readonly string EVENT = "Title";
                public static readonly string DATE_AND_TIME_OF_CHANGE = "Date_x0020_and_x0020_time_x0020_";
                public static readonly string USER = "Executor";
                public static readonly string TYPE_OF_CHANGE = "TypeOfChange";
                public static readonly string CHANGE_SECTION = "ChangeSection";
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
                    public static readonly string TITLE = "Version Budgets";
                    public static readonly string ROOT_FOLDER_NAME = "VersionBudgets";
                }

                public static class VersionTeam
                {
                    public static readonly string TITLE = "Team";
                    public static readonly string ROOT_FOLDER_NAME = "Team";
                }

                public static class CoSignaturesList
                {
                    public static readonly string TITLE = "Co Signatures List";
                    public static readonly string ROOT_FOLDER_NAME = "CoSignaturesList";
                }

                public static class CoSignatureWorkflow
                {
                    public static readonly string TITLE = "CoSignatureWorkflow";
                    public static readonly string ROOT_FOLDER_NAME = "CoSignatureWorkflow";
                }

                public static class VersionDocument
                {
                    public static readonly string TITLE = "Version Documents";
                    public static readonly string ROOT_FOLDER_NAME = "VersionDocuments";
                }

                public static class VersionChangeLog
                {
                    public static readonly string TITLE = "ChangeLog";
                    public static readonly string ROOT_FOLDER_NAME = "ChangeLog";
                }
            }
        }
    }
}