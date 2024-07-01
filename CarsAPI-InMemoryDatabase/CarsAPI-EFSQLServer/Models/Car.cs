using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using System.ComponentModel.DataAnnotations;


namespace CarsAPI_EFSQLServer.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required]
        public string CarName { get; set; }
        [Required]
        public string Category { get; set; }

        [Required]
        public decimal CarPrice { get; set; }
        
    }
}
