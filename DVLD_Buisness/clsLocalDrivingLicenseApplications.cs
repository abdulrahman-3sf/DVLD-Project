using DVLD_DataAccess;
using DVLD_Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsLocalDrivingLicenseApplications : clsApplications
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo;

        public enMode Mode = enMode.AddNew;

        public clsLocalDrivingLicenseApplications()
        {
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;
            Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID, int LicenseClassID, int ApplicationID,
            int ApplicationPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            float PaidFees, int CreatedByUserID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;
            LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            this.ApplicationID = ApplicationID;
            this.ApplicationPersonID = ApplicationPersonID;
            PersonInfo = clsPeople.Find(ApplicationPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            UserInfo = clsUser.FindByUserID(CreatedByUserID);
            Mode = enMode.Update;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicenseApplication(
                ApplicationID, LicenseClassID);

            return (LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationsData.UpdateLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
        }

        public static clsLocalDrivingLicenseApplications FindLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationInfoByID(
                LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID)) {
                clsApplications Application = clsApplications.FindByApplicationID(ApplicationID);

                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, LicenseClassID, ApplicationID,
                    Application.ApplicationPersonID, Application.ApplicationDate, Application.ApplicationTypeID,
                    Application.ApplicationStatus, Application.LastStatusDate,
                    Application.PaidFees, Application.CreatedByUserID);
            }
            else
                return null;
        }

        public static clsLocalDrivingLicenseApplications FindLocalDrivingLicenseApplicationByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationInfoByApplicationID(
                ref LocalDrivingLicenseApplicationID, ApplicationID, ref LicenseClassID))
            {
                clsApplications Application = clsApplications.FindByApplicationID(ApplicationID);

                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, LicenseClassID, ApplicationID,
                    Application.ApplicationPersonID, Application.ApplicationDate, Application.ApplicationTypeID,
                    Application.ApplicationStatus, Application.LastStatusDate,
                    Application.PaidFees, Application.CreatedByUserID);
            }
            else
                return null;
        }

        public bool Save()
        {
            base.Mode = (clsApplications.enMode)Mode;

            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApplication();

                default:
                    return false;
            }
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            clsLocalDrivingLicenseApplications LDLApplicatoin = FindLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID);

            if (LDLApplicatoin != null)
            {
                clsLocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
                clsApplications.DeleteApplication(LDLApplicatoin.ApplicationID);
                
                return true;
            }

            return false;
        }

        public static DataTable ListLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsData.ListLocalDrivingLicenseApplications();
        }

        public byte GetPassedTestCount()
        {
            return (byte)clsLocalDrivingLicenseApplicationsData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }
    }
}
