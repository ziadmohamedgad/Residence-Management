using Shared_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
namespace Data_Layer
{
    public class clsPersonData
    {
        private static void _BackupSqlDataBase()
        {
            string BackupFolderPath = @"C:\Residences Management\Backup Database";
            string BackupFile = Path.Combine(BackupFolderPath, "ResidencesDB_Backup.bak");
            if (!Directory.Exists(BackupFolderPath))
            {
                try
                {
                    Directory.CreateDirectory(BackupFolderPath);
                }
                catch (Exception ex)
                {
                    clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through creating folder with path: {BackupFolderPath}.",
                        EventLogEntryType.Warning);
                    return;
                }
            }
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = $@"BACKUP DATABASE [ResidenceDB] TO DISK = '{BackupFile}'
                                      WITH FORMAT, INIT, NAME = 'Full Backup of ResidenceDB'";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through backup database [ResidencesDB_Backup.bak] " +
                    $"to path: {BackupFolderPath}.", EventLogEntryType.Warning);
            }
        }
        public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName,
            ref string LastName, ref string Phone)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT * FROM People WHERE People.PersonID = @PersonID";
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
                                    LastName = (string)Reader["LastName"];
                                    Phone = Reader["Phone"] == DBNull.Value ? "" : (string)Reader["Phone"];
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
        public static int GetPersonIDByResidenceNumber(string ResidenceNumber)
        {
            int PersonID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT People.PersonID FROM People INNER JOIN Employees
                                     ON People.PersonID = Employees.PersonID 
                                     INNER JOIN Residences ON Employees.EmployeeID = Residences.EmployeeID 
                                     WHERE Residences.ResidenceNumber = @ResidenceNumber";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ResidenceNumber", ResidenceNumber);
                        object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            PersonID = ID;
                    }
                }
            }
            catch (SqlException ex)
            {
                PersonID = -1;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"person ID with Residence number = {ResidenceNumber}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                PersonID = -1;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"person ID with Residence number = {ResidenceNumber}.", EventLogEntryType.Error);
            }
            return PersonID;
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
                        Command.Parameters.AddWithValue("@LastName", LastName);
                        if (Phone != null && Phone != "")
                            Command.Parameters.AddWithValue("@Phone", Phone);
                        else
                            Command.Parameters.AddWithValue("Phone", DBNull.Value);
                            object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            PersonID = ID;
                    }
                }
                _BackupSqlDataBase();
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
                                         WHERE People.PersonID = @PersonID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@FirstName", FirstName);
                        Command.Parameters.AddWithValue("@SecondName", SecondName);
                        if (ThirdName != null && ThirdName != "")
                            Command.Parameters.AddWithValue("@ThirdName", ThirdName);
                        else
                            Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                        Command.Parameters.AddWithValue("@LastName", LastName);
                        if (Phone != null && Phone != "")
                            Command.Parameters.AddWithValue("@Phone", Phone);
                        else
                            Command.Parameters.AddWithValue("Phone", DBNull.Value);
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        RowsAffected = Command.ExecuteNonQuery();
                    }
                }
                _BackupSqlDataBase();
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
                            dt.Load(Reader);
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
                    string Query = @"SELECT FOUND = 1 FROM People WHERE People.PersonID = @PersonID";
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
                    $" if person with ID = {PersonID} exists or not.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through checking" +
                    $" if person with ID = {PersonID} exists or not.", EventLogEntryType.Error);
            }
            return IsFound;
        }
        public static bool IsThereEmployeeSponsored(int PersonID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT IsFound = 1 FROM Employees WHERE Employees.SponsorPersonID = @PersonID";
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
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through ensuring" +
                    $"employee sponsor with Sponsort Person ID = {PersonID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through ensuring" +
                    $"employee sponsor with Sponsor Person ID = {PersonID}.", EventLogEntryType.Error);
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
                    string Query = @"DELETE People WHERE People.PersonID = @PersonID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        RowsAffected = Command.ExecuteNonQuery();
                    }
                }
                _BackupSqlDataBase();
            }
            catch (SqlException ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through deleting" +
                    $" person with ID = {PersonID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through deleting" +
                    $" person with ID = {PersonID}.", EventLogEntryType.Error);
            }
            return RowsAffected > 0;
        }
    }
}