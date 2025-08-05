using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace Business_Layer
{
    public class clsResidence
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        public int ResidenceID {  get; set; }
        public string ResidenceNumber { get; set; }
        public enum enResidencePeriod : byte 
        { Three = 3, Six = 6, Nine = 9, Twelve = 12, Fifteen = 15, Eighteen = 18, TwentyOne = 21, TwentyFour = 24 }
        public enResidencePeriod ResidencePeriod { get; set; }
        DateTime IssueDate { get; set; }
        DateTime ExpirationDate {  get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public int EmployeeID { get; set; }
        public clsEmployee EmployeeInfo;
        public clsResidence()
        {
            this.ResidenceID = -1;
            this.ResidenceNumber = "";
            this.ResidencePeriod = enResidencePeriod.Three;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.ImageName = "";
            this.IsActive = false;
            this.Notes = "";
            this.EmployeeID = -1;
            this.EmployeeInfo = null;
            this.Mode = enMode.AddNew;
        }
        public clsResidence(int ResidenceID, string ResidenceNumber, enResidencePeriod ResidencePeriod, DateTime IssueDate,
                                DateTime ExpirationDate, string ImageName, bool IsActive, string Notes, int EmployeeID)
        {
            this.ResidenceID = ResidenceID;
            this.ResidenceNumber = ResidenceNumber;
            this.ResidencePeriod = ResidencePeriod;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.ImageName = ImageName;
            this.IsActive = IsActive;
            this.Notes = Notes;
            this.EmployeeID = EmployeeID;
            this.EmployeeInfo = clsEmployee.FindByEmployeeID(this.EmployeeID);
            this.Mode = enMode.Update;
        }
        private bool _AddNewResidence()
        {
            this.ResidenceID = clsResidencesData.AddNewResidence(this.ResidenceNumber, (byte)this.ResidencePeriod, this.IssueDate,
                this.ExpirationDate, this.ImageName, this.IsActive, this.Notes, this.EmployeeID);
            return this.ResidenceID != -1;
        }
        private bool _UpdateResidence()
        {
            return clsResidencesData.UpdateResidence(this.ResidenceID, this.ResidenceNumber, (byte)this.ResidencePeriod, this.IssueDate,
                this.ExpirationDate, this.ImageName, this.IsActive, this.Notes, this.EmployeeID);
        }
        public static clsResidence Find(int ResidenceID)
        {
            string ResidenceNumber = "", ImageName = "", Notes = "";
            byte ResidencePeriod = 3;
            DateTime IssueDate = DateTime.MinValue, ExpirationDate = DateTime.MinValue;
            bool IsActive = false;
            int EmployeeID = -1;
            bool IsFound = clsResidencesData.GetResidenceInfoByID(ResidenceID, ref ResidenceNumber, ref ResidencePeriod,
                ref IssueDate, ref ExpirationDate, ref ImageName, ref IsActive, ref Notes, ref EmployeeID);
            if (IsFound)
                return new clsResidence(ResidenceID, ResidenceNumber, (enResidencePeriod)ResidencePeriod, IssueDate, ExpirationDate,
                    ImageName, IsActive, Notes, EmployeeID);
            else
                return null;
        }
        public static int GetActiveResidenceIDByPersonID(int PersonID)
        {
            return clsResidencesData.GetActiveResidenceIDByPersonID(PersonID);
        }
        public static int GetActiveResidenceIDByEmployeeID(int EmployeeID)
        {
            return clsResidencesData.GetActiveResidenceIDByEmployeeID(EmployeeID);
        }
        public bool DeactivateResidence()
        {
            return DeactivateResidence(this.ResidenceID);
        }
        public static bool DeactivateResidence(int ResidenceID)
        {
            return clsResidencesData.DeactivateResidence(ResidenceID);
        }
        public bool DeleteResidence()
        {
            return DeleteResidence(this.ResidenceID);
        }
        public static bool DeleteResidence(int ResidenceID)
        {
            return clsResidencesData.DeleteResidence(ResidenceID);
        }
        public static DataTable GetAllResidences()
        {
            return clsResidencesData.GetAllResidences();
        }
    }
}
