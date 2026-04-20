namespace SudokuStudio.Views.Controls;

/// <summary>
/// Represents a font picker.
/// </summary>
public sealed partial class FontPicker : UserControl
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SelectedFontScale"/>.
	/// </summary>
	/// <seealso cref="SelectedFontScale"/>
	public static readonly DependencyProperty SelectedFontScaleProperty =
		DependencyProperty.Register(nameof(SelectedFontScale), typeof(decimal), typeof(FontPicker), new PropertyMetadata(default(decimal), SelectedFontScalePropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SelectedFont"/>.
	/// </summary>
	/// <seealso cref="SelectedFont"/>
	public static readonly DependencyProperty SelectedFontProperty =
		DependencyProperty.Register(nameof(SelectedFont), typeof(string), typeof(FontPicker), new PropertyMetadata(default(string), SelectedFontPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SelectedFontColor"/>.
	/// </summary>
	/// <seealso cref="SelectedFontColor"/>
	public static readonly DependencyProperty SelectedFontColorProperty =
		DependencyProperty.Register(nameof(SelectedFontColor), typeof(Color), typeof(FontPicker), new PropertyMetadata(default(Color), SelectedFontColorPropertyCallback));


	/// <summary>
	/// Indicates the <see cref="TextBlock"/> list that represents with fonts.
	/// </summary>
	private readonly IList<TextBlock> _fontTextBlocks = [.. from font in CanvasTextFormat.GetSystemFontFamilies() select new TextBlock { Text = font, FontFamily = new(font) }];


	/// <summary>
	/// Initializes a <see cref="FontPicker"/> instance.
	/// </summary>
	public FontPicker() => InitializeComponent();


	/// <summary>
	/// Indicates the selected font scale.
	/// </summary>
	public decimal SelectedFontScale
	{
		get => (decimal)GetValue(SelectedFontScaleProperty);

		set => SetValue(SelectedFontScaleProperty, value);
	}

	/// <summary>
	/// Indicates the selected font name.
	/// </summary>
	public string SelectedFont
	{
		get => (string)GetValue(SelectedFontProperty);

		set => SetValue(SelectedFontProperty, value);
	}

	/// <summary>
	/// Indicates the selected font color.
	/// </summary>
	public Color SelectedFontColor
	{
		get => (Color)GetValue(SelectedFontColorProperty);

		set => SetValue(SelectedFontColorProperty, value);
	}


	/// <summary>
	/// Indicates the event that will be triggered when the property <see cref="SelectedFont"/> has been changed.
	/// </summary>
	public event EventHandler<string>? SelectedFontChanged;

	/// <summary>
	/// Indicates the event that will be triggered when the property <see cref="SelectedFontScale"/> has been changed.
	/// </summary>
	public event EventHandler<decimal>? SelectedFontScaleChanged;

	/// <summary>
	/// Indicates the event that will be triggered when the property <see cref="SelectedFontColor"/> has been changed.
	/// </summary>
	public event EventHandler<Color>? SelectedFontColorChanged;


	private void SetSelectedFontScale(double value) => SelectedFontScale = (decimal)value;


	private static void SelectedFontPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if ((d, e) is (FontPicker instance, { NewValue: string value }))
		{
			instance.SelectedFontChanged?.Invoke(instance, value);
		}
	}

	private static void SelectedFontScalePropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if ((d, e) is (FontPicker instance, { NewValue: decimal value }))
		{
			instance.SelectedFontScaleChanged?.Invoke(instance, value);
		}
	}

	private static void SelectedFontColorPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if ((d, e) is (FontPicker instance, { NewValue: Color value }))
		{
			instance.SelectedFontColorChanged?.Invoke(instance, value);
		}
	}
}
