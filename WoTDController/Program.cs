using WorkOutToDO.Models;
using WorkOutToDO.Repos;
using WoTD_Semesterprojekt.Repos;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();
builder.Services.AddSingleton<PersonRepo>(new PersonRepo());
var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
