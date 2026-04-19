namespace SudokuStudio.BindableSource;

/// <summary>
/// Represents a library bindable source. This type is different with <see cref="LibrarySimpleBindableSource"/>
/// - this type contains more properties that can be bound with UI.
/// </summary>
/// <seealso cref="LibrarySimpleBindableSource"/>
public sealed partial class LibraryBindableSource : DependencyObject
{
	internal static readonly string NameDefaultValue = SR.Get("NoName", App.CurrentCulture);

	internal static readonly string AuthorDefaultValue = SR.Get("Anonymous", App.CurrentCulture);

	internal static readonly string DescriptionDefaultValue = SR.Get("NoDescription", App.CurrentCulture);


	/// <summary>
	/// Defines a dependency property that binds with property <see cref="IsActive"/>.
	/// </summary>
	/// <seealso cref="IsActive"/>
	public static readonly DependencyProperty IsActiveProperty =
		DependencyProperty.Register(nameof(IsActive), typeof(bool), typeof(LibraryBindableSource), new PropertyMetadata(default(bool)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="Name"/>.
	/// </summary>
	/// <seealso cref="Name"/>
	public static readonly DependencyProperty NameProperty =
		DependencyProperty.Register(nameof(Name), typeof(string), typeof(LibraryBindableSource), new PropertyMetadata(NameDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="FileId"/>.
	/// </summary>
	/// <seealso cref="FileId"/>
	public static readonly DependencyProperty FileIdProperty =
		DependencyProperty.Register(nameof(FileId), typeof(string), typeof(LibraryBindableSource), new PropertyMetadata(default(string)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="Author"/>.
	/// </summary>
	/// <seealso cref="Author"/>
	public static readonly DependencyProperty AuthorProperty =
		DependencyProperty.Register(nameof(Author), typeof(string), typeof(LibraryBindableSource), new PropertyMetadata(AuthorDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="Description"/>.
	/// </summary>
	/// <seealso cref="Description"/>
	public static readonly DependencyProperty DescriptionProperty =
		DependencyProperty.Register(nameof(Description), typeof(string), typeof(LibraryBindableSource), new PropertyMetadata(DescriptionDefaultValue));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="Tags"/>.
	/// </summary>
	/// <seealso cref="Tags"/>
	public static readonly DependencyProperty TagsProperty =
		DependencyProperty.Register(nameof(Tags), typeof(string[]), typeof(LibraryBindableSource), new PropertyMetadata(default(string[])));


	/// <summary>
	/// Indicates whether the current library is loading, updating, etc..
	/// </summary>
	public bool IsActive
	{
		get => (bool)GetValue(IsActiveProperty);

		set => SetValue(IsActiveProperty, value);
	}

	/// <summary>
	/// Indicates the name of the library.
	/// </summary>
	public string Name
	{
		get => (string)GetValue(NameProperty);

		set => SetValue(NameProperty, value);
	}

	/// <summary>
	/// Indicates the unique file name of the library.
	/// </summary>
	public string FileId
	{
		get => (string)GetValue(FileIdProperty);

		set => SetValue(FileIdProperty, value);
	}

	/// <summary>
	/// Indicates the author of the library.
	/// </summary>
	public string Author
	{
		get => (string)GetValue(AuthorProperty);

		set => SetValue(AuthorProperty, value);
	}

	/// <summary>
	/// Indicates the description to the library.
	/// </summary>
	public string Description
	{
		get => (string)GetValue(DescriptionProperty);

		set => SetValue(DescriptionProperty, value);
	}

	/// <summary>
	/// Indicates the tags of the library.
	/// </summary>
	public string[] Tags
	{
		get => (string[])GetValue(TagsProperty);

		set => SetValue(TagsProperty, value);
	}


	/// <summary>
	/// Indicates the corresponding <see cref="Sudoku.IO.Library"/> instance.
	/// </summary>
	/// <seealso cref="Sudoku.IO.Library"/>
	public Library Library => new(CommonPaths.Library, FileId);


	/// <summary>
	/// Try to create <see cref="LibraryBindableSource"/> instances from local path.
	/// </summary>
	/// <returns>A list of <see cref="LibraryBindableSource"/> instances.</returns>
	internal static ObservableCollection<LibraryBindableSource> GetLibrariesFromLocal()
	{
		if (!Directory.Exists(CommonPaths.Library))
		{
			// Implicitly create directory if the library directory does not exist.
			Directory.CreateDirectory(CommonPaths.Library);
			return [];
		}

		return [
			..
			from file in Directory.EnumerateFiles(CommonPaths.Library)
			let extension = io::Path.GetExtension(file)
			where extension == FileExtensions.JsonDocument
			let fileId = io::Path.GetFileNameWithoutExtension(file)
			let library = new Library(CommonPaths.Library, fileId)
			where File.Exists(library.LibraryPath)
			select new LibraryBindableSource
			{
				Name = library.ReadName() is var name and not "" ? name : NameDefaultValue,
				Author = library.ReadAuthor() is var author and not "" ? author : AuthorDefaultValue,
				Description = library.ReadDescription() is var description and not "" ? description : DescriptionDefaultValue,
				Tags = library.ReadTags() is var tags and not [] ? tags.ToArray() : [],
				FileId = fileId,
				IsActive = false
			}
		];
	}
}
