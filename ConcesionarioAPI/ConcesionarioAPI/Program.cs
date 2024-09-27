using concesionarioAPI.Config;
using concesionarioAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services: Agregamos los servicios al scope para utilizar Inyección de Depndencias.
builder.Services.AddScoped<AutoServices>();
builder.Services.AddScoped<CombustibleServices>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<IEncoderServices, EncoderServices>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Mapping));

// SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
});

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

app.Run();
