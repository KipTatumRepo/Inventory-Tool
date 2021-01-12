using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Tool
{
	/// <summary>
	/// Base for view models to inherit.  I know this application only calls for 1 View Model, but I feel this is good practice
	/// because we can inherit this class rather than implementing NotifyPropertyChanged in each View Model in more complex applications
	/// </summary>
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
