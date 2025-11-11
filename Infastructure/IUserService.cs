namespace DefaultNamespace;

public interface IUserService
{
    public Task<int> AddUserAsync(User user);
    public Task<int> UpdateUserAsync(User user);
    public Task<int>  DeleteUserAsync(int id);
    public Task<User> GetUserByIdAsync(int id);
    public Task<List<User>> GetUsersAsync();
}