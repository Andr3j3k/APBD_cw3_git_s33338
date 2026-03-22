# APBD_cw3_git_s33338

# System wypożyczania sprzętu

## Opis projektu
Projekt przedstawia prostą aplikację konsolową napisaną w języku C#, służącą do obsługi uczelnianej wypożyczalni sprzętu.

## Struktura projektu

### Modele domenowe
W projekcie zostały wydzielone klasy modelowe:
- `Equipment` – abstrakcyjna klasa bazowa dla wszystkich typów sprzętu,
- `Laptop`, `Projector`, `Camera` – klasy dziedziczące po `Equipment`,
- `User` – abstrakcyjna klasa bazowa użytkownika,
- `Student`, `Employee` – klasy dziedziczące po `User`,
- `Rental` – klasa opisująca pojedyncze wypożyczenie.

### Klasy serwisowe
Logika aplikacji została rozdzielona do klas serwisowych:
- `EquipmentService` – odpowiada za zarządzanie sprzętem,
- `UserService` – odpowiada za zarządzanie użytkownikami,
- `RentalService` – odpowiada za logikę wypożyczeń i zwrotów.

## Decyzje projektowe
Podział na modele i serwisy został zastosowany po to, aby rozdzielić dane od logiki biznesowej.

Klasy `Equipment` i `User` zostały wykonane jako klasy abstrakcyjne, ponieważ reprezentują wspólne cechy dla konkretnych typów sprzętu i użytkowników. Dzięki temu część wspólna nie jest powielana w klasach pochodnych.

Dziedziczenie zostało użyte tam, gdzie wynika to z modelu domeny:
- `Laptop`, `Projector` i `Camera` są rodzajami sprzętu,
- `Student` i `Employee` są rodzajami użytkowników.

## Scenariusz demonstracyjny
W `Main.cs` pokazano między innymi:
- dodanie kilku egzemplarzy sprzętu różnych typów,
- dodanie kilku użytkowników różnych typów,
- poprawne wypożyczenie sprzętu,
- próbę wykonania niepoprawnej operacji,
- zwrot sprzętu w terminie,
- zwrot opóźniony skutkujący naliczeniem kary,
- wyświetlenie raportu końcowego o stanie systemu.