namespace StationeryShopManagementSystem.Models
{
    /// <summary>
    /// Represents a product category (e.g., Writing, Paper, Art Supplies).
    /// Demonstrates encapsulation: private fields exposed through public properties.
    /// </summary>
    public class Category
    {
        // Private fields — encapsulation
        private int    _categoryId;
        private string _categoryName;

        // Default constructor — needed when creating an empty Category object
        public Category()
        {
        }

        // Parameterized constructor — used when creating a Category with known values
        public Category(int categoryId, string categoryName)
        {
            _categoryId   = categoryId;
            _categoryName = categoryName;
        }

        // Public properties — provide controlled access to the private fields
        public int CategoryID
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }

        // Override ToString so that ComboBox displays the name automatically
        public override string ToString()
        {
            return _categoryName;
        }
    }
}
