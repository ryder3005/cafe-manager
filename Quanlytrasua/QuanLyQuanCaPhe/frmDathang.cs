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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuanLyQuanCaPhe
{
    public partial class frmDathang : Form
    {
        private DBChiTietHoaDon dbChiTietHoaDon;
        private DBBan dbBan;
        private DBThucUong dbThucUong;
        private DBNhanVien dbNhanVien;
        private DBHoaDon dbHoaDon;
        private DBTaiKhoan dbTaiKhoan;
        private string idthucuong;
        private string tenthucuong;
        private string gia;
        private ThucUongItem ThucUongItemseleted = null;
        public frmDathang()
        {
            InitializeComponent();
            dbChiTietHoaDon = new DBChiTietHoaDon();
            dbBan = new DBBan();
            dbThucUong = new DBThucUong();
            dbNhanVien = new DBNhanVien();
            dbHoaDon = new DBHoaDon();
            dbTaiKhoan = new DBTaiKhoan();
            dgvGiohang.Columns.Add("id_thucuong", "ID");
            dgvGiohang.Columns.Add("tenthucuong", "Tên thức uống");
            dgvGiohang.Columns.Add("gia", "Giá");
            dgvGiohang.Columns.Add("soluong", "Số lượng");
            dgvGiohang.Columns.Add("thanhtien", "Thành tiền");


        }
        private void LoadInvoiceDetails()
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string error = "";

            int idBan = Convert.ToInt32(cbbBan.SelectedValue);
            string tenDangNhap = cbbNhanVien.SelectedValue?.ToString() ?? string.Empty;
            int trangThai = cbbTrangthai.SelectedIndex;
            int idhoadon=dbHoaDon.InsertHoaDon(ref error, idBan, tenDangNhap, trangThai);
            foreach (DataGridViewRow row in dgvGiohang.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[3].Value != null && row.Cells[4].Value != null)
                {
                    int idthucuong = Convert.ToInt32(row.Cells[0].Value);
                    int soluong = Convert.ToInt32(row.Cells[3].Value);
                    int thanhtien = Convert.ToInt32(row.Cells[4].Value);
                    dbChiTietHoaDon.InsertChiTietHoaDon(ref error, idhoadon, idthucuong, soluong, thanhtien);
                }
            }
            if (string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn thất bại"+error, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void frmDathang_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        DataRow crRow = null;
        private void LoadDrinks()
        {
            string error = "";
            var dataSet = dbThucUong.GetAllThucUong(ref error);
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                dgvDrinks.DataSource = dataSet.Tables[0];
            }
            else
            {
                MessageBox.Show("Error loading drinks: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            //var dataSet = dbThucUong.GetAllThucUong(ref error);
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                dgvDrinks.DataSource = dataSet.Tables[0];
                flowLayoutPanel1.Controls.Clear();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    ThucUongItem item = new ThucUongItem();
                    item.ten = row["Ten"].ToString();
                    item.gia = int.Parse(row["Gia"].ToString());
                    if (row["Anh"] != DBNull.Value)
                    {
                        MemoryStream ms = new MemoryStream((byte[])row["Anh"]);
                        item.image = Image.FromStream(ms);
                    }
                    item.id = int.Parse(row["id_thucUong"].ToString());
                    item.ItemClicked += (sender, e) =>
                    {
                        crRow = row;
                        idthucuong = (row["id_thucUong"].ToString());
                        ThucUongItem clickedthucuongitem = (ThucUongItem)sender;
                        if (ThucUongItemseleted != null)
                        {
                            ThucUongItemseleted.SetSelected(false);
                        }
                        clickedthucuongitem.SetSelected(true);
                        ThucUongItemseleted = clickedthucuongitem;
                        //MessageBox.Show("Bạn đã chọn: " + item.ten);
                    };
                    flowLayoutPanel1.Controls.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Error loading drinks: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            //LoadInvoiceDetails();
            LoadDrinks();
            string error = "";
            DataTable taikhoanlist = dbTaiKhoan.GetAllTaiKhoan(ref error).Tables[0];
            if (taikhoanlist != null && taikhoanlist.Columns.Contains("TenDangNhap"))
            {
                cbbNhanVien.DataSource = taikhoanlist;
                cbbNhanVien.DisplayMember = "TenDangNhap";
                cbbNhanVien.ValueMember = "TenDangNhap";
            }
            else
            {
                // Handle the error appropriately
                MessageBox.Show("Data source does not contain 'id_nhanvien' or is null.");
            }
            cbbTrangthai.Items.Add("Chưa thanh toán");
            cbbTrangthai.Items.Add("Đã thanh toán");
            cbbTrangthai.SelectedIndex = 0;
            DataTable banList = dbBan.GetAllBan(ref error).Tables[0];
            if (banList != null && banList.Columns.Contains("id_ban"))
            {
                cbbBan.DataSource = banList;
                cbbBan.DisplayMember = "Ten";
                cbbBan.ValueMember = "id_ban";
            }
            else
            {
                // Handle the error appropriately
                MessageBox.Show("Data source does not contain 'id_ban' or is null.");
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (idthucuong != null)
            {
                bool found = false;
                if (dgvGiohang.Rows.Count > 1)
                    foreach (DataGridViewRow row in dgvGiohang.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == idthucuong)
                        {
                            row.Cells[3].Value = (int)row.Cells[3].Value + (int)nUDvalue.Value;
                            found = true;

                        }
                    }
                if (!found)
                {
                    

                    if (crRow !=null) // Tránh xóa dòng trống
                    {
                        dgvGiohang.Rows.Add(crRow[0],
                            crRow[1],
                            crRow[3],
                            (int)nUDvalue.Value,
                            0);
                        //dgvGiohang.Rows.RemoveAt(rowIndex);
                    }
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn thức uống cần thêm vào giỏ hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (dgvGiohang.Rows.Count > 1)
                foreach (DataGridViewRow row in dgvGiohang.Rows)
                {
                    if (row.Cells[2].Value != null && row.Cells[3].Value != null) // Kiểm tra null
                    {
                        int gia = 0, soluong = 0;

                        // Kiểm tra và ép kiểu an toàn
                        if (int.TryParse(row.Cells[2].Value.ToString(), out gia) &&
                            int.TryParse(row.Cells[3].Value.ToString(), out soluong))
                        {
                            row.Cells[4].Value = gia * soluong;
                        }
                        else
                        {
                            MessageBox.Show("Dữ liệu nhập vào không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            int Tongtien = 0;
            foreach (DataGridViewRow row in dgvGiohang.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    Tongtien += Convert.ToInt32(row.Cells[4].Value);
                }
            }
            lblTongTien.Text = Tongtien.ToString();
        }

        private void dgvDrinks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDrinks.Rows[e.RowIndex];
            idthucuong = row.Cells[0].Value.ToString();
            tenthucuong = row.Cells[1].Value.ToString();
            gia = row.Cells[3].Value.ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGiohang.CurrentCell != null) // Kiểm tra có ô nào được chọn không
            {
                int rowIndex = dgvGiohang.CurrentCell.RowIndex;
                if (rowIndex >= 0 && !dgvGiohang.Rows[rowIndex].IsNewRow) // Tránh xóa dòng trống
                {
                    dgvGiohang.Rows.RemoveAt(rowIndex);
                }
            }
        }
    }
}
