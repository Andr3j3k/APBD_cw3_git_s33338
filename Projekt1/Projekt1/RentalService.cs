namespace Projekt1;

public class RentalService
{
    private List<Rental> _rentals=new List<Rental>();
    private EquipmentService _equipmentService;
    private UserService _userService;

    public RentalService(EquipmentService equipmentService, UserService userService)
    {
        _equipmentService = equipmentService;
        _userService = userService;
    }

    public void AddRental(Rental rental)
    {
        _rentals.Add(rental);
    }

    public List<Rental> GetAllRentals()
    {
        return _rentals;
    }

    public bool BorrowEquipment(int userId, int equipmentId, DateTime borrowDate, DateTime dueDate)
    {
        User? user = _userService.GetUserById(userId);
        Equipment? equipment = _equipmentService.GetEquipmentById(equipmentId);

        if (user == null)
        {
            Console.WriteLine("Nie znaleziono użytkownika.");
            return false;
        }

        if (equipment == null)
        {
            Console.WriteLine("Nie znaleziono sprzętu.");
            return false;
        }

        if (equipment.Status != EquipmentStatus.Available)
        {
            Console.WriteLine("Sprzęt nie jest dostępny.");
            return false;
        }

        if (dueDate <= borrowDate)
        {
            Console.WriteLine("Data zwrotu musi być późniejsza niż data wypożyczenia.");
            return false;
        }

        int activeRentalsCount = 0;

        foreach (Rental rental in _rentals)
        {
            if (rental.User.Id == userId && rental.ReturnDate == null)
            {
                activeRentalsCount++;
            }
        }

        int maxAllowedRentals = 0;

        if (user is Student)
        {
            maxAllowedRentals = 2;
        }
        else if (user is Employee)
        {
            maxAllowedRentals = 5;
        }

        if (activeRentalsCount >= maxAllowedRentals)
        {
            Console.WriteLine("Użytkownik przekroczył limit aktywnych wypożyczeń.");
            return false;
        }

        int newRentalId = _rentals.Count + 1;

        Rental rentalToAdd = new Rental(newRentalId, user, equipment, borrowDate, dueDate);

        _rentals.Add(rentalToAdd);
        equipment.Status = EquipmentStatus.Unavailable;

        Console.WriteLine("Sprzęt został poprawnie wypożyczony.");
        return true;
    }
}