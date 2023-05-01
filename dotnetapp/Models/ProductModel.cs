
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace dotnetapp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(14)]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(20)]
        public string ProductModelNo { get; set; }
        [Required]
        public DateTime DateOfPurchase { get; set; }
        [Required]
        [MaxLength(10)]
        public string ContactNumber { get; set;}

        [Required]
        [MaxLength(200)]
        public string ProblemDescription { get; set; }
        [Required]
        public DateTime AvailableSlots { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public UserModel User { get; set; }
        public int UserId { get; set; }
        
    }
}
