using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductCustomerMamnagement.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name field is required.")]
        [MaxLength(100,ErrorMessage ="Name cannot exceed 100 characters.")]
        public string Name { get; set; }
        [MaxLength(500,ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price field is required.")]
        [Range(0.01,double.MaxValue,ErrorMessage = "Price must be greater than 0.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "The Stock Quantity field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Stock Quantity must be a positive integer.")]
        public int StockQuantity { get; set; }
        [Required(ErrorMessage = "Category field is required.")]
        [MaxLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
        [RegularExpression(@"^(electronics|clothing|other|Device|food)$", ErrorMessage = "Category must be one of the following: electronics, clothing, other, Device, or food.")]
        public string Category { get; set; }
    }
}