using Infrastructure.Entities;
using Infrastructure.Helpers;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class UserFactory
{
    public static UserEntity Create(UserRegistrationForm form)
    {
        try
        {
            return new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                Password = PasswordHasher.GenerateSecurePassword(form.Password)
            };
        }
        catch { }
        return null!;
    }
}
