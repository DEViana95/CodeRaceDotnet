using BaseApi.Domain.Services;
using BaseApi.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#region Injeção de depêndencias
builder.Services.AddScoped<ICitiesService, CitiesService>();
builder.Services.AddScoped<IIncidentTypesService, IncidentTypesService>();
builder.Services.AddScoped<IParametersService, ParametersService>();
builder.Services.AddScoped<IUsersService, UsersService>();
#endregion Injeção de depêndencias

// Adiciona suporte para controladores
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
