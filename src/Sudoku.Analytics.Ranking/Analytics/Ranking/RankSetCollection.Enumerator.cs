namespace Sudoku.Analytics.Ranking;

public partial class RankSetCollection
{
	/// <summary>
	/// Represents an enumerator object.
	/// </summary>
	/// <param name="_set">Indicates the set.</param>
	/// <param name="_skipTruths">Indicates whether the enumerator skips for checking truths.</param>
	/// <param name="_skipLinks">Indicates whether the enumerator skips for checking links.</param>
	public ref struct Enumerator(SortedSet<RankSet> _set, bool _skipTruths = false, bool _skipLinks = false) :
		IEnumerator<RankSet>,
		IEnumerable<RankSet>
	{
		/// <summary>
		/// Indicates the backing enumerator.
		/// </summary>
		private SortedSet<RankSet>.Enumerator _enumerator = _set.GetEnumerator();


		/// <inheritdoc/>
		public readonly RankSet Current => _enumerator.Current;

		/// <inheritdoc/>
		readonly object IEnumerator.Current => Current;


		/// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
		public readonly Enumerator GetEnumerator() => this;

		/// <inheritdoc/>
		public bool MoveNext()
		{
			while (_enumerator.MoveNext())
			{
				var current = _enumerator.Current;
				if (current.IsTruth && _skipTruths)
				{
					continue;
				}
				if (current.IsLink && _skipLinks)
				{
					continue;
				}
				return true;
			}
			return false;
		}

		/// <inheritdoc/>
		readonly void IDisposable.Dispose()
		{
		}

		/// <inheritdoc/>
		[DoesNotReturn]
		readonly void IEnumerator.Reset() => throw new NotSupportedException();

		/// <inheritdoc/>
		readonly IEnumerator IEnumerable.GetEnumerator() => _set.GetEnumerator();

		/// <inheritdoc/>
		readonly IEnumerator<RankSet> IEnumerable<RankSet>.GetEnumerator() => _set.GetEnumerator();
	}
}
