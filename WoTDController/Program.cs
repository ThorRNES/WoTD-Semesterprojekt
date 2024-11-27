using WorkOutToDO.Models;
using WorkOutToDO.Repos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.AddSingleton<Func<Person, int>>(provider => person => person.Id);
builder.Services.AddSingleton<GenericRepo<Person>>();

builder.Services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
