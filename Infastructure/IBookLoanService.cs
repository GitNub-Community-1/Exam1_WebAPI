namespace DefaultNamespace;

using Domain;

public interface IBookLoanService
{
    public Task<int> AddBookLoanAsync(BookLoan bookLoan);
    public Task<int> UpdateBookLoanAsync(BookLoan bookLoan);
    public Task<int>  DeleteBookLoanAsync(int id);
    public Task<BookLoan?> GetBookLoanByIdAsync(int id);
    public Task<List<BookLoan>> GetBookLoansAsync();
}