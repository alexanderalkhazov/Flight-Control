namespace BL.Models
{
	public class PlaneGenerator 
	{
		private enum CountriesEnum
		{
			Israel = 0,
			India = 1,
			Pakistan = 2,
			Egypt = 3,
			Russia = 4,
			Ukraine = 5,
			Germany = 6,
			Tahiland = 7,
			Yemen = 8,
			Jordan = 9,
			China = 10,
			Japan = 11,
			USA = 12,
			Vietnam = 13,
			Greece = 14,
			France = 15,
			Romania = 16,
			Austria = 17,
			Poland = 18,
			Portugal = 19,
			Spain = 20,
			Argentina = 21,
			Marocco = 22,
			Indonesia = 23,
			Korea = 24,
			Cambodia = 25,
			Lebanon = 26,
			Sweden = 27,
		}
		public Flight GeneratePlane()
		{
			Random rnd = new Random();
			var values = Enum.GetValues(typeof(CountriesEnum));
			var randomCountry = (CountriesEnum)rnd.Next(values.Length);
			var rndCountryStr = randomCountry.ToString();
			var randomId = rnd.Next(100, 9999);
			return new Flight(rndCountryStr, randomId);
		}
	}
}
