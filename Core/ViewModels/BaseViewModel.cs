using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Core.Helpers;

namespace Core.ViewModels
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			if (propertyName == null)
				return;

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private NavigationHelper _navigationHelper;
		protected NavigationHelper NavigationHelper
		{
			get { return _navigationHelper ?? (_navigationHelper = new NavigationHelper()); }
		}

		private MessageHelper _messageHelper;
		public MessageHelper MessageHelper
		{
			get { return _messageHelper ?? (_messageHelper = new MessageHelper()); }
		}
	}
}
