using BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AirportController : ControllerBase
	{
		private readonly ISimulator _simulator;

		public AirportController(ISimulator simulator)
		{
			_simulator = simulator;
		}
		[HttpGet("starttimer")]
		public void GetStart()
		{
			 _simulator.Start();
		}
	}
}
