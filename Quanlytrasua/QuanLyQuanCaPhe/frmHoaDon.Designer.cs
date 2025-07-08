namespace QuanLyQuanCaPhe
{
    partial class frmHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInvoiceList;
        private System.Windows.Forms.TextBox txtTableID;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtInvoiceID;
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
            dgvInvoices = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblInvoiceList = new Label();
            txtTableID = new TextBox();
            txtUsername = new TextBox();
            txtTotalAmount = new TextBox();
            txtStatus = new TextBox();
            txtInvoiceID = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnprint = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).BeginInit();
            SuspendLayout();
            // 
            // dgvInvoices
            // 
            dgvInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoices.ColumnHeadersHeight = 29;
            dgvInvoices.Location = new Point(20, 130);
            dgvInvoices.Name = "dgvInvoices";
            dgvInvoices.ReadOnly = true;
            dgvInvoices.RowHeadersWidth = 51;
            dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoices.Size = new Size(600, 300);
            dgvInvoices.TabIndex = 0;
            dgvInvoices.SelectionChanged += dgvInvoices_SelectionChanged;
            // 
            // label1
            // 
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 1;
            label1.Text = "Table ID:";
            // 
            // label2
            // 
            label2.Location = new Point(20, 50);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 2;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.Location = new Point(300, 20);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 3;
            label3.Text = "Total Amount:";
            // 
            // label4
            // 
            label4.Location = new Point(300, 50);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 4;
            label4.Text = "Status:";
            // 
            // lblInvoiceList
            // 
            lblInvoiceList.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblInvoiceList.Location = new Point(20, 100);
            lblInvoiceList.Name = "lblInvoiceList";
            lblInvoiceList.Size = new Size(150, 30);
            lblInvoiceList.TabIndex = 5;
            lblInvoiceList.Text = "Invoice List";
            // 
            // txtTableID
            // 
            txtTableID.Location = new Point(120, 20);
            txtTableID.Name = "txtTableID";
            txtTableID.Size = new Size(150, 27);
            txtTableID.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(120, 50);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(150, 27);
            txtUsername.TabIndex = 2;
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.Location = new Point(400, 20);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.Size = new Size(150, 27);
            txtTotalAmount.TabIndex = 3;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(400, 50);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(150, 27);
            txtStatus.TabIndex = 4;
            // 
            // txtInvoiceID
            // 
            txtInvoiceID.Location = new Point(0, 0);
            txtInvoiceID.Name = "txtInvoiceID";
            txtInvoiceID.Size = new Size(100, 27);
            txtInvoiceID.TabIndex = 6;
            txtInvoiceID.Visible = false;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(650, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 30);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add Invoice";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(650, 60);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 30);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update Invoice";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(650, 100);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete Invoice";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnprint
            // 
            btnprint.Location = new Point(650, 136);
            btnprint.Name = "btnprint";
            btnprint.Size = new Size(100, 30);
            btnprint.TabIndex = 10;
            btnprint.Text = "Print";
            btnprint.Click += btnprint_Click;
            // 
            // frmHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(btnprint);
            Controls.Add(dgvInvoices);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(lblInvoiceList);
            Controls.Add(txtTableID);
            Controls.Add(txtUsername);
            Controls.Add(txtTotalAmount);
            Controls.Add(txtStatus);
            Controls.Add(txtInvoiceID);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Name = "frmHoaDon";
            Text = "Invoices - Quan Ly Quan Cafe";
            Load += frmHoaDon_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnprint;
    }
}