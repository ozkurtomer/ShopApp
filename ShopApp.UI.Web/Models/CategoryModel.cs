using ShopApp.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.UI.Web.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Kategori adi zorunludur")]
        [StringLength(100,MinimumLength =5, ErrorMessage ="Kategori alanı 5-100 karakter arasında olmalıdır")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kategori adi zorunludur")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Url alanı 5-100 karakter arasında olmalıdır")]
        public string Url { get; set; }

        public List<Product> Products { get; set; }
    }
}
