namespace eSchool.Models;

public class ClassroomStudent
{
    public int Id { get; set; }
    public ApplicationUser? Student { get; set; }
    public Classroom? Classroom { get; set; }
}