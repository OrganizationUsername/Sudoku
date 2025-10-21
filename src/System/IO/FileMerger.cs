namespace System.IO;

/// <summary>
/// Provides a way to merge files.
/// </summary>
public static class FileMerger
{
	/// <summary>
	/// Provides extension members on <see cref="File"/>.
	/// </summary>
	extension(File)
	{
		/// <summary>
		/// Merge all found text files into one file.
		/// </summary>
		/// <param name="folder">The folder.</param>
		/// <param name="filePath">The file path.</param>
		/// <param name="onlyRecordHeaderFromFirstFile">
		/// Indicates whether the output file only records header line from the first file.
		/// There're 3 possible values:
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <term><see langword="true"/></term>
		/// <description>Only records header line for the first file</description>
		/// </item>
		/// <item>
		/// <term><see langword="false"/></term>
		/// <description>Always including the first line (ignoring header line rule)</description>
		/// </item>
		/// <item>
		/// <term><see langword="null"/></term>
		/// <description>
		/// Always excluding the first line (treating the first lines from all files to be header and ignore them)
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="cancellationToken">The cancellation token that can cancel the current operation.</param>
		/// <returns>A task of <see cref="bool"/> value.</returns>
		/// <exception cref="OperationCanceledException">Throws when operation is canceled.</exception>
		public static async Task MergeAsync(string folder, string filePath, bool? onlyRecordHeaderFromFirstFile, CancellationToken cancellationToken = default)
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
						if (onlyRecordHeaderFromFirstFile is null
							|| onlyRecordHeaderFromFirstFile is true && !isFirstFile)
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
