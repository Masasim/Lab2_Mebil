namespace Lab2_Mebil.Models
{
    public class Invoice // Накладна -> Invoice
    {
        public int id { get; set; }
        public int orderId { get; set; } // id_замовлення -> orderId
        public int furnitureId { get; set; } // id_мебілі -> furnitureId
        public int warehouseId { get; set; } // id_складу -> warehouseId
        public decimal totalAmount { get; set; } // сума -> totalAmount
        public int furnitureCount { get; set; } // кількість_меблів -> furnitureCount

        public Order Order { get; set; } // Замовлення -> Order
        public Furniture Furniture { get; set; } // Мебіль -> Furniture
    }
}
