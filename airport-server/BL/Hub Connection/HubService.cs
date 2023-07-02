using Microsoft.AspNetCore.SignalR;
public class HubService : IHubService
{
	private readonly IHubContext<AirportHub> _hubContext;
	public HubService(IHubContext<AirportHub> hubContext)
	{
		_hubContext = hubContext;
	}
	public async Task UpdateState(List<Station> currentUpdate )
	{
		await _hubContext.Clients.All.SendAsync("GetStations", currentUpdate );
	}

	public async Task UpdateFlights(List<Flight> flightsUpdate)
	{
		await _hubContext.Clients.All.SendAsync("GetFlights", flightsUpdate);
	}
}









