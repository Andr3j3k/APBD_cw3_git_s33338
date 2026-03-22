namespace Projekt1;

public class Employee : User
{
    public string Department { get; set; }

    public Employee(int id, string name, string surname, string department) : base(id, name, surname)
    {
        Department = department;
    }
}