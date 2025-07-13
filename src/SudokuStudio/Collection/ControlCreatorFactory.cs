namespace SudokuStudio.Collection;

/// <summary>
/// Represents a control creator factory.
/// </summary>
internal sealed class ControlCreatorFactory() : Dictionary<Type, Func<GeneratedPuzzleConstraintPage, Constraint, Control?>>(
	EqualityComparer<Type>.Create(
		static (a, b) => a == b,
		static v => v.GetHashCode()
	)
);
