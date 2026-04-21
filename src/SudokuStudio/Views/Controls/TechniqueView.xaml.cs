namespace SudokuStudio.Views.Controls;

/// <summary>
/// Represents for a technique view.
/// </summary>
public sealed partial class TechniqueView : UserControl
{
	private static readonly TechniqueSet SelectedTechniquesDefaultValue = TechniqueSet.None;

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="HorizontalSpacing"/>.
	/// </summary>
	/// <seealso cref="HorizontalSpacing"/>
	public static readonly DependencyProperty HorizontalSpacingProperty =
		DependencyProperty.Register(nameof(HorizontalSpacing), typeof(double), typeof(TechniqueView), new PropertyMetadata(default(double)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="VerticalSpacing"/>.
	/// </summary>
	/// <seealso cref="VerticalSpacing"/>
	public static readonly DependencyProperty VerticalSpacingProperty =
		DependencyProperty.Register(nameof(VerticalSpacing), typeof(double), typeof(TechniqueView), new PropertyMetadata(default(double)));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="ShowMode"/>.
	/// </summary>
	/// <seealso cref="ShowMode"/>
	public static readonly DependencyProperty ShowModeProperty =
		DependencyProperty.Register(nameof(ShowMode), typeof(TechniqueViewShowMode), typeof(TechniqueView), new PropertyMetadata((TechniqueViewShowMode)3, ShowModePropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SelectionMode"/>.
	/// </summary>
	/// <seealso cref="SelectionMode"/>
	public static readonly DependencyProperty SelectionModeProperty =
		DependencyProperty.Register(nameof(SelectionMode), typeof(TechniqueViewSelectionMode), typeof(TechniqueView), new PropertyMetadata((TechniqueViewSelectionMode)1, SelectionModePropertyCallback));

	/// <summary>
	/// Defines a dependency property that binds with property <see cref="SelectedTechniques"/>.
	/// </summary>
	/// <seealso cref="SelectedTechniques"/>
	public static readonly DependencyProperty SelectedTechniquesProperty =
		DependencyProperty.Register(nameof(SelectedTechniques), typeof(TechniqueSet), typeof(TechniqueView), new PropertyMetadata(SelectedTechniquesDefaultValue, SelectedTechniquesPropertyCallback));


	/// <summary>
	/// Indicates the internal token views.
	/// </summary>
	private readonly List<TokenView> _tokenViews = [];

	/// <summary>
	/// Represents a collection that stores all technique groups used by list view in UI.
	/// </summary>
	private readonly ObservableCollection<TechniqueViewGroupBindableSource> _itemsSource = [];


	/// <summary>
	/// Initializes a <see cref="TechniqueView"/> instance.
	/// </summary>
	public TechniqueView()
	{
		InitializeComponent();
		UpdateShowMode(ShowMode);
	}


	/// <summary>
	/// The entry that can traverse for all tokens.
	/// </summary>
	private Dictionary<Technique, TokenItem> TokenItems
		=> [with([
			..
			from view in _tokenViews
			from item in view.ItemsPanelRoot.Children
			let tokenItem = item as TokenItem
			where tokenItem is not null
			let content = (TechniqueViewBindableSource)tokenItem.Content
			select new KeyValuePair<Technique, TokenItem>(content.TechniqueField, tokenItem)
		])];


	/// <summary>
	/// Indicates the horizontal spacing.
	/// </summary>
	public double HorizontalSpacing
	{
		get => (double)GetValue(HorizontalSpacingProperty);

		set => SetValue(HorizontalSpacingProperty, value);
	}

	/// <summary>
	/// Indicates the vertical spacing.
	/// </summary>
	public double VerticalSpacing
	{
		get => (double)GetValue(VerticalSpacingProperty);

		set => SetValue(VerticalSpacingProperty, value);
	}

	/// <summary>
	/// Indicates which techniques whose conclusion types are specified will be shown.
	/// </summary>
	public TechniqueViewShowMode ShowMode
	{
		get => (TechniqueViewShowMode)GetValue(ShowModeProperty);

		set => SetValue(ShowModeProperty, value);
	}

	/// <summary>
	/// Indicates the selection mode.
	/// </summary>
	public TechniqueViewSelectionMode SelectionMode
	{
		get => (TechniqueViewSelectionMode)GetValue(SelectionModeProperty);

		set => SetValue(SelectionModeProperty, value);
	}

	/// <summary>
	/// Indicates the final selected techniques.
	/// </summary>
	public TechniqueSet SelectedTechniques
	{
		get => (TechniqueSet)GetValue(SelectedTechniquesProperty);

		set => SetValue(SelectedTechniquesProperty, value);
	}


	/// <summary>
	/// Indicates the event triggered when selected techniques property is changed.
	/// </summary>
	public event EventHandler<TechniqueView, TechniqueViewSelectedTechniquesChangedEventArgs>? SelectedTechniquesChanged;

	/// <summary>
	/// Indicates the event triggered when the current selected technique is changed.
	/// </summary>
	public event EventHandler<TechniqueView, TechniqueViewCurrentSelectedTechniqueChangedEventArgs>? CurrentSelectedTechniqueChanged;


	/// <summary>
	/// Try to update all token items via selection state.
	/// </summary>
	private void UpdateSelection(TechniqueSet set)
	{
		foreach (var (technique, item) in TokenItems)
		{
			item.IsSelected = set.Contains(technique);
		}
	}

	/// <summary>
	/// Try to update visibility of technique bound controls.
	/// </summary>
	/// <param name="mode">The show mode.</param>
	private void UpdateShowMode(TechniqueViewShowMode mode)
	{
		foreach (var (technique, item) in TokenItems)
		{
			item.Visibility = GetVisibility(technique);
		}
	}

	/// <summary>
	/// Gets the visibility.
	/// </summary>
	/// <param name="technique">The technique.</param>
	/// <returns>The <see cref="Visibility"/> result.</returns>
	private Visibility GetVisibility(Technique technique)
		=> ShowMode switch
		{
			TechniqueViewShowMode.None => Visibility.Collapsed,
			TechniqueViewShowMode.OnlyAssignments => technique.IsAssignment ? Visibility.Visible : Visibility.Collapsed,
			TechniqueViewShowMode.OnlyEliminations => technique.IsAssignment ? Visibility.Collapsed : Visibility.Visible,
			_ => Visibility.Visible
		};


	[Callback]
	private static void ShowModePropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if ((d, e) is (TechniqueView view, { NewValue: TechniqueViewShowMode mode }))
		{
			view.UpdateShowMode(mode);
		}
	}

	[Callback]
	private static void SelectedTechniquesPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if ((d, e) is (TechniqueView view, { NewValue: TechniqueSet set }))
		{
			view.UpdateSelection(set);
		}
	}

	[Callback]
	private static void SelectionModePropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if ((d, e) is (TechniqueView view, { NewValue: TechniqueViewSelectionMode mode }))
		{
			foreach (var tokenView in view._tokenViews)
			{
				tokenView.SelectionMode = mode switch
				{
					TechniqueViewSelectionMode.None => ListViewSelectionMode.None,
					TechniqueViewSelectionMode.Single => ListViewSelectionMode.Single,
					TechniqueViewSelectionMode.Multiple => ListViewSelectionMode.Multiple
				};
			}

			foreach (var item in view._itemsSource)
			{
				item.ShowSelectAllButton = mode == TechniqueViewSelectionMode.Multiple;
			}
		}
	}


	private void TokenView_Loaded(object sender, RoutedEventArgs e)
	{
		var p = (TokenView)sender;
		p.SelectionMode = SelectionMode switch
		{
			TechniqueViewSelectionMode.None => ListViewSelectionMode.None,
			TechniqueViewSelectionMode.Single => ListViewSelectionMode.Single,
			TechniqueViewSelectionMode.Multiple => ListViewSelectionMode.Multiple
		};

		_tokenViews.Add(p);

		if (_tokenViews.Count == _itemsSource.Count)
		{
			UpdateSelection(SelectedTechniques);
			UpdateShowMode(ShowMode);
		}
	}

	private void TokenView_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (e is
			{
				OriginalSource: TokenView { ItemsPanelRoot.Children: var children } p,
				ClickedItem: TechniqueViewBindableSource { TechniqueField: var field }
			}
			&& children.OfType<TokenItem>().FirstOrDefault(s => lambda(s, field)) is { IsSelected: var isSelected } child)
		{
			var add = SelectedTechniques.Add;
			var remove = SelectedTechniques.Remove;
			(isSelected ? remove : add)(field);

			CurrentSelectedTechniqueChanged?.Invoke(this, new(field, isSelected));
			SelectedTechniquesChanged?.Invoke(this, new(SelectedTechniques));

			if (SelectionMode == TechniqueViewSelectionMode.Single)
			{
				// Special case: If the selection mode is "Single", we should remove all the other enabled token items.
				foreach (var q in _tokenViews)
				{
					if (!ReferenceEquals(p, q))
					{
						foreach (var element in q.ItemsPanelRoot.Children.OfType<TokenItem>())
						{
							if (element.IsSelected)
							{
								element.IsSelected = false;
							}
						}
					}
				}
			}
		}


		static bool lambda(TokenItem s, Technique field) => s.Content is TechniqueViewBindableSource { TechniqueField: var f } && f == field;
	}

	private async void UserControl_LoadedAsync(object sender, RoutedEventArgs e)
	{
		await 500.ms;
		foreach (var source in
			from technique in Technique.AllValues.ToArray()[1..]
			where !technique.Features.HasFlag(TechniqueFeatures.NotImplemented)
			select new TechniqueViewBindableSource(technique) into item
			group item by item.ContainingGroup into itemGroup
			orderby itemGroup.Key
			select new TechniqueViewGroupBindableSource
			{
				Group = itemGroup.Key,
				Items = [.. itemGroup],
				ShowSelectAllButton = SelectionMode == TechniqueViewSelectionMode.Multiple
			})
		{
			_itemsSource.Add(source);
			await 100.ms;
		}
	}

	private void SelectAllButton_Click(object sender, RoutedEventArgs e)
	{
		if (sender is not Button { Tag: TechniqueViewGroupBindableSource { Items: var items } })
		{
			return;
		}

		var originalTechniques = SelectedTechniques;
		foreach (var item in items)
		{
			originalTechniques.Add(item.TechniqueField);
		}

		SelectedTechniques = null!;
		SelectedTechniques = originalTechniques;

		SelectedTechniquesChanged?.Invoke(this, new(SelectedTechniques));
	}

	private void UnselectAllButton_Click(object sender, RoutedEventArgs e)
	{
		if (sender is not Button { Tag: TechniqueViewGroupBindableSource { Items: var items } })
		{
			return;
		}

		var originalTechniques = SelectedTechniques;
		foreach (var item in items)
		{
			originalTechniques.Remove(item.TechniqueField);
		}

		SelectedTechniques = null!;
		SelectedTechniques = originalTechniques;

		SelectedTechniquesChanged?.Invoke(this, new(SelectedTechniques));
	}
}
