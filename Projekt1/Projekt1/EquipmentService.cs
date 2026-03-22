namespace Projekt1;

public class EquipmentService
{
    private List<Equipment> _equipments=new List<Equipment>();

    public void AddEquipment(Equipment equipment)
    {
        _equipments.Add(equipment);
    }
    
    public List<Equipment> GetAllEquipments()
    {
        return _equipments;
    }
    
    public List<Equipment> GetAvailableEquipments()
    {
        List<Equipment> availableEquipments = new List<Equipment>();

        foreach(Equipment equipment in _equipments)
        {
            if (equipment.Status == EquipmentStatus.Available)
            {
                availableEquipments.Add(equipment);
            }
        }
        return availableEquipments;
    }

    public Equipment? GetEquipmentById(int id)
    {
        foreach (Equipment equipment in _equipments)
        {
            if (equipment.Id == id)
            {
                return equipment;
            }
        }
        return null;
    }
    
    public void MarkAsUnavailable(int id)
    {
        Equipment? equipment = GetEquipmentById(id);

        if (equipment != null)
        {
            equipment.Status=EquipmentStatus.Unavailable;
        }
    }
}