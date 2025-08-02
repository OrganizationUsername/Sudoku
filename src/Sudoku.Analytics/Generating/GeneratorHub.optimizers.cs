namespace Sudoku.Generating;

public partial class GeneratorHub
{
	private static partial Grid DefaultGenerator(Cell givens, SymmetricType symmetry, ConstraintCollection constraints, CancellationToken ct)
	{
		var puzzle = new Generator().Generate(givens, symmetry, ct);
		return puzzle.IsUndefined ? throw new OperationCanceledException() : puzzle;
	}

	private static partial Grid Optimizer_FullHouseOnly(Cell givens, SymmetricType type, ConstraintCollection constraints, CancellationToken ct)
		=> new FullHouseGenerator
		{
			SymmetricType = type,
			EmptyCellsCount = givens == -1 ? -1 : 81 - givens
		}.TryGenerateUnique(out var p, ct) ? p : throw new OperationCanceledException();

	private static partial Grid Optimizer_NakedSingleOnly(Cell givens, SymmetricType type, ConstraintCollection constraints, CancellationToken ct)
		=> new NakedSingleGenerator
		{
			SymmetricType = type,
			EmptyCellsCount = givens == -1 ? -1 : 81 - givens
		}.TryGenerateUnique(out var p, ct) ? p : throw new OperationCanceledException();

	private static partial Grid Optimizer_IttoryuMode(Cell givens, SymmetricType symmetry, ConstraintCollection constraints, CancellationToken ct)
	{
		var finder = new DisorderedIttoryuFinder();
		var generator = new Generator();
		while (true)
		{
			var puzzle = generator.Generate(givens, symmetry, ct);
			if (puzzle.IsUndefined)
			{
				throw new OperationCanceledException();
			}

			if (finder.FindPath(puzzle, ct) is { IsComplete: true } path)
			{
				puzzle.MakeIttoryu(path);
				return puzzle;
			}
		}
	}

	private static partial Grid Optimizer_MissingDigit(Cell givens, SymmetricType symmetry, ConstraintCollection constraints, CancellationToken ct)
	{
		// Set an arbitrary digit as missing digit.
		// The digit will be transformed to other one after the puzzle is satisfied the target constraints.
		var puzzle = new Generator { MissingDigit = 0 }.Generate(givens, symmetry, ct);
		return puzzle.IsUndefined ? throw new OperationCanceledException() : puzzle;
	}

	private static partial Grid Optimizer_EmptyHouses(Cell givens, SymmetricType symmetry, ConstraintCollection constraints, CancellationToken ct)
	{
		var puzzle = new EmptyHouseBasedGenerator
		{
			DesiredMissingHousesMask = constraints.OfType<EmptyHousesCountConstraint>().Aggregate(
				0,
				static (interim, next) => interim | (1 << next.Count) - 1 << (int)next.HouseType * 9
			)
		}.Generate(ct);
		return puzzle.IsUndefined ? throw new OperationCanceledException() : puzzle;
	}
}
