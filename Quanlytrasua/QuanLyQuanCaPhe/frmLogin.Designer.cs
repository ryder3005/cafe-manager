namespace QuanLyQuanCaPhe
{
    partial class frmLogin
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
            label1 = new Label();
            txbTendangnhap = new TextBox();
            txbMatkhau = new TextBox();
            btnLogin = new Button();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(340, 56);
            label1.Name = "label1";
            label1.Size = new Size(116, 28);
            label1.TabIndex = 0;
            label1.Text = "Login Page";
            // 
            // txbTendangnhap
            // 
            txbTendangnhap.Location = new Point(262, 111);
            txbTendangnhap.Name = "txbTendangnhap";
            txbTendangnhap.Size = new Size(320, 27);
            txbTendangnhap.TabIndex = 1;
            txbTendangnhap.TextChanged += textBox1_TextChanged;
            // 
            // txbMatkhau
            // 
            txbMatkhau.Location = new Point(262, 193);
            txbMatkhau.Name = "txbMatkhau";
            txbMatkhau.Size = new Size(320, 27);
            txbMatkhau.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(340, 264);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(116, 35);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.Location = new Point(140, 113);
            label2.Name = "label2";
            label2.Size = new Size(119, 23);
            label2.TabIndex = 4;
            label2.Text = "TenDangNhap";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.Location = new Point(179, 194);
            label3.Name = "label3";
            label3.Size = new Size(80, 23);
            label3.TabIndex = 5;
            label3.Text = "MatKhau";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnLogin);
            Controls.Add(txbMatkhau);
            Controls.Add(txbTendangnhap);
            Controls.Add(label1);
            Name = "frmLogin";
            Text = "frmLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txbTendangnhap;
        private TextBox txbMatkhau;
        private Button btnLogin;
        private Label label2;
        private Label label3;
    }
}