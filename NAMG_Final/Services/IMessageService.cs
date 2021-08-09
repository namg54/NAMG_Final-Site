using System.Threading.Tasks;
//using NAMG_Final.Services.Email;

namespace NAMG_Final.Services
{
    public interface IMessageService
    {
        string SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
