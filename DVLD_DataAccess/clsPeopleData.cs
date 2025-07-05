using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using DVLD_Shared;


namespace DVLD_DataAccess
{
    public class clsPeopleData
    {
        public static DataTable ListPeople()
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

        public static int AddPerson(stPersonWithoutID personWithoutID)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = @"insert into People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
                             values (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                             select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", personWithoutID.NationalNo);
            command.Parameters.AddWithValue("@FirstName", personWithoutID.FirstName);
            command.Parameters.AddWithValue("@SecondName", personWithoutID.SecondName);
            command.Parameters.AddWithValue("@LastName", personWithoutID.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", personWithoutID.DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", personWithoutID.Gender);
            command.Parameters.AddWithValue("@Address", personWithoutID.Address);
            command.Parameters.AddWithValue("@Phone", personWithoutID.Phone);
            command.Parameters.AddWithValue("@NationalityCountryID", personWithoutID.Nationality);

            if (personWithoutID.ThirdName != "")
                command.Parameters.AddWithValue("@ThirdName", personWithoutID.ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            if (personWithoutID.Email != "")
                command.Parameters.AddWithValue("@Email", personWithoutID.Email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);

            if (personWithoutID.ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", personWithoutID.ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int resultID))
                    PersonID = resultID;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }
    }
}
