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
    public partial class frmHoaDon : Form
    {
        private DBHoaDon dbHoaDon;

        public frmHoaDon()
        {
            InitializeComponent();
            dbHoaDon = new DBHoaDon();


        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {

            LoadInvoices();
        }

        private void LoadInvoices()
        {
            string error = "";
            var dataSet = dbHoaDon.GetAllHoaDon(ref error);
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                dgvInvoices.DataSource = dataSet.Tables[0];
                // Rename columns for better display
                if (dgvInvoices.Columns["id_hoaDon"] != null)
                    dgvInvoices.Columns["id_hoaDon"].HeaderText = "Invoice ID";
                if (dgvInvoices.Columns["id_ban"] != null)
                    dgvInvoices.Columns["id_ban"].HeaderText = "Table ID";
                if (dgvInvoices.Columns["TenDangNhap"] != null)
                    dgvInvoices.Columns["TenDangNhap"].HeaderText = "Username";
                if (dgvInvoices.Columns["TongTien"] != null)
                    dgvInvoices.Columns["TongTien"].HeaderText = "Total Amount";
                if (dgvInvoices.Columns["TrangThai"] != null)
                    dgvInvoices.Columns["TrangThai"].HeaderText = "Status";
            }
            else
            {
                MessageBox.Show("Error loading invoices: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDathang frmDathang = new frmDathang();
            frmDathang.ShowDialog();
            LoadInvoices();
            //// Validate input
            //if (string.IsNullOrWhiteSpace(txtTableID.Text) ||
            //    string.IsNullOrWhiteSpace(txtUsername.Text))
            //{
            //    MessageBox.Show("Please fill in all required fields (Table ID, Username).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //// Parse table ID
            //if (!int.TryParse(txtTableID.Text, out int tableID))
            //{
            //    MessageBox.Show("Table ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //// Add the invoice
            //string error = "";
            //bool success = dbHoaDon.InsertHoaDon(ref error, tableID, txtUsername.Text);
            //if (success)
            //{
            //    MessageBox.Show("Invoice added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    LoadInvoices(); // Refresh the grid
            //    ClearInputs();
            //}
            //else
            //{
            //    MessageBox.Show("Error adding invoice: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtInvoiceID.Text))
            {
                MessageBox.Show("Please select an invoice to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTotalAmount.Text) ||
                string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                MessageBox.Show("Please fill in all fields (Total Amount, Status).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse invoice ID, total amount, and status
            if (!int.TryParse(txtInvoiceID.Text, out int invoiceID) ||
                !float.TryParse(txtTotalAmount.Text, out float totalAmount) ||
                !int.TryParse(txtStatus.Text, out int status))
            {
                MessageBox.Show("Invoice ID, Total Amount, and Status must be valid numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update the invoice
            string error = "";
            bool success = dbHoaDon.UpdateHoaDon(ref error, invoiceID, totalAmount, status);
            if (success)
            {
                MessageBox.Show("Invoice updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInvoices(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error updating invoice: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtInvoiceID.Text))
            {
                MessageBox.Show("Please select an invoice to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtInvoiceID.Text, out int invoiceID))
            {
                MessageBox.Show("Invalid Invoice ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this invoice?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Delete the invoice
            string error = "";
            bool success = dbHoaDon.DeleteHoaDon(ref error, invoiceID);
            if (success)
            {
                MessageBox.Show("Invoice deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInvoices(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error deleting invoice: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvInvoices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvInvoices.SelectedRows[0];
                txtInvoiceID.Text = row.Cells["id_hoaDon"].Value.ToString();
                txtTableID.Text = row.Cells["id_ban"].Value.ToString();
                txtUsername.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtTotalAmount.Text = row.Cells["TongTien"].Value != null ? row.Cells["TongTien"].Value.ToString() : "";
                txtStatus.Text = row.Cells["TrangThai"].Value != null ? row.Cells["TrangThai"].Value.ToString() : "";
            }
        }

        private void ClearInputs()
        {
            txtInvoiceID.Text = "";
            txtTableID.Text = "";
            txtUsername.Text = "";
            txtTotalAmount.Text = "";
            txtStatus.Text = "";
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }
    }
}