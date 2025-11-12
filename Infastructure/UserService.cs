namespace Infastructure;
using Dapper;
using Npgsql;
using Domain;
using DefaultNamespace;
using Infastructure;
public class UserService : IUserService
{
    DbContext _conn;
    public UserService()
    {
        _conn = new DbContext();
    }
    public async Task<int> AddUserAsync(User user)
    {
        using var conn = _conn.GetConnect();
        string query = "insert into users(fullname,email,registeredat) values(@fullname,@email,@registeredat)";
        var result = await conn.ExecuteAsync(query, new{user.FullName,user.Email,user.RegisteredAt});
        return result;    
        }

    public async Task<int> DeleteUserAsync(int id)
    {
        using var conn = _conn.GetConnect();
        string query = "delete from users where id = @id";
        var result = await conn.ExecuteAsync(query, new { id});
        return result;    
        }
    

    public async Task<User?> GetUserByIdAsync(int id)
    {
        using var conn = _conn.GetConnect();
        string query = "select * from users where id = @id";
        var result = (await conn.QueryFirstOrDefaultAsync<User>(query,new{id}));
        return result;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        using var conn = _conn.GetConnect();
        string query = "select * from users";
        var result = (await conn.QueryAsync<User>(query)).ToList(); 
        return result;
    }

    public async Task<int> UpdateUserAsync(User user)
    {
        using var conn = _conn.GetConnect();
        string query = "update users set fullname = @fullname, email = @email, registeredat = @registeredat where id = @id";
        var result = await conn.ExecuteAsync(query, new {user.FullName,user.Email,user.RegisteredAt,user.Id});
        return result;
    }
}