using Microsoft.AspNetCore.Mvc;
using Domain;
using Infastructure;
using DefaultNamespace;
namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController
{
    private readonly IBookService bookService;

    public BookController(IBookService bookService)
    {
        this.bookService = bookService;
    }

    [HttpPost]
    public async Task<string> CreateBookAsync(Book book)
    {
        var result = await bookService.AddBookAsync((book));
        string answer = (result > 0) ? "Book Added Succefully!" : "Book not added sussefully!"; 
        return answer;
    }

    [HttpPut]
    public async Task<string> UpdateBookAsync(Book book)
    {
        var result = await bookService.UpdateBookAsync(book);
        string answer = (result > 0) ? "Book Update Succefully!" : "Book not update sussefully!"; 
        return answer;
    }

    [HttpDelete]
    public async Task<string> DeleteBookAsync(int id)
    {
        var result = await bookService.DeleteBookAsync(id);
        string answer = (result > 0) ? "Book Delete Succefully!" : "Book not delete sussefully!";
        return answer;
    }
    [HttpGet ("By Id")]
    public async Task<Book?> ShowBookByIdAsync(int id)
    {
        var result = await bookService.GetBookByIdAsync(id);
        return result;
    }
    [HttpGet]
    public async Task<List<Book>> ShowBooksAsync()
    {
        var result = await bookService.GetBooksAsync();
        return result;
    }
}