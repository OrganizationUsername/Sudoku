namespace Sudoku.Concepts.Marshalling;

/// <summary>
/// Represents a concept "Candidate".
/// </summary>
public static class CandidateMarshal
{
	/// <summary>
	/// Provides extension members on <see cref="Candidate"/>.
	/// </summary>
	extension(Candidate @this)
	{
		/// <summary>
		/// Converts the specified <see cref="Candidate"/> into a singleton <see cref="CandidateMap"/> instance.
		/// </summary>
		/// <returns>A <see cref="CandidateMap"/> instance, containing only one element of the current candidate.</returns>
#if CACHE_CANDIDATE_MAPS
		public ref readonly CandidateMap AsCandidateMap() => ref CandidateMaps[@this];
#else
		public CandidateMap AsCandidateMap() => [@this];
#endif


		/// <summary>
		/// Converts a candidate instance into a string instance that represents for a candidate.
		/// </summary>
		/// <param name="candidate">The candidate.</param>
		/// <param name="formatProvider">The formatter.</param>
		/// <returns>The string representation.</returns>
		public static string ToCandidateString(Candidate candidate, IFormatProvider? formatProvider)
		{
			var converter = CoordinateConverter.GetInstance(formatProvider);
			return converter.CandidateConverter(candidate.AsCandidateMap());
		}
	}

	/// <summary>
	/// Provides extension members on <see cref="Candidate"/>[].
	/// </summary>
	extension(Candidate[] @this)
	{
		/// <inheritdoc cref="extension(ReadOnlySpan{Candidate}).AsCandidateMap()"/>
		public CandidateMap AsCandidateMap() => [.. @this];
	}

	/// <summary>
	/// Provides extension members on <see cref="ReadOnlySpan{T}"/> of <see cref="Candidate"/>.
	/// </summary>
	extension(ReadOnlySpan<Candidate> @this)
	{
		/// <summary>
		/// Converts the specified list of <see cref="Candidate"/> instances into a <see cref="CandidateMap"/> instance.
		/// </summary>
		/// <returns>A <see cref="CandidateMap"/> instance, containing all elements come from the current sequence.</returns>
		public CandidateMap AsCandidateMap() => [.. @this];
	}
}
