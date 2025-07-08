using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessAccessLayer;

namespace QuanLyQuanCaPhe
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private DBTaiKhoan dbTaiKhoan = new DBTaiKhoan();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txbTendangnhap.Text.Trim();
            string matKhau = txbMatkhau.Text.Trim();
            string err = "";

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isLoginSuccess = dbTaiKhoan.CheckLogin(tenDangNhap, matKhau, ref err);
            if (isLoginSuccess)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Hide();
                var mainForm = new frmDashboard();
                
                
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại. Sai tên đăng nhập hoặc mật khẩu.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
