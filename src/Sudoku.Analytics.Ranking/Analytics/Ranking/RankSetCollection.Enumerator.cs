namespace Sudoku.Analytics.Ranking;

public partial class RankSetCollection
{
	/// <summary>
	/// Represents an enumerator object.
	/// </summary>
	public ref struct Enumerator(SortedSet<RankSet> set) : IEnumerator<RankSet>
	{
		/// <summary>
		/// Indicates the backing enumerator.
		/// </summary>
		private SortedSet<RankSet>.Enumerator _enumerator = set.GetEnumerator();


		/// <inheritdoc/>
		public readonly RankSet Current => _enumerator.Current;

		/// <inheritdoc/>
		readonly object IEnumerator.Current => Current;


		/// <inheritdoc/>
		public bool MoveNext() => _enumerator.MoveNext();

		/// <inheritdoc/>
		readonly void IDisposable.Dispose()
		{
		}

		/// <inheritdoc/>
		[DoesNotReturn]
		readonly void IEnumerator.Reset() => throw new NotSupportedException();
	}
}
