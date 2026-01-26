namespace System.Linq;

public partial class SpanEnumerable
{
	extension<TSource>(ReadOnlySpan<TSource> source)
	{
		/// <inheritdoc cref="ITakeMethod{TSelf, TSource}.Take(int)"/>
		public ReadOnlySpan<TSource> Take(int count)
		{
			var result = new List<TSource>(count);
			result.AddRangeRef(source[..Math.Min(count, source.Length)]);
			return result.AsSpan();
		}

		/// <inheritdoc cref="ITakeMethod{TSelf, TSource}.Take(Range)"/>
		public ReadOnlySpan<TSource> Take(Range range)
		{
			var minIndex = range.Start.GetOffset(source.Length);
			var maxIndex = range.End.GetOffset(source.Length);
			if (maxIndex <= minIndex)
			{
				throw new InvalidOperationException(SR.ExceptionMessage("NoElementsFoundInCollection"));
			}

			var result = new List<TSource>(maxIndex - minIndex);
			result.AddRangeRef(source[Math.Min(minIndex, source.Length)..Math.Min(maxIndex, source.Length)]);
			return result.AsSpan();
		}
	}
}
