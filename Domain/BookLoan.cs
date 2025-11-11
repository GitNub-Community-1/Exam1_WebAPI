namespace DefaultNamespace;

public class BookLoan
{
    public int Id { get; set; }
    public int Book_Id { get; set; }
    public int User_Id { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDate { get; set; }
}