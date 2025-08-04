using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Shared_Layer;
using System.Reflection.Emit;
using System.Data;
namespace Data_Layer
{
    public class clsPersonData
    {
        public static bool GetPersonInfoByID(int PersonID, string FirstName, string SecondName, string ThirdName,
            string LastName, string Phone)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT * FROM People WHERE People.ID = @PersonID";
                    {
                        using (SqlCommand Command = new SqlCommand(Query, Connection))
                        {
                            Command.Parameters.AddWithValue("@PersonID", PersonID);
                            using (SqlDataReader Reader = Command.ExecuteReader())
                            {
                                if (Reader.Read())
                                {
                                    IsFound = true;
                                    FirstName = (string)Reader["FirstName"];
                                    SecondName = (string)Reader["SecondName"];
                                    ThirdName = Reader["ThirdName"] == DBNull.Value ? "" : (string)Reader["ThirdName"];
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"person info for person ID = {PersonID}.", EventLogEntryType.Error);
            }
            catch(Exception ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"person info for person ID = {PersonID}.", EventLogEntryType.Error);
            }
            return IsFound;
        }
        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName, 
            string Phone)
        {
            int PersonID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"INSERT INTO People (FirstName, SecondName, ThirdName, LastName, Phone) 
                                     VALUES (@FirstName, @SecondName, @ThirdName, @LastName, @Phone);
                                     SELECT SCOPE_IDENTITY();";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@FirstName", FirstName);
                        Command.Parameters.AddWithValue("@SecondName", SecondName);
                        if (ThirdName != null && ThirdName != "")
                            Command.Parameters.AddWithValue("@ThirdName", ThirdName);
                        else
                            Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                        Command.Parameters.AddWithValue("@Phone", Phone);
                        object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            PersonID = ID;
                    }
                }
            }
            catch (SqlException ex)
            {
                PersonID = -1;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through adding " +
                    $"new person with name {FirstName} {SecondName}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                PersonID = -1;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through adding " +
                    $"new person with name {FirstName} {SecondName}.", EventLogEntryType.Error);
            }
            return PersonID;
        }
        public static bool UpdatePerson(int PersonID, string FirstName, string SecondName, string ThirdName, 
            string LastName, string Phone)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"UPDATE People 
                                     SET FirstName = @FirstName,
                                         SecondName = @SecondName,
                                         ThirdName = @ThirdName,
                                         LastName = @LastName,
                                         Phone = @Phone 
                                         WHERE People.ID = @PersonID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@FirstName", FirstName);
                        Command.Parameters.AddWithValue("@SecondName", SecondName);
                        if (ThirdName != null && ThirdName != "")
                            Command.Parameters.AddWithValue("@ThirdName", ThirdName);
                        else
                            Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                        Command.Parameters.AddWithValue("@Phone", Phone);
                        RowsAffected = Command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through updating " +
                    $"person with person ID = {PersonID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through updating " +
                    $"person with person ID = {PersonID}.", EventLogEntryType.Error);
            }
            return RowsAffected > 0;
        }
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT * FROM People ORDER BY People.FirstName";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                            {
                                dt.Load(Reader);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                dt = null;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"all people.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                dt = null;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"all people.", EventLogEntryType.Error);
            }
            return dt;
        }
        public static bool IsPersonExist(int PersonID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT FOUND = 1 FROM People WHERE People.ID = @PersonID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            IsFound = Reader.HasRows;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through checking" +
                    $"if person with ID = {PersonID} exists or not.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through checking" +
                    $"if person with ID = {PersonID} exists or not.", EventLogEntryType.Error);
            }
            return IsFound;
        }
        public static bool DeletePerson(int PersonID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"DELETE People WHERE People.ID = @PersonID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        RowsAffected = Command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through deleting" +
                    $"person with ID = {PersonID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through deleting" +
                    $"person with ID = {PersonID}.", EventLogEntryType.Error);//
            }
            return RowsAffected > 0;
        }
    }
}