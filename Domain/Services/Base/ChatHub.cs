using Microsoft.AspNetCore.SignalR;

namespace BaseApi.Domain.Services.Base
{
    using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    // Método chamado pelos clientes para enviar uma mensagem
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
}