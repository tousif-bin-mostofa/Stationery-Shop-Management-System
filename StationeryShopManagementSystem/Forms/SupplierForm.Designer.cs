namespace StationeryShopManagementSystem.Forms
{
    partial class SupplierForm
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
            this.lblSupplierId   = new System.Windows.Forms.Label();
            this.txtSupplierId   = new System.Windows.Forms.TextBox();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.lblPhone        = new System.Windows.Forms.Label();
            this.txtPhone        = new System.Windows.Forms.TextBox();
            this.lblEmail        = new System.Windows.Forms.Label();
            this.txtEmail        = new System.Windows.Forms.TextBox();
            this.lblAddress      = new System.Windows.Forms.Label();
            this.txtAddress      = new System.Windows.Forms.TextBox();
            this.grpButtons      = new System.Windows.Forms.GroupBox();
            this.btnAdd          = new System.Windows.Forms.Button();
            this.btnUpdate       = new System.Windows.Forms.Button();
            this.btnDelete       = new System.Windows.Forms.Button();
            this.btnClear        = new System.Windows.Forms.Button();
            this.dgvSuppliers    = new System.Windows.Forms.DataGridView();

            this.grpInput.SuspendLayout();
            this.grpButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
            this.SuspendLayout();

            // ---- lblTitle ----
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTitle.Location  = new System.Drawing.Point(12, 10);
            this.lblTitle.Size      = new System.Drawing.Size(560, 35);
            this.lblTitle.Text      = "Supplier Management";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ---- grpInput ----
            this.grpInput.Location = new System.Drawing.Point(12, 55);
            this.grpInput.Size     = new System.Drawing.Size(560, 160);
            this.grpInput.Text     = "Supplier Details";
            this.grpInput.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            int labelX  = 15;
            int inputX  = 130;
            int inputW  = 200;
            int rowH    = 30;

            // Row 1: Supplier ID
            this.lblSupplierId.Location = new System.Drawing.Point(labelX, 28);
            this.lblSupplierId.Size     = new System.Drawing.Size(110, 22);
            this.lblSupplierId.Text     = "Supplier ID:";
            this.lblSupplierId.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.txtSupplierId.Location  = new System.Drawing.Point(inputX, 26);
            this.txtSupplierId.Size      = new System.Drawing.Size(80, 22);
            this.txtSupplierId.ReadOnly  = true;
            this.txtSupplierId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSupplierId.Font      = new System.Drawing.Font("Segoe UI", 9F);

            // Row 1 (right): Supplier Name
            this.lblSupplierName.Location = new System.Drawing.Point(290, 28);
            this.lblSupplierName.Size     = new System.Drawing.Size(100, 22);
            this.lblSupplierName.Text     = "Supplier Name:";
            this.lblSupplierName.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.txtSupplierName.Location = new System.Drawing.Point(395, 26);
            this.txtSupplierName.Size     = new System.Drawing.Size(150, 22);
            this.txtSupplierName.Font     = new System.Drawing.Font("Segoe UI", 9F);

            // Row 2: Phone
            this.lblPhone.Location = new System.Drawing.Point(labelX, 28 + rowH);
            this.lblPhone.Size     = new System.Drawing.Size(110, 22);
            this.lblPhone.Text     = "Phone:";
            this.lblPhone.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.txtPhone.Location = new System.Drawing.Point(inputX, 26 + rowH);
            this.txtPhone.Size     = new System.Drawing.Size(inputW, 22);
            this.txtPhone.Font     = new System.Drawing.Font("Segoe UI", 9F);

            // Row 2 (right): Email
            this.lblEmail.Location = new System.Drawing.Point(290, 28 + rowH);
            this.lblEmail.Size     = new System.Drawing.Size(100, 22);
            this.lblEmail.Text     = "Email:";
            this.lblEmail.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.txtEmail.Location = new System.Drawing.Point(395, 26 + rowH);
            this.txtEmail.Size     = new System.Drawing.Size(150, 22);
            this.txtEmail.Font     = new System.Drawing.Font("Segoe UI", 9F);

            // Row 3: Address (full width)
            this.lblAddress.Location = new System.Drawing.Point(labelX, 28 + rowH * 2);
            this.lblAddress.Size     = new System.Drawing.Size(110, 22);
            this.lblAddress.Text     = "Address:";
            this.lblAddress.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.txtAddress.Location = new System.Drawing.Point(inputX, 26 + rowH * 2);
            this.txtAddress.Size     = new System.Drawing.Size(415, 22);
            this.txtAddress.Font     = new System.Drawing.Font("Segoe UI", 9F);

            this.grpInput.Controls.Add(this.lblSupplierId);
            this.grpInput.Controls.Add(this.txtSupplierId);
            this.grpInput.Controls.Add(this.lblSupplierName);
            this.grpInput.Controls.Add(this.txtSupplierName);
            this.grpInput.Controls.Add(this.lblPhone);
            this.grpInput.Controls.Add(this.txtPhone);
            this.grpInput.Controls.Add(this.lblEmail);
            this.grpInput.Controls.Add(this.txtEmail);
            this.grpInput.Controls.Add(this.lblAddress);
            this.grpInput.Controls.Add(this.txtAddress);

            // ---- grpButtons ----
            this.grpButtons.Location = new System.Drawing.Point(12, 225);
            this.grpButtons.Size     = new System.Drawing.Size(560, 60);
            this.grpButtons.Text     = "Actions";
            this.grpButtons.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.btnAdd.Location  = new System.Drawing.Point(15,  22);
            this.btnAdd.Size      = new System.Drawing.Size(110, 28);
            this.btnAdd.Text      = "Add";
            this.btnAdd.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Click    += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location  = new System.Drawing.Point(140, 22);
            this.btnUpdate.Size      = new System.Drawing.Size(110, 28);
            this.btnUpdate.Text      = "Update";
            this.btnUpdate.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Click    += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location  = new System.Drawing.Point(265, 22);
            this.btnDelete.Size      = new System.Drawing.Size(110, 28);
            this.btnDelete.Text      = "Delete";
            this.btnDelete.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Click    += new System.EventHandler(this.btnDelete_Click);

            this.btnClear.Location  = new System.Drawing.Point(390, 22);
            this.btnClear.Size      = new System.Drawing.Size(110, 28);
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

            // ---- dgvSuppliers ----
            this.dgvSuppliers.Location              = new System.Drawing.Point(12, 298);
            this.dgvSuppliers.Size                  = new System.Drawing.Size(560, 220);
            this.dgvSuppliers.ReadOnly              = true;
            this.dgvSuppliers.AllowUserToAddRows    = false;
            this.dgvSuppliers.AllowUserToDeleteRows = false;
            this.dgvSuppliers.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliers.MultiSelect           = false;
            this.dgvSuppliers.BackgroundColor       = System.Drawing.SystemColors.Window;
            this.dgvSuppliers.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuppliers.Font                  = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvSuppliers.CellClick            += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuppliers_CellClick);

            // ---- SupplierForm ----
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(584, 535);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.dgvSuppliers);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.Name                = "SupplierForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Supplier Management";
            this.Load               += new System.EventHandler(this.SupplierForm_Load);

            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.GroupBox       grpInput;
        private System.Windows.Forms.Label          lblSupplierId;
        private System.Windows.Forms.TextBox        txtSupplierId;
        private System.Windows.Forms.Label          lblSupplierName;
        private System.Windows.Forms.TextBox        txtSupplierName;
        private System.Windows.Forms.Label          lblPhone;
        private System.Windows.Forms.TextBox        txtPhone;
        private System.Windows.Forms.Label          lblEmail;
        private System.Windows.Forms.TextBox        txtEmail;
        private System.Windows.Forms.Label          lblAddress;
        private System.Windows.Forms.TextBox        txtAddress;
        private System.Windows.Forms.GroupBox       grpButtons;
        private System.Windows.Forms.Button         btnAdd;
        private System.Windows.Forms.Button         btnUpdate;
        private System.Windows.Forms.Button         btnDelete;
        private System.Windows.Forms.Button         btnClear;
        private System.Windows.Forms.DataGridView   dgvSuppliers;
    }
}
