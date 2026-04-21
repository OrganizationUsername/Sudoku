namespace SudokuStudio.Views.Controls;

/// <summary>
/// Represents a dash array text box.
/// </summary>
public sealed partial class DashArrayTextBox : UserControl
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="DashArray"/>.
	/// </summary>
	/// <seealso cref="DashArray"/>
	public static readonly DependencyProperty DashArrayProperty =
		DependencyProperty.Register(nameof(DashArray), typeof(DashArray), typeof(DashArrayTextBox), new PropertyMetadata(default(DashArray)));


	/// <summary>
	/// Initializes a <see cref="DashArrayTextBox"/> instance.
	/// </summary>
	public DashArrayTextBox() => InitializeComponent();


	/// <summary>
	/// Indicates the dash array input.
	/// </summary>
	public DashArray DashArray
	{
		get => (DashArray)GetValue(DashArrayProperty);

		set => SetValue(DashArrayProperty, value);
	}


	/// <summary>
	/// Indicates the event triggered when the dash array is changed.
	/// </summary>
	public event EventHandler<DashArray>? DashArrayChanged;


	private void CoreBox_KeyDown(object sender, KeyRoutedEventArgs e)
	{
		if (e.Key != VirtualKey.Enter)
		{
			return;
		}

		var values =
			from element in CoreBox.Text.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
			select double.TryParse(element, out var r) && r is >= 0 and <= 10 ? r : 0;
		if (Array.FindAll(values, static value => value == 0).Length >= 2)
		{
			DashArrayChanged?.Invoke(this, DashArray = []);
			return;
		}

		if (values.Length >= 2 && Array.IndexOf(values, 0) != -1)
		{
			DashArrayChanged?.Invoke(this, DashArray = []);
			return;
		}

		DashArrayChanged?.Invoke(this, DashArray = [.. values]);
	}
}
