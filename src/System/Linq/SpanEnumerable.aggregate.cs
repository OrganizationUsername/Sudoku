namespace System.Linq;

public partial class SpanEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TSource">The type of source elements.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<TSource>(ReadOnlySpan<TSource> source)
	{
		/// <inheritdoc cref="IAggregateMethod{TSelf, TSource}.Aggregate(Func{TSource, TSource, TSource})"/>
		public TSource Aggregate(Func<TSource, TSource, TSource> func)
		{
			var result = default(TSource)!;
			foreach (var element in source)
			{
				result = func(result, element);
			}
			return result;
		}

		/// <inheritdoc cref="IAggregateMethod{TSelf, TSource}.Aggregate{TAccumulate, TResult}(TAccumulate, Func{TAccumulate, TSource, TAccumulate}, Func{TAccumulate, TResult})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TAccumulate Aggregate<TAccumulate>(TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
			where TAccumulate : allows ref struct
		{
			var result = seed;
			foreach (var element in source)
			{
				result = func(result, element);
			}
			return result;
		}
	}
}
