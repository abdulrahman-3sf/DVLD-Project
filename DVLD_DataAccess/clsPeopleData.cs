using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using DVLD_Shared;


namespace DVLD_DataAccess
{
    public class clsPeopleData
    {
        public static DataTable listPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = "select * from People";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            } catch (Exception ex)
            {

            } finally
            {
                connection.Close();
            }

            return dt;
        }
    }
}
