namespace Sudoku.Analytics.Construction;

/// <summary>
/// Represents a type that describes a component in a pattern, which is unspeakable by normal implementation of pattern.
/// </summary>
public interface IComponent : IConstructible<ComponentType>
{
	/// <inheritdoc cref="IConstructible{TEnum}.Type"/>
	public new abstract ComponentType Type { get; }

	/// <inheritdoc/>
	ComponentType IConstructible<ComponentType>.Type => Type;
}
