using Microsoft.AspNetCore.Identity;

namespace eSchool.Models;

public class ApplicationUser:IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? DOB { get; set; }
    public DateOnly? DateOfJoin { get; set; }
    public bool Status { get; set; }
    public DateTime? LastLoginDate { get; set; }
    //public string? LastLoginIp { get; set; }
}