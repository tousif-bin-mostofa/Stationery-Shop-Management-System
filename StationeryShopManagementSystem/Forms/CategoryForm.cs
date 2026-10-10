using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StationeryShopManagementSystem.Helpers;
using StationeryShopManagementSystem.Models;

namespace StationeryShopManagementSystem.Forms
{
    /// <summary>
    /// Category Management Form — allows the user to Add, Update, Delete, and View categories.
    /// </summary>
    public partial class CategoryForm : Form
    {
        // Holds the CategoryID of the currently selected row (0 means nothing is selected)
        private int _selectedCategoryId = 0;

        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        /// <summary>
        /// Loads all categories from the database into the DataGridView.
        /// </summary>
        private void LoadCategories()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvCategories.DataSource = table;
                }

                // Rename columns for readability
                if (dgvCategories.Columns.Contains("CategoryID"))
                    dgvCategories.Columns["CategoryID"].HeaderText = "ID";
                if (dgvCategories.Columns.Contains("CategoryName"))
                    dgvCategories.Columns["CategoryName"].HeaderText = "Category Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories.\n\nDetails: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validates input before adding or updating.
        /// Returns true if input is valid.
        /// </summary>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Please enter the category name.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Clears the input fields and resets the selected category.
        /// </summary>
        private void ClearFields()
        {
            txtCategoryId.Clear();
            txtCategoryName.Clear();
            _selectedCategoryId = 0;
            txtCategoryName.Focus();
        }

        // --- Button event handlers ---

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                // Create a Category object using the entered data
                Category newCategory = new Category();
                newCategory.CategoryName = txtCategoryName.Text.Trim();

                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    // Use parameterized query — prevents SQL injection
                    string query = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CategoryName", newCategory.CategoryName);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Category added successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding category.\n\nDetails: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId == 0)
            {
                MessageBox.Show("Please select a category from the list first.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text.Trim());
                    command.Parameters.AddWithValue("@CategoryID",   _selectedCategoryId);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Category updated successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating category.\n\nDetails: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId == 0)
            {
                MessageBox.Show("Please select a category from the list first.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this category?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "DELETE FROM Categories WHERE CategoryID = @CategoryID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CategoryID", _selectedCategoryId);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Category deleted successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadCategories();
            }
            catch (SqlException sqlEx)
            {
                // Foreign key violation — a product still uses this category
                if (sqlEx.Number == 547)
                {
                    MessageBox.Show(
                        "Unable to delete this category because one or more products are still using it.\n" +
                        "Please remove or reassign those products first.",
                        "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Database error while deleting.\n\nDetails: " + sqlEx.Message,
                                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting category.\n\nDetails: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        /// <summary>
        /// When the user clicks a row in the DataGridView,
        /// populate the input fields with that row's data.
        /// </summary>
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
            _selectedCategoryId       = Convert.ToInt32(row.Cells["CategoryID"].Value);
            txtCategoryId.Text        = _selectedCategoryId.ToString();
            txtCategoryName.Text      = row.Cells["CategoryName"].Value.ToString();
        }
    }
}
