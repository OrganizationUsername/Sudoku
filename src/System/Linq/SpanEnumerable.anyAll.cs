namespace System.Linq;

public partial class SpanEnumerable
{
	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TSource"/>.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements of source.</typeparam>
	/// <param name="source">The collection to be used and checked.</param>
	extension<TSource>(ReadOnlySpan<TSource> source)
	{
		/// <inheritdoc cref="IAnyAllMethod{TSelf, TSource}.Any(Func{TSource, bool})"/>
		public bool Any(Func<TSource, bool> match)
		{
			foreach (var element in source)
			{
				if (match(element))
				{
					return true;
				}
			}
			return false;
		}

		/// <inheritdoc cref="Any{TSource}(ReadOnlySpan{TSource}, Func{TSource, bool})"/>
		public unsafe bool AnyUnsafe(delegate*<TSource, bool> match)
		{
			foreach (var element in source)
			{
				if (match(element))
				{
					return true;
				}
			}
			return false;
		}

		/// <inheritdoc cref="IAnyAllMethod{TSelf, TSource}.All(Func{TSource, bool})"/>
		public bool All(Func<TSource, bool> match)
		{
			foreach (var element in source)
			{
				if (!match(element))
				{
					return false;
				}
			}
			return true;
		}

		/// <inheritdoc cref="All{TSource}(ReadOnlySpan{TSource}, Func{TSource, bool})"/>
		public unsafe bool AllUnsafe(delegate*<TSource, bool> match)
		{
			foreach (var element in source)
			{
				if (!match(element))
				{
					return false;
				}
			}
			return true;
		}
	}
}
