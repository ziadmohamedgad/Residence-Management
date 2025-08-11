using Business_Layer;
using Presentation_Layer.People;
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

namespace Presentation_Layer.Residences
{
    public partial class frmListResidences : Form
    {
        private static DataTable _dtAllResidences = clsResidence.GetAllResidences();
        private static DataTable _dtResidences = _dtAllResidences.DefaultView.ToTable(false, "ResidenceID", "EmployeeFullName",
            "Job", "ResidenceNumber", "ExpirationDate", "IsActive");
        public frmListResidences()
        {
            InitializeComponent();
        }
        private void _RefreshResidencesList()
        {
            _dtAllResidences = clsResidence.GetAllResidences();
            _dtResidences = _dtAllResidences.DefaultView.ToTable(false, "ResidenceID", "EmployeeFullName",
            "Job", "ResidenceNumber", "ExpirationDate", "IsActive");
            dgvResidences.DataSource = _dtAllResidences;
            lblRecordsCount.Text = dgvResidences.Rows.Count.ToString();
        }
        private void frmListResidences_Load(object sender, EventArgs e)
        {
            dgvResidences.DataSource = _dtResidences;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = _dtResidences.Rows.Count.ToString();
            if (dgvResidences.Rows.Count >= 0)
            {
                dgvResidences.Columns[0].HeaderText = "الرقم التعريفي";
                dgvResidences.Columns[0].Width = 130;
                dgvResidences.Columns[1].HeaderText = "اسم الموظف";
                dgvResidences.Columns[1].Width = 210;
                dgvResidences.Columns[2].HeaderText = "الوظيفة";
                dgvResidences.Columns[2].Width = 180;
                dgvResidences.Columns[3].HeaderText = "رقم الإقامة";
                dgvResidences.Columns[3].Width = 130;
                dgvResidences.Columns[4].HeaderText = "تاريخ الانتهاء";
                dgvResidences.Columns[4].Width = 110;
                dgvResidences.Columns[5].HeaderText = "حالة الإقامة";
                dgvResidences.Columns[5].Width = 92;
            }
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            //            لاشيء
            //الرقم التعريفي
            //اسم الموظف
            //رقم الإقامة
            //الوظيفة
            //المدة
            //"ResidenceID", "EmployeeFullName", "Job", "ResidenceNumber", "ExpirationDate", "IsActive"
            string FilterColumn = "";
            switch(cbFilterBy.SelectedIndex)
            {
                case 1:
                    FilterColumn = "ResidenceID";
                    break;
                case 2:
                    FilterColumn = "EmployeeFullName";
                    break;
                case 3:
                    FilterColumn = "ResidenceNumber";
                    break;
                case 4:
                    FilterColumn = "Job";
                    break;
                case 5:
                    FilterColumn = ""
            }
        }
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            frmAddUpdateResidence frm = new frmAddUpdateResidence();
            frm.ShowDialog();
            _RefreshResidencesList();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateResidence frm = new frmAddUpdateResidence((int)dgvResidences.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshResidencesList();
        }
        private void dgvResidences_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvResidences.ClearSelection();
                dgvResidences.Rows[e.RowIndex].Selected = true;
                dgvResidences.CurrentCell = dgvResidences.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        private void dgvResidences_DoubleClick(object sender, EventArgs e)
        {
            frmShowResidenceInfo frm = new frmShowResidenceInfo((int)dgvResidences.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshResidencesList();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string EmployeeName = dgvResidences.CurrentRow.Cells[1].Value.ToString();
            if (MessageBox.Show("هل أنت متأكد أنك تريد مسح الإقامة الخاصة بالموظف: " +  EmployeeName + "؟", "تأكيد المسح",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsResidence.DeleteResidence((int)dgvResidences.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("تم حذف الإقامة بنجاح", "تمت عملية المسح", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    _RefreshResidencesList();
                }
                else
                {
                    MessageBox.Show("حدث خطأ أثناء عملية المسح!",
                        "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowResidenceInfo frm = new frmShowResidenceInfo((int)dgvResidences.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshResidencesList();
        }
        private void cbPeriods_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 5)
            {
                txtFilterValue.Visible = false;
                cbPeriods.Visible = true;
                cbPeriods.Focus();
                cbPeriods.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbPeriods.Visible = false;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }
    }
}