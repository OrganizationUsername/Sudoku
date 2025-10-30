namespace Sudoku.SetTheory;

public partial class LogicReasoner
{
	/// <summary>
	/// Represents a temporary equality comparer for comparison of <see cref="List{T}"/> of <see cref="Space"/>.
	/// </summary>
	private sealed class ListOfSpaceEqualityComparer : IEqualityComparer<List<Space>>
	{
		/// <summary>
		/// Indicates the singleton instance.
		/// </summary>
		public static readonly ListOfSpaceEqualityComparer Instance = new();


#nullable disable warnings
		/// <inheritdoc/>
		public bool Equals(List<Space> x, List<Space> y) => x.AsSpan().SequenceEqual(y.AsSpan());
#nullable restore

		/// <inheritdoc/>
		public int GetHashCode(List<Space> obj)
		{
			var result = new HashCode();
			foreach (var member in obj)
			{
				result.Add(member);
			}
			return result.ToHashCode();
		}
	}
}
