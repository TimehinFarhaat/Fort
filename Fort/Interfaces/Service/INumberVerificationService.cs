using Fort.DTOs;

namespace Fort.Interfaces.Service
{
    public interface INumberVerificationService
    {
        public Task<BaseResponse> VerifyMobileNumber(string mobileNumber);
    }
}
