namespace Projekt1;

public class Camera : Equipment
{
    public int MegaPixels { get; set; }
    public string LensType { get; set; }
    
    public Camera(int id,string name,string brand, EquipmentStatus status, int megaPixels, string lensType) : base(id,name,brand,status)
    {
        MegaPixels = megaPixels;
        LensType = lensType;
    }
}