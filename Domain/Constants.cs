namespace Domain
{
    public static class Constants
    {
        public static class SharePoint
        {
            public const int DEFAULT_QUERY_ROW_LIMIT = 100;
        }

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
                public static readonly string LINK = "UrlLink";
                public static readonly string LONG_DESCRIPTION = "Long_x0020_Description";
                public static readonly string MODIFIED = "Modified";
                public static readonly string ONBOARDING_DUE_DATE = "Onboarding_x0020_Due_x0020_Date";
                public static readonly string OSS_BUDGET_APPROVED = "OSS_x0020_Budget_x0020_Approved";
                public static readonly string OSS_BUDGET_CAPEX_PLAN = "OSS_x0020_Budget_x0020_Capex_x00";
                public static readonly string OSS_BUDGET_OPEX_PLAN = "OSS_x0020_Budget_x0020_Opex_x002";
                public static readonly string OSS_RELEASE_ASSIGNMENT = "OSS_x0020_Release_x0020_Assignme";
                public static readonly string OMITEMVERSION_COMMENT = "OMItemVersionComment";
                public static readonly string PRODUCT_ID = "Product_x0020_ID";
                public static readonly string PRODUCT_NAME = "Product_x0020_Name";
                public static readonly string PRODUCTNUMBER = "ProductNumber";
                public static readonly string REQUESTED_ONBOARDING = "Planned_x0020_Onboarding";
                public static readonly string SHORT_DESCRIPTION = "Short_x0020_Description";
                public static readonly string TEAMMEMBERS = "TeamMembers";
                public static readonly string TITLE = "Title";
                public static readonly string VERSION_ALIAS = "Version_x0020_Alias";
                public static readonly string VERSION_ID = "Version_x0020_ID";
                public static readonly string VERSION_MANAGER = "Version_x0020_Manager";
                public static readonly string VERSION_NAME = "Version_x0020_Name";
                public static readonly string VERSION_STATUS = "Version_x0020_Status";
                public static readonly string VERSIONNUMBER = "VersionNumber";
                public static readonly string CREATED_BY = "Author";
                public static readonly string MODIFIED_BY = "Editor";
                public static readonly string OLM_PHASE_VERSION = "OLM_x0020_Phase_x0020_Version";
                public static readonly string QIDXBASIC = "QIdxBasic";
                public static readonly string QIDXBUDGET = "QIdxBudget";
                public static readonly string QIDXMILESTONES = "QIdxMilestones";
                public static readonly string QIDXMEASURES = "QIdxMeasures";
                public static readonly string QIDXOVERALL = "QIdxOverall";
                public static readonly string LASTIDXUPDATE = "LastIdxUpdate";
                public static readonly string PIMSIDALLVERSION = "PIMSIDAllVersion";
                public static readonly string PORTFOLIOUNIT = "Product_x0020_Unit";
                public static readonly string OFFERING_TYPE = "OMItemOfferingType";
                public static readonly string OFFERING_NAME = "Offering_x0020_Name";
                public static readonly string OFFERING_MODULE = "Offering_x0020_Module";
                public static readonly string OFFERING_MODULE_ID = "Offering_x0020_Module_x0020_ID";
                public static readonly string PIMSIDOMITEM = "PIMSIDOMItem";
                public static readonly string PRODUCT_MANAGER = "Product_x0020_Manager";
                public static readonly string PRODUCT_ALIAS = "Product_x0020_Alias";
                public static readonly string OMITEMID = "Product_x0020_ID";
                public static readonly string PLM_PHASE = "PLM_x0020_Phase";
                public static readonly string PLM_DATE = "PLM_x0020_Date";
                public static readonly string PLM_PHASE_PLANNED = "PLM_x0020_phase_x0020_planned_x0";
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
                public static class AllOlmPhases
                {
                    public static readonly string TITLE = "PLM Phase";
                    public static readonly string ROOT_FOLDER_NAME = "PLMPhase";
                }

                public static class AllMilestones
                {
                    public static readonly string TITLE = "Milestones";
                    public static readonly string ROOT_FOLDER_NAME = "Milestones";
                }
            }

            public static class Fields
            {
                public static readonly string ACTIVE_STATUS = "Active_x0020_Status";
                public static readonly string CONFIDENTIALITY_CLASS = "Confidentiality_x0020_Class";
                public static readonly string CREATED = "Created";
                public static readonly string LONG_DESCRIPTION = "Long_x0020_Description";
                public static readonly string MODIFIED = "Modified";
                public static readonly string OFFERING_MODULE = "Offering_x0020_Module";
                public static readonly string OFFERING_MODULE_ID = "Offering_x0020_Module_x0020_ID";
                public static readonly string OFFERING_TYPE = "Classification";
                public static readonly string OFFERING_NAME = "Offering_x0020_Name";
                public static readonly string PLM_DATE = "PLM_x0020_Date";
                public static readonly string PLM_PHASE = "PLM_x0020_Phase";
                public static readonly string PLM_PHASE_PLANNED = "PLM_x0020_phase_x0020_planned_x0";
                public static readonly string PRODUCT_ALIAS = "Product_x0020_Alias";
                public static readonly string PRODUCT_ID = "Product_x0020_ID";
                public static readonly string PRODUCT_MANAGER = "Product_x0020_Manager";
                public static readonly string PRODUCT_NAME = "Product_x0020_Name";
                public static readonly string PRODUCT_UNIT = "Product_x0020_Unit";
                public static readonly string SHORT_DESCRIPTION = "Short_x0020_Description";
                public static readonly string CREATED_BY = "Author";
                public static readonly string MODIFIED_BY = "Editor";
                public static readonly string REPORTING_MONTH = "Reporting_x0020_Month";
                public static readonly string DELTA_CAPEX_YTD = "Delta_x0020_CAPEX_x0020_YTD";
                public static readonly string DELTA_OPEX_YTD = "Delta_x0020_OPEX_x0020_YTD";
                public static readonly string DELTA_REVENUE_YTD = "Delta_x0020_Revenue_x0020_YTD";
                public static readonly string TEAMMEMBERS = "TeamMembers";
                public static readonly string PRODUCT_NUMBER = "ProductNumber";
                public static readonly string PIMSIDOMITEM = "PIMSIDOMItem";
                public static readonly string OFFERING_CLUSTER = "Offering_x0020_Cluster";
                public static readonly string OLM_PHASE = "PLM_x0020_Phase";
                public static readonly string CURRENT_PHASE = "Current_x0020_Phase";
                public static readonly string PHASE_START_APPROVAL_DATE = "Phase_x0020_Start_x0020_Approval";
                public static readonly string PHASE_START_DATE = "Phase_x0020_Start_x0020_Date";
                public static readonly string PHASE_PLANNED_END_DATE = "Phase_x0020_Planned_x0020_End_x0";
                public static readonly string PHASE_DURATION = "Phase_x0020_Duration";
                public static readonly string MILESTONE_NAME = "MST_Name";
                public static readonly string DATE_BASIC_PLAN = "Date_x0020_Basic_x0020_Plan";
                public static readonly string DATE_PLAN = "Date_x0020_Plan";
                public static readonly string DATE_ACTUAL = "Date_x0020_Actual";
                public static readonly string MILESTONE_TYPE = "MST_Type";
                public static readonly string DEFAULT = "Default";
                public static readonly string SHORTDESCRIPTION = "Short_x0020_Description";
                public static readonly string COMMENT = "Comment1";
            }
        }
    }

}
