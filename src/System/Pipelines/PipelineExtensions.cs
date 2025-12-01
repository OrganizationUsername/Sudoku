namespace System.Pipelines;

/// <summary>
/// Provides a way to use pipeline syntax.
/// </summary>
public static class Pipeline
{
	/// <summary>
	/// Provides extension members on <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">The type of instance.</typeparam>
	/// <typeparam name="TResult">The type of result.</typeparam>
	extension<T, TResult>(T)
		where T : allows ref struct
		where TResult : allows ref struct
	{
		/// <summary>
		/// Performs pipeline operation. Syntax <c>arg | operation</c> means <c>operation(arg)</c>.
		/// </summary>
		/// <param name="left">The instance.</param>
		/// <param name="right">The function that receives <paramref name="left"/> as the only parameter.</param>
		/// <returns>The result.</returns>
		public static TResult operator |(T left, Func<T, TResult> right) => right(left);

		/// <inheritdoc cref="extension{T, TResult}(T).op_BitwiseOr(T, Func{T, TResult})"/>
		public static unsafe TResult operator |(T left, delegate*<T, TResult> right) => right(left);
	}

	/// <summary>
	/// Provides extension members on <typeparamref name="T1"/> and <typeparamref name="T2"/>.
	/// </summary>
	/// <typeparam name="T1">The type of parameter 1.</typeparam>
	/// <typeparam name="T2">The type of parameter 2.</typeparam>
	/// <typeparam name="TResult">The type of result.</typeparam>
	extension<T1, T2, TResult>(ValueTuple<T1, T2>) where TResult : allows ref struct
	{
		/// <summary>
		/// Performs pipeline operation. Syntax <c>(arg1, arg2) | operation</c> means <c>operation(arg1, arg2)</c>.
		/// </summary>
		/// <param name="left">The pair of arguments.</param>
		/// <param name="right">The function that receives <paramref name="left"/> as pair of parameters.</param>
		/// <returns>The result.</returns>
		public static TResult operator |(ValueTuple<T1, T2> left, Func<T1, T2, TResult> right) => right(left.Item1, left.Item2);

		/// <inheritdoc cref="extension{T1, T2, TResult}(ValueTuple{T1, T2}).op_BitwiseOr(ValueTuple{T1, T2}, Func{T1, T2, TResult})"/>
		public static unsafe TResult operator |(ValueTuple<T1, T2> left, delegate*<T1, T2, TResult> right)
			=> right(left.Item1, left.Item2);
	}

	/// <summary>
	/// Provides extension members on <typeparamref name="T1"/>, <typeparamref name="T2"/> and <typeparamref name="T3"/>.
	/// </summary>
	/// <typeparam name="T1">The type of parameter 1.</typeparam>
	/// <typeparam name="T2">The type of parameter 2.</typeparam>
	/// <typeparam name="T3">The type of parameter 3.</typeparam>
	/// <typeparam name="TResult">The type of result.</typeparam>
	extension<T1, T2, T3, TResult>(ValueTuple<T1, T2, T3>) where TResult : allows ref struct
	{
		/// <summary>
		/// Performs pipeline operation. Syntax <c>(arg1, arg2, arg3) | operation</c> means <c>operation(arg1, arg2, arg3)</c>.
		/// </summary>
		/// <param name="left">The triplet of arguments.</param>
		/// <param name="right">The function that receives <paramref name="left"/> as pair of parameters.</param>
		/// <returns>The result.</returns>
		public static TResult operator |(ValueTuple<T1, T2, T3> left, Func<T1, T2, T3, TResult> right)
			=> right(left.Item1, left.Item2, left.Item3);

		/// <inheritdoc cref="extension{T1, T2, T3, TResult}(ValueTuple{T1, T2, T3}).op_BitwiseOr(ValueTuple{T1, T2, T3}, Func{T1, T2, T3, TResult})"/>
		public static unsafe TResult operator |(ValueTuple<T1, T2, T3> left, delegate*<T1, T2, T3, TResult> right)
			=> right(left.Item1, left.Item2, left.Item3);
	}
}
