using WorkOutToDO.Models;
using WoTD_Semesterprojekt.Repos;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});

builder.Services.AddControllers();
builder.Services.AddSingleton<PersonRepo>(new PersonRepo());
var app = builder.Build();
app.UseCors("AllowAllOrigins");


// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
