using DotNet.ApplicationCore.DTOs;

namespace DotNet.Services.Services.Infrastructure
{
    public interface ITokenService
    {
        TokenResult BuildToken(AuthUser user);
    }
}
