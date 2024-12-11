using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Lab2_Mebil.Models
{
    public class CustomerViewModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "ID повинен бути додатнім числом")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ім'я є обов'язковим")]
        [StringLength(100, ErrorMessage = "Ім'я не може бути довшим за 100 символів")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Адреса не може бути довшою за 200 символів")]
        public string Address { get; set; }

        [StringLength(100, ErrorMessage = "Банківські реквізити не можуть бути довшими за 100 символів")]
        public string BankDetails { get; set; }
    }
}