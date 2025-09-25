var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

var app = builder.Build();

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // enable controller routing

app.Run();
