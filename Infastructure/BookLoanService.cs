namespace DefaultNamespace;
using Domain;
using Infastructure;
using Npgsql;
using Dapper;
public class BookLoanService
{
     DbContext _conn;
    public BookLoanService()
    {
        _conn = new DbContext();
    }
    public async Task<int> AddBookLoanAsync (BookLoan book)
    {
        using var conn = _conn.GetConnect();
        string query = "insert into bookloans(book_id,user_id,loandate,returndate) values(@book_id,@user_id,@loandate,@returndate)";
        var result = await conn.ExecuteAsync(query, new {book.Book_Id,book.User_Id,book.LoanDate,book.ReturnDate });
        return result;
    }

    public async Task<int> DeleteBookLoanAsync(int id)
    {
        using var conn = _conn.GetConnect();
        string query = "delete from bookloans where id = @id";
        var result = await conn.ExecuteAsync(query, new { id});
        return result;    }

    public async Task<List<BookLoan>> GetBookLoansAsync()
    {
        using var conn = _conn.GetConnect();
        string query = "select * from bookloans ";
        var result = (await conn.QueryAsync<BookLoan>(query)).ToList();
        return result;
    }

    public async Task<BookLoan> GetBookLoanByIdAsync(int id)
    {
        using var conn = _conn.GetConnect();
        string query = "select * from bookloans where id = @id";
        var result = (await conn.QueryFirstOrDefaultAsync<BookLoan>(query,new{id}));
        return result;
    }

    public async Task<int> UpdateBookLoanAsync(BookLoan book)
    {
        using var conn = _conn.GetConnect();
        string query = "update authors set book_id = @book_id, user_id = @user_id, loandate = @loandate, returndate = @returndate where id = @id";
        var result = await conn.ExecuteAsync(query, new {book.Book_Id,book.User_Id,book.LoanDate,book.ReturnDate,book.Id});
        return result;
    }
}