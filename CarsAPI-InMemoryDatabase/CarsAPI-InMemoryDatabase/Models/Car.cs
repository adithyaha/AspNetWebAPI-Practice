using System;
using System.ComponentModel.DataAnnotations;

namespace CarsAPI_InMemoryDatabase.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required] public string CarName { get; set; }
        [Required] public string Category { get; set; }
        [Required] public double CarPrice { get; set; }
    }
}
