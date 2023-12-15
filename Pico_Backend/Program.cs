using MySqlConnector;
using Pico_Backend.Interface;
using Pico_Backend.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        }
        );
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddMySqlDataSource(connectionString);
builder.Services.AddScoped<ITelevisonRepository, TelevisonRepository>();
builder.Services.AddScoped<IDieuHoaRepository, DieuHoaRepository>();
var app = builder.Build();
app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
