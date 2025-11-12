
using Domain;

namespace DefaultNamespace;

public interface IAuthorService
{
    public Task<int> AddAuthorAsync(Author author);
    public Task<int> UpdateAuthorAsync(Author author);
    public Task<int> DeleteAuthorAsync(int id);
    public Task<Author?> GetAuthorByIdAsync(int id);
    public Task<List<Author>> GetAuthorAsync();
}