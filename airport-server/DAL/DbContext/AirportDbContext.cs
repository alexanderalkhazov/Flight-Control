using DAL.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AirportDbContext : DbContext
	{
		public AirportDbContext(DbContextOptions options) : base(options)
		{
			Console.WriteLine("Db Context Was Instanced");
		}
		public virtual DbSet<FlightDto>? FlightDtos { get; set; }
	}

}
