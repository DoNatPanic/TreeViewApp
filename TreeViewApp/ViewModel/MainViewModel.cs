using System;
using System.Collections.ObjectModel;
using System.Windows;
using TreeViewApp.Core;

namespace TreeViewApp.ViewModel
{
	public enum UnitColors
	{
		noColor,
		green,
		black
	}

	public class Item : ObservableObject
	{
		public string ItemName { get; set; }
		public UnitColors ItemColor { get; set; }
	}

	public class Category : ObservableObject
	{
		public string CategoryName { get; set; }

		public UnitColors CategoryColor { get; set; }

		public ObservableCollection<Item> Items { get; set; }

		public Category()
		{
			Items = new ObservableCollection<Item>();
		}
	}

	public class MainViewModel : ObservableObject
	{
		private string _filterField;
		private int _loadBtnClickCount;

		public string FilterField
		{
			get => _filterField;
			set
			{
				_filterField = value;
				if (_filterField != "Filter" && _filterField != "" && _loadBtnClickCount != 0)
				{
					Search(_filterField);
				}
				else if (_loadBtnClickCount != 0)
				{
					CategoriesFront.Clear();
					foreach (var t in CategoriesBack)
					{
						CategoriesFront.Add(t);
					}
				}
				OnPropertyChanged();
			}
		}
		public ObservableCollection<Category> CategoriesBack { get; set; }
		public ObservableCollection<Category> CategoriesFront { get; set; }
		public RelayCommand LoadButtonCommand { get; set; }

		public MainViewModel()
		{
			FilterField = "Filter";
			CategoriesBack = new ObservableCollection<Category>();
			CategoriesFront = new ObservableCollection<Category>();

			LoadButtonCommand = new RelayCommand(obj =>
			{
				ProduceCategories();
			});
		}

		private void Search(string field)
		{
			int index = 0;
			bool isItemIncluded;
			CategoriesFront.Clear();
			if (CategoriesBack == null)
				return;
			foreach (var category in CategoriesBack)
			{
				if (category.CategoryName.Contains(field))
				{
					var items = new ObservableCollection<Item>();
					foreach (var s in category.Items)
					{
						var color = UnitColors.black;
						if (s.ItemName.Contains(field))
						{
							color = UnitColors.green;
						}
						items.Add(new Item() { ItemName = s.ItemName, ItemColor = color });
					}
					CategoriesFront.Add(new Category() {
						CategoryName = category.CategoryName, 
						CategoryColor = UnitColors.green, 
						Items = items 
					});

					index++;
				}
				else
				{
					isItemIncluded = false;
					foreach (var s in category.Items)
					{
						if (s.ItemName.Contains(field))
						{
							if (!isItemIncluded)
							{
								CategoriesFront.Add(new Category() {
									CategoryName = category.CategoryName,
									CategoryColor = UnitColors.black,
									Items = new ObservableCollection<Item>() { 
										new Item() { 
											ItemName = s.ItemName, 
											ItemColor = UnitColors.green 
										} 
									}
								});
								index++;
							}
							else
							{
								var item = new Item() { ItemName = s.ItemName, ItemColor = UnitColors.green };
								CategoriesFront[index].Items.Add(item);
							}
						}
					}
				}
			}
		}

		private void ProduceCategories()
		{
			_loadBtnClickCount++;
			var count_rnd = new Random();
			for (int i = 0; i < 25 * _loadBtnClickCount; i++)
			{
				var items = new ObservableCollection<Item>();
				var count = count_rnd.Next(1, 10);
				var items_rnd = new Random();
				for (int j = 0; j < count; j++)
				{
					var itemNum = items_rnd.Next(1, 30);
					items.Add(new Item() { ItemName = $"Item{itemNum}", ItemColor = UnitColors.noColor });
				}
				CategoriesBack.Add(new Category() {
					CategoryName = $"Category{i + 1}", 
					CategoryColor = UnitColors.noColor, 
					Items = items 
				});
			}

			CategoriesFront.Clear();
			foreach (var t in CategoriesBack)
			{
				CategoriesFront.Add(t);
			}
		}
	}
}
