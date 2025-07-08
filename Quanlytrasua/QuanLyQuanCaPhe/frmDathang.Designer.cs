namespace QuanLyQuanCaPhe
{
    partial class frmDathang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblTongTien = new Label();
            cbbBan = new ComboBox();
            cbbNhanVien = new ComboBox();
            cbbTrangthai = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dgvDrinks = new DataGridView();
            nUDvalue = new NumericUpDown();
            label6 = new Label();
            btnAdd = new Button();
            dgvGiohang = new DataGridView();
            btnDelete = new Button();
            btnComfirm = new Button();
            btnExit = new Button();
            label7 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrinks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nUDvalue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGiohang).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTongTien);
            panel1.Controls.Add(cbbBan);
            panel1.Controls.Add(cbbNhanVien);
            panel1.Controls.Add(cbbTrangthai);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(899, 109);
            panel1.TabIndex = 0;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(784, 39);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(17, 20);
            lblTongTien.TabIndex = 8;
            lblTongTien.Text = "0";
            // 
            // cbbBan
            // 
            cbbBan.FormattingEnabled = true;
            cbbBan.Location = new Point(503, 36);
            cbbBan.Name = "cbbBan";
            cbbBan.Size = new Size(151, 28);
            cbbBan.TabIndex = 7;
            // 
            // cbbNhanVien
            // 
            cbbNhanVien.FormattingEnabled = true;
            cbbNhanVien.Location = new Point(271, 36);
            cbbNhanVien.Name = "cbbNhanVien";
            cbbNhanVien.Size = new Size(151, 28);
            cbbNhanVien.TabIndex = 6;
            // 
            // cbbTrangthai
            // 
            cbbTrangthai.FormattingEnabled = true;
            cbbTrangthai.Location = new Point(16, 36);
            cbbTrangthai.Name = "cbbTrangthai";
            cbbTrangthai.Size = new Size(151, 28);
            cbbTrangthai.TabIndex = 5;
            cbbTrangthai.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(561, 13);
            label5.Name = "label5";
            label5.Size = new Size(34, 20);
            label5.TabIndex = 4;
            label5.Text = "Ban";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(295, 13);
            label4.Name = "label4";
            label4.Size = new Size(104, 20);
            label4.TabIndex = 3;
            label4.Text = "TenDangNhap";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 13);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 2;
            label3.Text = "Trang thai";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(757, 13);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 1;
            label2.Text = "Tong tien";
            // 
            // dgvDrinks
            // 
            dgvDrinks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrinks.Location = new Point(38, 413);
            dgvDrinks.Name = "dgvDrinks";
            dgvDrinks.RowHeadersWidth = 51;
            dgvDrinks.Size = new Size(79, 59);
            dgvDrinks.TabIndex = 1;
            dgvDrinks.Visible = false;
            dgvDrinks.CellClick += dgvDrinks_CellClick;
            // 
            // nUDvalue
            // 
            nUDvalue.Location = new Point(408, 388);
            nUDvalue.Name = "nUDvalue";
            nUDvalue.Size = new Size(150, 27);
            nUDvalue.TabIndex = 2;
            nUDvalue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(931, 25);
            label6.Name = "label6";
            label6.Size = new Size(149, 20);
            label6.TabIndex = 3;
            label6.Text = "Danh sách sản phẩm ";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(307, 430);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(158, 29);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Thêm ";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvGiohang
            // 
            dgvGiohang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGiohang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGiohang.Location = new Point(12, 175);
            dgvGiohang.Name = "dgvGiohang";
            dgvGiohang.RowHeadersWidth = 51;
            dgvGiohang.Size = new Size(899, 188);
            dgvGiohang.TabIndex = 5;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(495, 430);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(158, 29);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Xóa ";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnComfirm
            // 
            btnComfirm.Location = new Point(422, 505);
            btnComfirm.Name = "btnComfirm";
            btnComfirm.Size = new Size(109, 61);
            btnComfirm.TabIndex = 7;
            btnComfirm.Text = "Xác nhận ";
            btnComfirm.UseVisualStyleBackColor = true;
            btnComfirm.Click += button3_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(818, 505);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(105, 61);
            btnExit.TabIndex = 8;
            btnExit.Text = "Hủy";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(515, 141);
            label7.Name = "label7";
            label7.Size = new Size(115, 20);
            label7.TabIndex = 9;
            label7.Text = "Chi tiết hóa đơn";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(931, 51);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(437, 515);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // frmDathang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1380, 589);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label7);
            Controls.Add(btnExit);
            Controls.Add(btnComfirm);
            Controls.Add(btnDelete);
            Controls.Add(dgvGiohang);
            Controls.Add(btnAdd);
            Controls.Add(label6);
            Controls.Add(nUDvalue);
            Controls.Add(dgvDrinks);
            Controls.Add(panel1);
            Name = "frmDathang";
            Text = "frmDathang";
            Load += frmDathang_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrinks).EndInit();
            ((System.ComponentModel.ISupportInitialize)nUDvalue).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGiohang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DataGridView dgvDrinks;
        private NumericUpDown nUDvalue;
        private ComboBox cbbTrangthai;
        private ComboBox cbbNhanVien;
        private Label lblTongTien;
        private ComboBox cbbBan;
        private Label label6;
        private Button btnAdd;
        private DataGridView dgvGiohang;
        private Button btnDelete;
        private Button btnComfirm;
        private Button btnExit;
        private Label label7;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}