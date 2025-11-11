using Microsoft.AspNetCore.Mvc;
using Domain;
using Infastructure;
using DefaultNamespace;
namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost]
    public async Task<string> CreateUserAsync(User user)
    {
        var result = await userService.AddUserAsync(user);
        string answer = (result > 0) ? "User Added Successfully!" : "User not added successfully!"; 
        return answer;
    }

    [HttpPut]
    public async Task<string> UpdateUserAsync(User user)
    {
        var result = await userService.UpdateUserAsync(user);
        string answer = (result > 0) ? "User Updated Successfully!" : "User not updated successfully!"; 
        return answer;
    }

    [HttpDelete]
    public async Task<string> DeleteUserAsync(int id)
    {
        var result = await userService.DeleteUserAsync(id);
        string answer = (result > 0) ? "User Deleted Successfully!" : "User not deleted successfully!";
        return answer;
    }

    [HttpGet("ById")]
    public async Task<User?> GetUserByIdAsync(int id)
    {
        var result = await userService.GetUserByIdAsync(id);
        return result;
    }

    [HttpGet]
    public async Task<List<User>> GetUsersAsync()
    {
        var result = await userService.GetUsersAsync();
        return result;
    }
}
