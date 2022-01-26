using System.ComponentModel.DataAnnotations;

namespace ShopApp.UI.Web.Models
{
    public class LoginModel
    {
        //public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
