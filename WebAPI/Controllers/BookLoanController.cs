using Microsoft.AspNetCore.Mvc;
using Domain;
using Infastructure;
using DefaultNamespace;
namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookLoanController
{
    private readonly IBookLoanService bookLoanService;

    public BookLoanController(IBookLoanService bookLoanService)
    {
        this.bookLoanService = bookLoanService;
    }

    [HttpPost]
    public async Task<string> CreateBookLoanAsync(BookLoan bookLoan)
    {
        var result = await bookLoanService.AddBookLoanAsync(bookLoan);
        string answer = (result > 0) ? "Book Loan Added Successfully!" : "Book Loan not added successfully!"; 
        return answer;
    }

    [HttpPut]
    public async Task<string> UpdateBookLoanAsync(BookLoan bookLoan)
    {
        var result = await bookLoanService.UpdateBookLoanAsync(bookLoan);
        string answer = (result > 0) ? "Book Loan Updated Successfully!" : "Book Loan not updated successfully!"; 
        return answer;
    }

    [HttpDelete]
    public async Task<string> DeleteBookLoanAsync(int id)
    {
        var result = await bookLoanService.DeleteBookLoanAsync(id);
        string answer = (result > 0) ? "Book Loan Deleted Successfully!" : "Book Loan not deleted successfully!";
        return answer;
    }

    [HttpGet("ById")]
    public async Task<BookLoan?> GetBookLoanByIdAsync(int id)
    {
        var result = await bookLoanService.GetBookLoanByIdAsync(id);
        return result;
    }

    [HttpGet]
    public async Task<List<BookLoan>> GetBookLoansAsync()
    {
        var result = await bookLoanService.GetBookLoansAsync();
        return result;
    }
}
