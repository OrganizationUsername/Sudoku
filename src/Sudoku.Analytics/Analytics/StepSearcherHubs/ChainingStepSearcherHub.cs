namespace Sudoku.Analytics.StepSearcherHubs;

/// <summary>
/// Represents a type that can search for chains with general rules, which can be called by multiple different step searcher types.
/// </summary>
internal abstract partial class ChainingStepSearcherHub : StepSearcherHubBase
{
	/// <summary>
	/// The internal method that can collect for general-typed multiple forcing chains.
	/// </summary>
	/// <typeparam name="TMultipleForcingChains">The type of multiple forcing chains.</typeparam>
	/// <typeparam name="TMultipleForcingChainsStep">The type of target step can be created.</typeparam>
	/// <param name="context">The context.</param>
	/// <param name="accumulator">The instance that temporarily records for chain steps.</param>
	/// <param name="allowsAdvancedLinks">Indicates whether the method allows advanced links.</param>
	/// <param name="onlyFindFinnedChain">Indicates whether the method only finds for (grouped) finned chains.</param>
	/// <param name="componentCreator">Indicates the component that the current forcing chains pattern is.</param>
	/// <param name="chainsCollector">
	/// The collector method that can find a list of <typeparamref name="TMultipleForcingChains"/> instances in the grid.
	/// </param>
	/// <param name="stepCreator">The creator method that can create a chain step.</param>
	/// <returns>The first found step.</returns>
	protected static unsafe Step? CollectGeneralizedMultipleCore<TMultipleForcingChains, TMultipleForcingChainsStep>(
		ref StepAnalysisContext context,
		SortedSet<ChainStep> accumulator,
		bool allowsAdvancedLinks,
		bool onlyFindFinnedChain,
		delegate*<TMultipleForcingChains, MultipleChainBasedComponent> componentCreator,
		delegate*<in Grid, bool, ReadOnlySpan<TMultipleForcingChains>> chainsCollector,
		delegate*<TMultipleForcingChains, in Grid, in StepAnalysisContext, ChainingRuleCollection, TMultipleForcingChainsStep> stepCreator
	)
		where TMultipleForcingChains : MultipleForcingChains
		where TMultipleForcingChainsStep : PatternBasedChainStep
	{
		ref readonly var grid = ref context.Grid;
		InitializeLinks(
			grid,
			LinkType.MergeFlags([.. ChainingRule.ElementaryLinkTypes, .. allowsAdvancedLinks ? ChainingRule.AdvancedLinkTypes : []]),
			context.Options,
			out var supportedRules
		);

		foreach (var chain in chainsCollector(context.Grid, context.OnlyFindOne))
		{
			if (onlyFindFinnedChain && chain.TryCastToFinnedChain(out var finnedChain, out var f))
			{
				ref readonly var fins = ref Nullable.GetValueRefOrDefaultRef(in f);
				chain.PrepareFinnedChainViewNodes(finnedChain, supportedRules, grid, fins, out var views);

				var finnedChainStep = new FinnedChainStep(
					chain.Conclusions,
					views,
					context.Options,
					finnedChain,
					fins,
					componentCreator(chain)
				);
				if (finnedChain.IsStrictlyGrouped ^ allowsAdvancedLinks)
				{
					continue;
				}

				if (context.OnlyFindOne)
				{
					return finnedChainStep;
				}

				accumulator.Add(finnedChainStep);
				continue;
			}

			if (!onlyFindFinnedChain)
			{
				var rfcStep = stepCreator(chain, grid, context, supportedRules);
				if (context.OnlyFindOne)
				{
					return rfcStep;
				}

				accumulator.Add(rfcStep);
			}
		}
		return null;
	}
}
