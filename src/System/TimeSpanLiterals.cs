namespace System;

/// <summary>
/// Represents extension members that implicitly converts the value into a <see cref="TimeSpan"/> object
/// by using fluent way.
/// </summary>
/// <seealso cref="TimeSpan"/>
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
public static class TimeSpanLiterals
{
	/// <summary>
	/// Provides extension members on <see cref="int"/>.
	/// </summary>
	extension(int @this)
	{
		/// <summary>
		/// (<see cref="int"/> -> <see cref="TimeSpan"/>) in milliseconds.
		/// </summary>
		public TimeSpan ms => TimeSpan.FromMilliseconds(@this);

		/// <summary>
		/// (<see cref="int"/> -> <see cref="TimeSpan"/>) in seconds.
		/// </summary>
		public TimeSpan s => TimeSpan.FromSeconds(@this);

		/// <summary>
		/// (<see cref="int"/> -> <see cref="TimeSpan"/>) in minutes.
		/// </summary>
		public TimeSpan min => TimeSpan.FromMinutes(@this);

		/// <summary>
		/// (<see cref="int"/> -> <see cref="TimeSpan"/>) in hours.
		/// </summary>
		public TimeSpan h => TimeSpan.FromHours(@this);
	}

	/// <summary>
	/// Provides extension members on <see cref="double"/>.
	/// </summary>
	extension(double @this)
	{
		/// <summary>
		/// (<see cref="double"/> -> <see cref="TimeSpan"/>) in milliseconds.
		/// </summary>
		public TimeSpan ms => TimeSpan.FromMilliseconds(@this);

		/// <summary>
		/// (<see cref="double"/> -> <see cref="TimeSpan"/>) in seconds.
		/// </summary>
		public TimeSpan s => TimeSpan.FromSeconds(@this);

		/// <summary>
		/// (<see cref="double"/> -> <see cref="TimeSpan"/>) in minutes.
		/// </summary>
		public TimeSpan min => TimeSpan.FromMinutes(@this);

		/// <summary>
		/// (<see cref="double"/> -> <see cref="TimeSpan"/>) in hours.
		/// </summary>
		public TimeSpan h => TimeSpan.FromHours(@this);
	}
}
