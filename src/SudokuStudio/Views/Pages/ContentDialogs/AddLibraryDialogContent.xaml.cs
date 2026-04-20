namespace SudokuStudio.Views.Pages.ContentDialogs;

/// <summary>
/// Represents an "add library" page.
/// </summary>
public sealed partial class AddLibraryDialogContent : Page
{
	private static readonly ObservableCollection<string> LibraryTagsDefaultValue = [];

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="IsNameValidAsFileId"/>.
	/// </summary>
	/// <seealso cref="IsNameValidAsFileId"/>
	internal static readonly DependencyProperty IsNameValidAsFileIdProperty =
		DependencyProperty.Register(nameof(IsNameValidAsFileId), typeof(bool), typeof(AddLibraryDialogContent), new PropertyMetadata(default(bool), IsNameValidAsFileIdPropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="FileId"/>.
	/// </summary>
	/// <seealso cref="FileId"/>
	internal static readonly DependencyProperty FileIdProperty =
		DependencyProperty.Register(nameof(FileId), typeof(string), typeof(AddLibraryDialogContent), new PropertyMetadata(default(string)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="FilePath"/>.
	/// </summary>
	/// <seealso cref="FilePath"/>
	internal static readonly DependencyProperty FilePathProperty =
		DependencyProperty.Register(nameof(FilePath), typeof(string), typeof(AddLibraryDialogContent), new PropertyMetadata(default(string)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LibraryName"/>.
	/// </summary>
	/// <seealso cref="LibraryName"/>
	internal static readonly DependencyProperty LibraryNameProperty =
		DependencyProperty.Register(nameof(LibraryName), typeof(string), typeof(AddLibraryDialogContent), new PropertyMetadata(default(string), LibraryNamePropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LibraryAuthor"/>.
	/// </summary>
	/// <seealso cref="LibraryAuthor"/>
	internal static readonly DependencyProperty LibraryAuthorProperty =
		DependencyProperty.Register(nameof(LibraryAuthor), typeof(string), typeof(AddLibraryDialogContent), new PropertyMetadata(default(string)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LibraryDescription"/>.
	/// </summary>
	/// <seealso cref="LibraryDescription"/>
	internal static readonly DependencyProperty LibraryDescriptionProperty =
		DependencyProperty.Register(nameof(LibraryDescription), typeof(string), typeof(AddLibraryDialogContent), new PropertyMetadata(default(string)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="LibraryTags"/>.
	/// </summary>
	/// <seealso cref="LibraryTags"/>
	internal static readonly DependencyProperty LibraryTagsProperty =
		DependencyProperty.Register(nameof(LibraryTags), typeof(ObservableCollection<string>), typeof(AddLibraryDialogContent), new PropertyMetadata(LibraryTagsDefaultValue));


	/// <summary>
	/// Initializes an <see cref="AddLibraryDialogContent"/> instance.
	/// </summary>
	public AddLibraryDialogContent() => InitializeComponent();


	internal bool IsNameValidAsFileId
	{
		get => (bool)GetValue(IsNameValidAsFileIdProperty);

		set => SetValue(IsNameValidAsFileIdProperty, value);
	}

	internal string FileId
	{
		get => (string)GetValue(FileIdProperty);

		set => SetValue(FileIdProperty, value);
	}

	internal string FilePath
	{
		get => (string)GetValue(FilePathProperty);

		set => SetValue(FilePathProperty, value);
	}

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
	/// <para>Determines whether the specified file ID is available and stored in local, as the real file name.</para>
	/// <para>
	/// If the local path doesn't contain the same-name file, the file ID will be returned; otherwise,
	/// add a suffix to prevent same name.
	/// </para>
	/// </summary>
	/// <param name="fileId">The file ID.</param>
	/// <returns>An expected available file ID.</returns>
	private static string GetAvailbleFileId(string fileId)
	{
		var directory = CommonPaths.Library;
#if false
		// Create the current directory if not exist.
		if (!Directory.Exists(directory))
		{
			Directory.CreateDirectory(directory);
		}
#endif

		var filePath = $@"{directory}\{fileId}{FileExtensions.JsonDocument}";
		if (!File.Exists(filePath))
		{
			return fileId;
		}

		// Try for 1024 times.
		for (var i = 1U; i <= 1U << 10; i++)
		{
			filePath = $@"{directory}\{fileId}_{i}{FileExtensions.JsonDocument}";
			if (!File.Exists(filePath))
			{
				return $"{fileId}_{i}";
			}
		}

		throw new(SR.ExceptionMessage("NoAvailableNameCanBeUsed"));
	}


	private static void IsNameValidAsFileIdPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if ((d, e) is (AddLibraryDialogContent instance, { NewValue: bool value }))
		{
			if (value)
			{
				instance.ErrorInfoDisplayer.Visibility = Visibility.Collapsed;
				instance.PathDisplayer.Visibility = Visibility.Visible;
			}
			else
			{
				instance.ErrorInfoDisplayer.Visibility = Visibility.Visible;
				instance.PathDisplayer.Visibility = Visibility.Collapsed;
			}
		}
	}

	private static void LibraryNamePropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if ((d, e) is (AddLibraryDialogContent instance, { NewValue: string fileId }))
		{
			if (!File.IsValidFileName(fileId))
			{
				instance.IsNameValidAsFileId = false;
			}
			else
			{
				instance.FileId = GetAvailbleFileId(fileId);
				instance.FilePath = $@"{CommonPaths.Library}\{instance.FileId}{FileExtensions.JsonDocument}";
				instance.IsNameValidAsFileId = true;
			}
		}
	}
}
