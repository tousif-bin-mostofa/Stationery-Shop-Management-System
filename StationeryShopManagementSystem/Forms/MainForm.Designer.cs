namespace StationeryShopManagementSystem.Forms
{
    partial class MainForm
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
            this.lblTitle           = new System.Windows.Forms.Label();
            this.grpSummary         = new System.Windows.Forms.GroupBox();
            this.lblLowStockTitle   = new System.Windows.Forms.Label();
            this.dgvLowStock        = new System.Windows.Forms.DataGridView();
            this.lblSuppliersLabel  = new System.Windows.Forms.Label();
            this.lblTotalSuppliers  = new System.Windows.Forms.Label();
            this.lblCategoriesLabel = new System.Windows.Forms.Label();
            this.lblTotalCategories = new System.Windows.Forms.Label();
            this.lblProductsLabel   = new System.Windows.Forms.Label();
            this.lblTotalProducts   = new System.Windows.Forms.Label();
            this.grpNavigation      = new System.Windows.Forms.GroupBox();
            this.btnExit            = new System.Windows.Forms.Button();
            this.btnSuppliers       = new System.Windows.Forms.Button();
            this.btnCategories      = new System.Windows.Forms.Button();
            this.btnProducts        = new System.Windows.Forms.Button();

            this.grpSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            this.grpNavigation.SuspendLayout();
            this.SuspendLayout();

            // ---- lblTitle ----
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTitle.Location  = new System.Drawing.Point(12, 15);
            this.lblTitle.Size      = new System.Drawing.Size(560, 40);
            this.lblTitle.Text      = "Stationery Shop Management System";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ---- grpNavigation ----
            this.grpNavigation.Location = new System.Drawing.Point(12, 70);
            this.grpNavigation.Size     = new System.Drawing.Size(200, 200);
            this.grpNavigation.Text     = "Navigation";
            this.grpNavigation.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // btnProducts
            this.btnProducts.Location  = new System.Drawing.Point(15, 30);
            this.btnProducts.Size      = new System.Drawing.Size(170, 35);
            this.btnProducts.Text      = "Products";
            this.btnProducts.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnProducts.BackColor = System.Drawing.Color.SteelBlue;
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Click    += new System.EventHandler(this.btnProducts_Click);

            // btnCategories
            this.btnCategories.Location  = new System.Drawing.Point(15, 75);
            this.btnCategories.Size      = new System.Drawing.Size(170, 35);
            this.btnCategories.Text      = "Categories";
            this.btnCategories.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCategories.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCategories.ForeColor = System.Drawing.Color.White;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Click    += new System.EventHandler(this.btnCategories_Click);

            // btnSuppliers
            this.btnSuppliers.Location  = new System.Drawing.Point(15, 120);
            this.btnSuppliers.Size      = new System.Drawing.Size(170, 35);
            this.btnSuppliers.Text      = "Suppliers";
            this.btnSuppliers.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSuppliers.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSuppliers.ForeColor = System.Drawing.Color.White;
            this.btnSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuppliers.Click    += new System.EventHandler(this.btnSuppliers_Click);

            // btnExit
            this.btnExit.Location  = new System.Drawing.Point(15, 162);
            this.btnExit.Size      = new System.Drawing.Size(170, 30);
            this.btnExit.Text      = "Exit";
            this.btnExit.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnExit.BackColor = System.Drawing.Color.Firebrick;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Click    += new System.EventHandler(this.btnExit_Click);

            this.grpNavigation.Controls.Add(this.btnProducts);
            this.grpNavigation.Controls.Add(this.btnCategories);
            this.grpNavigation.Controls.Add(this.btnSuppliers);
            this.grpNavigation.Controls.Add(this.btnExit);

            // ---- grpSummary ----
            this.grpSummary.Location = new System.Drawing.Point(230, 70);
            this.grpSummary.Size     = new System.Drawing.Size(340, 340);
            this.grpSummary.Text     = "Summary";
            this.grpSummary.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // lblProductsLabel
            this.lblProductsLabel.Location  = new System.Drawing.Point(15, 30);
            this.lblProductsLabel.Size      = new System.Drawing.Size(140, 25);
            this.lblProductsLabel.Text      = "Total Products:";
            this.lblProductsLabel.Font      = new System.Drawing.Font("Segoe UI", 9.5F);

            // lblTotalProducts
            this.lblTotalProducts.Location  = new System.Drawing.Point(160, 30);
            this.lblTotalProducts.Size      = new System.Drawing.Size(60, 25);
            this.lblTotalProducts.Text      = "0";
            this.lblTotalProducts.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalProducts.ForeColor = System.Drawing.Color.DarkSlateBlue;

            // lblCategoriesLabel
            this.lblCategoriesLabel.Location = new System.Drawing.Point(15, 60);
            this.lblCategoriesLabel.Size     = new System.Drawing.Size(140, 25);
            this.lblCategoriesLabel.Text     = "Total Categories:";
            this.lblCategoriesLabel.Font     = new System.Drawing.Font("Segoe UI", 9.5F);

            // lblTotalCategories
            this.lblTotalCategories.Location  = new System.Drawing.Point(160, 60);
            this.lblTotalCategories.Size      = new System.Drawing.Size(60, 25);
            this.lblTotalCategories.Text      = "0";
            this.lblTotalCategories.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalCategories.ForeColor = System.Drawing.Color.SeaGreen;

            // lblSuppliersLabel
            this.lblSuppliersLabel.Location = new System.Drawing.Point(15, 90);
            this.lblSuppliersLabel.Size     = new System.Drawing.Size(140, 25);
            this.lblSuppliersLabel.Text     = "Total Suppliers:";
            this.lblSuppliersLabel.Font     = new System.Drawing.Font("Segoe UI", 9.5F);

            // lblTotalSuppliers
            this.lblTotalSuppliers.Location  = new System.Drawing.Point(160, 90);
            this.lblTotalSuppliers.Size      = new System.Drawing.Size(60, 25);
            this.lblTotalSuppliers.Text      = "0";
            this.lblTotalSuppliers.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalSuppliers.ForeColor = System.Drawing.Color.DarkOrange;

            // lblLowStockTitle
            this.lblLowStockTitle.Location  = new System.Drawing.Point(15, 125);
            this.lblLowStockTitle.Size      = new System.Drawing.Size(310, 20);
            this.lblLowStockTitle.Text      = "Low Stock Products (Stock ≤ Reorder Level):";
            this.lblLowStockTitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLowStockTitle.ForeColor = System.Drawing.Color.Firebrick;

            // dgvLowStock
            this.dgvLowStock.Location             = new System.Drawing.Point(15, 148);
            this.dgvLowStock.Size                 = new System.Drawing.Size(310, 178);
            this.dgvLowStock.ReadOnly             = true;
            this.dgvLowStock.AllowUserToAddRows   = false;
            this.dgvLowStock.AllowUserToDeleteRows = false;
            this.dgvLowStock.SelectionMode        = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLowStock.BackgroundColor      = System.Drawing.SystemColors.Window;
            this.dgvLowStock.AutoSizeColumnsMode  = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLowStock.Font                 = new System.Drawing.Font("Segoe UI", 8.5F);

            this.grpSummary.Controls.Add(this.lblProductsLabel);
            this.grpSummary.Controls.Add(this.lblTotalProducts);
            this.grpSummary.Controls.Add(this.lblCategoriesLabel);
            this.grpSummary.Controls.Add(this.lblTotalCategories);
            this.grpSummary.Controls.Add(this.lblSuppliersLabel);
            this.grpSummary.Controls.Add(this.lblTotalSuppliers);
            this.grpSummary.Controls.Add(this.lblLowStockTitle);
            this.grpSummary.Controls.Add(this.dgvLowStock);

            // ---- MainForm ----
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(584, 430);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpNavigation);
            this.Controls.Add(this.grpSummary);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.Name                = "MainForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Stationery Shop Management System";
            this.Load               += new System.EventHandler(this.MainForm_Load);

            this.grpSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            this.grpNavigation.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label            lblTitle;
        private System.Windows.Forms.GroupBox         grpSummary;
        private System.Windows.Forms.Label            lblLowStockTitle;
        private System.Windows.Forms.DataGridView     dgvLowStock;
        private System.Windows.Forms.Label            lblSuppliersLabel;
        private System.Windows.Forms.Label            lblTotalSuppliers;
        private System.Windows.Forms.Label            lblCategoriesLabel;
        private System.Windows.Forms.Label            lblTotalCategories;
        private System.Windows.Forms.Label            lblProductsLabel;
        private System.Windows.Forms.Label            lblTotalProducts;
        private System.Windows.Forms.GroupBox         grpNavigation;
        private System.Windows.Forms.Button           btnExit;
        private System.Windows.Forms.Button           btnSuppliers;
        private System.Windows.Forms.Button           btnCategories;
        private System.Windows.Forms.Button           btnProducts;
    }
}
