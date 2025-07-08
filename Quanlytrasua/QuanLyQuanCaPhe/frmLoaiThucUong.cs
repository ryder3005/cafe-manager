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
    public partial class frmLoaiThucUong : Form
    {
        private DBLoaiThucUong dbLoaiThucUong;

        public frmLoaiThucUong()
        {
            InitializeComponent();
            dbLoaiThucUong = new DBLoaiThucUong();
        }

        private void frmLoaiThucUong_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            string error = "";
            var dataSet = dbLoaiThucUong.GetAllLoaiThucUong(ref error);
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                dgvCategories.DataSource = dataSet.Tables[0];
                // Rename columns for better display
                if (dgvCategories.Columns["id_loaiThucUong"] != null)
                    dgvCategories.Columns["id_loaiThucUong"].HeaderText = "Category ID";
                if (dgvCategories.Columns["Ten"] != null)
                    dgvCategories.Columns["Ten"].HeaderText = "Category Name";
                if (dgvCategories.Columns["TrangThai"] != null)
                    dgvCategories.Columns["TrangThai"].HeaderText = "Status";
            }
            else
            {
                MessageBox.Show("Error loading categories: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text) ||
                string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                MessageBox.Show("Please fill in all fields (Category Name, Status).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse status
            if (!int.TryParse(txtStatus.Text, out int status))
            {
                MessageBox.Show("Status must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add the category
            string error = "";
            bool success = dbLoaiThucUong.InsertLoaiThucUong(ref error, txtCategoryName.Text, status);
            if (success)
            {
                MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error adding category: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
            {
                MessageBox.Show("Please select a category to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text) ||
                string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse category ID and status
            if (!int.TryParse(txtCategoryID.Text, out int categoryID) ||
                !int.TryParse(txtStatus.Text, out int status))
            {
                MessageBox.Show("Category ID and Status must be valid numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update the category
            string error = "";
            bool success = dbLoaiThucUong.UpdateLoaiThucUong(ref error, categoryID, txtCategoryName.Text, status);
            if (success)
            {
                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error updating category: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
            {
                MessageBox.Show("Please select a category to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCategoryID.Text, out int categoryID))
            {
                MessageBox.Show("Invalid Category ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Delete the category
            string error = "";
            bool success = dbLoaiThucUong.DeleteLoaiThucUong(ref error, categoryID);
            if (success)
            {
                MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error deleting category: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCategories.SelectedRows[0];
                txtCategoryID.Text = row.Cells["id_loaiThucUong"].Value.ToString();
                txtCategoryName.Text = row.Cells["Ten"].Value.ToString();
                txtStatus.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }

        private void ClearInputs()
        {
            txtCategoryID.Text = "";
            txtCategoryName.Text = "";
            txtStatus.Text = "";
        }
    }
}