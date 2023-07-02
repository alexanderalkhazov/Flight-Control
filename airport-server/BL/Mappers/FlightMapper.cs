using Accessories.Interfaces;
using DAL.DTOs;

namespace Accessories.Mappers
{
    public class FlightMapper : IMapper<Flight,FlightDto>
	{
		public FlightDto Map(Flight type)
		{
			var newDto = new FlightDto();
			newDto.FlightNumber = type.PlaneNumber;
			newDto.PlaneName = type.PlaneName;
			newDto.EnterTime = type.EnterTime;
			newDto.ExitTime = type.ExitTime;
			
			if (type.IsArriving)
			{
				newDto.FlightType = "Arrving Flight";
			}
			else
			{
				newDto.FlightType = "Departing Flight";
			}
			return newDto;
		}
	}
}
