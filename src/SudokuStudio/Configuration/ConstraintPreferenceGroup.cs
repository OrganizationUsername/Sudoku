namespace SudokuStudio.Configuration;

/// <summary>
/// Represents a constraint preference group.
/// </summary>
public sealed partial class ConstraintPreferenceGroup : PreferenceGroup
{
	private static readonly ConstraintCollection ConstraintsDefaultValue = [];

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="Constraints"/>.
	/// </summary>
	/// <seealso cref="Constraints"/>
	public static readonly DependencyProperty ConstraintsProperty =
		DependencyProperty.Register(nameof(Constraints), typeof(ConstraintCollection), typeof(ConstraintPreferenceGroup), new PropertyMetadata(ConstraintsDefaultValue));


	/// <summary>
	/// Indicates the constraints created.
	/// </summary>
	public ConstraintCollection Constraints
	{
		get => (ConstraintCollection)GetValue(ConstraintsProperty);

		set => SetValue(ConstraintsProperty, value);
	}
}
