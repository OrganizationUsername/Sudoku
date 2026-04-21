namespace SudokuStudio.Views.Pages.ContentDialogs;

/// <summary>
/// Represents "Properties" dialog content for libraries.
/// </summary>
public sealed partial class LibraryPropertiesDialogContent : Page
{
	/// <summary>
	/// Defines a dependency property that binds with property <see cref="IsLoadingPuzzlesCount"/>.
	/// </summary>
	/// <seealso cref="IsLoadingPuzzlesCount"/>
	internal static readonly DependencyProperty IsLoadingPuzzlesCountProperty =
		DependencyProperty.Register(nameof(IsLoadingPuzzlesCount), typeof(bool), typeof(LibraryPropertiesDialogContent), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LibraryName"/>.
	/// </summary>
	/// <seealso cref="LibraryName"/>
	internal static readonly DependencyProperty LibraryNameProperty =
		DependencyProperty.Register(nameof(LibraryName), typeof(string), typeof(LibraryPropertiesDialogContent), new PropertyMetadata(default(string)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LibraryAuthor"/>.
	/// </summary>
	/// <seealso cref="LibraryAuthor"/>
	internal static readonly DependencyProperty LibraryAuthorProperty =
		DependencyProperty.Register(nameof(LibraryAuthor), typeof(string), typeof(LibraryPropertiesDialogContent), new PropertyMetadata(default(string)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LibraryDescription"/>.
	/// </summary>
	/// <seealso cref="LibraryDescription"/>
	internal static readonly DependencyProperty LibraryDescriptionProperty =
		DependencyProperty.Register(nameof(LibraryDescription), typeof(string), typeof(LibraryPropertiesDialogContent), new PropertyMetadata(default(string)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LibraryLastModifiedTime"/>.
	/// </summary>
	/// <seealso cref="LibraryLastModifiedTime"/>
	internal static readonly DependencyProperty LibraryLastModifiedTimeProperty =
		DependencyProperty.Register(nameof(LibraryLastModifiedTime), typeof(DateTime), typeof(LibraryPropertiesDialogContent), new PropertyMetadata(default(DateTime)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="Library"/>.
	/// </summary>
	/// <seealso cref="Library"/>
	internal static readonly DependencyProperty LibraryProperty =
		DependencyProperty.Register(nameof(Library), typeof(Library), typeof(LibraryPropertiesDialogContent), new PropertyMetadata(default(Library)));


	/// <summary>
	/// Initializes a <see cref="LibraryPropertiesDialogContent"/> instance.
	/// </summary>
	public LibraryPropertiesDialogContent()
	{
		InitializeComponent();

		IsLoadingPuzzlesCount = true;
	}


	/// <summary>
	/// Indicates whether the page is loading.
	/// </summary>
	internal bool IsLoadingPuzzlesCount
	{
		get => (bool)GetValue(IsLoadingPuzzlesCountProperty);

		set => SetValue(IsLoadingPuzzlesCountProperty, value);
	}

	/// <summary>
	/// Indicates the library name.
	/// </summary>
	internal string LibraryName
	{
		get => (string)GetValue(LibraryNameProperty);

		set => SetValue(LibraryNameProperty, value);
	}

	/// <summary>
	/// Indicates the author of the library.
	/// </summary>
	internal string LibraryAuthor
	{
		get => (string)GetValue(LibraryAuthorProperty);

		set => SetValue(LibraryAuthorProperty, value);
	}

	/// <summary>
	/// Indicates the library description.
	/// </summary>
	internal string LibraryDescription
	{
		get => (string)GetValue(LibraryDescriptionProperty);

		set => SetValue(LibraryDescriptionProperty, value);
	}

	/// <summary>
	/// Indicates the last modified time of library.
	/// </summary>
	internal DateTime LibraryLastModifiedTime
	{
		get => (DateTime)GetValue(LibraryLastModifiedTimeProperty);

		set => SetValue(LibraryLastModifiedTimeProperty, value);
	}

	/// <summary>
	/// Indicates the library information.
	/// </summary>
	internal Library Library
	{
		get => (Library)GetValue(LibraryProperty);

		set => SetValue(LibraryProperty, value);
	}


	private void Page_Loaded(object sender, RoutedEventArgs e)
		=> DispatcherQueue.TryEnqueue(
			async () =>
			{
				TagsTokenView.ItemsSource = Library.ReadTags().ToArray();
				LibraryPuzzlesCountDisplayer.Text = (await Library.GetCountAsync()).ToString();
				IsLoadingPuzzlesCount = false;
			}
		);

	private async void NavigateToLibraryFileButton_ClickAsync(object sender, RoutedEventArgs e)
	{
		var folder = io::Path.GetDirectoryName(Library.LibraryPath);
		await Launcher.LaunchFolderPathAsync(folder);
	}

	private async void NavigateToLibraryFileButton2_ClickAsync(object sender, RoutedEventArgs e)
	{
		var folder = io::Path.GetDirectoryName(Library.InfoPath);
		await Launcher.LaunchFolderPathAsync(folder);
	}
}
