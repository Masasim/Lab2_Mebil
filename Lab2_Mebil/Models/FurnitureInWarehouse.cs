namespace Lab2_Mebil.Models
{
    public class FurnitureInWarehouse // Меблі_на_складі -> FurnitureInWarehouse
    {
        public int furnitureId { get; set; } // id_мебілі -> furnitureId
        public int warehouseId { get; set; } // id_складу -> warehouseId
        public int quantity { get; set; } // кількість -> quantity

        public Furniture Furniture { get; set; } // Мебіль -> Furniture
        public Warehouse Warehouse { get; set; } // Склад -> Warehouse
    }
}
