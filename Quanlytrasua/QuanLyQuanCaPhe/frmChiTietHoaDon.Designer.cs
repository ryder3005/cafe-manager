namespace QuanLyQuanCaPhe
{
    partial class frmChiTietHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvInvoiceDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInvoiceDetails;
        private System.Windows.Forms.TextBox txtInvoiceID;
        private System.Windows.Forms.TextBox txtDrinkID;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtInvoiceDetailID;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInvoiceDetails = new System.Windows.Forms.Label();
            this.txtInvoiceID = new System.Windows.Forms.TextBox();
            this.txtDrinkID = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtInvoiceDetailID = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).BeginInit();
            this.SuspendLayout();

            // dgvInvoiceDetails
            this.dgvInvoiceDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoiceDetails.Location = new System.Drawing.Point(20, 130);
            this.dgvInvoiceDetails.Name = "dgvInvoiceDetails";
            this.dgvInvoiceDetails.ReadOnly = true;
            this.dgvInvoiceDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceDetails.Size = new System.Drawing.Size(600, 300);
            this.dgvInvoiceDetails.TabIndex = 0;
            this.dgvInvoiceDetails.SelectionChanged += new System.EventHandler(this.dgvInvoiceDetails_SelectionChanged);

            // label1
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Invoice ID:";

            // label2
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Drink ID:";

            // label3
            this.label3.Location = new System.Drawing.Point(300, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Quantity:";

            // label4
            this.label4.Location = new System.Drawing.Point(300, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Unit Price:";

            // lblInvoiceDetails
            this.lblInvoiceDetails.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceDetails.Location = new System.Drawing.Point(20, 100);
            this.lblInvoiceDetails.Name = "lblInvoiceDetails";
            this.lblInvoiceDetails.Size = new System.Drawing.Size(150, 30);
            this.lblInvoiceDetails.Text = "Invoice Details";

            // txtInvoiceID
            this.txtInvoiceID.Location = new System.Drawing.Point(120, 20);
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Size = new System.Drawing.Size(150, 20);
            this.txtInvoiceID.TabIndex = 1;

            // txtDrinkID
            this.txtDrinkID.Location = new System.Drawing.Point(120, 50);
            this.txtDrinkID.Name = "txtDrinkID";
            this.txtDrinkID.Size = new System.Drawing.Size(150, 20);
            this.txtDrinkID.TabIndex = 2;

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(400, 20);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(150, 20);
            this.txtQuantity.TabIndex = 3;

            // txtUnitPrice
            this.txtUnitPrice.Location = new System.Drawing.Point(400, 50);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(150, 20);
            this.txtUnitPrice.TabIndex = 4;

            // txtInvoiceDetailID
            this.txtInvoiceDetailID.Visible = false;
            this.txtInvoiceDetailID.Name = "txtInvoiceDetailID";

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(650, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Text = "Add Detail";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(650, 60);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.Text = "Update Detail";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(650, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.Text = "Delete Detail";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // frmChiTietHoaDon
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.dgvInvoiceDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblInvoiceDetails);
            this.Controls.Add(this.txtInvoiceID);
            this.Controls.Add(this.txtDrinkID);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.txtInvoiceDetailID);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Name = "frmChiTietHoaDon";
            this.Text = "Invoice Details - Quan Ly Quan Cafe";
            this.Load += new System.EventHandler(this.frmChiTietHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}