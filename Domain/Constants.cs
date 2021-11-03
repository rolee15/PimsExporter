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
            }

            public static class Fields
            {
                public static readonly string ACTIVE_STATUS = "Active_x0020_Status";
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
            }
        }
    }

}
