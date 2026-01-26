namespace System.Linq;

public static partial class SpanEnumerable
{
	extension<TSource>(ReadOnlySpan<TSource> source)
	{
		/// <summary>
		/// Returns the first element of sequence.
		/// </summary>
		/// <returns>The element.</returns>
		[Obsolete("Use 'span[0]' instead.", true)]
		public TSource First() => source[0];

		/// <summary>
		/// Returns first element of the current instance or <see langword="default"/>(<typeparamref name="TSource"/>)
		/// if the list is empty.
		/// </summary>
		/// <returns>The element.</returns>
		[Obsolete("Use 'span is [var first, ..] ? first : default' instead.", true)]
		public TSource? FirstOrDefault() => source is [var first, ..] ? first : default;

		/// <inheritdoc cref="IFirstLastMethod{TSelf, TSource}.First(Func{TSource, bool})"/>
		public TSource First(Func<TSource, bool> predicate)
		{
			foreach (var element in source)
			{
				if (predicate(element))
				{
					return element;
				}
			}
			throw new InvalidOperationException(SR.ExceptionMessage("NoSuchElementSatisfyingCondition"));
		}

		/// <inheritdoc cref="IFirstLastMethod{TSelf, TSource}.First(Func{TSource, bool})"/>
		public ref readonly TSource FirstRef(Func<TSource, bool> predicate)
		{
			foreach (ref readonly var element in source)
			{
				if (predicate(element))
				{
					return ref element;
				}
			}
			throw new InvalidOperationException(SR.ExceptionMessage("NoSuchElementSatisfyingCondition"));
		}

		/// <inheritdoc cref="IFirstLastMethod{TSelf, TSource}.FirstOrDefault(Func{TSource, bool}, TSource)"/>
		public TSource? FirstOrDefault(Func<TSource, bool> predicate)
		{
			foreach (var element in source)
			{
				if (predicate(element))
				{
					return element;
				}
			}
			return default;
		}

		/// <inheritdoc cref="IFirstLastMethod{TSelf, TSource}.Last(Func{TSource, bool})"/>
		public TSource Last(Func<TSource, bool> predicate)
		{
			foreach (var element in ~source)
			{
				if (predicate(element))
				{
					return element;
				}
			}
			throw new InvalidOperationException(SR.ExceptionMessage("NoSuchElementSatisfyingCondition"));
		}

		/// <inheritdoc cref="IFirstLastMethod{TSelf, TSource}.LastOrDefault(Func{TSource, bool})"/>
		public TSource? LastOrDefault(Func<TSource, bool> predicate)
		{
			foreach (var element in ~source)
			{
				if (predicate(element))
				{
					return element;
				}
			}
			return default;
		}
	}
}
