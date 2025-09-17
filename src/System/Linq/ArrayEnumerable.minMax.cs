namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <summary>
	/// Provides extension members on <typeparamref name="TSource"/>[].
	/// </summary>
	/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
	/// <param name="source">A sequence of values to determine the minimum value of.</param>
	extension<TSource>(TSource[] source)
	{
		/// <summary>
		/// Invokes a transform function on each element of a sequence and returns the minimum <typeparamref name="TInterim"/> value.
		/// </summary>
		/// <typeparam name="TInterim">The type of projected values after the transform function invoked.</typeparam>
		/// <param name="selector">A transform function to apply to each element.</param>
		/// <returns>The value of type <typeparamref name="TInterim"/> that corresponds to the minimum value in the sequence.</returns>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TInterim Min<TInterim>(Func<TSource, TInterim> selector)
			where TInterim : IMinMaxValue<TInterim>, IComparisonOperators<TInterim, TInterim, bool>
		{
			var result = TInterim.MaxValue;
			foreach (var element in source)
			{
				var elementCasted = selector(element);
				if (elementCasted <= result)
				{
					result = elementCasted;
				}
			}
			return result;
		}

		/// <inheritdoc cref="Min{T, TInterim}(T[], Func{T, TInterim})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public unsafe TInterim MinUnsafe<TInterim>(delegate*<TSource, TInterim> selector)
			where TInterim : IMinMaxValue<TInterim>, IComparisonOperators<TInterim, TInterim, bool>
		{
			var result = TInterim.MaxValue;
			foreach (var element in source)
			{
				var elementCasted = selector(element);
				if (elementCasted <= result)
				{
					result = elementCasted;
				}
			}
			return result;
		}

		/// <summary>
		/// Invokes a transform function on each element of a sequence and returns the maximum <typeparamref name="TInterim"/> value.
		/// </summary>
		/// <typeparam name="TInterim">The type of projected values after the transform function invoked.</typeparam>
		/// <param name="selector">A transform function to apply to each element.</param>
		/// <returns>The value of type <typeparamref name="TInterim"/> that corresponds to the maximum value in the sequence.</returns>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TInterim Max<TInterim>(Func<TSource, TInterim> selector)
			where TInterim : IMinMaxValue<TInterim>, IComparisonOperators<TInterim, TInterim, bool>
		{
			var result = TInterim.MinValue;
			foreach (var element in source)
			{
				var elementCasted = selector(element);
				if (elementCasted >= result)
				{
					result = elementCasted;
				}
			}
			return result;
		}

		/// <inheritdoc cref="Max{T, TInterim}(T[], Func{T, TInterim})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public unsafe TInterim MaxUnsafe<TInterim>(delegate*<TSource, TInterim> selector)
			where TInterim : IMinMaxValue<TInterim>, IComparisonOperators<TInterim, TInterim, bool>
		{
			var result = TInterim.MinValue;
			foreach (var element in source)
			{
				var elementCasted = selector(element);
				if (elementCasted >= result)
				{
					result = elementCasted;
				}
			}
			return result;
		}

		/// <inheritdoc cref="Enumerable.MinBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TSource? MinBy<TKey>(Func<TSource, TKey> keySelector)
			where TKey : IComparable<TKey>, allows ref struct
		{
			var result = default(TSource);
			var minValue = default(TKey);
			foreach (ref readonly var element in source.AsReadOnlySpan())
			{
				var elementKey = keySelector(element);
				if (elementKey.CompareTo(minValue) <= 0)
				{
					result = element;
					minValue = elementKey;
				}
			}
			return result;
		}

		/// <inheritdoc cref="Enumerable.MinBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey}, IComparer{TKey}?)"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TSource? MinBy<TKey, TComparer>(Func<TSource, TKey> keySelector, TComparer? comparer)
			where TKey : allows ref struct
			where TComparer : IComparer<TKey>, new(), allows ref struct
		{
			comparer ??= new();

			var result = default(TSource);
			var minValue = default(TKey);
			foreach (ref readonly var element in source.AsReadOnlySpan())
			{
				var elementKey = keySelector(element);
				if (comparer.Compare(elementKey, minValue) <= 0)
				{
					result = element;
					minValue = elementKey;
				}
			}
			return result;
		}

		/// <inheritdoc cref="Enumerable.MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TSource? MaxBy<TKey>(Func<TSource, TKey> keySelector)
			where TKey : IComparable<TKey>, allows ref struct
		{
			var result = default(TSource);
			var maxValue = default(TKey);
			foreach (ref readonly var element in source.AsReadOnlySpan())
			{
				var elementKey = keySelector(element);
				if (elementKey.CompareTo(maxValue) >= 0)
				{
					result = element;
					maxValue = elementKey;
				}
			}
			return result;
		}

		/// <inheritdoc cref="Enumerable.MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey}, IComparer{TKey}?)"/>
		/// <remarks>
		/// <include
		///     file="../../global-doc-comments.xml"
		///     path="g/csharp14/feature[@name='extension-container']/target[@name='generic-method']"/>
		/// </remarks>
		public TSource? MaxBy<TKey, TComparer>(Func<TSource, TKey> keySelector, TComparer? comparer)
			where TKey : allows ref struct
			where TComparer : IComparer<TKey>, new(), allows ref struct
		{
			comparer ??= new();

			var result = default(TSource);
			var maxValue = default(TKey);
			foreach (ref readonly var element in source.AsReadOnlySpan())
			{
				var elementKey = keySelector(element);
				if (comparer.Compare(elementKey, maxValue) >= 0)
				{
					result = element;
					maxValue = elementKey;
				}
			}
			return result;
		}
	}
}
