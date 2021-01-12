using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Tool
{
	/// <summary>
	/// Class for InventoryItem
	/// </summary>
	public class InventoryItem : ViewModelBase
	{
		private string _name;
		private int _itemCount;

		//Name of the InventoryItem
		public string Name 
		{
			get { return _name; }
			set
			{
				if (_name != value)
				{
					_name = value;
					NotifyPropertyChanged(nameof(Name));
				}
			} 
		}

		//Count of the InventoryItem
		public int ItemCount 
		{
			get 
			{ 
				return _itemCount; 
			}
			set
			{
				_itemCount = value;
				NotifyPropertyChanged(nameof(ItemCount));
			}
		}
	}
}
