namespace SudokuStudio.Views.Controls.Shapes;

/// <summary>
/// Represents a diamond shape.
/// </summary>
public sealed partial class Diamond : UserControl
{
	private static readonly double StrokeThicknessDefaultValue = 6;

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="StrokeThickness"/>.
	/// </summary>
	/// <seealso cref="StrokeThickness"/>
	public static readonly DependencyProperty StrokeThicknessProperty =
		DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(Diamond), new PropertyMetadata(StrokeThicknessDefaultValue, StrokeThicknessPropertyCallback));


	/// <summary>
	/// Initializes a <see cref="Diamond"/> instance.
	/// </summary>
	public Diamond() => InitializeComponent();


	/// <summary>
	/// Indicates the stroke thickness for the star.
	/// </summary>
	public double StrokeThickness
	{
		get => (double)GetValue(StrokeThicknessProperty);

		set => SetValue(StrokeThicknessProperty, value);
	}


	private void ParentViewBox_SizeChanged(object sender, SizeChangedEventArgs e)
		=> PathPresenter.StrokeThickness = StrokeThicknessDefaultValue * 16 / ParentViewBox.ActualWidth;


	private static void StrokeThicknessPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is not Path { Parent: Viewbox { ActualWidth: var aw } } pathControl)
		{
			return;
		}

		pathControl.StrokeThickness = (double)e.NewValue * 16 / aw;
	}
}
