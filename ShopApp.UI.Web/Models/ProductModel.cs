using ShopApp.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.UI.Web.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Display(Name ="Name",Prompt ="Enter product name")]
        [Required(ErrorMessage ="Name alanı zorunludur.")]
        [StringLength(60,MinimumLength =5,ErrorMessage ="Ürün ismi 5-60 karakter arasında olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price alanı zorunludur.")]
        [Range(1,10000,ErrorMessage ="Fiyat için 1-10000 arasında değer girmelisiniz.")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Description alanı zorunludur.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Description ismi 5-100 karakter arasında olmalıdır.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ImageUrl alanı zorunludur.")]
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }

        [Required(ErrorMessage = "Url alanı zorunludur.")]
        public string Url { get; set; }
        public bool IsHome { get; set; }

        public List<Category> SelectedCategories { get; set; }
    }
}
