public class Flight 
{
   private CancellationTokenSource _cts = null!;
    public Flight(string planeName,int planeNum)
    {
		PlaneName = planeName;
        PlaneNumber = planeNum;
        IsArriving = true;
    }
   public int PlaneNumber { get; set; }
   public string PlaneName { get; private set; }
   public bool IsArriving { get; set; }
   public DateTime EnterTime { get; set; }
   public DateTime ExitTime { get; set; }

    public async Task RunFlight(IHubService hub, List<(Station from, Station to)> edges, IRoute route, List<Flight> activeFlights)
    {
        await Task.Run(async() =>
        {
            Station nextStation = edges[0].to;
            Station? currentStation = edges[0].from;
			await hub.UpdateFlights(activeFlights);
            while (currentStation != null){
                _cts = new();
                await currentStation.ExitStation(this, hub, route.Stations);
                List<Station> tos = GetNextStations(currentStation, edges);
                if (tos.Count == 0)
                {
                    break;
                }
                nextStation = await GetFirstEnters(tos, hub);
                await MoveToNextStation(nextStation, hub, route.Stations, currentStation);
                currentStation = nextStation;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"------Flight {PlaneNumber} {PlaneName} left the terminal at {ExitTime}-------");
            activeFlights.Remove(this);
            await hub.UpdateFlights(activeFlights);
        });
    }
    private List<Station> GetNextStations(Station from, List<(Station from, Station to)> edges)
    {
        var listOfTo = new List<Station>();
        foreach (var edge in edges)
        {
            if (from == edge.from)
                listOfTo.Add(edge.to);
        }
        return listOfTo;
    }
    private async Task<Station> GetFirstEnters(List<Station> stations, IHubService hub)
    {
        var enterStationTasks = stations
           .Select(async s => await s.CheckEnter(this, _cts)).ToList();

        var enteredStation = await Task.WhenAny(enterStationTasks);
        return await enteredStation;
    }
    private async Task MoveToNextStation(Station NextStation, IHubService hub, List<Station> stationList , Station CurrentStation)
    {
        await NextStation.EnterStation( hub, stationList);
    }
}



