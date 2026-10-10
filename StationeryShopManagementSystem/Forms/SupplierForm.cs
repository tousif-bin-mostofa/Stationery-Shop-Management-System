using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using StationeryShopManagementSystem.Helpers;
using StationeryShopManagementSystem.Models;

namespace StationeryShopManagementSystem.Forms
{
    /// <summary>
    /// Supplier Management Form — allows the user to Add, Update, Delete, and View suppliers.
    /// </summary>
    public partial class SupplierForm : Form
    {
        private int _selectedSupplierId = 0;

        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        /// <summary>
        /// Loads all suppliers from the database into the DataGridView.
        /// </summary>
        private void LoadSuppliers()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT SupplierID, SupplierName, Phone, Email, Address FROM Suppliers ORDER BY SupplierName";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvSuppliers.DataSource = table;
                }

                // Rename headers for readability
                if (dgvSuppliers.Columns.Contains("SupplierID"))
                    dgvSuppliers.Columns["SupplierID"].HeaderText = "ID";
                if (dgvSuppliers.Columns.Contains("SupplierName"))
                    dgvSuppliers.Columns["SupplierName"].HeaderText = "Supplier Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers.\n\nDetails: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validates user input.
        /// </summary>
        private bool ValidateInput()
        {
            // Supplier name is required
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("Please enter the supplier name.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierName.Focus();
                return false;
            }

            // Basic email format check (only if an email was entered)
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email))
            {
                bool emailIsValid = Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                if (!emailIsValid)
                {
                    MessageBox.Show("Please enter a valid email address.",
                                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            // Basic phone check — should not contain letters
            string phone = txtPhone.Text.Trim();
            if (!string.IsNullOrEmpty(phone) && Regex.IsMatch(phone, @"[a-zA-Z]"))
            {
                MessageBox.Show("Phone number should not contain letters.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            txtSupplierId.Clear();
            txtSupplierName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            _selectedSupplierId = 0;
            txtSupplierName.Focus();
        }

        // --- Button event handlers ---

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                // Build a Supplier object from the form inputs
                Supplier newSupplier = new Supplier();
                newSupplier.SupplierName = txtSupplierName.Text.Trim();
                newSupplier.Phone        = txtPhone.Text.Trim();
                newSupplier.Email        = txtEmail.Text.Trim();
                newSupplier.Address      = txtAddress.Text.Trim();

                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"INSERT INTO Suppliers (SupplierName, Phone, Email, Address)
                                     VALUES (@SupplierName, @Phone, @Email, @Address)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SupplierName", newSupplier.SupplierName);
                    command.Parameters.AddWithValue("@Phone",        newSupplier.Phone);
                    command.Parameters.AddWithValue("@Email",        newSupplier.Email);
                    command.Parameters.AddWithValue("@Address",      newSupplier.Address);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Supplier added successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding supplier.\n\nDetails: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedSupplierId == 0)
            {
                MessageBox.Show("Please select a supplier from the list first.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"UPDATE Suppliers
                                     SET SupplierName = @SupplierName,
                                         Phone        = @Phone,
                                         Email        = @Email,
                                         Address      = @Address
                                     WHERE SupplierID = @SupplierID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text.Trim());
                    command.Parameters.AddWithValue("@Phone",        txtPhone.Text.Trim());
                    command.Parameters.AddWithValue("@Email",        txtEmail.Text.Trim());
                    command.Parameters.AddWithValue("@Address",      txtAddress.Text.Trim());
                    command.Parameters.AddWithValue("@SupplierID",   _selectedSupplierId);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Supplier updated successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating supplier.\n\nDetails: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedSupplierId == 0)
            {
                MessageBox.Show("Please select a supplier from the list first.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this supplier?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "DELETE FROM Suppliers WHERE SupplierID = @SupplierID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SupplierID", _selectedSupplierId);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Supplier deleted successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadSuppliers();
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 547)
                {
                    MessageBox.Show(
                        "Unable to delete this supplier because one or more products are still linked to it.\n" +
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
                MessageBox.Show("Error deleting supplier.\n\nDetails: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];
            _selectedSupplierId       = Convert.ToInt32(row.Cells["SupplierID"].Value);
            txtSupplierId.Text        = _selectedSupplierId.ToString();
            txtSupplierName.Text      = row.Cells["SupplierName"].Value?.ToString()  ?? "";
            txtPhone.Text             = row.Cells["Phone"].Value?.ToString()          ?? "";
            txtEmail.Text             = row.Cells["Email"].Value?.ToString()          ?? "";
            txtAddress.Text           = row.Cells["Address"].Value?.ToString()        ?? "";
        }
    }
}
