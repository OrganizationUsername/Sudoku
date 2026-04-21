namespace SudokuStudio.Views.Controls.Shapes;

/// <summary>
/// Represents a cross-sign shape.
/// </summary>
public sealed partial class Cross : UserControl
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="StrokeThickness"/>.
	/// </summary>
	/// <seealso cref="StrokeThickness"/>
	public static readonly DependencyProperty StrokeThicknessProperty =
		DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(Cross), new PropertyMetadata(StrokeThicknessDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ForwardLineVisibility"/>.
	/// </summary>
	/// <seealso cref="ForwardLineVisibility"/>
	public static readonly DependencyProperty ForwardLineVisibilityProperty =
		DependencyProperty.Register(nameof(ForwardLineVisibility), typeof(Visibility), typeof(Cross), new PropertyMetadata((Visibility)0));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="BackwardLineVisibility"/>.
	/// </summary>
	/// <seealso cref="BackwardLineVisibility"/>
	public static readonly DependencyProperty BackwardLineVisibilityProperty =
		DependencyProperty.Register(nameof(BackwardLineVisibility), typeof(Visibility), typeof(Cross), new PropertyMetadata((Visibility)0));

	private static readonly double StrokeThicknessDefaultValue = 6;


	/// <summary>
	/// Initializes a <see cref="Cross"/> instance.
	/// </summary>
	public Cross()
	{
		InitializeComponent();
		Background = new SolidColorBrush(Colors.DimGray with { A = 64 });
	}


	/// <summary>
	/// Indicates the stroke thickness.
	/// </summary>
	public double StrokeThickness
	{
		get => (double)GetValue(StrokeThicknessProperty);

		set => SetValue(StrokeThicknessProperty, value);
	}

	/// <summary>
	/// Indicates whether the forward line is shown.
	/// </summary>
	public Visibility ForwardLineVisibility
	{
		get => (Visibility)GetValue(ForwardLineVisibilityProperty);

		set => SetValue(ForwardLineVisibilityProperty, value);
	}

	/// <summary>
	/// Indicates whether the backward line is shown.
	/// </summary>
	public Visibility BackwardLineVisibility
	{
		get => (Visibility)GetValue(BackwardLineVisibilityProperty);

		set => SetValue(BackwardLineVisibilityProperty, value);
	}
}
