namespace SudokuStudio.Interaction.Conversions;

/// <summary>
/// Provides with conversion methods used by XAML designer, about <see cref="ColorIdentifier"/> instances.
/// </summary>
/// <seealso cref="ColorIdentifier"/>
internal static class IdentifierConversion
{
	public static Color GetColor(ColorIdentifier id)
	{
		var uiPref = Application.CurrentApp.Preference.UIPreferences;
		return id switch
		{
			(_, (byte a, byte r, byte g, byte b)) => Color.FromArgb(a, r, g, b),
			(_, int idValue) when getValueById(idValue, out var color) => color,
			(_, ColorIdentifierAlias namedKind) => namedKind switch
			{
				ColorIdentifierAlias.Normal => uiPref.NormalColor,
				ColorIdentifierAlias.Assignment => uiPref.AssignmentColor,
				ColorIdentifierAlias.OverlappedAssignment => uiPref.OverlappedAssignmentColor,
				ColorIdentifierAlias.Elimination => uiPref.EliminationColor,
				ColorIdentifierAlias.Cannibalism => uiPref.CannibalismColor,
				ColorIdentifierAlias.Exofin => uiPref.ExofinColor,
				ColorIdentifierAlias.Endofin => uiPref.EndofinColor,
				ColorIdentifierAlias.Link => uiPref.ChainColor,
				ColorIdentifierAlias.Auxiliary1 => uiPref.AuxiliaryColors[0],
				ColorIdentifierAlias.Auxiliary2 => uiPref.AuxiliaryColors[1],
				ColorIdentifierAlias.Auxiliary3 => uiPref.AuxiliaryColors[2],
				ColorIdentifierAlias.AlmostLockedSet1 => uiPref.AlmostLockedSetsColors[0],
				ColorIdentifierAlias.AlmostLockedSet2 => uiPref.AlmostLockedSetsColors[1],
				ColorIdentifierAlias.AlmostLockedSet3 => uiPref.AlmostLockedSetsColors[2],
				ColorIdentifierAlias.AlmostLockedSet4 => uiPref.AlmostLockedSetsColors[3],
				ColorIdentifierAlias.AlmostLockedSet5 => uiPref.AlmostLockedSetsColors[4],
				ColorIdentifierAlias.Rectangle1 => uiPref.RectangleColors[0],
				ColorIdentifierAlias.Rectangle2 => uiPref.RectangleColors[1],
				ColorIdentifierAlias.Rectangle3 => uiPref.RectangleColors[2],
				_ => throw new InvalidOperationException(SR.ExceptionMessage("SuchColorCannotBeFound"))
			},
			_ => throw new InvalidOperationException(SR.ExceptionMessage("SuchInstanceIsInvalid"))
		};


		bool getValueById(int idValue, out Color result)
		{
			var palette = uiPref.UserDefinedColorPalette;
			return (result = palette.Count > idValue ? palette[idValue] : Colors.Transparent) != Colors.Transparent;
		}
	}
}
