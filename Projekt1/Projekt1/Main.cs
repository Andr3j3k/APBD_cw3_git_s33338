using Projekt1;

EquipmentService equipmentService = new EquipmentService();
UserService userService = new UserService();
RentalService rentalService = new RentalService(equipmentService, userService);

// Użytkownicy
Student student1 = new Student(1, "Jan", "Kowalski", "s12345");
Employee employee1 = new Employee(2, "Anna", "Nowak", "IT");

// Sprzęt
Laptop laptop1 = new Laptop(1, "Dell XPS 15", "Dell", EquipmentStatus.Available, 16, "Intel i7");
Projector projector1 = new Projector(2, "Epson EB-X49", "Epson", EquipmentStatus.Available, 3600, "1024x768");
Camera camera1 = new Camera(3, "Canon EOS 250D", "Canon", EquipmentStatus.Available, 24, "18-55mm");

// Dodanie użytkowników
userService.AddUser(student1);
userService.AddUser(employee1);

// Dodanie sprzętu
equipmentService.AddEquipment(laptop1);
equipmentService.AddEquipment(projector1);
equipmentService.AddEquipment(camera1);

Console.WriteLine("Dodano użytkowników i sprzęt do systemu.");

Console.WriteLine("\n--- Cały sprzęt ---");
foreach (Equipment equipment in equipmentService.GetAllEquipments())
{
    Console.WriteLine($"{equipment.Id} | {equipment.Name} | {equipment.Brand} | {equipment.Status}");
}

Console.WriteLine("\n--- Dostępny sprzęt ---");
foreach (Equipment equipment in equipmentService.GetAvailableEquipments())
{
    Console.WriteLine($"{equipment.Id} | {equipment.Name} | {equipment.Brand} | {equipment.Status}");
}

Console.WriteLine("\n--- Poprawne wypożyczenie ---");
rentalService.BorrowEquipment(1, 1, DateTime.Now, DateTime.Now.AddDays(7));

Console.WriteLine("\n--- Błędna próba wypożyczenia tego samego sprzętu ---");
rentalService.BorrowEquipment(2, 1, DateTime.Now, DateTime.Now.AddDays(3));

Console.WriteLine("\n--- Zwrot w terminie ---");
rentalService.ReturnEquipment(1, DateTime.Now.AddDays(5));

Console.WriteLine("\n--- Wypożyczenie kamery przez pracownika ---");
rentalService.BorrowEquipment(2, 3, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5));

Console.WriteLine("\n--- Zwrot po terminie ---");
rentalService.ReturnEquipment(2, DateTime.Now);
Console.WriteLine("\n--- Szczegóły wypożyczeń po zwrocie ---");
foreach (Rental rental in rentalService.GetAllRentals())
{
    Console.WriteLine($"RentalId: {rental.Id} | Sprzęt: {rental.Equipment.Name} | Kara: {rental.Penalty} | Data zwrotu: {rental.ReturnDate}");
}

Console.WriteLine("\n--- Aktywne wypożyczenia użytkownika 2 ---");
foreach (Rental rental in rentalService.GetActiveRentalsByUser(2))
{
    Console.WriteLine($"RentalId: {rental.Id} | Sprzęt: {rental.Equipment.Name} | Termin: {rental.DueDate}");
}

Console.WriteLine("\n--- Przeterminowane wypożyczenia ---");
foreach (Rental rental in rentalService.GetOverDueRentals())
{
    Console.WriteLine($"RentalId: {rental.Id} | Użytkownik: {rental.User.Name} {rental.User.Surname} | Sprzęt: {rental.Equipment.Name} | Termin: {rental.DueDate}");
}

Console.WriteLine("\n--- Raport końcowy ---");
Console.WriteLine($"Liczba użytkowników: {userService.GetAllUsers().Count}");
Console.WriteLine($"Liczba sprzętów: {equipmentService.GetAllEquipments().Count}");
Console.WriteLine($"Liczba wypożyczeń: {rentalService.GetAllRentals().Count}");
Console.WriteLine($"Liczba dostępnych sprzętów: {equipmentService.GetAvailableEquipments().Count}");
Console.WriteLine($"Liczba przeterminowanych wypożyczeń: {rentalService.GetOverDueRentals().Count}");