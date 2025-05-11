using System.ComponentModel.DataAnnotations;

namespace SmartSpense.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int Value { get; set; }
        [Required]
        public String? Description { get; set; }

    }
   
}
