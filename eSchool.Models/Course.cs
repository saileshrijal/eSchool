namespace eSchool.Models;

public class Course
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Grade? Grade { get; set; }
}