namespace Lab2_Mebil.Models
{
    public class FurnitureInOrder // Меблі_в_замовленні -> FurnitureInOrder
    {
        public int orderId { get; set; } // id_замовлення -> orderId
        public int productId { get; set; } // id_товару -> productId
        public int quantity { get; set; } // кількість -> quantity
        public decimal price { get; set; } // ціна -> price
        //public Furniture FurnitureInOrder { get; set; } // Мебіль -> Furniture
    }
}
