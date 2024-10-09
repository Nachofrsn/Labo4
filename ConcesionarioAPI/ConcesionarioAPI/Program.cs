using concesionarioAPI.Config;
using concesionarioAPI.Repositories;
using concesionarioAPI.Services;
<<<<<<< HEAD
using concesionarioAPI.Utils.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
=======
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
>>>>>>> 030e5a364a6670effa8e7a2f8c43c7491087b1d9
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { 
        Version = "v1",
        Title = "Un concesionario",
        Description = "Hay autos"
    });

    options.AddSecurityDefinition("Tony token", new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Description = "Ingrese el tony token JWT que va a ser usado en cabecera",
        Name = "Tony AUTH",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    options.OperationFilter<AuthOperationFilter>();
});

// Services: Agregamos los servicios al scope para utilizar Inyección de Depndencias.
builder.Services.AddScoped<AutoServices>();
builder.Services.AddScoped<CombustibleServices>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<IEncoderServices, EncoderServices>();
builder.Services.AddScoped<AuthServices>();

// Repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAutoRepository, AutoRepository>();
builder.Services.AddScoped<ICombustibleRepository, CombustibleRespository>();

// Repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Mapping));

// SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
});

<<<<<<< HEAD
// secret key
var secretKey = builder.Configuration.GetSection("jwtSettings").GetSection("secretKey").ToString();

// JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });
=======
//secret key
string secretKey = builder.Configuration.GetSection("jwtSettings").GetSection("secretKey").ToString();

// jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
    };
});
>>>>>>> 030e5a364a6670effa8e7a2f8c43c7491087b1d9

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
