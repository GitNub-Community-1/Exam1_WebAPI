namespace DefaultNamespace;

public interface IBookService
{
    public Task<int> AddBookAsync(Book book);
    public Task<int> UpdateBookAsync(Book book);
    public Task<int>  DeleteBookAsync(int id);
    public Task<Book> GetBookByIdAsync(int id);
    public Task<List<Book>> GetBooksAsync();
}