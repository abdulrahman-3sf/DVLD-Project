using DVLD_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsLocalDrivingLicenseApplications
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public int LocalDrivingLicenseApplicationID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
    }
}
