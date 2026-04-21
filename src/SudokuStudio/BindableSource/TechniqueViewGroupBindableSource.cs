namespace SudokuStudio.BindableSource;

/// <summary>
/// Represents a bindable source for a group of <see cref="Technique"/> instances.
/// </summary>
/// <seealso cref="Technique"/>
public sealed partial class TechniqueViewGroupBindableSource : DependencyObject
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ShowSelectAllButton"/>.
	/// </summary>
	/// <seealso cref="ShowSelectAllButton"/>
	public static readonly DependencyProperty ShowSelectAllButtonProperty =
		DependencyProperty.Register(nameof(ShowSelectAllButton), typeof(bool), typeof(TechniqueViewGroupBindableSource), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="Group"/>.
	/// </summary>
	/// <seealso cref="Group"/>
	public static readonly DependencyProperty GroupProperty =
		DependencyProperty.Register(nameof(Group), typeof(TechniqueGroup), typeof(TechniqueViewGroupBindableSource), new PropertyMetadata(default(TechniqueGroup)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="Items"/>.
	/// </summary>
	/// <seealso cref="Items"/>
	public static readonly DependencyProperty ItemsProperty =
		DependencyProperty.Register(nameof(Items), typeof(TechniqueViewBindableSource[]), typeof(TechniqueViewGroupBindableSource), new PropertyMetadata(default(TechniqueViewBindableSource[])));


	/// <summary>
	/// Indicates whether the "Select all" button should be shown.
	/// </summary>
	public bool ShowSelectAllButton
	{
		get => (bool)GetValue(ShowSelectAllButtonProperty);

		set => SetValue(ShowSelectAllButtonProperty, value);
	}

	/// <summary>
	/// Indicates the full name of the group.
	/// </summary>
	public string GroupFullName => (GroupName, ShortenedName) switch { var (a, b) => a == b ? a : $"{a} ({b})" };

	/// <summary>
	/// Indicates the group name.
	/// </summary>
	public string GroupName => Group.GetName(App.CurrentCulture);

	/// <summary>
	/// Indicates the shortened name of the group.
	/// </summary>
	public string ShortenedName => Group.GetShortenedName(App.CurrentCulture);

	/// <summary>
	/// Indicates the group of the techniques.
	/// </summary>
	public TechniqueGroup Group
	{
		get => (TechniqueGroup)GetValue(GroupProperty);

		set => SetValue(GroupProperty, value);
	}

	/// <summary>
	/// Indicates the items belonging to the group.
	/// </summary>
	public TechniqueViewBindableSource[] Items
	{
		get => (TechniqueViewBindableSource[])GetValue(ItemsProperty);

		set => SetValue(ItemsProperty, value);
	}
}
