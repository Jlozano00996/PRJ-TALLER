using Taller.Domain.ComponentModels;

namespace Editorial.UI.Application.Contracts
{
    public interface IEmailSender
    {
        void Send(Email email);
    }
}
