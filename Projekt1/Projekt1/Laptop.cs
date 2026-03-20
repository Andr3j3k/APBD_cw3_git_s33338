namespace Projekt1;

public class Laptop : Equipment
{
    public int RamGB{get; set;}
    public string Processor{get; set;}

    public Laptop(int id, string name, string brand, EquipmentStatus status, int ramGB, string processor) : base(id,
        name, brand, status)
    {
        RamGB = ramGB;
        Processor = processor;
    }
}