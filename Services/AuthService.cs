using System.Security.Claims;
using MarketInventoryApplication.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace MarketInventoryApplication.Services;

public class AuthService
{
    private readonly MarketInventoryContext _db;

    public AuthService(MarketInventoryContext db)
    {
        _db = db;
    }

    public async Task<User?> AuthenticateAsync(string name, string password)
    {
        User? user = await _db.Users.FirstOrDefaultAsync(u => u.Name == name);
        if (user is null || !PasswordHasher.Verify(password, user.Password))
        {
            return null;
        }
        return user;
    }

    public async Task SignInAsync(HttpContext context, User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, user.RoleName),
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var properties = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8),
        };
        await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);
    }

    public async Task SignOutAsync(HttpContext context)
    {
        await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public async Task<(bool Success, string Error)> CreateUserAsync(string name, string password, int level)
    {
        name = name.Trim();
        if (string.IsNullOrEmpty(name))
        {
            return (false, "Username is required.");
        }
        if (password.Length < 6)
        {
            return (false, "Password must be at least 6 characters long.");
        }
        if (level is < 1 or > 2)
        {
            return (false, "Invalid role selected.");
        }
        if (await _db.Users.AnyAsync(u => u.Name == name))
        {
            return (false, "A user with that name already exists.");
        }

        _db.Users.Add(new User
        {
            Name = name,
            Password = PasswordHasher.Hash(password),
            Level = level,
        });
        await _db.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<List<User>> ListUsersAsync()
    {
        return await _db.Users.OrderBy(u => u.Id).ToListAsync();
    }
}
