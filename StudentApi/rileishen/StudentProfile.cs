using System.ComponentModel.DataAnnotations.Schema;

public class StudentProfile
{
    public int Id { get; set; }

    [ForeignKey("Student")] // Data Annotation
    public int StudentId { get; set; }

    public Student Student { get; set; }
}