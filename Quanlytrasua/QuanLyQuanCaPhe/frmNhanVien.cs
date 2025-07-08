using BusinessAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe
{
    public partial class frmNhanVien : Form
    {
        private DBNhanVien dbNhanVien;

        public frmNhanVien()
        {
            InitializeComponent();
            dbNhanVien = new DBNhanVien();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            string error = "";
            var dataSet = dbNhanVien.GetAllNhanVien(ref error);
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                dgvEmployees.DataSource = dataSet.Tables[0];
                // Rename columns for better display
                if (dgvEmployees.Columns["id_nhanVien"] != null)
                    dgvEmployees.Columns["id_nhanVien"].HeaderText = "Employee ID";
                if (dgvEmployees.Columns["TenDangNhap"] != null)
                    dgvEmployees.Columns["TenDangNhap"].HeaderText = "Username";
                if (dgvEmployees.Columns["HoTen"] != null)
                    dgvEmployees.Columns["HoTen"].HeaderText = "Full Name";
                if (dgvEmployees.Columns["GioiTinh"] != null)
                    dgvEmployees.Columns["GioiTinh"].HeaderText = "Gender";
                if (dgvEmployees.Columns["DienThoai"] != null)
                    dgvEmployees.Columns["DienThoai"].HeaderText = "Phone";
                if (dgvEmployees.Columns["ChucVu"] != null)
                    dgvEmployees.Columns["ChucVu"].HeaderText = "Position";
                if (dgvEmployees.Columns["TrangThai"] != null)
                    dgvEmployees.Columns["TrangThai"].HeaderText = "Status";
            }
            else
            {
                MessageBox.Show("Error loading employees: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtGender.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Please fill in all required fields (Username, Full Name, Gender, Phone, Position).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add the employee
            string error = "";
            bool success = dbNhanVien.InsertNhanVien(ref error, txtUsername.Text, txtFullName.Text, txtGender.Text, txtPhone.Text, txtPosition.Text);
            if (success)
            {
                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error adding employee: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text))
            {
                MessageBox.Show("Please select an employee to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtGender.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtPosition.Text) ||
                string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse employee ID and status
            if (!int.TryParse(txtEmployeeID.Text, out int employeeID) ||
                !int.TryParse(txtStatus.Text, out int status))
            {
                MessageBox.Show("Employee ID and Status must be valid numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update the employee
            string error = "";
            bool success = dbNhanVien.UpdateNhanVien(ref error, employeeID, txtFullName.Text, txtGender.Text, txtPhone.Text, txtPosition.Text, status);
            if (success)
            {
                MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error updating employee: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text))
            {
                MessageBox.Show("Please select an employee to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtEmployeeID.Text, out int employeeID))
            {
                MessageBox.Show("Invalid Employee ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Delete the employee
            string error = "";
            bool success = dbNhanVien.DeleteNhanVien(ref error, employeeID);
            if (success)
            {
                MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error deleting employee: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvEmployees.SelectedRows[0];
                txtEmployeeID.Text = row.Cells["id_nhanVien"].Value.ToString();
                txtUsername.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtFullName.Text = row.Cells["HoTen"].Value.ToString();
                txtGender.Text = row.Cells["GioiTinh"].Value.ToString();
                txtPhone.Text = row.Cells["DienThoai"].Value.ToString();
                txtPosition.Text = row.Cells["ChucVu"].Value.ToString();
                txtStatus.Text = row.Cells["TrangThai"].Value != null ? row.Cells["TrangThai"].Value.ToString() : "";
            }
        }

        private void ClearInputs()
        {
            txtEmployeeID.Text = "";
            txtUsername.Text = "";
            txtFullName.Text = "";
            txtGender.Text = "";
            txtPhone.Text = "";
            txtPosition.Text = "";
            txtStatus.Text = "";
        }
    }
}