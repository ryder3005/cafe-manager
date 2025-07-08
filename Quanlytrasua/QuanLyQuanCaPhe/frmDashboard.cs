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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        // Event handler for "Manage Tables" button (frmBan)
        private void btnOpenTables_Click(object sender, EventArgs e)
        {
            //frmBan formBan = new frmBan();
            //formBan.Show();
            openchildform(new frmBan());
        }

        // Event handler for "Manage Invoice Details" button (frmChiTietHoaDon)
        private void btnOpenInvoiceDetails_Click(object sender, EventArgs e)
        {
            //frmChiTietHoaDon formChiTietHoaDon = new frmChiTietHoaDon();
            //formChiTietHoaDon.Show();
            frmDathang frmDathang = new frmDathang();
            frmDathang.ShowDialog();
            //openchildform(new frmChiTietHoaDon());
        }

        // Event handler for "Manage Invoices" button (frmHoaDon)
        private void btnOpenInvoices_Click(object sender, EventArgs e)
        {
            //frmHoaDon formHoaDon = new frmHoaDon();
            //formHoaDon.Show();
            openchildform(new frmHoaDon());
        }

        // Event handler for "Manage Drink Categories" button (frmLoaiThucUong)
        private void btnOpenDrinkCategories_Click(object sender, EventArgs e)
        {
            //frmLoaiThucUong formLoaiThucUong = new frmLoaiThucUong();
            //formLoaiThucUong.Show();
            openchildform(new frmLoaiThucUong());
        }

        // Event handler for "Manage Employees" button (frmNhanVien)
        private void btnOpenEmployees_Click(object sender, EventArgs e)
        {
            //frmNhanVien formNhanVien = new frmNhanVien();
            //formNhanVien.Show();
            openchildform(new frmNhanVien());
        }

        // Event handler for "Manage Accounts" button (frmTaiKhoan)
        private void btnOpenAccounts_Click(object sender, EventArgs e)
        {
            //frmTaiKhoan formTaiKhoan = new frmTaiKhoan();
            //formTaiKhoan.Show();
            openchildform(new frmTaiKhoan());
        }

        // Event handler for "Manage Drinks" button (frmThucUong)
        private void btnOpenDrinks_Click(object sender, EventArgs e)
        {
            //frmThucUong formThucUong = new frmThucUong();
            //formThucUong.Show();
            openchildform(new frmThucUong());
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {

        }
        private void openchildform(Form childForm)
        {
            panelchild.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelchild.Controls.Add(childForm);
            childForm.Show();
        }
    }
}