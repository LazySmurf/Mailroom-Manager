global using Mailroom_API.Data;
global using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Testing routes, to check that everything is working.
/*
app.MapGet("/", () => "Welcome to the Mailroom API. Please enter a valid request."); //Returns a default response to the API server root
app.MapGet("/time/now", () => DateTime.Now.ToString("hh:mm:ss dd/MM/yyyy")); //Returns the current Time and Date
app.MapGet("/time/now/unix", () => DateTimeOffset.Now.ToUnixTimeSeconds().ToString()); //Returns the current Unix timestamp
*/

app.Run();