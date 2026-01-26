namespace System.IO;

/// <summary>
/// Provides a way to merge files.
/// </summary>
public static class FileMerger
{
	/// <include
	///     file="../../global-doc-comments.xml"
	///     path="/g/csharp14/feature[@name='extension-container']/target[@name='container']"/>
	extension(File)
	{
		/// <summary>
		/// Merge all found text files into one file.
		/// </summary>
		/// <param name="folder">The folder.</param>
		/// <param name="filePath">The file path.</param>
		/// <param name="option">
		/// An option indicating whether the output file only records header line from the first file.
		/// </param>
		/// <param name="cancellationToken">The cancellation token that can cancel the current operation.</param>
		/// <returns>A task of <see cref="bool"/> value.</returns>
		/// <exception cref="OperationCanceledException">Throws when operation is canceled.</exception>
		public static async Task MergeAsync(
			string folder,
			string filePath,
			FileMergerHeaderLineOption option,
			CancellationToken cancellationToken = default
		)
		{
			await using var sw = new StreamWriter(filePath);
			var isFirstFile = true;
			foreach (var fi in new DirectoryInfo(folder).EnumerateFiles())
			{
				var isFirstLine = true;
				var path = fi.FullName;
				await foreach (var line in File.ReadLinesAsync(path, cancellationToken))
				{
					if (isFirstLine)
					{
						isFirstLine = false;
						if (option == FileMergerHeaderLineOption.AlwaysExcluding
							|| option == FileMergerHeaderLineOption.OnlyFirstFile && !isFirstFile)
						{
							continue;
						}
					}
					await sw.WriteLineAsync(line.AsMemory(), cancellationToken);
				}
				isFirstFile = false;
			}
		}
	}
}
