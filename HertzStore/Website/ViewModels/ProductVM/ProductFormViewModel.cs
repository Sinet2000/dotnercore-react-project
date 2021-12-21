using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Website.ViewModels.ProductVM
{
    public class ProductFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "SKU cannot be longer that 8 characters.")]
        public string SKU { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid count of products")]
        public int Count { get; set; }

        [Required]
        [Range(0.00, double.MaxValue, ErrorMessage = "Please enter valid price for the product")]
        public double Price { get; set; }

        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "Please provide image link")]
        public string ImageLink { get; set; }

        // Can be used to extend functionality
        // public IEnumerable<SelectListItem> Suppliers { get; set; }

        //public ProductFormViewModel(IEnumerable<SelectListItem> suppliers)
        //{
        //    Suppliers = suppliers;
        //}

        public AttachmentType AttachmentType { get; set; }

        public bool IsFileUploaded { get; set; }
    }
}
