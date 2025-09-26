namespace Sudoku.Analytics.StepSearchers;

/// <summary>
/// Provides with a <b>Multifish</b> step searcher.
/// The step searcher will include the following techniques:
/// <list type="bullet">
/// <item>Multifish</item>
/// </list>
/// </summary>
[StepSearcher("StepSearcherName_MultifishStepSearcher", Technique.Multifish)]
public sealed partial class MultifishStepSearcher : StepSearcher
{
	/// <summary>
	/// Represents block table, grouped by chute.
	/// </summary>
	private static readonly House[][] ChuteBlocks = [[0, 1, 2], [3, 4, 5], [6, 7, 8], [0, 3, 6], [1, 4, 7], [2, 5, 8]];


	/// <inheritdoc/>
	protected internal override Step? Collect(ref StepAnalysisContext context)
	{
		ref readonly var grid = ref context.Grid;

		var notSolved = new Mask[27];
		foreach (var cell in EmptyCells)
		{
			var mask = grid.GetCandidates(cell);
			notSolved[cell >> HouseType.Block] |= mask;
			notSolved[cell >> HouseType.Row] |= mask;
			notSolved[cell >> HouseType.Column] |= mask;
		}

		// Iterate digit combinations via bit enumerator.
		for (var digitSize = 2; digitSize <= 4; digitSize++)
		{
			// Iterate each digit combination of length 'digitSize'.
			foreach (var digitsMask in new BitCombinationGenerator<Mask>(9, digitSize))
			{
				// Iterate main line type. The multifish "bones" should be either in rows or in columns.
				foreach (var isRow in (true, false))
				{
					// Iterate on houses offsets, also via bit enumerator.
					for (var houseOffsetsSize = digitSize == 2 ? 3 : 2; houseOffsetsSize <= 5; houseOffsetsSize++)
					{
						// Here variable is a 9-bit integer, with some bits set 1 of length 'houseOffsetsSize' exactly.
						// The variable will be used for house checking (via operations << 9 and << 18).
						foreach (var houseOffsets in new BitCombinationGenerator<Mask>(9, houseOffsetsSize))
						{
							// Skip cases when the chosen houses don't use important 3 lines in a chute.
							if ((houseOffsets & ~7) == 0 || (houseOffsets & ~56) == 0 || (houseOffsets & ~448) == 0)
							{
								continue;
							}

							var housesMask = houseOffsets << (isRow ? 9 : 18);

							// Iterate on each house.
							var patternCells = CellMap.Empty;
							var patternCellsGroupedByDigit = new CellMap[9];
							var rctValidDigitsMask = new Mask[27];
							var availableDigitsMask = (Mask)0;
							foreach (var house in housesMask)
							{
								ref var rctValidDigitsMaskCurrentHouse = ref rctValidDigitsMask[house];
								foreach (var digit in digitsMask)
								{
									var cells = HousesMap[house] & CandidatesMap[digit];
									if (cells.Count < 2)
									{
										// Potential hidden single found. But in this technique we don't handle with that.
										continue;
									}

									rctValidDigitsMaskCurrentHouse |= (Mask)(1 << digit);
									patternCellsGroupedByDigit[digit] |= cells;
									patternCells |= cells;
								}

								if (PopCount((uint)rctValidDigitsMaskCurrentHouse) < 2)
								{
									// We cannot choose such houses with specified line type.
									goto NextLineTypeCase;
								}

								availableDigitsMask |= rctValidDigitsMaskCurrentHouse;
							}
							if (availableDigitsMask != digitsMask)
							{
								// Not all available digits can be used in chosen houses.
								continue;
							}

							// Here we know that the houses can be treated as valid truths. Now we should find for links.

							// Iterate on each pattern cell, to collect all possible links that can be iterated.
							var houseDigitTruths = new Mask[27];
							var houseDigitLinks = new Mask[27];
							foreach (var cell in patternCells)
							{
								var oppositeLineToCell = cell >> (isRow ? HouseType.Column : HouseType.Row);
								var candidates = (Mask)(grid.GetCandidates(cell) & digitsMask);
								houseDigitTruths[oppositeLineToCell] |= candidates;
								houseDigitLinks[oppositeLineToCell] |= candidates;
								houseDigitTruths[cell >> HouseType.Block] |= candidates;
								houseDigitLinks[cell >> HouseType.Block] |= candidates;
							}

							var removedHouses = new House[27];
							var isWorthTable = new bool[3];

							// Let's suppose we should choose line links. Block links can be adjusted later.
							var (tempLineLinksCount, tempBlockLinksCount) = (0, 0);

							// Iterate on each house.
							for (var (house, houseIteration) = (isRow ? 18 : 9, 0); houseIteration < 3; house += 3, houseIteration++)
							{
								// Define a local counter to sum up usage cases on 3 bands or towers having any house-digit truths.
								// This value can be used for rank-balancing operations.
								var localCounter = (houseDigitTruths[house] != 0 ? 1 : 0)
									+ (houseDigitTruths[house + 1] != 0 ? 1 : 0)
									+ (houseDigitTruths[house + 2] != 0 ? 1 : 0);

								// House type index: 9..18 => 0..3, 18..27 => 3..6.
								var chuteIndex = (house - 9) / 3;
								switch (localCounter)
								{
									// There'll be only one line link. We don't consider any conversions to block links.
									case 1:
									{
										// Set cached truths in blocks to 0 (ignore block links to be calculated).
										houseDigitTruths[ChuteBlocks[chuteIndex][0]] = 0;
										houseDigitTruths[ChuteBlocks[chuteIndex][1]] = 0;
										houseDigitTruths[ChuteBlocks[chuteIndex][2]] = 0;
										break;
									}

									// There'll be 2 line links. We should measure block links here.
									case 2:
									{
										for (var line = house; line < house + 3; line++)
										{
											if (houseDigitTruths[line] == 0)
											{
												continue;
											}

											var cells = patternCells & HousesMap[line];
											tempLineLinksCount += Math.Min(PopCount((uint)houseDigitTruths[line]), cells.Count);
										}
										for (var i = 0; i < 3; i++)
										{
											var block = ChuteBlocks[chuteIndex][i];
											if (houseDigitTruths[block] == 0)
											{
												continue;
											}

											var cells = patternCells & HousesMap[block];
											tempBlockLinksCount += Math.Min(PopCount((uint)houseDigitTruths[block]), cells.Count);
										}
										if (tempBlockLinksCount < tempLineLinksCount)
										{
											houseDigitTruths[ChuteBlocks[chuteIndex][0]] = 0;
											houseDigitTruths[ChuteBlocks[chuteIndex][1]] = 0;
											houseDigitTruths[ChuteBlocks[chuteIndex][2]] = 0;
										}
										else
										{
											// Worth to adjust.
											if (tempLineLinksCount == tempBlockLinksCount && tempBlockLinksCount != 0)
											{
												isWorthTable[house % 9 / 3] = true;
											}

											houseDigitTruths[ChuteBlocks[chuteIndex][0]] = 0;
											houseDigitTruths[ChuteBlocks[chuteIndex][1]] = 0;
											houseDigitTruths[ChuteBlocks[chuteIndex][2]] = 0;
										}

										removedHouses[ChuteBlocks[chuteIndex][0]] = -1;
										removedHouses[ChuteBlocks[chuteIndex][1]] = -1;
										removedHouses[ChuteBlocks[chuteIndex][2]] = -1;
										break;
									}

									// There'll be 3 line links.
									case 3:
									{
										var minInLine = new int[3];
										for (var i = 0; i < 3; i++)
										{
											var currentHouse = house + i;
											var cells = patternCells & HousesMap[currentHouse];
											if (PopCount((uint)houseDigitTruths[currentHouse]) is var p && p <= cells.Count)
											{
												tempLineLinksCount += p;
												minInLine[i] = p;
											}
										}

										var flag = false;

										for (var i = 0; i < 3; i++)
										{
											var block = ChuteBlocks[chuteIndex][i];
											if (houseDigitTruths[block] == 0)
											{
												continue;
											}

											var cells = patternCells & HousesMap[block];
											if (cells.Count >= houseOffsetsSize)
											{
												flag = true;
											}

											tempBlockLinksCount += Math.Min(PopCount((uint)houseDigitTruths[block]), cells.Count);
										}

										var (state, count) = tempBlockLinksCount < tempLineLinksCount
											|| tempBlockLinksCount == tempLineLinksCount && flag
											? (4, tempBlockLinksCount)
											: (0, tempLineLinksCount);
										var temp = 0;
										var blockLinkTable = new Mask[3];
										var bbl = new Mask[3];
										for (var i = 0; i < 2; i++)
										{
											for (var j = 1; j < 3; j++)
											{
												temp++;
												var deletedCount = 0;
												var cells = patternCells & (HousesMap[house + i] | HousesMap[house + j]);
												for (var k = 0; k < 3; k++)
												{
													var other = cells & HousesMap[ChuteBlocks[chuteIndex][k]];
													blockLinkTable[k] = 0;

													if (!other)
													{
														continue;
													}

													foreach (var cell in other)
													{
														blockLinkTable[k] |= (Mask)(grid.GetCandidates(cell) & digitsMask);
													}
													deletedCount += Math.Min(PopCount((uint)blockLinkTable[k]), other.Count);
												}
												if (deletedCount + minInLine[3 - i - j] is var p && p < count)
												{
													state = temp;
													count = deletedCount + p;
													blockLinkTable.AsReadOnlySpan().CopyTo(bbl);
												}
											}
										}

										switch (state)
										{
											case 0:
											{
												houseDigitTruths[ChuteBlocks[chuteIndex][0]] = 0;
												houseDigitTruths[ChuteBlocks[chuteIndex][1]] = 0;
												houseDigitTruths[ChuteBlocks[chuteIndex][2]] = 0;
												if (tempBlockLinksCount == tempLineLinksCount && tempBlockLinksCount != 0)
												{
													isWorthTable[house % 9 / 3] = true;
												}
												break;
											}
											case 4:
											{
												houseDigitTruths[house] = 0;
												houseDigitTruths[house + 1] = 0;
												houseDigitTruths[house + 2] = 0;
												removedHouses[ChuteBlocks[chuteIndex][0]] = -1;
												removedHouses[ChuteBlocks[chuteIndex][1]] = -1;
												removedHouses[ChuteBlocks[chuteIndex][2]] = -1;
												break;
											}
											default:
											{
												// Performs an adjustment to block link.
												var chuteLinesArray = (int[][])[[], [0, 1], [0, 2], [1, 2]];
												houseDigitTruths[house + chuteLinesArray[state][0]] = 0;
												houseDigitTruths[house + chuteLinesArray[state][1]] = 0;
												houseDigitTruths[ChuteBlocks[chuteIndex][0]] = bbl[0];
												houseDigitTruths[ChuteBlocks[chuteIndex][1]] = bbl[1];
												houseDigitTruths[ChuteBlocks[chuteIndex][2]] = bbl[2];
												removedHouses[ChuteBlocks[chuteIndex][0]] = 3 - state + house;
												removedHouses[ChuteBlocks[chuteIndex][1]] = 3 - state + house;
												removedHouses[ChuteBlocks[chuteIndex][2]] = 3 - state + house;
												break;
											}
										}
										break;
									}
								}
							}

							var cellTruths = CellMap.Empty;

							// According to previous judgement of line links, we should here find a best rank of link combinations,
							// which is an optimization of a single house
							// (choosing four kinds of links in order to make rank to be a minimum value).
							var rcTruths = new Mask[27];
							var rcLinks = new Mask[27];
							var cellLinks = CellMap.Empty;
							for (var house = 0; house < 27; house++)
							{
								if (houseDigitTruths[house] == 0)
								{
									continue;
								}

								ChooseLink(
									grid,
									patternCells,
									ref cellTruths,
									ref cellLinks,
									rcTruths,
									rcLinks,
									houseDigitTruths,
									house,
									notSolved,
									removedHouses
								);
							}

							var truthsCount = cellTruths.Count;
							var linksCount = cellLinks.Count;
							foreach (var mask in rcTruths)
							{
								truthsCount += PopCount((uint)mask);
							}
							foreach (var mask in rcLinks)
							{
								linksCount += PopCount((uint)mask);
							}

							// Try to merge cell links into block links in order to make pattern valid.
							// Every cell links here only holds one digit of multifish pattern,
							// and all cells covered by line links are inside one block, so we can try this.
							if (linksCount > truthsCount && linksCount < truthsCount + 3)
							{
								// Adjust links phase 1.
								foreach (var cell in cellLinks)
								{
									var linkHouse = cell >> (isRow ? HouseType.Column : HouseType.Row);
									var candidates = (Mask)((Mask)(grid.GetCandidates(cell) & digitsMask) | rcLinks[linkHouse]);
									if (PopCount((uint)candidates) != 1)
									{
										continue;
									}

									var (first, second) = (linkHouse % 3) switch
									{
										0 => (linkHouse + 1, linkHouse + 2),
										1 => (linkHouse - 1, linkHouse + 1),
										_ => (linkHouse - 2, linkHouse - 1)
									};
									for (var i = 0; i < 2; i++)
									{
										var house = i == 0 ? first : second;
										if ((rcLinks[house] & candidates) == 0)
										{
											continue;
										}

										var tempCells = CandidatesMap[Log2((uint)candidates)]
											& HousesMap[house]
											& (patternCells | cellTruths);
										if (tempCells.PeerIntersection.Contains(cell))
										{
											// This cell can be cleared, to form a block link.
											rcLinks[cell >> HouseType.Block] |= candidates;
											rcLinks[house] &= (Mask)~candidates;
											cellLinks -= cell;
											linksCount--;
										}
									}
								}

								// Adjust links phase 2.
								if (linksCount > truthsCount)
								{
									// Add block truths.
									var blockMask = cellLinks.BlockMask;
									foreach (var block in blockMask)
									{
										var chuteRow = block / 3 * 3 + 9;
										var chuteColumn = block % 3 * 3 + 18;
#pragma warning disable CS0675
										// Calculate truths in chute row (band) and chute column (tower) and its containing block,
										// in order to avoid truth triplets.
										var candidatesMask = (Mask)(
											rcTruths[chuteRow]
												| rcTruths[chuteRow + 1]
												| rcTruths[chuteRow + 2]
												| rcTruths[chuteColumn]
												| rcTruths[chuteColumn + 1]
												| rcTruths[chuteColumn + 2]
												| rcTruths[block]
										);
#pragma warning restore CS0675
										candidatesMask = (Mask)(notSolved[block] & ~candidatesMask);
										if (candidatesMask == 0)
										{
											continue;
										}

										var candidates = candidatesMask.AllSets;
										foreach (var digitCombination in candidates | candidates.Length - 1)
										{
											var digitCombinationMask = Mask.Create(digitCombination);
											var cells = CellMap.Empty;
											foreach (var digit in digitCombinationMask)
											{
												cells |= CandidatesMap[digit];
											}
											cells &= HousesMap[block] & ~cellLinks;
											if (cells.Count >= digitCombination.Length)
											{
												continue;
											}

											// The new block link is found here.
											truthsCount += digitCombination.Length;
											cellLinks |= cells;
											rcTruths[block] |= candidatesMask;
											if (linksCount == truthsCount)
											{
												// Okay for now.
												goto ExitForAdjustmentPhase2;
											}
										}
									}

								ExitForAdjustmentPhase2:;
								}

								// Adjust links phase 3.
								if (linksCount > truthsCount)
								{
									// Rebalance rank by using adjustment to block links.
									var rebalanced = false;
									for (var (house, i) = (isRow ? 18 : 9, 0); i < 3; house += 3, i++)
									{
										if (!isWorthTable[house % 9 / 3]
											|| rcTruths[HousesCells[house][0] >> HouseType.Block] != 0
											|| rcTruths[HousesCells[house][3] >> HouseType.Block] != 0
											|| rcTruths[HousesCells[house][6] >> HouseType.Block] != 0)
										{
											continue;
										}

										var cells = HousesMap[house] | HousesMap[house + 1] | HousesMap[house + 2] & cellTruths;
										rebalanced = true;

										houseDigitTruths[house] = 0;
										houseDigitTruths[house + 1] = 0;
										houseDigitTruths[house + 2] = 0;
										rcLinks[house] = 0;
										rcLinks[house + 1] = 0;
										rcLinks[house + 2] = 0;
										rcTruths[house] = 0;
										rcTruths[house + 1] = 0;
										rcTruths[house + 2] = 0;
										rcLinks[ChuteBlocks[house / 3][0]] = houseDigitLinks[ChuteBlocks[house / 3][0]];
										rcLinks[ChuteBlocks[house / 3][1]] = houseDigitLinks[ChuteBlocks[house / 3][1]];
										rcLinks[ChuteBlocks[house / 3][2]] = houseDigitLinks[ChuteBlocks[house / 3][2]];

										cellLinks &= ~(HousesMap[house] | HousesMap[house + 1] | HousesMap[house + 2]);
										cellTruths &= ~cells;
										removedHouses[ChuteBlocks[house / 3][0]] = -1;
										removedHouses[ChuteBlocks[house / 3][1]] = -1;
										removedHouses[ChuteBlocks[house / 3][2]] = -1;
										for (var j = 0; j < 3; j++)
										{
											ChooseLink(
												grid,
												patternCells,
												ref cellTruths,
												ref cellLinks,
												rcTruths,
												rcLinks,
												houseDigitTruths,
												house,
												notSolved,
												removedHouses
											);
										}
									}
									if (rebalanced)
									{
										truthsCount += cellTruths.Count;
										linksCount += cellLinks.Count;
										foreach (var mask in rcTruths)
										{
											truthsCount += PopCount((uint)mask);
										}
										foreach (var mask in rcLinks)
										{
											linksCount += PopCount((uint)mask);
										}
									}
								}
							}

							// I have run out of thoughts to rebalance rank. Now check rank.
							if (linksCount != truthsCount)
							{
								continue;
							}

							var conclusions = new List<Conclusion>();

							// Elimination phase - cell links.
							foreach (var cell in cellLinks)
							{
								var line = cell >> (isRow ? HouseType.Column : HouseType.Row);
								var block = cell >> HouseType.Block;
								foreach (var digit in
#pragma warning disable CS0675
									(Mask)(grid.GetCandidates(cell) & ~(rcTruths[block] | digitsMask | rcTruths[line])))
#pragma warning restore CS0675
								{
									conclusions.Add(new(Elimination, cell, digit));
								}
							}

							// Elimination phase - cannibalism on cell links.
							var cannibalismDigitsMaskTable = new Mask[81];
							foreach (var cell in cellLinks)
							{
								var cannibalismDigitsMask = (Mask)(grid.GetCandidates(cell) & rcLinks[cell >> HouseType.Block]);
								foreach (var digit in cannibalismDigitsMask)
								{
									conclusions.Add(new(Elimination, cell, digit));
								}
								cannibalismDigitsMaskTable[cell] |= cannibalismDigitsMask;
							}

							// Elimination phase - house-digit links.
							for (var house = 0; house < 27; house++)
							{
								if (rcLinks[house] == 0)
								{
									continue;
								}

								foreach (var cell in HousesMap[house] & EmptyCells & ~(cellTruths | patternCells))
								{
									foreach (var digit in (Mask)(grid.GetCandidates(cell) & rcLinks[house]))
									{
										conclusions.Add(new(Elimination, cell, digit));
									}
								}

								foreach (var cell in HousesMap[house] & EmptyCells & ~(cellTruths | cellLinks))
								{
									foreach (var digit in (Mask)(houseDigitTruths[house] & ~digitsMask))
									{
										conclusions.Add(new(Elimination, cell, digit));
									}
								}

								if ((HousesMap[house] & (patternCells | cellTruths) & ~cellLinks) is var rebalancedLinkCells
									&& rebalancedLinkCells.Count == PopCount((uint)rcLinks[house]))
								{
									foreach (var cell in rebalancedLinkCells)
									{
										foreach (var digit in (Mask)(grid.GetCandidates(cell) & ~houseDigitTruths[house]))
										{
											conclusions.Add(new(Elimination, cell, digit));
										}
									}
								}

								foreach (var digit in rcLinks[house])
								{
									var cannibalismCells = ((patternCellsGroupedByDigit[digit] | cellTruths) & HousesMap[house] & CandidatesMap[digit]).PeerIntersection
										& CandidatesMap[digit]
										& ~HousesMap[house];
									if (!cannibalismCells)
									{
										continue;
									}

									var cells = patternCellsGroupedByDigit[digit] | cellTruths;
									foreach (var cell in cannibalismCells)
									{
										if (cells.Contains(cell))
										{
											cannibalismDigitsMaskTable[cell] |= (Mask)(1 << digit);
										}
										conclusions.Add(new(Elimination, cell, digit));
									}
								}
							}

							foreach (var cell in patternCells)
							{
								foreach (var digit in (Mask)(
									grid.GetCandidates(cell)
										& rcLinks[cell >> (isRow ? HouseType.Column : HouseType.Row)]
										& rcLinks[cell >> HouseType.Block]
								))
								{
									conclusions.Add(new(Elimination, cell, digit));
								}
							}

							for (var house = 0; house < 27; house++)
							{
								if (rcLinks[house] == 0)
								{
									continue;
								}

								foreach (var cell in cellLinks & HousesMap[house])
								{
									foreach (var digit in (Mask)(grid.GetCandidates(cell) & rcLinks[house]))
									{
										conclusions.Add(new(Elimination, cell, digit));
									}
								}
							}

							if (conclusions.Count == 0)
							{
								continue;
							}

							var candidateOffsets = new List<CandidateViewNode>();
							var (truths, links) = (SpaceSet.Empty, SpaceSet.Empty);

							// Collect for cell truths & candidate view nodes.
							foreach (var cell in cellTruths)
							{
								truths += Space.RowColumn(cell / 9, cell % 9);
								foreach (var digit in grid.GetCandidates(cell))
								{
									candidateOffsets.Add(new(ColorIdentifier.Auxiliary3, cell * 9 + digit));
								}
							}

							// Collect for house-digit truths & candidate view nodes.
							for (var house = 0; house < 27; house++)
							{
								if (rcTruths[house] == 0)
								{
									continue;
								}

								var houseColorIdentifier = house switch
								{
									< 9 => ColorIdentifier.Auxiliary2,
									< 18 => ColorIdentifier.Normal,
									_ => ColorIdentifier.Auxiliary1
								};
								foreach (var digit in rcTruths[house])
								{
									truths += house switch
									{
										< 9 => Space.BlockDigit(house, digit),
										< 18 => Space.RowDigit(house - 9, digit),
										_ => Space.ColumnDigit(house - 18, digit)
									};
								}
								var cells = CellMap.Empty;
								foreach (var digit in rcTruths[house])
								{
									cells |= CandidatesMap[digit];
								}
								foreach (var cell in cells & HousesMap[house])
								{
									foreach (var digit in (Mask)(grid.GetCandidates(cell) & rcTruths[house]))
									{
										candidateOffsets.Add(new(houseColorIdentifier, cell * 9 + digit));
									}
								}
							}

							// Collect for cell links.
							foreach (var cell in cellLinks)
							{
								links += Space.RowColumn(cell / 9, cell % 9);
							}
							for (var house = 0; house < 27; house++)
							{
								foreach (var digit in rcLinks[house])
								{
									links += house switch
									{
										< 9 => Space.BlockDigit(house, digit),
										< 18 => Space.RowDigit(house - 9, digit),
										_ => Space.ColumnDigit(house - 18, digit)
									};
								}
							}

							// Add step to the target collection or just return if only-one mode is enabled.
							var step = new MultifishStep(
								conclusions.AsMemory(),
								[[.. candidateOffsets]],
								context.Options,
								truths,
								links
							);
							if (context.OnlyFindOne)
							{
								return step;
							}

							context.Accumulator.Add(step);
						}
					}

				NextLineTypeCase:;
				}
			}
		}
		return null;
	}

	/// <summary>
	/// To convert links in order to balance rank value, in order to make rank equal to 0.
	/// </summary>
	/// <param name="grid">The target grid.</param>
	/// <param name="patternCells">The pattern cells.</param>
	/// <param name="cellTruths">The cell truths.</param>
	/// <param name="cellLinks">The cell links.</param>
	/// <param name="rcTruths">The house-digit truths.</param>
	/// <param name="rcLinks">The house-digit links.</param>
	/// <param name="houseDigitTruths">The house-digit truths.</param>
	/// <param name="house">The house.</param>
	/// <param name="notSolved">Unsolved candidates table.</param>
	/// <param name="removedHouses">Removed houses.</param>
	private void ChooseLink(
		in Grid grid,
		in CellMap patternCells,
		ref CellMap cellTruths,
		ref CellMap cellLinks,
		Span<Mask> rcTruths,
		Span<Mask> rcLinks,
		ReadOnlySpan<Mask> houseDigitTruths,
		House house,
		ReadOnlySpan<Mask> notSolved,
		ReadOnlySpan<House> removedHouses
	)
	{
		var cells = patternCells & HousesMap[house];
		if (house < 9 && removedHouses[house] != -1)
		{
			// Previous cases on adjustment from line links to block links.
			cells &= ~HousesMap[removedHouses[house]];
		}

		var possibleTruthTripletDigitsMask = (Mask)0;
		if (house < 9)
		{
			for (var pos = 0; pos < 9; pos++)
			{
				var cell = HousesCells[house][pos];
				if (grid.GetState(cell) != CellState.Empty)
				{
					continue;
				}

				possibleTruthTripletDigitsMask |= (Mask)(
					grid.GetCandidates(cell) & (rcTruths[cell >> HouseType.Row] | rcTruths[cell >> HouseType.Column])
				);
			}
		}

		var reduction = int.MinValue;
		var addedDigitsCombination = (Mask)0;
		var addedCellLink = CellMap.Empty;
		if (cells.Count <= PopCount((uint)houseDigitTruths[house]))
		{
			// Add line truths.
			var candidatesMask = (Mask)(notSolved[house] & ~(houseDigitTruths[house] | possibleTruthTripletDigitsMask));
			var candidates = candidatesMask.AllSets;
			foreach (var candidateCombination in candidates | candidates.Length - 1)
			{
				var candidateCombinationMask = Mask.Create(candidateCombination);
				var tempCells = CellMap.Empty;
				foreach (var candidate in candidateCombination)
				{
					tempCells |= CandidatesMap[candidate];
				}
				tempCells &= HousesMap[house] & ~cells;

				if (candidateCombination.Length > reduction)
				{
					reduction = candidateCombination.Length;
					addedDigitsCombination = candidateCombinationMask;
					addedCellLink = tempCells;
				}
			}
			if (reduction > 0)
			{
				rcTruths[house] |= addedDigitsCombination;
				cellLinks |= addedCellLink | cells;
				return;
			}

			if (cells.Count < PopCount((uint)houseDigitTruths[house]))
			{
				cellLinks |= cells;
			}
		}

		var isAnyCellsAdded = false;
		if (cells.Count >= PopCount((uint)houseDigitTruths[house]))
		{
			// Add cell truths.
			var tempCells = HousesMap[house] & EmptyCells & ~cells;
			if (tempCells.Count < 2)
			{
				rcLinks[house] |= houseDigitTruths[house];
				return;
			}

			foreach (var cell in tempCells)
			{
				if ((grid.GetCandidates(cell) & ~houseDigitTruths[house]) == 0)
				{
					cellTruths += cell;
					isAnyCellsAdded = true;
				}
			}
			if (isAnyCellsAdded)
			{
				rcLinks[house] |= houseDigitTruths[house];
				return;
			}

			for (var cellSize = 2; cellSize <= tempCells.Count - 1; cellSize++)
			{
				foreach (ref readonly var cellCombination in tempCells & cellSize)
				{
					var candidates = (Mask)0;
					foreach (var cell in cellCombination)
					{
						candidates |= grid.GetCandidates(cell);
					}

					candidates &= (Mask)~houseDigitTruths[house];

					if (PopCount((uint)candidates) < cellSize)
					{
						cellTruths |= cellCombination;
						rcLinks[house] |= (Mask)(candidates | houseDigitTruths[house]);
						return;
					}
				}
			}

			if (cells.Count > PopCount((uint)houseDigitTruths[house]))
			{
				rcLinks[house] |= houseDigitTruths[house];
			}
		}

		if (cells.Count == PopCount((uint)houseDigitTruths[house]))
		{
			rcLinks[house] |= houseDigitTruths[house];
		}
	}
}
