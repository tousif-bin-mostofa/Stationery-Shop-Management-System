namespace StationeryShopManagementSystem.Forms
{
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle        = new System.Windows.Forms.Label();
            this.grpInput        = new System.Windows.Forms.GroupBox();
            this.lblProductId    = new System.Windows.Forms.Label();
            this.txtProductId    = new System.Windows.Forms.TextBox();
            this.lblProductName  = new System.Windows.Forms.Label();
            this.txtProductName  = new System.Windows.Forms.TextBox();
            this.lblCategory     = new System.Windows.Forms.Label();
            this.cmbCategory     = new System.Windows.Forms.ComboBox();
            this.lblSupplier     = new System.Windows.Forms.Label();
            this.cmbSupplier     = new System.Windows.Forms.ComboBox();
            this.lblPrice        = new System.Windows.Forms.Label();
            this.txtPrice        = new System.Windows.Forms.TextBox();
            this.lblQuantity     = new System.Windows.Forms.Label();
            this.txtQuantity     = new System.Windows.Forms.TextBox();
            this.lblReorderLevel = new System.Windows.Forms.Label();
            this.txtReorderLevel = new System.Windows.Forms.TextBox();
            this.grpButtons      = new System.Windows.Forms.GroupBox();
            this.btnAdd          = new System.Windows.Forms.Button();
            this.btnUpdate       = new System.Windows.Forms.Button();
            this.btnDelete       = new System.Windows.Forms.Button();
            this.btnClear        = new System.Windows.Forms.Button();
            this.grpSearch       = new System.Windows.Forms.GroupBox();
            this.lblSearch       = new System.Windows.Forms.Label();
            this.txtSearch       = new System.Windows.Forms.TextBox();
            this.btnSearch       = new System.Windows.Forms.Button();
            this.dgvProducts     = new System.Windows.Forms.DataGridView();

            this.grpInput.SuspendLayout();
            this.grpButtons.SuspendLayout();
            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // ---- lblTitle ----
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTitle.Location  = new System.Drawing.Point(12, 10);
            this.lblTitle.Size      = new System.Drawing.Size(760, 35);
            this.lblTitle.Text      = "Product Management";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ---- grpInput ----
            this.grpInput.Location = new System.Drawing.Point(12, 55);
            this.grpInput.Size     = new System.Drawing.Size(760, 165);
            this.grpInput.Text     = "Product Details";
            this.grpInput.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            int col1L = 15,  col1I = 115, ctrlW = 180;
            int col2L = 330, col2I = 440;
            int row1Y = 26, row2Y = 62, row3Y = 98, row4Y = 130;

            // Product ID
            this.lblProductId.Location = new System.Drawing.Point(col1L, row1Y + 2);
            this.lblProductId.Size     = new System.Drawing.Size(95, 22);
            this.lblProductId.Text     = "Product ID:";
            this.lblProductId.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.txtProductId.Location  = new System.Drawing.Point(col1I, row1Y);
            this.txtProductId.Size      = new System.Drawing.Size(70, 22);
            this.txtProductId.ReadOnly  = true;
            this.txtProductId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtProductId.Font      = new System.Drawing.Font("Segoe UI", 9F);

            // Product Name
            this.lblProductName.Location = new System.Drawing.Point(col2L, row1Y + 2);
            this.lblProductName.Size     = new System.Drawing.Size(100, 22);
            this.lblProductName.Text     = "Product Name:";
            this.lblProductName.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.txtProductName.Location = new System.Drawing.Point(col2I, row1Y);
            this.txtProductName.Size     = new System.Drawing.Size(ctrlW, 22);
            this.txtProductName.Font     = new System.Drawing.Font("Segoe UI", 9F);

            // Category
            this.lblCategory.Location = new System.Drawing.Point(col1L, row2Y + 2);
            this.lblCategory.Size     = new System.Drawing.Size(95, 22);
            this.lblCategory.Text     = "Category:";
            this.lblCategory.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.cmbCategory.Location         = new System.Drawing.Point(col1I, row2Y);
            this.cmbCategory.Size             = new System.Drawing.Size(ctrlW, 22);
            this.cmbCategory.DropDownStyle    = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font             = new System.Drawing.Font("Segoe UI", 9F);

            // Supplier
            this.lblSupplier.Location = new System.Drawing.Point(col2L, row2Y + 2);
            this.lblSupplier.Size     = new System.Drawing.Size(100, 22);
            this.lblSupplier.Text     = "Supplier:";
            this.lblSupplier.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.cmbSupplier.Location      = new System.Drawing.Point(col2I, row2Y);
            this.cmbSupplier.Size          = new System.Drawing.Size(ctrlW, 22);
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.Font          = new System.Drawing.Font("Segoe UI", 9F);

            // Unit Price
            this.lblPrice.Location = new System.Drawing.Point(col1L, row3Y + 2);
            this.lblPrice.Size     = new System.Drawing.Size(95, 22);
            this.lblPrice.Text     = "Unit Price:";
            this.lblPrice.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.txtPrice.Location = new System.Drawing.Point(col1I, row3Y);
            this.txtPrice.Size     = new System.Drawing.Size(ctrlW, 22);
            this.txtPrice.Font     = new System.Drawing.Font("Segoe UI", 9F);

            // Quantity
            this.lblQuantity.Location = new System.Drawing.Point(col2L, row3Y + 2);
            this.lblQuantity.Size     = new System.Drawing.Size(100, 22);
            this.lblQuantity.Text     = "Qty in Stock:";
            this.lblQuantity.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.txtQuantity.Location = new System.Drawing.Point(col2I, row3Y);
            this.txtQuantity.Size     = new System.Drawing.Size(ctrlW, 22);
            this.txtQuantity.Font     = new System.Drawing.Font("Segoe UI", 9F);

            // Reorder Level
            this.lblReorderLevel.Location = new System.Drawing.Point(col1L, row4Y + 2);
            this.lblReorderLevel.Size     = new System.Drawing.Size(95, 22);
            this.lblReorderLevel.Text     = "Reorder Level:";
            this.lblReorderLevel.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.txtReorderLevel.Location = new System.Drawing.Point(col1I, row4Y);
            this.txtReorderLevel.Size     = new System.Drawing.Size(ctrlW, 22);
            this.txtReorderLevel.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.grpInput.Controls.Add(this.lblProductId);
            this.grpInput.Controls.Add(this.txtProductId);
            this.grpInput.Controls.Add(this.lblProductName);
            this.grpInput.Controls.Add(this.txtProductName);
            this.grpInput.Controls.Add(this.lblCategory);
            this.grpInput.Controls.Add(this.cmbCategory);
            this.grpInput.Controls.Add(this.lblSupplier);
            this.grpInput.Controls.Add(this.cmbSupplier);
            this.grpInput.Controls.Add(this.lblPrice);
            this.grpInput.Controls.Add(this.txtPrice);
            this.grpInput.Controls.Add(this.lblQuantity);
            this.grpInput.Controls.Add(this.txtQuantity);
            this.grpInput.Controls.Add(this.lblReorderLevel);
            this.grpInput.Controls.Add(this.txtReorderLevel);

            // ---- grpButtons ----
            this.grpButtons.Location = new System.Drawing.Point(12, 230);
            this.grpButtons.Size     = new System.Drawing.Size(760, 60);
            this.grpButtons.Text     = "Actions";
            this.grpButtons.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.btnAdd.Location  = new System.Drawing.Point(15,  22);
            this.btnAdd.Size      = new System.Drawing.Size(130, 28);
            this.btnAdd.Text      = "Add Product";
            this.btnAdd.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Click    += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location  = new System.Drawing.Point(160, 22);
            this.btnUpdate.Size      = new System.Drawing.Size(130, 28);
            this.btnUpdate.Text      = "Update Product";
            this.btnUpdate.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Click    += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location  = new System.Drawing.Point(305, 22);
            this.btnDelete.Size      = new System.Drawing.Size(130, 28);
            this.btnDelete.Text      = "Delete Product";
            this.btnDelete.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Click    += new System.EventHandler(this.btnDelete_Click);

            this.btnClear.Location  = new System.Drawing.Point(450, 22);
            this.btnClear.Size      = new System.Drawing.Size(130, 28);
            this.btnClear.Text      = "Clear";
            this.btnClear.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Click    += new System.EventHandler(this.btnClear_Click);

            this.grpButtons.Controls.Add(this.btnAdd);
            this.grpButtons.Controls.Add(this.btnUpdate);
            this.grpButtons.Controls.Add(this.btnDelete);
            this.grpButtons.Controls.Add(this.btnClear);

            // ---- grpSearch ----
            this.grpSearch.Location = new System.Drawing.Point(12, 300);
            this.grpSearch.Size     = new System.Drawing.Size(760, 55);
            this.grpSearch.Text     = "Search Products";
            this.grpSearch.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.lblSearch.Location = new System.Drawing.Point(15, 22);
            this.lblSearch.Size     = new System.Drawing.Size(100, 22);
            this.lblSearch.Text     = "Search by Name:";
            this.lblSearch.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.txtSearch.Location = new System.Drawing.Point(120, 20);
            this.txtSearch.Size     = new System.Drawing.Size(300, 22);
            this.txtSearch.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.btnSearch.Location  = new System.Drawing.Point(435, 19);
            this.btnSearch.Size      = new System.Drawing.Size(100, 26);
            this.btnSearch.Text      = "Search";
            this.btnSearch.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Click    += new System.EventHandler(this.btnSearch_Click);

            this.grpSearch.Controls.Add(this.lblSearch);
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Controls.Add(this.btnSearch);

            // ---- dgvProducts ----
            this.dgvProducts.Location              = new System.Drawing.Point(12, 368);
            this.dgvProducts.Size                  = new System.Drawing.Size(760, 260);
            this.dgvProducts.ReadOnly              = true;
            this.dgvProducts.AllowUserToAddRows    = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect           = false;
            this.dgvProducts.BackgroundColor       = System.Drawing.SystemColors.Window;
            this.dgvProducts.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.Font                  = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvProducts.CellClick            += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);

            // ---- ProductForm ----
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(784, 645);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.dgvProducts);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.Name                = "ProductForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Product Management";
            this.Load               += new System.EventHandler(this.ProductForm_Load);

            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpButtons.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.GroupBox       grpInput;
        private System.Windows.Forms.Label          lblProductId;
        private System.Windows.Forms.TextBox        txtProductId;
        private System.Windows.Forms.Label          lblProductName;
        private System.Windows.Forms.TextBox        txtProductName;
        private System.Windows.Forms.Label          lblCategory;
        private System.Windows.Forms.ComboBox       cmbCategory;
        private System.Windows.Forms.Label          lblSupplier;
        private System.Windows.Forms.ComboBox       cmbSupplier;
        private System.Windows.Forms.Label          lblPrice;
        private System.Windows.Forms.TextBox        txtPrice;
        private System.Windows.Forms.Label          lblQuantity;
        private System.Windows.Forms.TextBox        txtQuantity;
        private System.Windows.Forms.Label          lblReorderLevel;
        private System.Windows.Forms.TextBox        txtReorderLevel;
        private System.Windows.Forms.GroupBox       grpButtons;
        private System.Windows.Forms.Button         btnAdd;
        private System.Windows.Forms.Button         btnUpdate;
        private System.Windows.Forms.Button         btnDelete;
        private System.Windows.Forms.Button         btnClear;
        private System.Windows.Forms.GroupBox       grpSearch;
        private System.Windows.Forms.Label          lblSearch;
        private System.Windows.Forms.TextBox        txtSearch;
        private System.Windows.Forms.Button         btnSearch;
        private System.Windows.Forms.DataGridView   dgvProducts;
    }
}
