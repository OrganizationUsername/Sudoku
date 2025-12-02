namespace Sudoku.Linq;

/// <summary>
/// Provides extension methods on <see cref="Step"/> sequence.
/// </summary>
public static class StepCollectionExtensions
{
	/// <summary>
	/// Provides with extension members on <see cref="ReadOnlySpan{T}"/> of <see cref="Step"/>.
	/// </summary>
	/// <param name="this">The instance.</param>
	extension<TStep>(ReadOnlySpan<Step> @this) where TStep : Step
	{
		/// <inheritdoc cref="ICastMethod{TSelf, TSource}.Cast{TResult}"/>
		public ReadOnlySpan<TStep> Cast()
		{
			var result = new TStep[@this.Length];
			for (var i = 0; i < @this.Length; i++)
			{
				result[i] = (TStep)@this[i];
			}
			return result;
		}
	}
}
