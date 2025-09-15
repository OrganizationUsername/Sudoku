namespace Sudoku.Resources;

/// <summary>
/// Represents a read-only array of <see cref="Interpolation"/> values.
/// </summary>
/// <param name="_values">Indicates the values.</param>
/// <seealso cref="Interpolation"/>
[CollectionBuilder(typeof(InterpolationArray), nameof(Create))]
public readonly ref struct InterpolationArray(ReadOnlyMemory<Interpolation> _values) :
	IEnumerable<Interpolation>,
	IToArrayMethod<InterpolationArray, Interpolation>,
	IReadOnlyList<Interpolation>,
	IReadOnlyCollection<Interpolation>
{
	/// <summary>
	/// Indicates the number of elements in the collection.
	/// </summary>
	public int Length => _values.Length;

	/// <summary>
	/// Provides a way to visit each elements in the collection.
	/// </summary>
	public ReadOnlySpan<Interpolation> Span => _values.Span;

	/// <inheritdoc/>
	int IReadOnlyCollection<Interpolation>.Count => Length;


	/// <summary>
	/// Try to get the target resource value at the desired index, and belong the specified culture.
	/// </summary>
	/// <param name="culture">The desired culture.</param>
	/// <param name="valueIndex">The index of the target resource value.</param>
	/// <returns>The target resource value.</returns>
	public string this[string culture, int valueIndex] => this[culture].Values[valueIndex];

	/// <inheritdoc cref="this[string, int]"/>
	public string this[string culture, Index valueIndex] => this[culture].Values[valueIndex];

	/// <inheritdoc cref="this[string, int]"/>
	public string this[CultureInfo culture, int valueIndex] => this[culture].Values[valueIndex];

	/// <inheritdoc cref="this[string, int]"/>
	public string this[CultureInfo culture, Index valueIndex] => this[culture].Values[valueIndex];

	/// <summary>
	/// Try to get a slice of <see cref="string"/> resource values
	/// inside the specified culture resource dictionary.
	/// </summary>
	/// <param name="culture">The desired culture.</param>
	/// <param name="range">The range.</param>
	/// <returns>A list of resource value sliced.</returns>
	public ReadOnlySpan<string> this[string culture, Range range] => this[culture].Values[range];

	/// <inheritdoc cref="this[string, Range]"/>
	public ReadOnlySpan<string> this[CultureInfo culture, Range range] => this[culture].Values[range];

	/// <summary>
	/// Try to get the element at the specified index.
	/// </summary>
	/// <param name="index">The desired index.</param>
	/// <returns>The reference to the target element.</returns>
	/// <exception cref="IndexOutOfRangeException">Throws when <paramref name="index"/> is out of range.</exception>
	public Interpolation this[int index] => _values.Span[index];

	/// <summary>
	/// Returns an <see cref="Interpolation"/> instance via the specified culture.
	/// </summary>
	/// <param name="culture">The desired culture.</param>
	/// <returns>An <see cref="Interpolation"/> instance.</returns>
	public Interpolation this[string culture]
	{
		get
		{
			var enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				var element = enumerator.Current;
				if (element.CultureName.Equals(culture, StringComparison.OrdinalIgnoreCase))
				{
					return element;
				}
			}
			return default;
		}
	}

	/// <inheritdoc cref="this[string]"/>
	public Interpolation this[CultureInfo culture] => this[culture.Name];


	/// <inheritdoc cref="object.ToString"/>
	public override string ToString()
	{
		const string separator = ", ";
		var sb = new StringBuilder();
		sb.Append('[');
		for (var i = 0; i < Length; i++)
		{
			var (cultureName, values) = this[i];
			sb.Append(cultureName);
			sb.Append(": ");
			for (var j = 0; j < values.Length; j++)
			{
				sb.Append(values[j]);
				if (j != values.Length - 1)
				{
					sb.Append(separator);
				}
			}
			if (i != Length - 1)
			{
				sb.Append(separator);
			}
		}
		sb.Append(']');
		return sb.ToString();
	}

	/// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
	public AnonymousSpanEnumerator<Interpolation> GetEnumerator() => new(_values.Span);

	/// <inheritdoc/>
	public Interpolation[] ToArray() => _values.ToArray();

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => ToArray().GetEnumerator();

	/// <inheritdoc/>
	IEnumerator<Interpolation> IEnumerable<Interpolation>.GetEnumerator() => ToArray().AsEnumerable().GetEnumerator();


	/// <summary>
	/// Creates an <see cref="InterpolationArray"/> instance via a list of <see cref="Interpolation"/> instances.
	/// </summary>
	/// <param name="values">
	/// <para>A list of interpolations.</para>
	/// <include file="../../global-doc-comments.xml" path="g/csharp11/feature[@name='scoped-keyword']"/>
	/// </param>
	/// <returns>An <see cref="InterpolationArray"/> instance.</returns>
	public static InterpolationArray Create(scoped ReadOnlySpan<Interpolation> values) => new(values.ToArray());
}
