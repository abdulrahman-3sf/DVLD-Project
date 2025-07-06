using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using DVLD_Shared;


namespace DVLD_DataAccess
{
    public class clsPeopleData
    {
        public static bool GetPersonInfoByID(int PersonID, ref stPersonWithoutID Person)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = "select * from People where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    Person.NationalNo = (string)reader["NationalNo"];
                    Person.FirstName = (string)reader["FirstName"];
                    Person.SecondName = (string)reader["SecondName"];
                    Person.LastName = (string)reader["LastName"];
                    Person.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Person.Gender = (DVLD_Shared.enGender)reader["Gendor"];
                    Person.Address = (string)reader["Address"];
                    Person.Phone = (string)reader["Phone"];
                    Person.NationalityCountryID = (int)reader["NationalityCountryID"];
                    
                    if (reader["ThirdName"] == DBNull.Value)
                        Person.ThirdName = "";
                    else
                        Person.ThirdName = (string)reader["ThirdName"];

                    if (reader["Email"] == DBNull.Value)
                        Person.Email = "";
                    else
                        Person.Email = (string)reader["Email"];

                    if (reader["ImagePath"] == DBNull.Value)
                        Person.ImagePath = "";
                    else
                        Person.ImagePath = (string)reader["ImagePath"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetPersonInfoByNationalNo(ref int PersonID, ref stPersonWithoutID Person)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = "select * from People where NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", Person.NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    Person.FirstName = (string)reader["FirstName"];
                    Person.SecondName = (string)reader["SecondName"];
                    Person.LastName = (string)reader["LastName"];
                    Person.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Person.Gender = (DVLD_Shared.enGender)reader["Gendor"];
                    Person.Address = (string)reader["Address"];
                    Person.Phone = (string)reader["Phone"];
                    Person.NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ThirdName"] == DBNull.Value)
                        Person.ThirdName = "";
                    else
                        Person.ThirdName = (string)reader["ThirdName"];

                    if (reader["Email"] == DBNull.Value)
                        Person.Email = "";
                    else
                        Person.Email = (string)reader["Email"];

                    if (reader["ImagePath"] == DBNull.Value)
                        Person.ImagePath = "";
                    else
                        Person.ImagePath = (string)reader["ImagePath"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
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
            command.Parameters.AddWithValue("@NationalityCountryID", personWithoutID.NationalityCountryID);

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

        public static bool UpdatePerson(int PersonID, stPersonWithoutID personWithoutID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = @"update People
                     set NationalNo = @NationalNo,
                         FirstName = @FirstName,
                         SecondName = @SecondName,
                         ThirdName = @ThirdName,
                         LastName = @LastName,
                         DateOfBirth = @DateOfBirth,
                         Gendor = @Gendor,
                         Address = @Address,
                         Phone = @Phone,
                         Email = @Email,
                         NationalityCountryID = @NationalityCountryID,
                         ImagePath = @ImagePath
                         where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", personWithoutID.NationalNo);
            command.Parameters.AddWithValue("@FirstName", personWithoutID.FirstName);
            command.Parameters.AddWithValue("@SecondName", personWithoutID.SecondName);
            command.Parameters.AddWithValue("@LastName", personWithoutID.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", personWithoutID.DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", personWithoutID.Gender);
            command.Parameters.AddWithValue("@Address", personWithoutID.Address);
            command.Parameters.AddWithValue("@Phone", personWithoutID.Phone);
            command.Parameters.AddWithValue("@NationalityCountryID", personWithoutID.NationalityCountryID);
            command.Parameters.AddWithValue("@PersonID", PersonID);

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
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

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
