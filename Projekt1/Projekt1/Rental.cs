namespace Projekt1;

public class Rental
{
    public int Id { get; set; }
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal Penalty { get; set; }

    public Rental(int id, User user, Equipment equipment, DateTime borrowDate, DateTime dueDate)
    {
        Id = id;
        User = user;
        Equipment = equipment;
        BorrowDate = borrowDate;
        DueDate = dueDate;
        ReturnDate = null;
        Penalty = 0;
    }
}