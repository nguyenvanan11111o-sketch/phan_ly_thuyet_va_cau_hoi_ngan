using System.Drawing;
using System.Windows.Forms;

namespace Bai03
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exportCSVToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;

        private TableLayoutPanel tableMain;
        private TableLayoutPanel tableInput;
        private TableLayoutPanel tableRight;

        private Label lblProductId;
        private Label lblProductName;
        private Label lblCategory;
        private Label lblUnitPrice;
        private Label lblQuantity;
        private Label lblAvatar;
        private Label lblSearch;

        private TextBox txtProductId;
        private TextBox txtProductName;
        private TextBox txtUnitPrice;
        private TextBox txtQuantity;
        private TextBox txtSearch;

        private ComboBox cboCategory;

        private PictureBox picAvatar;

        private Button btnChooseImage;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;

        private DataGridView dgvProducts;

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblTotalProducts;

        private ErrorProvider errorProvider;

        private BindingSource bindingSourceProducts;

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components =
                new System.ComponentModel.Container();

            menuStrip1 =
                new MenuStrip();

            fileToolStripMenuItem =
                new ToolStripMenuItem();

            exportCSVToolStripMenuItem =
                new ToolStripMenuItem();

            exitToolStripMenuItem =
                new ToolStripMenuItem();

            tableMain =
                new TableLayoutPanel();

            tableInput =
                new TableLayoutPanel();

            tableRight =
                new TableLayoutPanel();

            lblProductId =
                new Label();

            lblProductName =
                new Label();

            lblCategory =
                new Label();

            lblUnitPrice =
                new Label();

            lblQuantity =
                new Label();

            lblAvatar =
                new Label();

            lblSearch =
                new Label();

            txtProductId =
                new TextBox();

            txtProductName =
                new TextBox();

            txtUnitPrice =
                new TextBox();

            txtQuantity =
new TextBox();

            txtSearch =
                new TextBox();

            cboCategory =
                new ComboBox();

            picAvatar =
                new PictureBox();

            btnChooseImage =
                new Button();

            btnAdd =
                new Button();

            btnUpdate =
                new Button();

            btnDelete =
                new Button();

            dgvProducts =
                new DataGridView();

            statusStrip1 =
                new StatusStrip();

            lblTotalProducts =
                new ToolStripStatusLabel();

            errorProvider =
                new ErrorProvider(components);

            bindingSourceProducts =
                new BindingSource(components);

            openFileDialog =
                new OpenFileDialog();

            saveFileDialog =
                new SaveFileDialog();

            SuspendLayout();

            // ============================
            // FORM
            // ============================
            Text = "TechMart Product Manager";

            StartPosition =
                FormStartPosition.CenterScreen;

            Width = 1200;
            Height = 700;

            MinimumSize =
                new Size(900, 550);

            // ============================
            // MENU
            // ============================
            fileToolStripMenuItem.Text =
                "File";

            exportCSVToolStripMenuItem.Text =
                "Export CSV";

            exportCSVToolStripMenuItem.ShortcutKeys =
                Keys.Control | Keys.E;

            exitToolStripMenuItem.Text =
                "Exit";

            exitToolStripMenuItem.ShortcutKeys =
                Keys.Control | Keys.X;

            fileToolStripMenuItem.DropDownItems.Add(
                exportCSVToolStripMenuItem
            );

            fileToolStripMenuItem.DropDownItems.Add(
                exitToolStripMenuItem
            );

            menuStrip1.Items.Add(
                fileToolStripMenuItem
            );

            menuStrip1.Dock =
                DockStyle.Top;

            MainMenuStrip =
                menuStrip1;

            // ============================
            // MAIN TABLE
            // ============================
            tableMain.Dock =
                DockStyle.Fill;

            tableMain.ColumnCount =
                2;

            tableMain.RowCount =
                1;

            tableMain.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    35F
                )
            );

            tableMain.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    65F
                )
            );

            tableMain.Padding =
                new Padding(10);

            // ============================
            // LEFT INPUT
// ============================
            tableInput.Dock =
                DockStyle.Fill;

            tableInput.ColumnCount =
                2;

            tableInput.RowCount =
                8;

            tableInput.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    35F
                )
            );

            tableInput.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    65F
                )
            );

            lblProductId.Text =
                "Mã SP:";

            lblProductName.Text =
                "Tên SP:";

            lblCategory.Text =
                "Danh mục:";

            lblUnitPrice.Text =
                "Đơn giá:";

            lblQuantity.Text =
                "Số lượng:";

            lblAvatar.Text =
                "Ảnh:";

            txtProductId.Dock =
                DockStyle.Fill;

            txtProductName.Dock =
                DockStyle.Fill;

            txtUnitPrice.Dock =
                DockStyle.Fill;

            txtQuantity.Dock =
                DockStyle.Fill;

            cboCategory.Dock =
                DockStyle.Fill;

            cboCategory.DropDownStyle =
                ComboBoxStyle.DropDownList;

            picAvatar.Dock =
                DockStyle.Fill;

            picAvatar.Height =
                160;

            picAvatar.BorderStyle =
                BorderStyle.FixedSingle;

            picAvatar.SizeMode =
                PictureBoxSizeMode.Zoom;

            btnChooseImage.Text =
                "Chọn ảnh";

            btnChooseImage.Dock =
                DockStyle.Fill;

            FlowLayoutPanel panelButtons =
                new FlowLayoutPanel();

            panelButtons.Dock =
                DockStyle.Fill;

            panelButtons.AutoSize =
                true;

            btnAdd.Text =
                "Thêm mới";

            btnUpdate.Text =
                "Cập nhật";

            btnDelete.Text =
                "Xóa";

            panelButtons.Controls.Add(
                btnAdd
            );

            panelButtons.Controls.Add(
                btnUpdate
            );

            panelButtons.Controls.Add(
                btnDelete
            );

            tableInput.Controls.Add(
                lblProductId,
                0,
                0
            );

            tableInput.Controls.Add(
                txtProductId,
                1,
                0
            );

            tableInput.Controls.Add(
                lblProductName,
                0,
                1
            );

            tableInput.Controls.Add(
                txtProductName,
                1,
                1
            );

            tableInput.Controls.Add(
                lblCategory,
                0,
                2
            );

            tableInput.Controls.Add(
cboCategory,
                1,
                2
            );

            tableInput.Controls.Add(
                lblUnitPrice,
                0,
                3
            );

            tableInput.Controls.Add(
                txtUnitPrice,
                1,
                3
            );

            tableInput.Controls.Add(
                lblQuantity,
                0,
                4
            );

            tableInput.Controls.Add(
                txtQuantity,
                1,
                4
            );

            tableInput.Controls.Add(
                lblAvatar,
                0,
                5
            );

            tableInput.Controls.Add(
                picAvatar,
                1,
                5
            );

            tableInput.Controls.Add(
                btnChooseImage,
                1,
                6
            );

            tableInput.Controls.Add(
                panelButtons,
                0,
                7
            );

            tableInput.SetColumnSpan(
                panelButtons,
                2
            );

            // ============================
            // RIGHT AREA
            // ============================
            tableRight.Dock =
                DockStyle.Fill;

            tableRight.ColumnCount =
                1;

            tableRight.RowCount =
                2;

            tableRight.RowStyles.Add(
                new RowStyle(
                    SizeType.AutoSize
                )
            );

            tableRight.RowStyles.Add(
                new RowStyle(
                    SizeType.Percent,
                    100F
                )
            );

            FlowLayoutPanel searchPanel =
                new FlowLayoutPanel();

            searchPanel.Dock =
                DockStyle.Fill;

            searchPanel.AutoSize =
                true;

            lblSearch.Text =
                "Tìm kiếm:";

            txtSearch.Width =
                300;

            searchPanel.Controls.Add(
                lblSearch
            );

            searchPanel.Controls.Add(
                txtSearch
            );

            // ============================
            // DATAGRIDVIEW
            // ============================
            dgvProducts.Dock =
                DockStyle.Fill;

            dgvProducts.AutoGenerateColumns =
                false;

            dgvProducts.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvProducts.MultiSelect =
                false;

            dgvProducts.ReadOnly =
                true;

            dgvProducts.AllowUserToAddRows =
                false;

            dgvProducts.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewTextBoxColumn colId =
                new DataGridViewTextBoxColumn();

            colId.HeaderText =
                "Mã SP";
colId.DataPropertyName =
                "ProductId";

            DataGridViewTextBoxColumn colName =
                new DataGridViewTextBoxColumn();

            colName.HeaderText =
                "Tên SP";

            colName.DataPropertyName =
                "ProductName";

            DataGridViewTextBoxColumn colCategory =
                new DataGridViewTextBoxColumn();

            colCategory.HeaderText =
                "Danh Mục";

            colCategory.DataPropertyName =
                "CategoryName";

            DataGridViewTextBoxColumn colPrice =
                new DataGridViewTextBoxColumn();

            colPrice.HeaderText =
                "Đơn Giá";

            colPrice.DataPropertyName =
                "UnitPrice";

            colPrice.DefaultCellStyle.Format =
                "N0";

            DataGridViewTextBoxColumn colQuantity =
                new DataGridViewTextBoxColumn();

            colQuantity.HeaderText =
                "Số Lượng";

            colQuantity.DataPropertyName =
                "Quantity";

            dgvProducts.Columns.AddRange(
                colId,
                colName,
                colCategory,
                colPrice,
                colQuantity
            );

            tableRight.Controls.Add(
                searchPanel,
                0,
                0
            );

            tableRight.Controls.Add(
                dgvProducts,
                0,
                1
            );

            tableMain.Controls.Add(
                tableInput,
                0,
                0
            );

            tableMain.Controls.Add(
                tableRight,
                1,
                0
            );

            // ============================
            // STATUS
            // ============================
            lblTotalProducts.Text =
                "Tổng số sản phẩm: 0";

            statusStrip1.Items.Add(
                lblTotalProducts
            );

            statusStrip1.Dock =
                DockStyle.Bottom;

            // ============================
            // ERROR PROVIDER
            // ============================
            errorProvider.ContainerControl =
                this;

            // ============================
            // EVENTS
            // ============================
            Load += Form1_Load;

            btnChooseImage.Click +=
                btnChooseImage_Click;

            btnAdd.Click +=
                btnAdd_Click;

            btnUpdate.Click +=
                btnUpdate_Click;

            btnDelete.Click +=
                btnDelete_Click;

            dgvProducts.CellClick +=
                dgvProducts_CellClick;

            txtSearch.TextChanged +=
                txtSearch_TextChanged;

            exportCSVToolStripMenuItem.Click +=
                exportCSVToolStripMenuItem_Click;

            exitToolStripMenuItem.Click +=
exitToolStripMenuItem_Click;

            // ============================
            // ADD CONTROLS
            // ============================
            Controls.Add(
                tableMain
            );

            Controls.Add(
                statusStrip1
            );

            Controls.Add(
                menuStrip1
            );

            MainMenuStrip =
                menuStrip1;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
