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
    public partial class frmTaiKhoan : Form
    {
        private DBTaiKhoan dbTaiKhoan;

        public frmTaiKhoan()
        {
            InitializeComponent();
            dbTaiKhoan = new DBTaiKhoan();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            string error = "";
            var dataSet = dbTaiKhoan.GetAllTaiKhoan(ref error);
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                dgvAccounts.DataSource = dataSet.Tables[0];
                // Rename columns for better display
                if (dgvAccounts.Columns["TenDangNhap"] != null)
                    dgvAccounts.Columns["TenDangNhap"].HeaderText = "Username";
                if (dgvAccounts.Columns["MatKhau"] != null)
                    dgvAccounts.Columns["MatKhau"].HeaderText = "Password";
                if (dgvAccounts.Columns["Loai"] != null)
                    dgvAccounts.Columns["Loai"].HeaderText = "Account Type";
                if (dgvAccounts.Columns["TrangThai"] != null)
                    dgvAccounts.Columns["TrangThai"].HeaderText = "Status";
            }
            else
            {
                MessageBox.Show("Error loading accounts: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtAccountType.Text))
            {
                MessageBox.Show("Please fill in all required fields (Username, Password, Account Type).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add the account
            string error = "";
            bool success = dbTaiKhoan.InsertTaiKhoan(ref error, txtUsername.Text, txtPassword.Text, txtAccountType.Text);
            if (success)
            {
                MessageBox.Show("Account added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error adding account: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtAccountType.Text) ||
                string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse status
            if (!int.TryParse(txtStatus.Text, out int status))
            {
                MessageBox.Show("Status must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update the account
            string error = "";
            bool success = dbTaiKhoan.UpdateTaiKhoan(ref error, txtUsername.Text, txtPassword.Text, txtAccountType.Text, status);
            if (success)
            {
                MessageBox.Show("Account updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error updating account: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please select an account to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this account?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Delete the account
            string error = "";
            bool success = dbTaiKhoan.DeleteTaiKhoan(ref error, txtUsername.Text);
            if (success)
            {
                MessageBox.Show("Account deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error deleting account: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAccounts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvAccounts.SelectedRows[0];
                txtUsername.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtPassword.Text = row.Cells["MatKhau"].Value.ToString();
                txtAccountType.Text = row.Cells["Loai"].Value.ToString();
                txtStatus.Text = row.Cells["TrangThai"].Value != null ? row.Cells["TrangThai"].Value.ToString() : "";
            }
        }

        private void ClearInputs()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtAccountType.Text = "";
            txtStatus.Text = "";
        }
    }
}