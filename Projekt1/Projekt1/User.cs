namespace Projekt1;

public abstract class User
{
    public int  Id{get;set;}
    public string Name{get;set;}
    public string Surname{get;set;}

    protected User(int id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }
}