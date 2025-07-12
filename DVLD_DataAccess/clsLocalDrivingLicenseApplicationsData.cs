using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationsData
    {
        public static DataTable ListLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = @"SELECT       LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LicenseClasses.ClassName, People.NationalNo, FullName = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName, Applications.ApplicationDate, 
                         Applications.ApplicationStatus,
						 CASE
							WHEN Applications.ApplicationStatus = 1 THEN 'New'
							WHEN Applications.ApplicationStatus = 2 THEN 'Cancelled'
							WHEN Applications.ApplicationStatus = 3 THEN 'Completed'
							ELSE 'Unknown'
						 END as Status
FROM            LicenseClasses INNER JOIN
                         LocalDrivingLicenseApplications ON LicenseClasses.LicenseClassID = LocalDrivingLicenseApplications.LicenseClassID INNER JOIN
                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN
                         People ON Applications.ApplicantPersonID = People.PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
    }
}
