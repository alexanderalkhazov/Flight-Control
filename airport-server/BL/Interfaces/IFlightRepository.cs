namespace BL.Interfaces
{
	public interface IFlightRepository<T>
	{
		void SaveFlight(T obj);
	}
}
