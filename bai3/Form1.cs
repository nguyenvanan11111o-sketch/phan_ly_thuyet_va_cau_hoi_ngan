using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bai03
{
    public partial class Form1 : Form
    {
        private BindingList<Product> products =
            new BindingList<Product>();

        private Product? selectedProduct;

        private string selectedImagePath = "";

        public Form1()
        {
            InitializeComponent();
        }

        // =====================================
        // FORM LOAD
        // =====================================
        private void Form1_Load(
            object sender,
            EventArgs e)
        {
            LoadCategories();

            bindingSourceProducts.DataSource =
                products;

            dgvProducts.DataSource =
                bindingSourceProducts;

            UpdateStatus();
        }

        // =====================================
        // CATEGORY
        // =====================================
        private void LoadCategories()
        {
            List<Category> categories =
                new List<Category>()
                {
                    new Category
                    {
                        Id = 1,
                        Name = "Điện thoại"
                    },

                    new Category
                    {
                        Id = 2,
                        Name = "Laptop"
                    },

                    new Category
                    {
                        Id = 3,
                        Name = "Phụ kiện"
                    }
                };

            cboCategory.DataSource =
                categories;

            cboCategory.DisplayMember =
                "Name";

            cboCategory.ValueMember =
                "Id";
        }

        // =====================================
        // VALIDATION
        // =====================================
        private bool ValidateInput()
        {
            errorProvider.Clear();

            bool valid = true;

            if (string.IsNullOrWhiteSpace(
                txtProductName.Text))
            {
                errorProvider.SetError(
                    txtProductName,
                    "Tên sản phẩm không được để trống!"
                );

                valid = false;
            }

            if (!decimal.TryParse(
                    txtUnitPrice.Text,
                    out decimal price)
                || price <= 0)
            {
                errorProvider.SetError(
                    txtUnitPrice,
                    "Đơn giá phải lớn hơn 0!"
                );

                valid = false;
            }

            if (!int.TryParse(
                    txtQuantity.Text,
                    out int quantity)
                || quantity < 0)
            {
                errorProvider.SetError(
txtQuantity,
                    "Số lượng phải >= 0!"
                );

                valid = false;
            }

            return valid;
        }

        // =====================================
        // CHỌN ẢNH
        // =====================================
        private void btnChooseImage_Click(
            object sender,
            EventArgs e)
        {
            openFileDialog.Filter =
                "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            openFileDialog.Title =
                "Chọn ảnh sản phẩm";

            if (openFileDialog.ShowDialog()
                == DialogResult.OK)
            {
                selectedImagePath =
                    openFileDialog.FileName;

                LoadImage(
                    selectedImagePath
                );
            }
        }

        private void LoadImage(
            string path)
        {
            if (picAvatar.Image != null)
            {
                picAvatar.Image.Dispose();
                picAvatar.Image = null;
            }

            if (string.IsNullOrWhiteSpace(path)
                || !File.Exists(path))
            {
                return;
            }

            using Image image =
                Image.FromFile(path);

            picAvatar.Image =
                new Bitmap(image);
        }

        // =====================================
        // THÊM MỚI
        // =====================================
        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            Category? category =
                cboCategory.SelectedItem
                as Category;

            Product product =
                new Product()
                {
                    ProductId =
                        txtProductId.Text.Trim(),

                    ProductName =
                        txtProductName.Text.Trim(),

                    CategoryId =
                        category?.Id ?? 0,

                    CategoryName =
                        category?.Name ?? "",

                    UnitPrice =
                        decimal.Parse(
                            txtUnitPrice.Text
                        ),

                    Quantity =
                        int.Parse(
                            txtQuantity.Text
                        ),

                    ImagePath =
                        selectedImagePath
                };

            products.Add(product);

            bindingSourceProducts.DataSource =
                products;

            UpdateStatus();

            ClearInput();
        }

        // =====================================
        // CLICK DÒNG DATAGRIDVIEW
        // =====================================
        private void dgvProducts_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvProducts.Rows[e.RowIndex]
                .DataBoundItem is not Product product)
            {
                return;
            }

            selectedProduct =
                product;

            txtProductId.Text =
                product.ProductId;

            txtProductName.Text =
                product.ProductName;

            txtUnitPrice.Text =
                product.UnitPrice.ToString();

            txtQuantity.Text =
                product.Quantity.ToString();

            cboCategory.SelectedValue =
                product.CategoryId;

            selectedImagePath =
                product.ImagePath;

            LoadImage(
                selectedImagePath
            );
        }

        // =====================================
        // CẬP NHẬT
        // =====================================
        private void btnUpdate_Click(
            object sender,
            EventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần cập nhật!"
                );

                return;
            }

            if (!ValidateInput())
            {
                return;
            }

            Category? category =
                cboCategory.SelectedItem
                as Category;

            selectedProduct.ProductId =
                txtProductId.Text.Trim();

            selectedProduct.ProductName =
                txtProductName.Text.Trim();

            selectedProduct.CategoryId =
                category?.Id ?? 0;

            selectedProduct.CategoryName =
                category?.Name ?? "";

            selectedProduct.UnitPrice =
                decimal.Parse(
                    txtUnitPrice.Text
                );

            selectedProduct.Quantity =
                int.Parse(
                    txtQuantity.Text
                );

            selectedProduct.ImagePath =
                selectedImagePath;

            dgvProducts.Refresh();

            UpdateStatus();

            ClearInput();
        }

        // =====================================
        // XÓA
        // =====================================
        private void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần xóa!"
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Bạn có chắc muốn xóa sản phẩm này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                products.Remove(
selectedProduct
                );

                selectedProduct =
                    null;

                bindingSourceProducts.DataSource =
                    products;

                UpdateStatus();

                ClearInput();
            }
        }

        // =====================================
        // SEARCH LIVE
        // =====================================
        private void txtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            string keyword =
                txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(
                keyword))
            {
                bindingSourceProducts.DataSource =
                    products;

                return;
            }

            List<Product> result =
                products
                .Where(
                    p =>
                    p.ProductName.Contains(
                        keyword,
                        StringComparison.OrdinalIgnoreCase
                    )
                )
                .ToList();

            bindingSourceProducts.DataSource =
                new BindingList<Product>(
                    result
                );
        }

        // =====================================
        // STATUS
        // =====================================
        private void UpdateStatus()
        {
            lblTotalProducts.Text =
                "Tổng số sản phẩm: "
                + products.Count;
        }

        // =====================================
        // CLEAR
        // =====================================
        private void ClearInput()
        {
            txtProductId.Clear();

            txtProductName.Clear();

            txtUnitPrice.Clear();

            txtQuantity.Clear();

            if (cboCategory.Items.Count > 0)
            {
                cboCategory.SelectedIndex =
                    0;
            }

            if (picAvatar.Image != null)
            {
                picAvatar.Image.Dispose();

                picAvatar.Image =
                    null;
            }

            selectedImagePath =
                "";

            selectedProduct =
                null;

            errorProvider.Clear();
        }

        // =====================================
        // EXPORT CSV
        // =====================================
        private void exportCSVToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            saveFileDialog.Filter =
                "CSV Files|*.csv";

            saveFileDialog.FileName =
                "products.csv";

            if (saveFileDialog.ShowDialog()
                != DialogResult.OK)
            {
                return;
            }

            using StreamWriter writer =
                new StreamWriter(
                    saveFileDialog.FileName,
                    false,
                    new UTF8Encoding(true)
);

            writer.WriteLine(
                "MaSP,TenSP,DanhMuc,DonGia,SoLuong"
            );

            foreach (Product product
                     in products)
            {
                writer.WriteLine(
                    CsvEscape(product.ProductId)
                    + ","
                    + CsvEscape(product.ProductName)
                    + ","
                    + CsvEscape(product.CategoryName)
                    + ","
                    + product.UnitPrice
                    + ","
                    + product.Quantity
                );
            }

            MessageBox.Show(
                "Xuất CSV thành công!"
            );
        }

        private string CsvEscape(
            string value)
        {
            if (value.Contains(",")
                || value.Contains("\"")
                || value.Contains("\n"))
            {
                value =
                    value.Replace(
                        "\"",
                        "\"\""
                    );

                return "\""
                       + value
                       + "\"";
            }

            return value;
        }

        // =====================================
        // EXIT
        // =====================================
        private void exitToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}
