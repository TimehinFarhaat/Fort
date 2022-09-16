using Fort.DTOs;

namespace Fort.Interfaces.Service
{
    public interface IMailAddressVerification
    {
        public  Task<BaseResponse> VerifyMailAddress(string emailAddress);
    }
}
