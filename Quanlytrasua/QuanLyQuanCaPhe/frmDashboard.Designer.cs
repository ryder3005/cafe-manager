namespace QuanLyQuanCaPhe
{
    partial class frmDashboard
    {
        private System.ComponentModel.IContainer components = null;

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
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            fbtnOpenTables = new FontAwesome.Sharp.IconButton();
            iconButton5 = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            iconButton6 = new FontAwesome.Sharp.IconButton();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            panelchild = new Panel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(35, 40, 45);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Controls.Add(iconButton4);
            flowLayoutPanel1.Controls.Add(fbtnOpenTables);
            flowLayoutPanel1.Controls.Add(iconButton5);
            flowLayoutPanel1.Controls.Add(iconButton2);
            flowLayoutPanel1.Controls.Add(iconButton1);
            flowLayoutPanel1.Controls.Add(iconButton6);
            flowLayoutPanel1.Controls.Add(iconButton3);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(250, 674);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(247, 125);
            panel1.TabIndex = 8;
            // 
            // iconButton4
            // 
            iconButton4.Anchor = AnchorStyles.Bottom;
            iconButton4.FlatAppearance.BorderSize = 0;
            iconButton4.FlatStyle = FlatStyle.Flat;
            iconButton4.ForeColor = Color.Transparent;
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.BuildingUser;
            iconButton4.IconColor = Color.LightGray;
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconButton4.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton4.Location = new Point(3, 134);
            iconButton4.Name = "iconButton4";
            iconButton4.Size = new Size(249, 50);
            iconButton4.TabIndex = 14;
            iconButton4.Text = "Manage Employees";
            iconButton4.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton4.UseVisualStyleBackColor = true;
            iconButton4.Click += btnOpenEmployees_Click;
            // 
            // fbtnOpenTables
            // 
            fbtnOpenTables.Anchor = AnchorStyles.Bottom;
            fbtnOpenTables.FlatAppearance.BorderSize = 0;
            fbtnOpenTables.FlatStyle = FlatStyle.Flat;
            fbtnOpenTables.ForeColor = Color.Transparent;
            fbtnOpenTables.IconChar = FontAwesome.Sharp.IconChar.Dumpster;
            fbtnOpenTables.IconColor = Color.LightGray;
            fbtnOpenTables.IconFont = FontAwesome.Sharp.IconFont.Solid;
            fbtnOpenTables.ImageAlign = ContentAlignment.MiddleLeft;
            fbtnOpenTables.Location = new Point(3, 190);
            fbtnOpenTables.Name = "fbtnOpenTables";
            fbtnOpenTables.Size = new Size(249, 50);
            fbtnOpenTables.TabIndex = 10;
            fbtnOpenTables.Text = "Manage Tables";
            fbtnOpenTables.TextImageRelation = TextImageRelation.ImageBeforeText;
            fbtnOpenTables.UseVisualStyleBackColor = true;
            fbtnOpenTables.Click += btnOpenTables_Click;
            // 
            // iconButton5
            // 
            iconButton5.Anchor = AnchorStyles.Bottom;
            iconButton5.FlatAppearance.BorderSize = 0;
            iconButton5.FlatStyle = FlatStyle.Flat;
            iconButton5.ForeColor = Color.Transparent;
            iconButton5.IconChar = FontAwesome.Sharp.IconChar.Users;
            iconButton5.IconColor = Color.LightGray;
            iconButton5.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconButton5.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton5.Location = new Point(3, 246);
            iconButton5.Name = "iconButton5";
            iconButton5.Size = new Size(249, 42);
            iconButton5.TabIndex = 15;
            iconButton5.Text = "Manage Accounts";
            iconButton5.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton5.UseVisualStyleBackColor = true;
            iconButton5.Click += btnOpenAccounts_Click;
            // 
            // iconButton2
            // 
            iconButton2.Anchor = AnchorStyles.Bottom;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.ForeColor = Color.Transparent;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            iconButton2.IconColor = Color.LightGray;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(3, 294);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(247, 50);
            iconButton2.TabIndex = 12;
            iconButton2.Text = "Manage Invoices";
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += btnOpenInvoices_Click;
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Bottom;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.ForeColor = Color.Transparent;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            iconButton1.IconColor = Color.LightGray;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(3, 350);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(247, 50);
            iconButton1.TabIndex = 11;
            iconButton1.Text = "Manage Invoice Details";
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += btnOpenInvoiceDetails_Click;
            // 
            // iconButton6
            // 
            iconButton6.CausesValidation = false;
            iconButton6.FlatAppearance.BorderSize = 0;
            iconButton6.FlatStyle = FlatStyle.Flat;
            iconButton6.ForeColor = Color.Transparent;
            iconButton6.IconChar = FontAwesome.Sharp.IconChar.WineGlass;
            iconButton6.IconColor = Color.LightGray;
            iconButton6.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconButton6.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton6.Location = new Point(3, 406);
            iconButton6.Name = "iconButton6";
            iconButton6.Size = new Size(247, 48);
            iconButton6.TabIndex = 16;
            iconButton6.Text = "Manage Drinks";
            iconButton6.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton6.UseVisualStyleBackColor = true;
            iconButton6.Click += btnOpenDrinks_Click;
            // 
            // iconButton3
            // 
            iconButton3.Anchor = AnchorStyles.Bottom;
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.ForeColor = Color.Transparent;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.ListDots;
            iconButton3.IconColor = Color.LightGray;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconButton3.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton3.Location = new Point(3, 460);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(247, 50);
            iconButton3.TabIndex = 13;
            iconButton3.Text = "Manage Drink Categories";
            iconButton3.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton3.UseVisualStyleBackColor = true;
            iconButton3.Click += btnOpenDrinkCategories_Click;
            // 
            // panelchild
            // 
            panelchild.Dock = DockStyle.Fill;
            panelchild.Location = new Point(250, 0);
            panelchild.Name = "panelchild";
            panelchild.Size = new Size(1027, 674);
            panelchild.TabIndex = 8;
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1277, 674);
            Controls.Add(panelchild);
            Controls.Add(flowLayoutPanel1);
            Name = "frmDashboard";
            Text = "Dashboard - Quan Ly Quan Cafe";
            Load += frmDashboard_Load;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton fbtnOpenTables;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton4;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton iconButton6;
        private Panel panelchild;
    }
}