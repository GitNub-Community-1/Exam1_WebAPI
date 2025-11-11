using Microsoft.AspNetCore.Mvc;
using Domain;
using Infastructure;
using DefaultNamespace;
namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController
{
    private readonly IAuthorService authorService;

    public AuthorController(IAuthorService authorService)
    {
        this.authorService = authorService;
    }

    [HttpPost]
    public async Task<string> CreateAuthorAsync(Author author)
    {
        var result = await authorService.AddAuthorAsync(author);
        string answer = (result > 0) ? "Author Added Successfully!" : "Author not added successfully!"; 
        return answer;
    }

    [HttpPut]
    public async Task<string> UpdateAuthorAsync(Author author)
    {
        var result = await authorService.UpdateAuthorAsync(author);
        string answer = (result > 0) ? "Author Updated Successfully!" : "Author not updated successfully!"; 
        return answer;
    }

    [HttpDelete]
    public async Task<string> DeleteAuthorAsync(int id)
    {
        var result = await authorService.DeleteAuthorAsync(id);
        string answer = (result > 0) ? "Author Deleted Successfully!" : "Author not deleted successfully!";
        return answer;
    }

    [HttpGet("ById")]
    public async Task<Author?> GetAuthorByIdAsync(int id)
    {
        var result = await authorService.GetAuthorByIdAsync(id);
        return result;
    }

    [HttpGet]
    public async Task<List<Author>> GetAuthorsAsync()
    {
        var result = await authorService.GetAuthorAsync();
        return result;
    }
}
