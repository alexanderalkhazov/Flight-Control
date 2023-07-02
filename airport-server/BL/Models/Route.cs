public class Route : IRoute
{
	public Route()
	{
		Stations = new List<Station>();
		Edges = new List<(Station from, Station to)>();
		InitializeStructure();
	}
	public List<Station> Stations { get; }
	public List<(Station from, Station to)> Edges { get; }
	private void InitializeStructure()
	{
		Station station0 = new Station("Edge1");
		Station station1 = new Station("Station 1");
		Station station2 = new Station("Station 2");
		Station station3 = new Station("Station 3");
		Station station4 = new Station("Station 4");
		Station station5 = new Station("Station 5");
		Station station6 = new Station("Station 6");
		Station station7 = new Station("Station 7");
		Station station8 = new Station("Station 8");
		Station station9 = new Station("Station 9");
		Station station10 = new Station("Edge2");

        this.AddStation(station0);
		this.AddStation(station1);
		this.AddStation(station2);
		this.AddStation(station3);
		this.AddStation(station4);
		this.AddStation(station5);
		this.AddStation(station6);
		this.AddStation(station7);
		this.AddStation(station8);
		this.AddStation(station9);
		this.AddStation(station10);

		this.AddEdge(station0, station6);   //0
		this.AddEdge(station0, station7);   //1
		this.AddEdge(station1, station2);   //2
		this.AddEdge(station2, station3);   //3
		this.AddEdge(station3, station4);   //4
		this.AddEdge(station4, station5);   //5
		this.AddEdge(station4, station9);   //6
		this.AddEdge(station5, station6);   //7
		this.AddEdge(station5, station7);   //8
		this.AddEdge(station6, station8);   //9
		this.AddEdge(station7, station8);   //10 
		this.AddEdge(station8, station4);   //11
		this.AddEdge(station10 , station1); //12
    }
	private void AddStation(Station station)
	{
		if (!Stations.Contains(station))
		{
			Stations.Add(station);
		}
	}
	private void AddEdge(Station from, Station to)
	{
		Edges.Add(new(from, to));
	}
	public List<(Station from, Station to)> GetArrivingRoute()
	{
		return new List<(Station from, Station to)>
		{
			this.Edges[12], 
			this.Edges[2],  
			this.Edges[3], 
			this.Edges[4],  
			this.Edges[5], 
			this.Edges[7],
			this.Edges[8],  
		};
	}
	public List<(Station from, Station to)> GetDepartingRoute()
	{
		return new List<(Station from, Station to)>
		{
			this.Edges[0],  
			this.Edges[1],  
			this.Edges[9],  
			this.Edges[10], 
			this.Edges[11], 
			this.Edges[6]
    };
	}
}



