namespace SudokuStudio.BindableSource;

/// <summary>
/// Represents a type that can be used for binding as source, for repository information
/// used for displaying the source code referencing.
/// </summary>
public sealed class RepositoryInfoBindableSource
{
	/// <summary>
	/// Indicates whether the repository code is for reference.
	/// </summary>
	public bool IsForReference { get; set; }

	/// <summary>
	/// Indicates the open-source license being used for this repository.
	/// </summary>
	public string OpenSourceLicense { get; set; } = string.Empty;

	/// <summary>
	/// Indicates the name of the image.
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Indicates the website which name is corresponding to.
	/// </summary>
	public Uri? Site { get; set; }
}
