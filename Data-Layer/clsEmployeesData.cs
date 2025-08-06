using Shared_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data_Layer
{
    public class clsEmployeesData
    {
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
        public static bool IsThereEmployeeSponsored(int SponsorPersonID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT IsFound = 1 FROM Employees WHERE Employees.SponsorPersonID = @SponsorPersonID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@SponsorPersonID", SponsorPersonID);
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
                    $"employee sponsor with Sponsor ID = {SponsorPersonID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through ensuring" +
                    $"employee sponsor with Sponsor ID = {SponsorPersonID}.", EventLogEntryType.Error);
            }
            return IsFound;
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