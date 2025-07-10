using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsApplicationTypes
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public float ApplicationTypeFees { get; set; }

        public clsApplicationTypes()
        {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = "";
            ApplicationTypeFees = 0;
        }

        private clsApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitle, float ApplicationTypeFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationTypeFees;
        }

        public static DataTable ListApplicationTypes()
        {
            return clsApplicationTypesData.ListApplicationTypes();
        }
    }
}
