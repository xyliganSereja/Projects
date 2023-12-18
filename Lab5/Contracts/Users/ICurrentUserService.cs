using Models.Users;

namespace Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; set; }
    public UserRole Role { get; set; }
}