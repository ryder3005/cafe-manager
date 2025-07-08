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
    public partial class ThucUongItem : UserControl
    {
        private int _gia; // Biến lưu giá trị giá tiền
        private string _ten; // Biến lưu giá trị tên thức uống
        private Image _image;
        private int _id;
        public event EventHandler ItemClicked;
        

        public void SetSelected(bool isSelected)
        {
            this.BackColor = isSelected ? Color.LightBlue : Color.FromArgb(100, 192, 192, 255);
        }
        public ThucUongItem()
        {
            InitializeComponent();
            this.Click += ThucUongItem_Click;
            pictureBox1.Click += ThucUongItem_Click;
            lblTen.Click += ThucUongItem_Click;
        }

        private void ThucUongItem_Click(object? sender, EventArgs e)
        {
            
            ItemClicked?.Invoke(this, e);
        }

        public int gia
        {
            get { return _gia; } // Trả về giá trị lưu trữ
            set
            {
                _gia = value; // Lưu giá trị mới
                lblGia.Text = _gia.ToString() + " đ"; // Hiển thị trên Label
            }
        }

        public string ten
        {
            get { return _ten; } // Trả về giá trị lưu trữ
            set
            {
                _ten = value; // Lưu giá trị mới
                lblTen.Text = _ten; // Hiển thị trên Label
            }
        }
        public Image image
        {
            get { return _image; } // Trả về giá trị lưu trữ
            set
            {
                _image = value; // Lưu giá trị mới
                pictureBox1.Image = _image; // Hiển thị trên PictureBox
            }
        }
        public int id
        {
            get { return _id; } // Trả về giá trị lưu trữ
            set
            {
                _id = value; // Lưu giá trị mới
                lbl_Id.Text = "#"+_id.ToString(); // Hiển thị trên Label
            }
        }
    }

}
