namespace Projekt1;

public class Projector : Equipment
{
    public int BrightnessLumens{get; set;}
    public string Resolution{get; set;}
    
    public Projector(int id,string name,string brand,EquipmentStatus status, int brightnessLumens,string resolution):base(id,name,brand,status)
    { 
        BrightnessLumens = brightnessLumens;
        Resolution = resolution;
    }
}