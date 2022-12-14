using eSchool.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eSchool.Repository;

public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
    }

    public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
    public DbSet<Grade>? Grades { get; set; }
    public DbSet<Course>? Courses { get; set; }
}