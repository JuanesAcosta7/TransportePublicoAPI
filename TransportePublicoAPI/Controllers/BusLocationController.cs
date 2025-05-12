using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

[ApiController]
[Route("api/[controller]")]
public class BusLocationController : ControllerBase
{
    private readonly IHubContext<BusHub> _hubContext;

    public BusLocationController(IHubContext<BusHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost]
    public async Task<IActionResult> PostLocation([FromBody] string location)
    {
        // Envía la ubicación a todos los clientes conectados
        await _hubContext.Clients.All.SendAsync("ReceiveBusLocation", location);
        return Ok(new { success = true });
    }
}
