using System.Net.WebSockets;
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
builder.Services.AddScoped<IReportDisasterService, ReportDisasterService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IGravityService, GravityService>();
#endregion Injeção de depêndencias

// Adiciona suporte para controladores
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() // Allows all origins
                   .AllowAnyHeader() // Allows all headers
                   .AllowAnyMethod(); // Allows all methods
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseWebSockets(); // Adiciona suporte a WebSocket

app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        var webSocket = await context.WebSockets.AcceptWebSocketAsync();
        await SendAllData(context, webSocket);
    }
    else
    {
        context.Response.StatusCode = 400;
    }
});

app.MapControllers();

app.Run();

static async Task SendAllData(HttpContext context, WebSocket webSocket)
{
    // Chame o serviço para obter todos os dados
    var reportDisasterService = context.RequestServices.GetRequiredService<IReportDisasterService>();
    var response = reportDisasterService.GetAll();

    // Converte os dados para JSON
    var jsonResponse = System.Text.Json.JsonSerializer.Serialize(response);

    // Envia os dados JSON através do WebSocket
    var buffer = System.Text.Encoding.UTF8.GetBytes(jsonResponse);
    await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);

    // Fecha o WebSocket
    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Data sent", CancellationToken.None);
}