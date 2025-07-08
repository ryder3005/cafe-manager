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
    public partial class frmBan : Form
    {
        private DBBan dbBan;

        public frmBan()
        {
            InitializeComponent();
            dbBan = new DBBan();
        }

        private void frmBan_Load(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void LoadTables()
        {
            string error = "";
            var dataSet = dbBan.GetAllBan(ref error);
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                dgvTables.DataSource = dataSet.Tables[0];
                // Rename columns for better display
                if (dgvTables.Columns["id_ban"] != null)
                    dgvTables.Columns["id_ban"].HeaderText = "Table ID";
                if (dgvTables.Columns["Ten"] != null)
                    dgvTables.Columns["Ten"].HeaderText = "Table Name";
                if (dgvTables.Columns["TrangThai"] != null)
                    dgvTables.Columns["TrangThai"].HeaderText = "Status";
            }
            else
            {
                MessageBox.Show("Error loading tables: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtTableName.Text) ||
                string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                MessageBox.Show("Please fill in all fields (Table Name, Status).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse status
            if (!int.TryParse(txtStatus.Text, out int status))
            {
                MessageBox.Show("Status must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add the table
            string error = "";
            bool success = dbBan.InsertBan(ref error, txtTableName.Text, status);
            if (success)
            {
                MessageBox.Show("Table added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTables(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error adding table: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtTableID.Text))
            {
                MessageBox.Show("Please select a table to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTableName.Text) ||
                string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse table ID and status
            if (!int.TryParse(txtTableID.Text, out int tableID) ||
                !int.TryParse(txtStatus.Text, out int status))
            {
                MessageBox.Show("Table ID and Status must be valid numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update the table
            string error = "";
            bool success = dbBan.UpdateBan(ref error, tableID, txtTableName.Text, status);
            if (success)
            {
                MessageBox.Show("Table updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTables(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error updating table: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtTableID.Text))
            {
                MessageBox.Show("Please select a table to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtTableID.Text, out int tableID))
            {
                MessageBox.Show("Invalid Table ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this table?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Delete the table
            string error = "";
            bool success = dbBan.DeleteBan(ref error, tableID);
            if (success)
            {
                MessageBox.Show("Table deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTables(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error deleting table: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTables_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTables.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTables.SelectedRows[0];
                txtTableID.Text = row.Cells["id_ban"].Value.ToString();
                txtTableName.Text = row.Cells["Ten"].Value.ToString();
                txtStatus.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }

        private void ClearInputs()
        {
            txtTableID.Text = "";
            txtTableName.Text = "";
            txtStatus.Text = "";
        }
    }
}