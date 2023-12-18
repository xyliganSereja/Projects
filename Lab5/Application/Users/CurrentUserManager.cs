using Contracts.Users;
using Models.Users;

namespace Application.Users;

public class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
    public UserRole Role { get; set; }
}