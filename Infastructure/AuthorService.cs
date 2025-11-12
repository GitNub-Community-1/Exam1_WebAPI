
using System.Data.Common;
using Domain;
using Infastructure;
using Dapper;
using Npgsql;
namespace DefaultNamespace;

public class AuthorService : IAuthorService
{
    DbContext _conn;
    public AuthorService()
    {
        _conn = new DbContext();
    }
    public async Task<int> AddAuthorAsync(Author author)
    {
        using var conn = _conn.GetConnect();
        string query = "insert into authors(fullname,birthdate,country) values(@fullname,@birthdate,@country)";
        var result = await conn.ExecuteAsync(query, new { author.FullName, author.BirthDate, author.Country });
        return result;
    }

    public async Task<int> DeleteAuthorAsync(int id)
    {
        using var conn = _conn.GetConnect();
        string query = "delete from authors where id = @id";
        var result = await conn.ExecuteAsync(query, new { id});
        return result;    }

    public async Task<List<Author>> GetAuthorAsync()
    {
        using var conn = _conn.GetConnect();
        string query = "select * from authors ";
        var result = (await conn.QueryAsync<Author>(query)).ToList();
        return result;
    }

    public async Task<Author?> GetAuthorByIdAsync(int id)
    {
        using var conn = _conn.GetConnect();
        string query = "select * from authors where id = @id";
        var result = (await conn.QueryFirstOrDefaultAsync<Author>(query,new{id}));
        return result;
    }

    public async Task<int> UpdateAuthorAsync(Author author)
    {
        using var conn = _conn.GetConnect();
        string query = "update authors set fullname = @fullname,birthdate = @birthdate,country = @country where id = @id";
        var result = await conn.ExecuteAsync(query, new { author.FullName, author.BirthDate, author.Country, author.Id });
        return result;
    }
}