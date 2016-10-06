using System;
using System.Collections.Generic;
using Core.Models;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
	public partial class ContactView : ContentPage
	{
		private ContactViewModel _viewModel;
		public ContactView()
		{
			InitializeComponent();

			_viewModel = new ContactViewModel();
			BindingContext = _viewModel;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewModel.LoadDataCommand.Execute(null);
		}

		public void OnTapped(object sender, ItemTappedEventArgs args)
		{
			System.Diagnostics.Debug.WriteLine("TAPPED!!");
			ContactModel contactModel = (ContactModel)args.Item;
			_viewModel.GotoNewDetailCommand.Execute(contactModel.Id);
		}
	}
}
