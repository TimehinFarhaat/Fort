using Fort.DTOs;

namespace Fort.Interfaces.Service
{
    public interface IResponseService
    {
        public Task<BaseResponse> SendResponse(string phoneNumber);
    }
}
