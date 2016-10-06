using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Core.Fake;
using Core.Helpers;
using Core.Models;
using Xamarin.Forms;

namespace Core.ViewModels
{
	public class ContactDetailViewModel : BaseViewModel
	{
		public ICommand SaveCommand { get; private set; }

		private ContactModel _data;
		public ContactModel Data
		{
			get { return _data; }
			set { _data = value; OnPropertyChanged(); }
		}

		public ContactDetailViewModel(string id = null)
		{
			SaveCommand = new Command(async () => await Save());

			if (string.IsNullOrEmpty(id))
			{
				Data = new ContactModel();
			}
			else
			{
				Data = ContactFake.GetById(id);
			}
		}

		private async Task Save()
		{
			if (   string.IsNullOrEmpty(Data.Name)
			    || string.IsNullOrEmpty(Data.Profession)
			    || string.IsNullOrEmpty(Data.City)
			   ) {
				await MessageHelper.ShowMessage("Aconteceu um erro", "Você precisa preencher todos os campos!", "Ok");
				return;
			}

			if (string.IsNullOrEmpty(Data.Id))
			{
				ContactFake.Save(Data);
			}
			else
			{
				ContactFake.Update(Data);
			}

			await NavigationHelper.GoBack();
		}
	}
}
