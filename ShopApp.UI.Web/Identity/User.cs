using Microsoft.AspNetCore.Identity;

namespace ShopApp.UI.Web.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
