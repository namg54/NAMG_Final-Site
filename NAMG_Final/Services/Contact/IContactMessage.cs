using System.Threading.Tasks;
//using NAMG_Final.Services.Email;

namespace NAMG_Final.Services.Contact
{
    public interface IContactMessage
    {
       string  SendContactAsync(string name,string email, string subject, string htmlMessage);
    }
}
