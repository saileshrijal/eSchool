using eSchool.Models;
using eSchool.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eSchool.Utilities;

public class DbInitializer:IDbInitializer
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _context;
    public void Initialize()
    {
        
        try
        {
            if (_context.Database.GetPendingMigrations().Count()>0)
            {
                _context.Database.Migrate();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        if (!_roleManager.RoleExistsAsync(WebsiteRole.WebsiteAdmin).GetAwaiter().GetResult())
        {
            _roleManager.CreateAsync(new IdentityRole(WebsiteRole.WebsiteAdmin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(WebsiteRole.WebsiteEmployee)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(WebsiteRole.WebsiteStudent)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(WebsiteRole.WebsiteTeacher)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser()
            {
                UserName = "Admin",
                Email = "admin@gmail.com",
            }, "Admin@123");

            var appUser = _context.ApplicationUsers.Where(x => x.Email == "admin@gmail.com").FirstOrDefault();
            if (appUser != null)
            {
                _userManager.AddToRoleAsync(appUser, WebsiteRole.WebsiteAdmin).GetAwaiter().GetResult();
            }
        }
    }
}