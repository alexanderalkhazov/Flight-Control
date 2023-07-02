using Accessories.Interfaces;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessories.Mappers
{
	public class FlightMapper : IMapper<Flight,FlightDto>
	{
		public FlightDto Map(Flight type)
		{
			var newDto = new FlightDto();

			newDto.PlaneId = type.PlaneId;
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
