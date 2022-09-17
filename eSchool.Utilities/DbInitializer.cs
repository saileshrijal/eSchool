﻿using eSchool.Models;
using eSchool.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eSchool.Utilities;

public class DbInitializer : IDbInitializer
{
    private UserManager<ApplicationUser> _userManager;
    private RoleManager<IdentityRole> _roleManager;
    private ApplicationDbContext _context;

    public DbInitializer(UserManager<ApplicationUser> userManager,
                            RoleManager<IdentityRole> roleManager,
                            ApplicationDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

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

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "Admin",
                Email = "admin@gmail.com",
                FirstName = "Admin",
                LastName = "Admin"
            }, "Admin@0011").Wait();

            var appUser = _context.ApplicationUsers.Where(x => x.Email == "admin@gmail.com").FirstOrDefault();
            if (appUser != null)
            {
                _userManager.AddToRoleAsync(appUser, WebsiteRole.WebsiteAdmin).GetAwaiter().GetResult();
            }
        }
    }
}