namespace SudokuStudio.Views.Controls.Shapes;

/// <summary>
/// Represents a circle ring.
/// </summary>
public sealed partial class CircleRing : UserControl
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="StrokeThickness"/>.
	/// </summary>
	/// <seealso cref="StrokeThickness"/>
	public static readonly DependencyProperty StrokeThicknessProperty =
		DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(CircleRing), new PropertyMetadata(6D));


	/// <summary>
	/// Indicates the stroke thickness.
	/// </summary>
	public double StrokeThickness
	{
		get => (double)GetValue(StrokeThicknessProperty);

		set => SetValue(StrokeThicknessProperty, value);
	}


	/// <summary>
	/// Initializes a <see cref="CircleRing"/> instance.
	/// </summary>
	public CircleRing()
	{
		InitializeComponent();

		Background = new SolidColorBrush(Colors.DimGray with { A = 64 });
	}
}
