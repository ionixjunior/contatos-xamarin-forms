using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Core.Fake;
using Core.Helpers;
using Core.Models;
using Core.Services;
using Core.Views;
using Xamarin.Forms;

namespace Core.ViewModels
{
	public class ContactViewModel : BaseViewModel
	{
		public ICommand GotoDetailCommand { get; private set; }
		public ICommand GotoNewDetailCommand { get; private set; }
		public ICommand LoadDataCommand { get; private set; }
		public ICommand SearchCommand { get; private set; }

		private ContactService _contactService;
		public ContactService ContactService
		{
			get { return _contactService ?? (_contactService = new ContactService()); }
		}

		private string _searchText;
		public string SearchText
		{
			get { return _searchText; }
			set { _searchText = value; OnPropertyChanged(); }
		}

		private ObservableCollection<ContactModel> _data;
		public ObservableCollection<ContactModel> Data
		{
			get { return _data; }
			set { _data = value; OnPropertyChanged(); }
		}

		public ContactViewModel()
		{
			GotoDetailCommand = new Command(async () => await GotoDetail());
			GotoNewDetailCommand = new Command<string>(async (id) => await GotoNewDetail(id));
			LoadDataCommand = new Command(LoadData);
			SearchCommand = new Command(Search);

			SearchText = string.Empty;
		}

		private void LoadData()
		{
			Data = new ObservableCollection<ContactModel>();

			//Consumo da API
			//await ContactService.Get()

			foreach (ContactModel contact in ContactFake.GetAll())
			{
				Data.Add(contact);
			}
		}

		private void Search()
		{
			Data.Clear();

			foreach (ContactModel contact in ContactFake.Search(SearchText))
			{
				Data.Add(contact);
			}
		}

		private async Task GotoDetail()
		{
			await NavigationHelper.GotoDetail();
		}

		private async Task GotoNewDetail(string id)
		{
			await NavigationHelper.GotoNewDetail(id);
		}
	}
}
