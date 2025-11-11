namespace DefaultNamespace;

using Infastructure;
using Domain;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;

public class BookService : IBookService
{
    DbContext _conn;
    public BookService()
    {
        _conn = new DbContext();
    }
    public async Task<int> AddBookAsync(Book book)
    {
        using var conn = _conn.GetConnect();
        string query = "insert into books(title,publishedyear,genre,author_id) values(@title,@publishedyear,@genre,@author_id)";
        var result = await conn.ExecuteAsync(query, new {book.Title,book.PublishedYear,book.Genre,book.Author_Id });
        return result;    
        }

    public async Task<int> DeleteBookAsync(int id)
    {
         using var conn = _conn.GetConnect();
        string query = "delete from books where id = @id";
        var result = await conn.ExecuteAsync(query, new { id});
        return result;    
        }
    

    public async Task<Book> GetBookByIdAsync(int id)
    {
        using var conn = _conn.GetConnect();
        string query = "select * from bookloans where id = @id";
        var result = (await conn.QueryAsync<Book>(query,new{id})).ToList();
        return result;
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        using var conn = _conn.GetConnect();
        string query = "select * from bookloans where id = @id";
        var result = (await conn.QueryFirstOrDefaultAsync<Book>(query));
        return result;
    }

    public async Task<int> UpdateBookAsync(Book book)
    {
        using var conn = _conn.GetConnect();
        string query = "update books set tite = @title, publishedyear = @publishedyear, genre = @genre, author_id where id = @id";
        var result = await conn.ExecuteAsync(query, new {book.Title,book.PublishedYear,book.Genre,book.Author_Id,book.Id});
        return result;
    }

  
}