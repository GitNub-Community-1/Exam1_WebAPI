using DefaultNamespace;
using Domain;
using Infastructure;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5000", "https://localhost:7000");
// Add services to the container
builder.Services.AddScoped<IAuthorService,AuthorService>();
builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookLoanService,BookLoanService>();
builder.Services.AddScoped<DbContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
