namespace eSchool.Models;

public class Exam
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? StartDate { get; set; }
    public ExamType? ExamType { get; set; }
}