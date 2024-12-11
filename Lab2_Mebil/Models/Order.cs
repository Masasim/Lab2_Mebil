using Lab2_Mebil.Models;

namespace Lab2_Mebil.Models
{
    public class Order // Замовлення -> Order
    {
        public int id { get; set; }
        public int customerId { get; set; } // id_Customerа -> customerId
        public DateTime orderDate { get; set; } // дата_замовлення -> orderDate
        public decimal totalCost { get; set; } // загальна_вартість -> totalCost
        public string orderStatus { get; set; } // статус_замовлення -> orderStatus

        public Customer Customer { get; set; } // Customer -> Customer
    }
}
