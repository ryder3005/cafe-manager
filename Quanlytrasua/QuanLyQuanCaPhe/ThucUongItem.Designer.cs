namespace QuanLyQuanCaPhe
{
    partial class ThucUongItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            lblTen = new Label();
            lblGia = new Label();
            lbl_Id = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.exampledrink;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(0, 145);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(49, 20);
            lblTen.TabIndex = 1;
            lblTen.Text = "lblTen";
            lblTen.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Location = new Point(90, 115);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(60, 20);
            lblGia.TabIndex = 2;
            lblGia.Text = "10000D";
            lblGia.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Id
            // 
            lbl_Id.AutoSize = true;
            lbl_Id.Location = new Point(0, 115);
            lbl_Id.Name = "lbl_Id";
            lbl_Id.Size = new Size(50, 20);
            lbl_Id.TabIndex = 3;
            lbl_Id.Text = "label1";
            // 
            // ThucUongItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            Controls.Add(lbl_Id);
            Controls.Add(lblGia);
            Controls.Add(lblTen);
            Controls.Add(pictureBox1);
            Name = "ThucUongItem";
            Size = new Size(150, 165);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblTen;
        private Label lblGia;
        private Label lbl_Id;
    }
}
