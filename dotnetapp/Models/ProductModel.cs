using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace dotnetapp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductModelNo { get; set; }
        [Required]
        public DateTime DateOfPurchase { get; set; }
        [Required]
        public string ContactNumber { get; set;}

        [Required]
        public string ProblemDescription { get; set; }
        [Required]
        public DateTime AvailableSlots { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public UserModel User { get; set; }
        public int UserId { get; set; }
        
    }
}
