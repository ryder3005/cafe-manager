using BusinessAccessLayer;
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
    public partial class frmThucUong : Form
    {
        private DBThucUong dbThucUong;
        private DBLoaiThucUong DBLoaiThucUong;

        public frmThucUong()
        {
            InitializeComponent();
            dbThucUong = new DBThucUong();
            DBLoaiThucUong = new DBLoaiThucUong();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            LoadDrinks();
        }

        private void LoadDrinks()
        {
            string error = "";
            var dataSet = dbThucUong.GetAllThucUong(ref error);
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
                    flowLayoutPanel1.Controls.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Error loading drinks: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            var dsLoaiThucUong = DBLoaiThucUong.GetAllLoaiThucUong(ref error);
            if (dsLoaiThucUong != null && dsLoaiThucUong.Tables.Count > 0)
            {
                cbbCategory.DataSource = dsLoaiThucUong.Tables[0];
                cbbCategory.DisplayMember = "Ten";
                cbbCategory.ValueMember = "id_loaiThucUong";
            }
            else
            {
                MessageBox.Show("Error loading categories: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            var statusList = new List<object>
            {
                new { Text = "Active", Value = 1 },
                new { Text = "Inactive", Value = 0 }
            };

            cbbStatus.DataSource = statusList;
            cbbStatus.DisplayMember = "Text";
            cbbStatus.ValueMember = "Value";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtDrinkName.Text) ||
                cbbCategory.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtPrice.Text) )
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse input
            if (!int.TryParse(cbbCategory.SelectedItem?.ToString(), out int categoryID) ||
            !float.TryParse(txtPrice.Text, out float price)         )
            {
                MessageBox.Show("Category ID, Price, and Status must be valid numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add the drink
            string error = "";
            if (string.IsNullOrWhiteSpace(selectedImagePath))
            {
                MessageBox.Show("Please select an image for the drink.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            byte[] imageData = File.ReadAllBytes(selectedImagePath);
            bool success = dbThucUong.InsertThucUong(ref error, txtDrinkName.Text, (int )cbbCategory.SelectedValue, price, (int)cbbStatus.SelectedValue,imageData);
            if (success)
            {
                MessageBox.Show("Drink added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDrinks(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error adding drink: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtDrinkID.Text))
            {
                MessageBox.Show("Please select a drink to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDrinkName.Text) ||
                
                string.IsNullOrWhiteSpace(txtPrice.Text) )
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse input
            if (!int.TryParse(txtDrinkID.Text, out int drinkID) ||
                !float.TryParse(txtPrice.Text, out float price)) 
            {
                MessageBox.Show("Drink ID, Category ID, Price, and Status must be valid numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update the drink
            string error = "";
            bool success = dbThucUong.UpdateThucUong(ref error, drinkID, txtDrinkName.Text, (int)cbbCategory.SelectedValue, price, (int)cbbStatus.SelectedValue);
            if (success)
            {
                MessageBox.Show("Drink updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadDrinks(); // Refresh the grid
            }
            else
            {
                MessageBox.Show("Error updating drink: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtDrinkID.Text))
            {
                MessageBox.Show("Please select a drink to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDrinkID.Text, out int drinkID))
            {
                MessageBox.Show("Invalid Drink ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this drink?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Delete the drink
            string error = "";
            bool success = dbThucUong.DeleteThucUong(ref error, drinkID);
            if (success)
            {
                MessageBox.Show("Drink deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDrinks(); // Refresh the grid
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Error deleting drink: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDrinks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDrinks.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDrinks.SelectedRows[0];
                txtDrinkID.Text = row.Cells["id_thucUong"].Value.ToString();
                txtDrinkName.Text = row.Cells["Ten"].Value.ToString();
                //txtCategoryID.Text = row.Cells["id_loaiThucUong"].Value.ToString();
                cbbCategory.SelectedValue = row.Cells["id_loaiThucUong"].Value;
                txtPrice.Text = row.Cells["Gia"].Value.ToString();
                //txtStatus.Text = row.Cells["TrangThai"].Value.ToString();
                cbbStatus.SelectedValue = row.Cells["TrangThai"].Value;
            }
        }

        private void ClearInputs()
        {
            txtDrinkID.Text = "";
            txtDrinkName.Text = "";
            //txtCategoryID.Text = "";
            cbbStatus.SelectedIndex = 0;
            txtPrice.Text = "";
            
        }

        private void txtDrinkID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDrinkMenu_Click(object sender, EventArgs e)
        {

        }
        private string selectedImagePath;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Chọn ảnh",
                Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
                Multiselect = false
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog1.FileName;
                PicNew.Image = Image.FromFile(selectedImagePath);
                PicNew.SizeMode = PictureBoxSizeMode.StretchImage;
                lblnew.Text = Path.GetFileName(selectedImagePath);
            }
        }
    }
}
