using Fort.DTOs;

namespace Fort.Implementation.Service
{
    public interface IAuthentication
    {
        string GenerateToken(UserDto user);
      
    }
}
