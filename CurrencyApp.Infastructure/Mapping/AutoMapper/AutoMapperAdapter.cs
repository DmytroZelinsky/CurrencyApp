using AutoMapper;

using CurrencyApp.Application.Abstraction;

namespace CurrencyApp.Infrastructure.Mapping.AutoMapper;

public class AutoMapperAdapter(IMapper mapper) : ICustomMapper
{
	/// <inheritdoc/>
	public T2 Map<T1, T2>(T1 source) => mapper.Map<T2>(source);

	/// <inheritdoc/>
	public IEnumerable<T2> Map<T1, T2>(IEnumerable<T1> source) => mapper.Map<IEnumerable<T2>>(source);
}
