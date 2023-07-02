namespace Accessories.Interfaces
{
    public interface IMapper<F,D>
	{
		D Map(F type);
	}
}
