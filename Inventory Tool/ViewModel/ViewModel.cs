using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Inventory_Tool
{
	public class ViewModel : ViewModelBase
	{
		private InventoryItem _item;
		private string _inputName;
		private ObservableCollection<InventoryItem> _inventoryItems;
		private ICommand _addItem;
		private ICommand _removeOne;
		

		public InventoryItem Item
		{
			get 
			{
				return _item;
			}
			set
			{
				_item = value;
				NotifyPropertyChanged(nameof(Item));
			}
		}

		public InventoryItem SelectedItem { get; set; }
		
		public string InputName
		{
			get { return _inputName; }
			set 
			{
				if (_inputName != value)
				{
					_inputName = value;
					NotifyPropertyChanged(nameof(InputName));
				}
			}
		}

		public ObservableCollection<InventoryItem> InventoryItems
		{
			get
			{
				return _inventoryItems;
			}
			set
			{
				_inventoryItems = value;
				NotifyPropertyChanged(nameof(InventoryItems));
			}
		}

		/// <summary>
		/// The addButton will call the AddItemToList method 
		/// </summary>
		public ICommand AddItem
		{
			get
			{
				if (_addItem == null)
				{
					_addItem = new RelayCommand(ParamArrayAttribute => this.AddItemToList(), null);
				}
				return _addItem;
			}
		}

		/// <summary>
		/// The removeButton will call the RemoveOneFromList method
		/// </summary>
		public ICommand RemoveOne
		{
			get 
			{
				if (_removeOne == null)
				{
					_removeOne = new RelayCommand(ParamArrayAttribute => this.RemoveOneFromList(), null);
				}
				return _removeOne;
			}
		}

		public ViewModel()
		{
			Item = new InventoryItem();
			InventoryItems = new ObservableCollection<InventoryItem>();
		}

		/// <summary>
		/// We will look at the InventoryItems if the current text in the textbox is in the ListView
		/// we just need to add to the count, if not we need to add to the InventoryItems
		/// </summary>
		private void AddItemToList()
		{
			
			if (InventoryItems.Any(p => p.Name == InputName))
			{
				InventoryItems.First(x => x.Name == InputName).ItemCount++;
			}
			else
			{
				InventoryItems.Add(new InventoryItem() { Name = InputName, ItemCount = 1 });
			}
			
			Item = new InventoryItem();
		}

		/// <summary>
		/// Find the selected item in InventoryItems and subtract 1 from the count
		/// If the count becomes 0 remove the item from InventoryItems
		/// </summary>
		private void RemoveOneFromList()
		{
			if (SelectedItem == null)
			{
				MessageBox.Show("Please Select an Item to remove.");
				return;
			}
			InventoryItem item = InventoryItems.First(x => x.Name == SelectedItem.Name);
			item.ItemCount--;

			if (item.ItemCount == 0)
			{
				InventoryItems.Remove(item);
			}
		}
	}
}
