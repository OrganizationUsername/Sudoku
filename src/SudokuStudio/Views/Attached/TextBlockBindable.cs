namespace SudokuStudio.Views.Attached;

/// <summary>
/// Defines a bind behaviors on <see cref="TextBlock"/> instances.
/// </summary>
/// <seealso cref="TextBlock"/>
public static class TextBlockBindable
{
	/// <summary>
	/// Defines a attached property that binds with setter and getter methods <see cref="InlinesProperty"/>.
	/// </summary>
	public static readonly DependencyProperty InlinesProperty =
		DependencyProperty.RegisterAttached("Inlines", typeof(IEnumerable<Inline>), typeof(TextBlockBindable), new PropertyMetadata(default(IEnumerable<Inline>), InlinesPropertyCallback));


	/// <summary>
	/// Sets the attached property <see cref="InlinesProperty"/> with the specified value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <param name="value">The value to be set.</param>
	public static void SetInlines(DependencyObject obj, IEnumerable<Inline> value) => obj.SetValue(InlinesProperty, value);

	/// <summary>
	/// Gets the attached property <see cref="InlinesProperty"/> of its containing value.
	/// </summary>
	/// <param name="obj">The containing object of the property.</param>
	/// <returns>The value returned.</returns>
	public static IEnumerable<Inline> GetInlines(DependencyObject obj) => (IEnumerable<Inline>)obj.GetValue(InlinesProperty);


	private static void InlinesPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if ((d, e) is not (TextBlock target, { NewValue: IEnumerable<Inline> inlines }))
		{
			return;
		}

		var originalCollectionValues = new Inline[target.Inlines.Count];
		target.Inlines.CopyTo(originalCollectionValues, 0);

		try
		{
			target.Inlines.Clear();
			foreach (var inline in inlines)
			{
				target.Inlines.Add(inline);
			}
		}
		catch (COMException ex) when (ex.HResult == -2146496512)
		{
#if false
			// Rollback.
			target.Inlines.Clear();
			foreach (var inline in originalCollectionValues)
			{
				target.Inlines.Add(inline);
			}
#endif
		}
	}
}
