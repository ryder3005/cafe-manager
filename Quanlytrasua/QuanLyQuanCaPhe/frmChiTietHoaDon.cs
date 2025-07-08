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
    public partial class frmChiTietHoaDon : Form
    {
        private DBChiTietHoaDon dbChiTietHoaDon;

        public frmChiTietHoaDon()
        {
            InitializeComponent();
            dbChiTietHoaDon = new DBChiTietHoaDon();
        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadInvoiceDetails();
        }

        private void LoadInvoiceDetails()
        {
            string error = "";
            var dataSet = dbChiTietHoaDon.GetAllChiTietHoaDon(ref error);
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                dgvInvoiceDetails.DataSource = dataSet.Tables[0];
                // Rename columns for better display
                if (dgvInvoiceDetails.Columns["id_chiTietHoaDon"] != null)
                    dgvInvoiceDetails.Columns["id_chiTietHoaDon"].HeaderText = "Detail ID";
                if (dgvInvoiceDetails.Columns["id_hoaDon"] != null)
                    dgvInvoiceDetails.Columns["id_hoaDon"].HeaderText = "Invoice ID";
                if (dgvInvoiceDetails.Columns["id_thucUong"] != null)
                    dgvInvoiceDetails.Columns["id_thucUong"].HeaderText = "Drink ID";
                if (dgvInvoiceDetails.Columns["SoLuong"] != null)
                    dgvInvoiceDetails.Columns["SoLuong"].HeaderText = "Quantity";
                if (dgvInvoiceDetails.Columns["DonGia"] != null)
                    dgvInvoiceDetails.Columns["DonGia"].HeaderText = "Unit Price";
            }
            else
            {
                MessageBox.Show("Error loading invoice details: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtInvoiceID.Text) ||
                string.IsNullOrWhiteSpace(txtDrinkID.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtUnitPrice.Text))
            {
                MessageBox.Show("Please fill in all required fields (Invoice ID, Drink ID, Quantity, Unit Price).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse input values
            if (!int.TryParse(txtInvoiceID.Text, out int invoiceID) ||
                !int.TryParse(txtDrinkID.Text, out int drinkID) ||
                !int.TryParse(txtQuantity.Text, out int quantity) ||
                !float.TryParse(txtUnitPrice.Text, out float unitPrice))
            {
                MessageBox.Show("Invoice ID, Drink ID, Quantity, and Unit Price must be valid numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add the invoice detail
            string error = "";
            bool success = dbChiTietHoaDon.InsertChiTietHoaDon(ref error, invoiceID, drinkID, quantity, unitPrice);
            if (success)
            {
                MessageBox.Show("Invoice detail added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInvoiceDetails(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error adding invoice detail: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtInvoiceDetailID.Text))
            {
                MessageBox.Show("Please select an invoice detail to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please fill in the Quantity field.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse invoice detail ID and quantity
            if (!int.TryParse(txtInvoiceDetailID.Text, out int invoiceDetailID) ||
                !int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Invoice Detail ID and Quantity must be valid numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update the invoice detail
            string error = "";
            bool success = dbChiTietHoaDon.UpdateChiTietHoaDon(ref error, invoiceDetailID, quantity);
            if (success)
            {
                MessageBox.Show("Invoice detail updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInvoiceDetails(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error updating invoice detail: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtInvoiceDetailID.Text))
            {
                MessageBox.Show("Please select an invoice detail to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtInvoiceDetailID.Text, out int invoiceDetailID))
            {
                MessageBox.Show("Invalid Invoice Detail ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this invoice detail?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Delete the invoice detail
            string error = "";
            bool success = dbChiTietHoaDon.DeleteChiTietHoaDon(ref error, invoiceDetailID);
            if (success)
            {
                MessageBox.Show("Invoice detail deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInvoiceDetails(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error deleting invoice detail: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvInvoiceDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInvoiceDetails.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvInvoiceDetails.SelectedRows[0];
                txtInvoiceDetailID.Text = row.Cells["id_chiTietHoaDon"].Value.ToString();
                txtInvoiceID.Text = row.Cells["id_hoaDon"].Value.ToString();
                txtDrinkID.Text = row.Cells["id_thucUong"].Value.ToString();
                txtQuantity.Text = row.Cells["SoLuong"].Value.ToString();
                txtUnitPrice.Text = row.Cells["DonGia"].Value.ToString();
            }
        }

        private void ClearInputs()
        {
            txtInvoiceDetailID.Text = "";
            txtInvoiceID.Text = "";
            txtDrinkID.Text = "";
            txtQuantity.Text = "";
            txtUnitPrice.Text = "";
        }
    }
}