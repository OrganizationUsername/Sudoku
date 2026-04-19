namespace SudokuStudio.Views.Pages.ContentDialogs;

/// <summary>
/// Represents a library modifiy properties page.
/// </summary>
public sealed partial class LibraryModifyPropertiesDialogContent : Page
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LibraryName"/>.
	/// </summary>
	/// <seealso cref="LibraryName"/>
	internal static readonly DependencyProperty LibraryNameProperty =
		DependencyProperty.Register(nameof(LibraryName), typeof(string), typeof(LibraryModifyPropertiesDialogContent), new PropertyMetadata(default(string)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LibraryAuthor"/>.
	/// </summary>
	/// <seealso cref="LibraryAuthor"/>
	internal static readonly DependencyProperty LibraryAuthorProperty =
		DependencyProperty.Register(nameof(LibraryAuthor), typeof(string), typeof(LibraryModifyPropertiesDialogContent), new PropertyMetadata(default(string)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LibraryDescription"/>.
	/// </summary>
	/// <seealso cref="LibraryDescription"/>
	internal static readonly DependencyProperty LibraryDescriptionProperty =
		DependencyProperty.Register(nameof(LibraryDescription), typeof(string), typeof(LibraryModifyPropertiesDialogContent), new PropertyMetadata(default(string)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LibraryTags"/>.
	/// </summary>
	/// <seealso cref="LibraryTags"/>
	internal static readonly DependencyProperty LibraryTagsProperty =
		DependencyProperty.Register(nameof(LibraryTags), typeof(ObservableCollection<string>), typeof(LibraryModifyPropertiesDialogContent), new PropertyMetadata((ObservableCollection<string>)[]));


	internal string? LibraryName
	{
		get => (string?)GetValue(LibraryNameProperty);

		set => SetValue(LibraryNameProperty, value);
	}

	internal string? LibraryAuthor
	{
		get => (string?)GetValue(LibraryAuthorProperty);

		set => SetValue(LibraryAuthorProperty, value);
	}

	internal string? LibraryDescription
	{
		get => (string?)GetValue(LibraryDescriptionProperty);

		set => SetValue(LibraryDescriptionProperty, value);
	}

	internal ObservableCollection<string> LibraryTags
	{
		get => (ObservableCollection<string>)GetValue(LibraryTagsProperty);

		set => SetValue(LibraryTagsProperty, value);
	}


	/// <summary>
	/// Initializes a <see cref="LibraryModifyPropertiesDialogContent"/> instance.
	/// </summary>
	public LibraryModifyPropertiesDialogContent() => InitializeComponent();
}
