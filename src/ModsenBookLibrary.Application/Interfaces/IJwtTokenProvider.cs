using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Interfaces;
public interface IJwtTokenProvider
{
    string GetJwtToken(User user);
}
