using Accessories.Interfaces;
using Accessories.Mappers;
using BL.Interfaces;
using DAL;
using DAL.DTOs;
using Microsoft.Extensions.DependencyInjection;

namespace BL.Repositories
{
    public class FlightRepository : IFlightRepository<Flight>
	{
	    private readonly IMapper<Flight,FlightDto> _mapper;
		private readonly IServiceScopeFactory _serviceScopeFactory;

		public FlightRepository(IServiceScopeFactory serviceScopeFactory)
		{
			_mapper = new FlightMapper();
			_serviceScopeFactory = serviceScopeFactory;
		}
		public void SaveFlight(Flight obj)
		{
			using (var scope = _serviceScopeFactory.CreateScope())
			{
				var myScopedService = scope.ServiceProvider.GetService<AirportDbContext>();
				var dto = _mapper.Map(obj);
				if (myScopedService != null && myScopedService.FlightDtos != null)
				{
					myScopedService.FlightDtos.Add(dto);
					myScopedService.SaveChanges();
					Console.WriteLine("Flight info saved");
				}
			}
		}
	}
}
