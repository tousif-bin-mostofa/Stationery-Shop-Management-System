namespace StationeryShopManagementSystem.Models
{
    /// <summary>
    /// Represents a stationery product sold in the shop.
    /// </summary>
    public class Product
    {
        // Private fields — encapsulation
        private int     _productId;
        private string  _productName;
        private int     _categoryId;
        private int     _supplierId;
        private decimal _unitPrice;
        private int     _quantityInStock;
        private int     _reorderLevel;

        // Default constructor
        public Product()
        {
        }

        // Parameterized constructor
        public Product(int productId, string productName, int categoryId, int supplierId,
                       decimal unitPrice, int quantityInStock, int reorderLevel)
        {
            _productId       = productId;
            _productName     = productName;
            _categoryId      = categoryId;
            _supplierId      = supplierId;
            _unitPrice       = unitPrice;
            _quantityInStock = quantityInStock;
            _reorderLevel    = reorderLevel;
        }

        // Public properties
        public int ProductID
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public int CategoryID
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        public int SupplierID
        {
            get { return _supplierId; }
            set { _supplierId = value; }
        }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        public int QuantityInStock
        {
            get { return _quantityInStock; }
            set { _quantityInStock = value; }
        }

        public int ReorderLevel
        {
            get { return _reorderLevel; }
            set { _reorderLevel = value; }
        }

        /// <summary>
        /// Returns true when the current stock is at or below the reorder level.
        /// </summary>
        public bool IsLowStock()
        {
            return _quantityInStock <= _reorderLevel;
        }
    }
}
