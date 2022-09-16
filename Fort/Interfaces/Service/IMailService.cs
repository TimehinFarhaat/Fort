using Fort.DTOs;

namespace Fort.Interfaces.Service
{
    public interface IMailService
    {
        public void SendEmail(MailRequest mailRequest);
    }
}
