using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace Business_Layer
{
    public class clsEmployee
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        public int EmployeeID { get; set; }
        public int PersonID { get; set; }
        public string Job {  get; set; }
        public int SponsorPersonID { get; set; }
        public clsPerson PersonInfo;
        public clsPerson SponsorPersonInfo;
        public clsEmployee()
        {
            this.EmployeeID = 0;
            this.PersonID = 0;
            this.Job = "";
            this.PersonInfo = null;
            this.SponsorPersonInfo = null;
            this.Mode = enMode.AddNew;
        }
        public clsEmployee(int EmployeeID, int PersonID, string Job, int SponsorPersonID)
        {
            this.EmployeeID = EmployeeID;
            this.PersonID = PersonID;
            this.Job = Job;
            this.PersonInfo = clsPerson.Find(this.PersonID);
            this.SponsorPersonInfo = clsPerson.Find(this.SponsorPersonID);
            this.Mode = enMode.Update;
        }
        private bool _AddNewEmployee()
        {
            this.EmployeeID = clsEmployeesData.AddNewEmployee(this.PersonID, this.Job, this.SponsorPersonID);
            return this.EmployeeID != -1;
        }
        private bool _UpdateEmployee()
        {
            return clsEmployeesData.UpdateEmployee(this.EmployeeID, this.PersonID, this.Job, this.SponsorPersonID);
        }
        public static clsEmployee FindByEmployeeID(int EmployeeID)
        {
            int PersonID = -1, SponsorPersonID = -1;
            string Job = "";
            bool IsFound = clsEmployeesData.GetEmployeeInfoByEmployeeID(EmployeeID, ref PersonID, ref Job, ref SponsorPersonID);
            if (IsFound)
                return new clsEmployee(EmployeeID, PersonID, Job, SponsorPersonID);
            else
                return null;
        }
        public static clsEmployee FindByPersonID(int PersonID)
        {
            int EmployeeID = -1, SponsorPersonID = -1;
            string Job = "";
            bool IsFound = clsEmployeesData.GetEmployeeInfoByPersonID(PersonID, ref EmployeeID, ref Job, ref SponsorPersonID);
            if (IsFound)
                return new clsEmployee(EmployeeID, PersonID, Job, SponsorPersonID);
            else
                return null;
        }
        public bool Save()
        {
            switch(this.Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewEmployee())
                        {
                            this.Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return _UpdateEmployee();
            }
            return false;
        }
        public bool DeleteEmployee()
        {
            return DeleteEmployee(this.EmployeeID);
        }
        public static bool DeleteEmployee(int EmployeeID)
        {
            return clsEmployeesData.DeleteEmployee(EmployeeID);
        }
        public static DataTable GetAllEmployees()
        {
            return clsEmployeesData.GetAllEmployees();
        }
        public static bool IsThereEmployeeSponsored(int SponsorPersonID)
        {
            return clsEmployeesData.IsThereEmployeeSponsored(SponsorPersonID);
        }
    }
}