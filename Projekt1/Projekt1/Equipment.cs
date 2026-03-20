namespace Projekt1;

public abstract class Equipment
{
    public int Id{get;set;}
    public string Name{get;set;}
    public string Brand{get;set;}
    public EquipmentStatus Status{get;set;}

    protected Equipment(int id, string name, string brand, EquipmentStatus status)
    {
        Id = id;
        Name = name;
        Brand = brand;
        Status = status;
    }
}