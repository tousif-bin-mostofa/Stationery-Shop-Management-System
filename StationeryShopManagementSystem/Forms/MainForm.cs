using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StationeryShopManagementSystem.Forms;
using StationeryShopManagementSystem.Helpers;

namespace StationeryShopManagementSystem.Forms
{
    /// <summary>
    /// Main dashboard form.
    /// Shows total counts and navigation buttons to other forms.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Load summary counts when the form opens
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSummary();
        }

        /// <summary>
        /// Queries the database for total counts and low-stock products,
        /// then updates the summary labels on the dashboard.
        /// </summary>
        private void LoadSummary()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    // Total products
                    SqlCommand cmdProducts = new SqlCommand("SELECT COUNT(*) FROM Products", connection);
                    int totalProducts = (int)cmdProducts.ExecuteScalar();
                    lblTotalProducts.Text = totalProducts.ToString();

                    // Total categories
                    SqlCommand cmdCategories = new SqlCommand("SELECT COUNT(*) FROM Categories", connection);
                    int totalCategories = (int)cmdCategories.ExecuteScalar();
                    lblTotalCategories.Text = totalCategories.ToString();

                    // Total suppliers
                    SqlCommand cmdSuppliers = new SqlCommand("SELECT COUNT(*) FROM Suppliers", connection);
                    int totalSuppliers = (int)cmdSuppliers.ExecuteScalar();
                    lblTotalSuppliers.Text = totalSuppliers.ToString();

                    // Low-stock products (QuantityInStock <= ReorderLevel)
                    string lowStockQuery = @"
                        SELECT p.ProductName, p.QuantityInStock, p.ReorderLevel
                        FROM   Products p
                        WHERE  p.QuantityInStock <= p.ReorderLevel
                        ORDER  BY p.ProductName";

                    SqlDataAdapter adapter = new SqlDataAdapter(lowStockQuery, connection);
                    DataTable lowStockTable = new DataTable();
                    adapter.Fill(lowStockTable);
                    dgvLowStock.DataSource = lowStockTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load summary data.\n\nDetails: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Navigation buttons ---

        private void btnProducts_Click(object sender, EventArgs e)
        {
            // Open the Product Management Form
            ProductForm productForm = new ProductForm();
            productForm.ShowDialog();

            // Refresh summary when returning from the form
            LoadSummary();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.ShowDialog();
            LoadSummary();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm();
            supplierForm.ShowDialog();
            LoadSummary();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
