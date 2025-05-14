namespace CurrencyApp.Application.Abstraction;

public interface ICustomMapper
{ 
	T2 Map<T1, T2>(T1 source);

	IEnumerable<T2> Map<T1, T2>(IEnumerable<T1> source);
}
