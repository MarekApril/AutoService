using System.Threading.Tasks;

namespace AutoServis.Contracts
{
    public interface ISendGridEmailFactory
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}