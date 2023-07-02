public class Station
{
    private const int TIMER_IN_STATION = 2000;
    private readonly SemaphoreSlim _sem;
	public Station(string stationName)
	{
		StationName = stationName;
		_sem  = new(1);
	}
	public string StationName { get; set; }
	public Flight? CurrentPlane { get; set; }
    public async Task EnterStation(IHubService hub,List<Station> stations)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Flight {CurrentPlane!.PlaneName} {CurrentPlane!.PlaneNumber} Entered station {StationName} at {CurrentPlane!.EnterTime}");
        await hub.UpdateState(stations);
        await Task.Delay(TIMER_IN_STATION);
    }
    public async Task<Station> CheckEnter(Flight flight, CancellationTokenSource cts)
    {
        CancellationToken token = cts.Token;
        await _sem.WaitAsync(token);
        cts.Cancel();    
        CurrentPlane = flight;
        return this;
    }
    public async Task ExitStation(Flight flight,IHubService hub,List<Station> stations)
	{
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Flight {flight.PlaneName} {flight.PlaneNumber} existed station {StationName} at {flight.EnterTime}");
		await hub.UpdateState(stations);
        CurrentPlane = null;
		_sem.Release();
	}

}



