using System.ComponentModel.DataAnnotations;

namespace Lab2_Mebil.Models
{
    public class Customer
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string address { get; set; }

        [Required(ErrorMessage = "Bank details are required")]
        [StringLength(50, ErrorMessage = "Bank details can't be longer than 50 characters")]
        public string bankDetails { get; set; }
    }
}
