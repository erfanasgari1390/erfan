public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Phone { get; set; }

    // Navigation Property
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}