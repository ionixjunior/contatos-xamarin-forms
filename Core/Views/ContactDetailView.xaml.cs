using System;
using System.Collections.Generic;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
	public partial class ContactDetailView : ContentPage
	{
		public ContactDetailView(string id = null)
		{
			InitializeComponent();
			BindingContext = new ContactDetailViewModel(id);
		}
	}
}
