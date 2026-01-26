namespace System.Text.RegularExpressions;

/// <summary>
/// Provides LINQ-based extension methods on <see cref="MatchCollection"/>, <see cref="GroupCollection"/> and <see cref="CaptureCollection"/>.
/// </summary>
/// <seealso cref="CaptureCollection"/>
/// <seealso cref="MatchCollection"/>
/// <seealso cref="GroupCollection"/>
public static class RegularExpressionCollectionEnumerable
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TResult">The type of result elements.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<TResult>(MatchCollection source)
	{
		/// <inheritdoc cref="SpanEnumerable.Select{T, TResult}(ReadOnlySpan{T}, Func{T, TResult})"/>
		public ReadOnlySpan<TResult> Select(Func<Match, TResult> selector)
		{
			var result = new TResult[source.Count];
			var i = 0;
			foreach (Match element in source)
			{
				result[i++] = selector(element);
			}
			return result;
		}
	}

	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TResult">The type of result elements.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<TResult>(GroupCollection source)
	{
		/// <inheritdoc cref="SpanEnumerable.Select{T, TResult}(ReadOnlySpan{T}, Func{T, TResult})"/>
		public ReadOnlySpan<TResult> Select(Func<Group, TResult> selector)
		{
			var result = new TResult[source.Count];
			var i = 0;
			foreach (Group element in source)
			{
				result[i++] = selector(element);
			}
			return result;
		}
	}

	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	/// <typeparam name="TResult">The type of result elements.</typeparam>
	/// <param name="source">The source collection.</param>
	extension<TResult>(CaptureCollection source)
	{
		/// <inheritdoc cref="SpanEnumerable.Select{T, TResult}(ReadOnlySpan{T}, Func{T, TResult})"/>
		public ReadOnlySpan<TResult> Select(Func<Capture, TResult> selector)
		{
			var result = new TResult[source.Count];
			var i = 0;
			foreach (Capture element in source)
			{
				result[i++] = selector(element);
			}
			return result;
		}
	}
}
