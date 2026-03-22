namespace Projekt1;

public class Student : User
{
    public string StudentNumber { get; set; }

    public Student(int id, string name, string surname, string studentNumber) : base(id,name, surname)
    {
        StudentNumber = studentNumber;
    }
}