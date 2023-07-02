using System.Timers;
using BL.Interfaces;

namespace BL.Models
{
    namespace Airportproject1.Services
    {
        public class Simulator : ISimulator
		{
			private readonly System.Timers.Timer _timerArriving;
			private readonly System.Timers.Timer _timerDeparturing;
			private readonly IHubService _hub;
			private readonly PlaneGenerator _planeGenerator;
			private readonly IRoute _route;
			private readonly List<Flight> _activeFlights;
			private readonly IFlightRepository<Flight> _repo;
			private const int TIMER_INTERVAL = 5000;

			public Simulator(IHubService service , IRoute route , IFlightRepository<Flight> repo)
			{
				_planeGenerator = new PlaneGenerator();
				_activeFlights = new List<Flight>();
				_hub = service;
				_route = route;
				_repo = repo;
				_timerDeparturing = new System.Timers.Timer(TIMER_INTERVAL);
				_timerArriving = new System.Timers.Timer(TIMER_INTERVAL);
			}
			public void Start()
			{
				_timerArriving.Elapsed += CreateArrivngFlight;
				_timerArriving.AutoReset = true;
				_timerArriving.Enabled = true;
				_timerDeparturing.Elapsed += CreateDepartingFlight;
				_timerDeparturing.AutoReset = true;
				_timerDeparturing.Enabled = true;
			}
			public void CreateArrivngFlight(object? sender, ElapsedEventArgs e)
			{
				var arrivngFlight = _planeGenerator.GeneratePlane();
				arrivngFlight.IsArriving = true;
				arrivngFlight.EnterTime = DateTime.Now;
				Task.Run(async () =>
				{
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Created Arriving Flight {arrivngFlight.PlaneNumber} {arrivngFlight.PlaneName} at {arrivngFlight.EnterTime} ");
                    var arrivingRoute = _route.GetArrivingRoute();
				    _activeFlights.Add(arrivngFlight);
					await arrivngFlight.RunFlight(_hub, arrivingRoute, _route , _activeFlights);
				});

                arrivngFlight.ExitTime = DateTime.Now;
              //  _repo.SaveFlight(arrivngFlight);
            }
			public void CreateDepartingFlight(object? sender, ElapsedEventArgs e)
			{
				var departingFlight = _planeGenerator.GeneratePlane();
				departingFlight.IsArriving = false;
				departingFlight.EnterTime = DateTime.Now;
				Task.Run(async () =>
				{
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Created Departing Flight {departingFlight.PlaneNumber} {departingFlight.PlaneName} at {departingFlight.EnterTime} ");
                    var dep = _route.GetDepartingRoute();
				    _activeFlights.Add(departingFlight);
                    await departingFlight.RunFlight(_hub, dep , _route , _activeFlights);
				});
                departingFlight.ExitTime = DateTime.Now;
			//	_repo.SaveFlight(departingFlight);
			}
		}
	}
}