namespace SudokuStudio.Views.Controls;

/// <summary>
/// Represents a digit set control.
/// </summary>
public sealed partial class DigitSet : UserControl
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SelectedDigit"/>.
	/// </summary>
	/// <seealso cref="SelectedDigit"/>
	public static readonly DependencyProperty SelectedDigitProperty =
		DependencyProperty.Register(nameof(SelectedDigit), typeof(Digit), typeof(DigitSet), new PropertyMetadata(-1));


	/// <summary>
	/// Indicates the items source.
	/// </summary>
	private readonly Digit[] _itemsSource = [0, 1, 2, 3, 4, 5, 6, 7, 8];


	/// <summary>
	/// Initializes a <see cref="DigitSet"/> instance.
	/// </summary>
	public DigitSet() => InitializeComponent();


	/// <summary>
	/// Indicates the selected digit.
	/// </summary>
	public Digit SelectedDigit
	{
		get => (Digit)GetValue(SelectedDigitProperty);

		set => SetValue(SelectedDigitProperty, value);
	}


	/// <summary>
	/// Indicates the event triggered when the selected digit is changed.
	/// </summary>
	public event EventHandler<DigitSet, DigitSetSelectedDigitChangedEventArgs>? SelectedDigitChanged;


	private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		SelectedDigit = (Digit)((ListView)sender).SelectedItem;
		SelectedDigitChanged?.Invoke(this, new(SelectedDigit));
	}
}
