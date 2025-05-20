using System;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();

    public void Enroll(Course course)
    {
        Courses.Add(course);
        course.Students.Add(this);
    }
}

public class Course
{
    public string Title { get; set; }
    public int Credits { get; set; }
    public Professor Instructor { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
    
    public void AssignProfessor(Professor professor)
    {
        Instructor = professor;
        professor.Courses.Add(this);
    }
}

public class Professor
{
    public string Name { get; set; }
    public string Degree { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();
}

class Program
{
    static void Main()
    {
        var math = new Course { Title = "Mathematics", Credits = 4 };
        var physics = new Course { Title = "Physics", Credits = 3 };
        
        var smith = new Professor { Name = "Dr. Smith", Degree = "PhD" };
        var johnson = new Professor { Name = "Prof. Johnson", Degree = "MSc" };
        
        var alice = new Student { Name = "Alice", Age = 20 };
        var bob = new Student { Name = "Bob", Age = 21 };
        
        math.AssignProfessor(smith);
        physics.AssignProfessor(johnson);
        
        alice.Enroll(math);
        alice.Enroll(physics);
        bob.Enroll(math);
    }
}
