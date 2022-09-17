namespace eSchool.Models;

public class Classroom
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string? Section { get; set; }
    public string? Remarks { get; set; }
    public bool Status { get; set; }
    public ApplicationUser? Teacher { get; set; }
    public Grade? Grade { get; set; }
}