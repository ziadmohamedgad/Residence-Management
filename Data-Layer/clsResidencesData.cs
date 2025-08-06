using Shared_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;
namespace Data_Layer
{
    public class clsResidencesData
    {
        public static bool GetResidenceInfoByID(int ResidenceID, ref string ResidenceNumber, ref byte ResidencePeriod,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref string ImageName, ref bool IsActive, ref string Notes, ref int EmployeeID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT * FROM Residences WHERE Residences.ResidenceID = @ResidenceID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ResidenceID", ResidenceID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                ResidenceNumber = (string)Reader["ResidenceNumber"];
                                ResidencePeriod = (byte)Reader["ResidencePeriod"];
                                IssueDate = (DateTime)Reader["IssueDate"];
                                ExpirationDate = (DateTime)Reader["ExpirationDate"];
                                ImageName = Reader["ImageName"] == DBNull.Value ? "" : (string)Reader["ImageName"];
                                IsActive = (bool)Reader["IsActive"];
                                Notes = Reader["Notes"] == DBNull.Value ? "" : (string)Reader["Notes"];
                                EmployeeID = (int)Reader["EmployeeID"];
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"residence info with residence ID = {ResidenceID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"residence info with residence ID = {ResidenceID}.", EventLogEntryType.Error);
            }
            return IsFound;
        }
        public static bool GetResidenceByResidenceNumber(string ResidenceNumber, ref int ResidenceID, ref byte ResidencePeriod,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref string ImageName, ref bool IsActive, ref string Notes, ref int EmployeeID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT * FROM Residences WHERE Residences.ResidenceNumber = @ResidenceNumber";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ResidenceNumber", ResidenceNumber);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                ResidenceID = (int)Reader["ResidenceID"];
                                ResidencePeriod = (byte)Reader["ResidencePeriod"];
                                IssueDate = (DateTime)Reader["IssueDate"];
                                ExpirationDate = (DateTime)Reader["ExpirationDate"];
                                ImageName = Reader["ImageName"] == DBNull.Value ? "" : (string)Reader["ImageName"];
                                IsActive = (bool)Reader["IsActive"];
                                Notes = Reader["Notes"] == DBNull.Value ? "" : (string)Reader["Notes"];
                                EmployeeID = (int)Reader["EmployeeID"];
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"residence info with residence Number = {ResidenceNumber}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"residence info with residence Number = {ResidenceNumber}.", EventLogEntryType.Error);
            }
            return IsFound;
        }
        public static bool GetResidenceByEmployeeID(int EmployeeID, ref int ResidenceID, 
            ref string ResidenceNumber, ref byte ResidencePeriod,  ref DateTime IssueDate, ref DateTime ExpirationDate, 
            ref string ImageName, ref bool IsActive, ref string Notes)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT * FROM Residences WHERE Residences.EmployeeID = @EmployeeID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                ResidenceID = (int)Reader["ResidenceID"];
                                ResidenceNumber = (string)Reader["ResidenceNumber"];
                                ResidencePeriod = (byte)Reader["ResidencePeriod"];
                                IssueDate = (DateTime)Reader["IssueDate"];
                                ExpirationDate = (DateTime)Reader["ExpirationDate"];
                                ImageName = Reader["ImageName"] == DBNull.Value ? "" : (string)Reader["ImageName"];
                                IsActive = (bool)Reader["IsActive"];
                                Notes = Reader["Notes"] == DBNull.Value ? "" : (string)Reader["Notes"];
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"residence info with employee ID = {EmployeeID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                IsFound = false;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"residence info with employee ID = {EmployeeID}.", EventLogEntryType.Error);
            }
            return IsFound;
        }
        public static int AddNewResidence(string ResidenceNumber, byte ResidencePeriod, DateTime IssueDate, DateTime ExpirationDate,
            string ImageName, bool IsActive, string Notes, int EmployeeID)
        {
            int ResidenceID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"INSERT INTO Residences (ResidenceNumber, ResidencePeriod, IssueDate, ExpirationDate, ImageName,
                                     IsActive, Notes, EmployeeID)
                                     VALUES (@ResidenceNumber, @ResidencePeriod, @IssueDate, @ExpirationDate, @ImageName, @Notes, @EmployeeID);
                                     SELECT SCOPE_IDENTITY();";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ResidenceNumber", ResidenceNumber);
                        Command.Parameters.AddWithValue("@ResidencePeriod", ResidencePeriod);
                        Command.Parameters.AddWithValue("@IssueDate", IssueDate);
                        Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                        if (ImageName != null && ImageName != "")
                            Command.Parameters.AddWithValue("@ImageName", ImageName);
                        else
                            Command.Parameters.AddWithValue("@ImageName", DBNull.Value);
                        Command.Parameters.AddWithValue("@IsActive", IsActive);
                        if (Notes != null && Notes != "")
                            Command.Parameters.AddWithValue("@Notes", Notes);
                        else
                            Command.Parameters.AddWithValue("@Notes", DBNull.Value);

                        Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            ResidenceID = ID;
                    }    
                }
            }
            catch (SqlException ex)
            {
                ResidenceID = -1;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through adding " +
                    $"new residence with number {ResidenceNumber}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                ResidenceID = -1;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through adding " +
                    $"new residence with number {ResidenceNumber}.", EventLogEntryType.Error);
            }
            return ResidenceID;
        }
        public static bool UpdateResidence(int ResidenceID, string ResidenceNumber, byte ResidencePeriod, DateTime IssueDate,
            DateTime ExpirationDate, string ImageName, bool IsActive, string Notes, int EmployeeID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"UPDATE Residences 
                                     SET ResidenceNumber = @ResidenceNumber, 
                                         ResidencePeriod = @ResidencePeriod,
                                         IssueDate = @IssueDate,
                                         ExpirationDate = @ExpirationDate,
                                         ImageName = @ImageName,
                                         IsActive = @IsActive,
                                         Notes = @Notes 
                                         EmployeeID = @EmployeeID 
                                      WHERE Residences.ResidenceID = @ResidenceID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ResidenceNumber", ResidenceNumber);
                        Command.Parameters.AddWithValue("@ResidencePeriod", ResidencePeriod);
                        Command.Parameters.AddWithValue("@IssueDate", IssueDate);
                        Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                        if (ImageName != null && ImageName != "")
                            Command.Parameters.AddWithValue("@ImageName", ImageName);
                        else
                            Command.Parameters.AddWithValue("@ImageName", DBNull.Value);
                        Command.Parameters.AddWithValue("@IsActive", IsActive);
                        if (Notes != null && Notes != "")
                            Command.Parameters.AddWithValue("@Notes", Notes);
                        else
                            Command.Parameters.AddWithValue("@Notes", DBNull.Value);
                        Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        RowsAffected = Command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through updating " +
                    $"residence info with ID = {ResidenceID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through updating " +
                    $"residence info with ID = {ResidenceID}.", EventLogEntryType.Error);
            }
            return RowsAffected > 0;
        }
        public static int GetActiveResidenceIDByPersonID(int PersonID)
        {
            int ResidenceID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT Residences.ResidenceID FROM Residences INNER JOIN Employees ON 
                                              Residences.EmployeeID = Employees.EmployeeID 
                                              WHERE Employees.PersonID = @PersonID 
                                              AND Residences.IsActive = 1";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            ResidenceID = ID;
                    }
                }
            }
            catch (SqlException ex)
            {
                ResidenceID = -1;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"active residence for person ID {PersonID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                ResidenceID = -1;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"active residence for person ID {PersonID}.", EventLogEntryType.Error);
            }
            return ResidenceID;
        }
        public static int GetActiveResidenceIDByEmployeeID(int EmployeeID)
        {
            int ResidenceID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT Residences.ResidenceID FROM Residences INNER JOIN Employees ON 
                                              Residences.EmployeeID = Employees.EmployeeID
                                              WHERE Employees.EmployeeID = @EmployeeID AND Residences.IsActive = 1";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            ResidenceID = ID;
                    }
                }
            }
            catch (SqlException ex)
            {
                ResidenceID = -1;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"active residence for employee ID {EmployeeID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                ResidenceID = -1;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through fetching " +
                    $"active residence for employee ID {EmployeeID}.", EventLogEntryType.Error);
            }
            return ResidenceID;
        }
        public static bool DeactivateResidence(int ResidenceID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"UPDATE Residences SET IsActive = 0 WHERE Residences.ResidenceID = @ResidenceID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ResidenceID", ResidenceID);
                        RowsAffected = Command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through deactivating " +
                    $"residence with ID = {ResidenceID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through deactivating " +
                    $"residence with ID = {ResidenceID}.", EventLogEntryType.Error);
            }
            return RowsAffected > 0;
        }
        public static bool DeleteResidence(int ResidenceID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"DELETE Residences WHERE Residences.ResidenceID = @ResidenceID";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ResidenceID", ResidenceID);
                        RowsAffected = Command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through deleting" +
                    $"residence with ID = {ResidenceID}.", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                RowsAffected = 0;
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through deleting" +
                    $"residence with ID = {ResidenceID}.", EventLogEntryType.Error);
            }
            return RowsAffected > 0;
        }
        public static DataTable GetAllResidences()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT * FROM Residences_View ORDER BY ExpirationDate ASC";
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