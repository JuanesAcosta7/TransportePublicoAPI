using Microsoft.AspNetCore.SignalR;

public class BusHub : Hub
{
    public async Task SendBusLocation(string location)
    {
        // Envía la ubicación del bus a todos los clientes conectados
        await Clients.All.SendAsync("ReceiveBusLocation", location);
    }
}
