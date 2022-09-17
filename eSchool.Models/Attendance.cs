namespace eSchool.Models;

public class Attendance
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public bool Status { get; set; }
    public string? Remarks { get; set; }
    public ApplicationUser? Student { get; set; }
}