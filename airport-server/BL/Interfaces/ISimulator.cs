using System.Timers;

namespace BL.Interfaces
{
    public interface ISimulator
    {
        void CreateArrivngFlight(object? sender, ElapsedEventArgs e);
        void CreateDepartingFlight(object? sender, ElapsedEventArgs e);
		void Start();
    }
}