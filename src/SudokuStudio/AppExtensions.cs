namespace SudokuStudio;

/// <summary>
/// Provides with extension methods on <see cref="App"/>.
/// </summary>
/// <seealso cref="App"/>
public static class AppExtensions
{
	/// <summary>
	/// Provides extension members on <see cref="App"/>.
	/// </summary>
	extension(App @this)
	{
		/// <summary>
		/// Try to get <see cref="StepSearcher"/> instances via configuration for the specified application.
		/// </summary>
		/// <returns>A list of <see cref="StepSearcher"/> instances.</returns>
		public StepSearcher[] GetStepSearchers()
			=> [
				..
				from data in @this.Preference.StepSearcherOrdering.StepSearchersOrder
				where data.IsEnabled
				select data.CreateStepSearcher()
			];
	}

	/// <summary>
	/// Provides extension members on <see cref="Application"/>.
	/// </summary>
	extension(Application @this)
	{
		/// <summary>
		/// Converts the current instance into an <see cref="App"/> instance;
		/// throw <see cref="InvalidCastException"/> if the current object is not an <see cref="App"/> instance.
		/// </summary>
		/// <returns>The result casted.</returns>
		public App AsApp() => (App)@this;
	}
}
