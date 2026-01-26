namespace System.Linq;

public partial class ArrayEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TSource">The type of source elements.</typeparam>
	/// <typeparam name="TKey">The type of key.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<TSource, TKey>(TSource[] source)
	{
		/// <inheritdoc cref="Enumerable.ThenBy{TSource, TKey}(IOrderedEnumerable{TSource}, Func{TSource, TKey})"/>
		public ArrayOrderedEnumerable<TSource> OrderBy(Func<TSource, TKey> selector)
			=> new(
				source,
				(l, r) => (selector(l), selector(r)) switch
				{
					(IComparable<TKey> left, var right) => left.CompareTo(right),
					var (a, b) => Comparer<TKey>.Default.Compare(a, b)
				}
			);

		/// <inheritdoc cref="Enumerable.ThenByDescending{TSource, TKey}(IOrderedEnumerable{TSource}, Func{TSource, TKey})"/>
		public ArrayOrderedEnumerable<TSource> OrderByDescending(Func<TSource, TKey> selector)
			=> new(
				source,
				(l, r) => (selector(l), selector(r)) switch
				{
					(IComparable<TKey> left, var right) => -left.CompareTo(right),
					var (a, b) => -Comparer<TKey>.Default.Compare(a, b)
				}
			);
	}
}
