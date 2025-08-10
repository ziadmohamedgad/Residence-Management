using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;
using Presentation_Layer.People;
namespace Presentation_Layer.Employees
{
    public partial class frmListEmployees : Form
    {
        private static DataTable _dtAllEmployees = clsEmployee.GetAllEmployees();
        private static DataTable _dtEmployees = _dtAllEmployees.DefaultView.ToTable(false, "EmployeeID", "EmployeeFullName",
            "Job", "SponsorFullName");
        public frmListEmployees()
        {
            InitializeComponent();
        }
        private void _RefreshEmployeeList()
        {
            _dtAllEmployees = clsEmployee.GetAllEmployees();
            _dtEmployees = _dtAllEmployees.DefaultView.ToTable(false, "EmployeeID", "EmployeeFullName",
            "Job", "SponsorFullName");
            dgvEmployees.DataSource = _dtEmployees;
            lblRecordsCount.Text = dgvEmployees.Rows.Count.ToString();
        }
        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            dgvEmployees.DataSource = _dtEmployees;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = _dtEmployees.Rows.Count.ToString();
            if (dgvEmployees.Rows.Count >= 0)
            {
                dgvEmployees.Columns[0].HeaderText = "الرقم التعريفي";
                dgvEmployees.Columns[0].Width = 130;
                dgvEmployees.Columns[1].HeaderText = "الاسم";
                dgvEmployees.Columns[1].Width = 250;
                dgvEmployees.Columns[2].HeaderText = "الوظيفة";
                dgvEmployees.Columns[2].Width = 180;
                dgvEmployees.Columns[3].HeaderText = "اسم الكفيل";
                dgvEmployees.Columns[3].Width = 250;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            // noting, id, name, sponsor name, job
            string FilterColumn = "";
            switch(cbFilterBy.SelectedIndex)
            {
                case 1:
                    FilterColumn = "EmployeeID";
                    break;
                case 2:
                    FilterColumn = "EmployeeFullName";
                    break;
                case 3:
                    FilterColumn = "SponsorFullName";
                    break;
                case 4:
                    FilterColumn = "Job";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtEmployees.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvEmployees.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "EmployeeID")
                _dtEmployees.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtEmployees.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            lblRecordsCount.Text = dgvEmployees.Rows.Count.ToString();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1)
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.SelectedIndex != 0);
            if (txtFilterValue.Visible)
                txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee frm = new frmAddUpdateEmployee();
            frm.ShowDialog();
            _RefreshEmployeeList();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee frm = new frmAddUpdateEmployee((int)dgvEmployees.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshEmployeeList();
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowEmployeeInfo frm = new frmShowEmployeeInfo((int)dgvEmployees.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshEmployeeList();
        }
        private void dgvEmployees_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvEmployees.ClearSelection();
                dgvEmployees.Rows[e.RowIndex].Selected = true;
                dgvEmployees.CurrentCell = dgvEmployees.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void cmsEmployees_Opening(object sender, CancelEventArgs e)
        {

        }
        private void showResidenceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void createResidenceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}