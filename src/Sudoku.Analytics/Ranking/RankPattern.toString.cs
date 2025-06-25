namespace Sudoku.Ranking;

public partial struct RankPattern
{
	/// <inheritdoc cref="object.ToString"/>
	public override string ToString()
	{
		var virtualTruthsString = string.Join(' ', from truth in VirtualTruths select truth.Candidates.ToString());
		var virtualLinksString = string.Join(' ', from link in VirtualLinks select link.Candidates.ToString());
		return (virtualTruthsString.Length, virtualLinksString.Length) switch
		{
			(0, 0) => $"T{Truths.Count} = {Truths}, L{Links.Count} = {Links}",
			(_, 0) => $"T{Truths.Count} = {Truths}, L{Links.Count} = {Links}, VT = {virtualTruthsString}",
			(0, _) => $"T{Truths.Count} = {Truths}, L{Links.Count} = {Links}, VL = {virtualLinksString}",
			_ => $"T{Truths.Count} = {Truths}, L{Links.Count} = {Links}, VT = {virtualTruthsString}, VL = {virtualLinksString}"
		};
	}

	/// <summary>
	/// Gets the full string of the current pattern, including its details (rank, eliminations and so on).
	/// </summary>
	/// <returns>The string.</returns>
	public unsafe string ToFullString()
	{
		var combinations = GetAssignmentCombinations();
		return string.Format(
			SR.Get("RankInfo"),
			Grid.ToString("@:"),
			ToString(),
			combinations.Length,
			GetRankCore(combinations)?.ToString() ?? SR.Get("UnstableRank"),
			GetEliminationsCore(combinations).ToString(),
			GetRank0LinksCore(combinations).ToString(),
			SR.Get(GetIsRank0PatternCore(combinations) ? "IsRank0Pattern" : "IsNotRank0Pattern")
		);
	}
}
