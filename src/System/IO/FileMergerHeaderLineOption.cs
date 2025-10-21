namespace System.IO;

/// <summary>
/// Represents an option to define a behavior recording header lines into output file,
/// while merging text files from a folder.
/// </summary>
public enum FileMergerHeaderLineOption
{
	/// <summary>
	/// Indicates we only records the header line for the first file.
	/// </summary>
	OnlyFirstFile,

	/// <summary>
	/// Indicates we always including header lines,
	/// meaning we don't treat the first lines from all files as the header lines.
	/// </summary>
	AlwaysIncluding,

	/// <summary>
	/// Indicates we always excluding header lines, not outputting them into result file.
	/// </summary>
	AlwaysExcluding
}
