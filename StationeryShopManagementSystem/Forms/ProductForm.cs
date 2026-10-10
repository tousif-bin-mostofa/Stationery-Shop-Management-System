using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StationeryShopManagementSystem.Helpers;
using StationeryShopManagementSystem.Models;

namespace StationeryShopManagementSystem.Forms
{
    /// <summary>
    /// Product Management Form — the most important form in the application.
    /// Supports full CRUD and product search by name.
    /// </summary>
    public partial class ProductForm : Form
    {
        // Holds the ProductID of the currently selected row (0 = nothing selected)
        private int _selectedProductId = 0;

        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            // Load combo boxes first so products can be displayed with names
            LoadCategoryComboBox();
            LoadSupplierComboBox();
            LoadProducts();
        }

        // ---------------------------------------------------------------
        // DATA LOADING METHODS
        // ---------------------------------------------------------------

        /// <summary>
        /// Populates the Category ComboBox from the database.
        /// </summary>
        private void LoadCategoryComboBox()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    cmbCategory.Items.Clear();
                    while (reader.Read())
                    {
                        // Create a Category object and add it to the ComboBox
                        Category category = new Category(
                            Convert.ToInt32(reader["CategoryID"]),
                            reader["CategoryName"].ToString());
                        cmbCategory.Items.Add(category);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories.\n\nDetails: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Populates the Supplier ComboBox from the database.
        /// </summary>
        private void LoadSupplierComboBox()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT SupplierID, SupplierName FROM Suppliers ORDER BY SupplierName";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    cmbSupplier.Items.Clear();
                    while (reader.Read())
                    {
                        Supplier supplier = new Supplier();
                        supplier.SupplierID   = Convert.ToInt32(reader["SupplierID"]);
                        supplier.SupplierName = reader["SupplierName"].ToString();
                        cmbSupplier.Items.Add(supplier);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers.\n\nDetails: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads products from the database into the DataGridView.
        /// Joins with Categories and Suppliers to show names, not just IDs.
        /// Optionally filters by product name when searchTerm is provided.
        /// </summary>
        private void LoadProducts(string searchTerm = "")
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT p.ProductID,
                               p.ProductName,
                               c.CategoryName,
                               s.SupplierName,
                               p.UnitPrice,
                               p.QuantityInStock,
                               p.ReorderLevel,
                               CASE WHEN p.QuantityInStock <= p.ReorderLevel THEN 'Low Stock' ELSE '' END AS StockStatus
                        FROM   Products  p
                        INNER  JOIN Categories c ON p.CategoryID = c.CategoryID
                        INNER  JOIN Suppliers  s ON p.SupplierID = s.SupplierID
                        WHERE  p.ProductName LIKE @SearchTerm
                        ORDER  BY p.ProductName";

                    SqlCommand command = new SqlCommand(query, connection);
                    // Parameterized search — safe against SQL injection
                    command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvProducts.DataSource = table;
                }

                // Rename column headers for readability
                RenameProductGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products.\n\nDetails: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sets friendly header names on the products DataGridView.
        /// </summary>
        private void RenameProductGridColumns()
        {
            if (dgvProducts.Columns.Contains("ProductID"))
                dgvProducts.Columns["ProductID"].HeaderText = "ID";
            if (dgvProducts.Columns.Contains("ProductName"))
                dgvProducts.Columns["ProductName"].HeaderText = "Product Name";
            if (dgvProducts.Columns.Contains("CategoryName"))
                dgvProducts.Columns["CategoryName"].HeaderText = "Category";
            if (dgvProducts.Columns.Contains("SupplierName"))
                dgvProducts.Columns["SupplierName"].HeaderText = "Supplier";
            if (dgvProducts.Columns.Contains("UnitPrice"))
                dgvProducts.Columns["UnitPrice"].HeaderText = "Unit Price";
            if (dgvProducts.Columns.Contains("QuantityInStock"))
                dgvProducts.Columns["QuantityInStock"].HeaderText = "Qty in Stock";
            if (dgvProducts.Columns.Contains("ReorderLevel"))
                dgvProducts.Columns["ReorderLevel"].HeaderText = "Reorder Level";
            if (dgvProducts.Columns.Contains("StockStatus"))
                dgvProducts.Columns["StockStatus"].HeaderText = "Status";
        }

        // ---------------------------------------------------------------
        // VALIDATION
        // ---------------------------------------------------------------

        /// <summary>
        /// Validates the product input fields.
        /// Returns true when all inputs are valid.
        /// </summary>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please enter the product name.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return false;
            }

            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (cmbSupplier.SelectedItem == null)
            {
                MessageBox.Show("Please select a supplier.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSupplier.Focus();
                return false;
            }

            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid positive price.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            int quantity;
            if (!int.TryParse(txtQuantity.Text, out quantity) || quantity < 0)
            {
                MessageBox.Show("Please enter a valid non-negative quantity.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return false;
            }

            int reorderLevel;
            if (!int.TryParse(txtReorderLevel.Text, out reorderLevel) || reorderLevel < 0)
            {
                MessageBox.Show("Please enter a valid non-negative reorder level.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReorderLevel.Focus();
                return false;
            }

            return true;
        }

        // ---------------------------------------------------------------
        // HELPER METHODS
        // ---------------------------------------------------------------

        /// <summary>
        /// Clears all form fields and resets the selected product.
        /// </summary>
        private void ClearFields()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            cmbCategory.SelectedIndex   = -1;
            cmbSupplier.SelectedIndex   = -1;
            txtPrice.Clear();
            txtQuantity.Clear();
            txtReorderLevel.Clear();
            _selectedProductId = 0;
            txtProductName.Focus();
        }

        /// <summary>
        /// Gets the CategoryID from the currently selected ComboBox item.
        /// </summary>
        private int GetSelectedCategoryId()
        {
            Category selected = (Category)cmbCategory.SelectedItem;
            return selected.CategoryID;
        }

        /// <summary>
        /// Gets the SupplierID from the currently selected ComboBox item.
        /// </summary>
        private int GetSelectedSupplierId()
        {
            Supplier selected = (Supplier)cmbSupplier.SelectedItem;
            return selected.SupplierID;
        }

        /// <summary>
        /// Selects the correct ComboBox item by matching a given ID.
        /// </summary>
        private void SelectCategoryById(int categoryId)
        {
            foreach (object item in cmbCategory.Items)
            {
                Category category = (Category)item;
                if (category.CategoryID == categoryId)
                {
                    cmbCategory.SelectedItem = category;
                    return;
                }
            }
        }

        private void SelectSupplierById(int supplierId)
        {
            foreach (object item in cmbSupplier.Items)
            {
                Supplier supplier = (Supplier)item;
                if (supplier.SupplierID == supplierId)
                {
                    cmbSupplier.SelectedItem = supplier;
                    return;
                }
            }
        }

        // ---------------------------------------------------------------
        // BUTTON EVENT HANDLERS
        // ---------------------------------------------------------------

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                // Build a Product object from the form inputs
                Product newProduct = new Product();
                newProduct.ProductName     = txtProductName.Text.Trim();
                newProduct.CategoryID      = GetSelectedCategoryId();
                newProduct.SupplierID      = GetSelectedSupplierId();
                newProduct.UnitPrice       = decimal.Parse(txtPrice.Text);
                newProduct.QuantityInStock = int.Parse(txtQuantity.Text);
                newProduct.ReorderLevel    = int.Parse(txtReorderLevel.Text);

                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"
                        INSERT INTO Products (ProductName, CategoryID, SupplierID, UnitPrice, QuantityInStock, ReorderLevel)
                        VALUES (@ProductName, @CategoryID, @SupplierID, @UnitPrice, @QuantityInStock, @ReorderLevel)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductName",     newProduct.ProductName);
                    command.Parameters.AddWithValue("@CategoryID",      newProduct.CategoryID);
                    command.Parameters.AddWithValue("@SupplierID",      newProduct.SupplierID);
                    command.Parameters.AddWithValue("@UnitPrice",       newProduct.UnitPrice);
                    command.Parameters.AddWithValue("@QuantityInStock", newProduct.QuantityInStock);
                    command.Parameters.AddWithValue("@ReorderLevel",    newProduct.ReorderLevel);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Product added successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product.\n\nDetails: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == 0)
            {
                MessageBox.Show("Please select a product from the list first.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"
                        UPDATE Products
                        SET ProductName     = @ProductName,
                            CategoryID      = @CategoryID,
                            SupplierID      = @SupplierID,
                            UnitPrice       = @UnitPrice,
                            QuantityInStock = @QuantityInStock,
                            ReorderLevel    = @ReorderLevel
                        WHERE ProductID = @ProductID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductName",     txtProductName.Text.Trim());
                    command.Parameters.AddWithValue("@CategoryID",      GetSelectedCategoryId());
                    command.Parameters.AddWithValue("@SupplierID",      GetSelectedSupplierId());
                    command.Parameters.AddWithValue("@UnitPrice",       decimal.Parse(txtPrice.Text));
                    command.Parameters.AddWithValue("@QuantityInStock", int.Parse(txtQuantity.Text));
                    command.Parameters.AddWithValue("@ReorderLevel",    int.Parse(txtReorderLevel.Text));
                    command.Parameters.AddWithValue("@ProductID",       _selectedProductId);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Product updated successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product.\n\nDetails: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == 0)
            {
                MessageBox.Show("Please select a product from the list first.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductID", _selectedProductId);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Product deleted successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product.\n\nDetails: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Search by the text in the search box
            LoadProducts(txtSearch.Text.Trim());
        }

        // ---------------------------------------------------------------
        // DATAGRIDVIEW — row click event
        // ---------------------------------------------------------------

        /// <summary>
        /// When the user clicks a product row, populate the form fields with that product's data.
        /// </summary>
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

            // Store selected ID so Update and Delete know which product to affect
            _selectedProductId = Convert.ToInt32(row.Cells["ProductID"].Value);

            // Populate text fields
            txtProductId.Text    = _selectedProductId.ToString();
            txtProductName.Text  = row.Cells["ProductName"].Value?.ToString()    ?? "";
            txtPrice.Text        = row.Cells["UnitPrice"].Value?.ToString()       ?? "";
            txtQuantity.Text     = row.Cells["QuantityInStock"].Value?.ToString() ?? "";
            txtReorderLevel.Text = row.Cells["ReorderLevel"].Value?.ToString()    ?? "";

            // To select the correct Category in the ComboBox, we need the CategoryID.
            // The DataGridView shows CategoryName (joined). We must fetch the ID from the DB.
            LoadSelectedProductIds(_selectedProductId);
        }

        /// <summary>
        /// Fetches CategoryID and SupplierID for the selected product and sets the ComboBoxes.
        /// This is needed because the DataGridView shows names (not IDs) from the JOIN query.
        /// </summary>
        private void LoadSelectedProductIds(int productId)
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT CategoryID, SupplierID FROM Products WHERE ProductID = @ProductID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductID", productId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int categoryId = Convert.ToInt32(reader["CategoryID"]);
                        int supplierId = Convert.ToInt32(reader["SupplierID"]);
                        SelectCategoryById(categoryId);
                        SelectSupplierById(supplierId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product details.\n\nDetails: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
