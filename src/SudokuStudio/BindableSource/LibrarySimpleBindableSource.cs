namespace SudokuStudio.BindableSource;

/// <summary>
/// Represents the bindable source for libraries.
/// </summary>
public sealed partial class LibrarySimpleBindableSource
{
	/// <summary>
	/// Indicates the display name.
	/// </summary>
	public string DisplayName
		=> LibraryConversion.GetDisplayName(
			Library.ReadName(),
			io::Path.GetFileNameWithoutExtension(Library.LibraryPath)
		);

	/// <summary>
	/// Indicates the library.
	/// </summary>
	public required Library Library { get; set; }


	/// <summary>
	/// Try to fetch all <see cref="Library"/> instances stored in the local path.
	/// </summary>
	/// <returns>All possible <see cref="Library"/> instances.</returns>
	internal static Library[] GetLibraries()
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
			select library
		];
	}
}
