using System.ComponentModel.DataAnnotations;

namespace NWC.Application.Layer.Models
{
    public class NumberModel
    {
       
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Decimal number is required.")]
        [RegularExpression(@"^[\+\-]?\d{0,13}\.?\d*$", ErrorMessage = "Please enter a valid decimal number between -1000000000000 and +1000000000000")]
        public string Number { get; set; }

        
    }
}