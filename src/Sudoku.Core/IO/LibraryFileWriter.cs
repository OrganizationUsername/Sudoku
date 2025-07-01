namespace Sudoku.IO;

/// <summary>
/// Represents a UTF-8 format library file writer.
/// </summary>
internal sealed class LibraryFileWriter : IAsyncDisposable
{
	/// <summary>
	/// Represents a new line character sequence.
	/// </summary>
	private const string NewLineCharacters = "\r\n";


	/// <summary>
	/// Indicates the writer.
	/// </summary>
	private readonly StreamWriter _writer;

	/// <summary>
	/// Indicates the semaphore.
	/// </summary>
	private readonly SemaphoreSlim _semaphore = new(1, 1);

	/// <summary>
	/// Indicates the buffer. If the maximum number of lines is reached, a flush operation will be triggered.
	/// </summary>
	private readonly List<string> _buffer = [];

	/// <summary>
	/// Indicates whether the object had already been disposed before <see cref="DisposeAsync"/> was called.
	/// If this field holds <see langword="false"/> value, <see cref="DisposeAsync"/> will throw an
	/// <see cref="ObjectDisposedException"/> to report the error.
	/// </summary>
	/// <seealso cref="DisposeAsync"/>
	/// <seealso cref="ObjectDisposedException"/>
	private bool _isDisposed;


	/// <summary>
	/// Initializes a <see cref="LibraryFileWriter"/> instance via the specified file path;
	/// if the specified path doesn't exist, a new file will be created.
	/// </summary>
	/// <param name="filePath">The file path.</param>
	/// <param name="exists">Indicates whether the file exists.</param>
	public LibraryFileWriter(string filePath, out bool exists)
	{
		FilePath = filePath;
		exists = File.Exists(filePath);
		_writer = new(
			new FileStream(
				filePath,
				FileMode.Append,
				FileAccess.Write,
				FileShare.Read,
				1024,
				FileOptions.Asynchronous
			),
			Encoding.UTF8
		);
	}


	/// <summary>
	/// Indicates whether the flush operation will be automatically triggered.
	/// </summary>
	public bool AutoFlush { get; init; }

	/// <summary>
	/// Indicates the buffer size, indicating the maximum number of lines of puzzles can be recorded in backing buffer.
	/// By default it's 1024.
	/// </summary>
	public int BufferSize { get; } = 1024;

	/// <summary>
	/// Indicates the file path.
	/// </summary>
	public string FilePath { get; }


	/// <inheritdoc/>
	/// <exception cref="ObjectDisposedException">Throws when the object had already been disposed.</exception>
	public async ValueTask DisposeAsync()
	{
		ObjectDisposedException.ThrowIf(_isDisposed, this);

		await FlushAsync(); // Flush memory and write for the last values.

		// Dispose values.
		await _writer.DisposeAsync();
		_isDisposed = true;
	}

	/// <summary>
	/// Write a new line of values into the file.
	/// </summary>
	/// <param name="line">A line.</param>
	/// <param name="cancellationToken">The cancellation token that can cancel the current operation.</param>
	/// <returns>A <see cref="Task"/> object that can be used as asynchronous operation.</returns>
	public async Task WriteLineAsync(string line, CancellationToken cancellationToken = default)
	{
		await _semaphore.WaitAsync(cancellationToken);

		try
		{
			_buffer.Add(line);
			if (AutoFlush || _buffer.Count >= BufferSize)
			{
				await FlushInternalAsync();
			}
		}
		finally
		{
			_semaphore.Release();
		}
	}

	/// <summary>
	/// Flushes the buffer and write them into file.
	/// </summary>
	/// <returns>A <see cref="Task"/> object that can be used as asynchronous operation.</returns>
	public async Task FlushAsync()
	{
		await _semaphore.WaitAsync();

		try
		{
			await FlushInternalAsync();
		}
		finally
		{
			_semaphore.Release();
		}
	}

	/// <summary>
	/// The backing logic on flushing the buffer, writting the buffer into the file.
	/// </summary>
	/// <returns>A <see cref="Task"/> object that can be used as asynchronous operation.</returns>
	private async Task FlushInternalAsync()
	{
		if (_buffer.Count == 0)
		{
			return;
		}

		await _writer.WriteLineAsync(string.Join(NewLineCharacters, _buffer.AsSpan()));
		await _writer.FlushAsync();
		_buffer.Clear();
	}
}
