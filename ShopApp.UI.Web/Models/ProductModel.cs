using System.ComponentModel.DataAnnotations;

namespace ShopApp.UI.Web.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public bool IsHome { get; set; }
    }
}
