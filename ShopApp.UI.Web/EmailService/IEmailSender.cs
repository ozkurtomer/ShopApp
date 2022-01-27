using System.Threading.Tasks;

namespace ShopApp.UI.Web.EmailService
{
    public interface IEmailSender
    {
        Task SenEmailAsync(string email, string subject, string htmlMessage);
    }
}
