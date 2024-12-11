namespace Lab2_Mebil.Models
{
    public class Furniture // Мебіль -> Furniture
    {
        public int id { get; set; }
        public int factoryId { get; set; } // id_фабрsкs -> factoryId
        public string name { get; set; } // name -> name
        public string furnitureType { get; set; } // тsп_мебілі -> furnitureType
        public decimal currentPrice { get; set; } // поточна_ціна -> currentPrice

        public Factory Factory { get; set; } // Фабрsка -> Factory
    }
}
