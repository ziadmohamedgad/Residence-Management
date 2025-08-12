using Business_Layer;
using Presentation_Layer.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Presentation_Layer.People
{
    public partial class frmListPeople : Form
    {
        public frmListPeople()
        {
            InitializeComponent();
        }
        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();
        private static DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "FirstName",
            "SecondName", "ThirdName", "LastName", "Phone");
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _RefreshPeopleList();
        }
        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "FirstName", "SecondName", "ThirdName",
                "LastName", "Phone");
            dgvPeople.DataSource = _dtPeople;
            lblRecordsCount.Text = _dtPeople.Rows.Count.ToString();
        }
        private void frmListPeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            cbFilterBy.SelectedIndex = 0;
            if (dgvPeople.Rows.Count >= 0)
            {
                dgvPeople.Columns[0].HeaderText = "الرقم التعريفي";
                dgvPeople.Columns[0].Width = 130;
                dgvPeople.Columns[1].HeaderText = "الاسم الأول";
                dgvPeople.Columns[1].Width = 120;
                dgvPeople.Columns[2].HeaderText = "الاسم الثاني";
                dgvPeople.Columns[2].Width = 120;
                dgvPeople.Columns[3].HeaderText = "الاسم الثالث";
                dgvPeople.Columns[3].Width = 120;
                dgvPeople.Columns[4].HeaderText = "الاسم الأخير";
                dgvPeople.Columns[4].Width = 120;
                dgvPeople.Columns[5].HeaderText = "رقم الجوال";
                dgvPeople.Columns[5].Width = 200;
            }
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.SelectedIndex != 0);
            if (txtFilterValue.Visible)
                txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 6)
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);   
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            // nothing, id, firname, secname, thirname, lastname, phone
            string FilterColumn = "";
            switch(cbFilterBy.SelectedIndex)
            {
                case 1:
                    FilterColumn = "PersonID";
                    break;
                case 2:
                    FilterColumn = "FirstName";
                    break;
                case 3:
                    FilterColumn = "SecondName";
                    break;
                case 4:
                    FilterColumn = "ThirdName";
                    break;
                case 5:
                    FilterColumn = "LastName";
                    break;
                case 6:
                    FilterColumn = "Phone";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "PersonID")
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            }
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }
        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            if (clsPerson.IsThereEmployeeSponsored(PersonID))
            {
                MessageBox.Show("لا يمكنك مسح شخص وهو يكفل موظف حالي، حاول مسح الموظف أولًا", "لا يمكن المسح", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("هل أنت متأكد أنك تريد مسح الشخص [" + PersonID + "]؟",
                "تأكيد المسح", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsEmployee Employee = clsEmployee.FindByPersonID(PersonID);
                if (Employee != null)
                {
                    clsResidence Residence = clsResidence.FindByEmployeeID(Employee.EmployeeID);
                    if (Residence != null)
                    {
                        if (MessageBox.Show("الشخص المراد مسحه مربوط بموظف رقمه [" + Employee.EmployeeID + "] وإقامة رقمها [" + Residence.ResidenceID + "] فهل أنت متأكد من مسحهم أيضا؟",
                            "تأكيد المسح الكامل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (Residence.DeleteResidence() && Employee.DeleteEmployee() && clsPerson.Delete(PersonID))
                            {
                                MessageBox.Show("تم الحذف الكامل للإقامة والموظف والشخص", "تمت عملية المسح", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                _RefreshPeopleList();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("حدث خطأ أثناء عملية المسح!",
                                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                            return;
                    }
                    else //no residence
                    {
                        if (MessageBox.Show("الشخص المراد مسحه مربوط بموظف رقمه [" + Employee.EmployeeID + "] فهل أنت متأكد من مسحه أيضا؟",
                            "تأكيد المسح الكامل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (Employee.DeleteEmployee() && clsPerson.Delete(PersonID))
                            {
                                MessageBox.Show("تم الحذف الكامل للموظف والشخص", "تمت عملية المسح", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                _RefreshPeopleList();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("حدث خطأ أثناء عملية المسح!",
                                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                            return;
                    }
                }
                else if (clsPerson.Delete(PersonID))
                {
                    MessageBox.Show("تم حذف الشخص بنجاح", "تمت عملية المسح", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("حدث خطأ أثناء عملية المسح!",
                        "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cmsPeople_Opening(object sender, CancelEventArgs e)
        {
            employToolStripMenuItem.Enabled = clsEmployee.FindByPersonID((int)dgvPeople.CurrentRow.Cells[0].Value) == null;
        }
        private void employToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee frm = new frmAddUpdateEmployee();
            frm.PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            frm.Mode = frmAddUpdateEmployee.enMode.EmployeePerson;
            frm.ShowDialog();
            _RefreshPeopleList();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvPeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvPeople.ClearSelection();
                dgvPeople.Rows[e.RowIndex].Selected = true;
                dgvPeople.CurrentCell = dgvPeople.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
    }
}