namespace QuanLyQuanCaPhe
{
    partial class frmThucUong
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvDrinks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDrinkMenu;
        private System.Windows.Forms.TextBox txtDrinkName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtDrinkID;
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
            dgvDrinks = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblDrinkMenu = new Label();
            txtDrinkName = new TextBox();
            txtPrice = new TextBox();
            txtDrinkID = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            PicNew = new PictureBox();
            button1 = new Button();
            lblnew = new Label();
            cbbCategory = new ComboBox();
            cbbStatus = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvDrinks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicNew).BeginInit();
            SuspendLayout();
            // 
            // dgvDrinks
            // 
            dgvDrinks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDrinks.ColumnHeadersHeight = 29;
            dgvDrinks.Location = new Point(23, 412);
            dgvDrinks.Margin = new Padding(3, 4, 3, 4);
            dgvDrinks.Name = "dgvDrinks";
            dgvDrinks.ReadOnly = true;
            dgvDrinks.RowHeadersWidth = 51;
            dgvDrinks.Size = new Size(686, 135);
            dgvDrinks.TabIndex = 0;
            dgvDrinks.SelectionChanged += dgvDrinks_SelectionChanged;
            // 
            // label1
            // 
            label1.Location = new Point(23, 27);
            label1.Name = "label1";
            label1.Size = new Size(114, 27);
            label1.TabIndex = 1;
            label1.Text = "Drink Name:";
            // 
            // label2
            // 
            label2.Location = new Point(23, 67);
            label2.Name = "label2";
            label2.Size = new Size(114, 27);
            label2.TabIndex = 2;
            label2.Text = "Category ID:";
            // 
            // label3
            // 
            label3.Location = new Point(343, 27);
            label3.Name = "label3";
            label3.Size = new Size(114, 27);
            label3.TabIndex = 3;
            label3.Text = "Price:";
            // 
            // label4
            // 
            label4.Location = new Point(343, 67);
            label4.Name = "label4";
            label4.Size = new Size(114, 27);
            label4.TabIndex = 4;
            label4.Text = "Status:";
            // 
            // lblDrinkMenu
            // 
            lblDrinkMenu.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblDrinkMenu.Location = new Point(23, 128);
            lblDrinkMenu.Name = "lblDrinkMenu";
            lblDrinkMenu.Size = new Size(171, 40);
            lblDrinkMenu.TabIndex = 5;
            lblDrinkMenu.Text = "Drink Menu";
            lblDrinkMenu.Click += lblDrinkMenu_Click;
            // 
            // txtDrinkName
            // 
            txtDrinkName.Location = new Point(137, 27);
            txtDrinkName.Margin = new Padding(3, 4, 3, 4);
            txtDrinkName.Name = "txtDrinkName";
            txtDrinkName.Size = new Size(171, 27);
            txtDrinkName.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(457, 27);
            txtPrice.Margin = new Padding(3, 4, 3, 4);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(171, 27);
            txtPrice.TabIndex = 3;
            // 
            // txtDrinkID
            // 
            txtDrinkID.Location = new Point(0, 0);
            txtDrinkID.Margin = new Padding(3, 4, 3, 4);
            txtDrinkID.Name = "txtDrinkID";
            txtDrinkID.Size = new Size(114, 27);
            txtDrinkID.TabIndex = 6;
            txtDrinkID.Visible = false;
            txtDrinkID.TextChanged += txtDrinkID_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(743, 27);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(114, 40);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add Drink";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(743, 80);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(114, 40);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update Drink";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(743, 133);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 40);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete Drink";
            btnDelete.Click += btnDelete_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(23, 203);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(673, 173);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // PicNew
            // 
            PicNew.Location = new Point(474, 119);
            PicNew.Name = "PicNew";
            PicNew.Size = new Size(125, 62);
            PicNew.SizeMode = PictureBoxSizeMode.StretchImage;
            PicNew.TabIndex = 11;
            PicNew.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(743, 181);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(114, 40);
            button1.TabIndex = 12;
            button1.Text = "Chọn Ảnh";
            button1.Click += button1_Click;
            // 
            // lblnew
            // 
            lblnew.AutoSize = true;
            lblnew.Location = new Point(268, 143);
            lblnew.Name = "lblnew";
            lblnew.Size = new Size(53, 20);
            lblnew.TabIndex = 13;
            lblnew.Text = "lblnew";
            // 
            // cbbCategory
            // 
            cbbCategory.FormattingEnabled = true;
            cbbCategory.Location = new Point(137, 66);
            cbbCategory.Name = "cbbCategory";
            cbbCategory.Size = new Size(171, 28);
            cbbCategory.TabIndex = 14;
            // 
            // cbbStatus
            // 
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Location = new Point(457, 64);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(171, 28);
            cbbStatus.TabIndex = 15;
            // 
            // frmThucUong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 667);
            Controls.Add(cbbStatus);
            Controls.Add(cbbCategory);
            Controls.Add(lblnew);
            Controls.Add(button1);
            Controls.Add(PicNew);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(dgvDrinks);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(lblDrinkMenu);
            Controls.Add(txtDrinkName);
            Controls.Add(txtPrice);
            Controls.Add(txtDrinkID);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmThucUong";
            Text = "Drink Menu - Quan Ly Quan Cafe";
            Load += frmMenu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDrinks).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicNew).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox PicNew;
        private Button button1;
        private Label lblnew;
        private ComboBox cbbCategory;
        private ComboBox cbbStatus;
    }
}