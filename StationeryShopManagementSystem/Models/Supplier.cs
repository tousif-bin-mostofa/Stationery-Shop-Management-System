namespace StationeryShopManagementSystem.Models
{
    /// <summary>
    /// Represents a supplier who provides stationery products to the shop.
    /// </summary>
    public class Supplier
    {
        // Private fields — encapsulation
        private int    _supplierId;
        private string _supplierName;
        private string _phone;
        private string _email;
        private string _address;

        // Default constructor
        public Supplier()
        {
        }

        // Parameterized constructor
        public Supplier(int supplierId, string supplierName, string phone, string email, string address)
        {
            _supplierId   = supplierId;
            _supplierName = supplierName;
            _phone        = phone;
            _email        = email;
            _address      = address;
        }

        // Public properties
        public int SupplierID
        {
            get { return _supplierId; }
            set { _supplierId = value; }
        }

        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        // Override ToString so that ComboBox displays the name automatically
        public override string ToString()
        {
            return _supplierName;
        }
    }
}
