using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Course
{
    public int Id { get; set; }

    [Required] // Data Annotations
    [MaxLength(100)]
    public string Title { get; set; }

    // Foreign Key (convention)
    public int StudentId { get; set; }

    // Navigation Property (with Data Annotation)
    [ForeignKey("StudentId")]
    public Student Student { get; set; }
}