namespace Sudoku.Analytics.StepSearcherHubs;

internal partial class ChainingStepSearcherHub
{
	/// <summary>
	/// <para>Finds a list of nodes that can implicitly connects to current node via a forcing chain.</para>
	/// <para>This method only uses cached fields <see cref="StrongLinkDictionary"/> and <see cref="WeakLinkDictionary"/>.</para>
	/// </summary>
	/// <param name="startNode">The current instance.</param>
	/// <returns>
	/// A pair of <see cref="HashSet{T}"/> of <see cref="Node"/> instances, indicating all possible nodes
	/// that can implicitly connects to the current node via the whole forcing chain, grouped by their own initial states,
	/// encapsulating with type <see cref="ForcingChainsInfo"/>.
	/// </returns>
	/// <seealso cref="StrongLinkDictionary"/>
	/// <seealso cref="WeakLinkDictionary"/>
	/// <seealso cref="HashSet{T}"/>
	/// <seealso cref="Node"/>
	/// <seealso cref="ForcingChainsInfo"/>
	protected static ForcingChainsInfo FindForcingChains(Node startNode)
	{
		var (pendingNodesSupposedOn, pendingNodesSupposedOff) = (new Queue<Node>(), new Queue<Node>());
		(startNode.IsOn ? pendingNodesSupposedOn : pendingNodesSupposedOff).Enqueue(startNode);

		var nodesSupposedOn = new HashSet<Node>(ChainingComparers.NodeMapComparer);
		var nodesSupposedOff = new HashSet<Node>(ChainingComparers.NodeMapComparer);
		while (pendingNodesSupposedOn.Count != 0 || pendingNodesSupposedOff.Count != 0)
		{
			if (pendingNodesSupposedOn.Count != 0)
			{
				var currentNode = pendingNodesSupposedOn.Dequeue();
				if (WeakLinkDictionary.TryGetValue(currentNode, out var supposedOff))
				{
					foreach (var node in supposedOff)
					{
						var nextNode = node >> currentNode;
						if (nodesSupposedOn.Contains(~nextNode))
						{
							// Contradiction is found.
							goto ReturnResult;
						}

						if (nodesSupposedOff.Add(nextNode))
						{
							pendingNodesSupposedOff.Enqueue(nextNode);
						}
					}
				}
			}
			else
			{
				var currentNode = pendingNodesSupposedOff.Dequeue();
				if (StrongLinkDictionary.TryGetValue(currentNode, out var supposedOn))
				{
					foreach (var node in supposedOn)
					{
						var nextNode = node >> currentNode;
						if (nodesSupposedOff.Contains(~nextNode))
						{
							// Contradiction is found.
							goto ReturnResult;
						}

						if (nodesSupposedOn.Add(nextNode))
						{
							pendingNodesSupposedOn.Enqueue(nextNode);
						}
					}
				}
			}
		}

	ReturnResult:
		// Returns the found result.
		return new(nodesSupposedOn, nodesSupposedOff);
	}
}
