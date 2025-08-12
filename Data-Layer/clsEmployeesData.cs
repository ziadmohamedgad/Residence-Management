using Shared_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data_Layer
{
    public class clsEmployeesData
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
        public static bool GetEmployeeInfoByEmployeeID(int EmployeeID, ref int PersonID, ref string Job, ref int SponsorPersonID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT * FROM Employees WHERE Employees.EmployeeID = @EmployeeID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                PersonID = (int)Reader["PersonID"];
                                Job = (string)Reader["Job"];
                                SponsorPersonID = (int)Reader["SponsorPersonID"];
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"employee info with employee ID = {EmployeeID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"employee info with employee ID = {EmployeeID}.", EventLogEntryType.Error);
            }
            return IsFound;
        }
        public static bool GetEmployeeInfoByPersonID(int PersonID, ref int EmployeeID, ref string Job, ref int SponsorPersonID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT * FROM Employees WHERE Employees.PersonID = @PersonID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                EmployeeID = (int)Reader["EmployeeID"];
                                Job = (string)Reader["Job"];
                                SponsorPersonID = (int)Reader["SponsorPersonID"];
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"employee info with person ID = {PersonID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"employee info with person ID = {PersonID}.", EventLogEntryType.Error);
            }
            return IsFound;
        }
        public static int AddNewEmployee(int PersonID, string Job, int SponsorPersonID)
        {
            int EmployeeID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"INSERT INTO Employees (PersonID, Job, SponsorPersonID) 
                                     VALUES (@PersonID, @Job, @SponsorPersonID);
                                     SELECT SCOPE_IDENTITY();";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        Command.Parameters.AddWithValue("@Job", Job);
                        Command.Parameters.AddWithValue("@SponsorPersonID", SponsorPersonID);
                        object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            EmployeeID = ID;
                    }
                }
                _BackupSqlDataBase();
            }
            catch (SqlException ex)
            {
                EmployeeID = -1;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through adding" +
                    $" new Employee for person ID = {PersonID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                EmployeeID = -1;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through adding" +
                    $" new Employee for person ID = {PersonID}.", EventLogEntryType.Error);
            }
            return EmployeeID;
        }
        public static bool UpdateEmployee(int EmployeeID, int PersonID, string Job, int SponsorPersonID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"UPDATE Employees 
                                     SET PersonID = @PersonID, 
                                         Job = @Job,
                                         SponsorPersonID = @SponsorPersonID 
                                         WHERE EmployeeID = @EmployeeID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        Command.Parameters.AddWithValue("@Job", Job);
                        Command.Parameters.AddWithValue("@SponsorPersonID", SponsorPersonID);
                        Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        RowsAffected = Command.ExecuteNonQuery();
                    }
                }
                _BackupSqlDataBase();
            }
            catch (SqlException ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through updating" +
                    $" employee with employee ID = {EmployeeID} for person ID = {PersonID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through updating" +
                    $" employee with employee ID = {EmployeeID} for person ID = {PersonID}.", EventLogEntryType.Error);
            }
            return RowsAffected > 0;
        }
        public static bool DeleteEmployee(int EmployeeID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"DELETE Employees WHERE Employees.EmployeeID = @EmployeeID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        RowsAffected = Command.ExecuteNonQuery();
                    }
                }
                _BackupSqlDataBase();
            }
            catch (SqlException ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through deleting" +
                    $"employee with ID = {EmployeeID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through deleting" +
                    $"employee with ID = {EmployeeID}.", EventLogEntryType.Error);
            }
            return RowsAffected > 0;
        }
        public static DataTable GetAllEmployees()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT * FROM Employees_View"; //edit the query
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
                    $"all employees.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                dt = null;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"all employees.", EventLogEntryType.Error);
            }
            return dt;
        }
    }
}