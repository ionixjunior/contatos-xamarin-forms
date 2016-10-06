using System;
using System.Threading.Tasks;
using Core.Views;
using Xamarin.Forms;

namespace Core.Helpers
{
	public class NavigationHelper
	{
		public async Task GotoDetail()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new ContactDetailView());
		}

		public async Task GotoNewDetail(string id)
		{
			await Application.Current.MainPage.Navigation.PushAsync(new ContactDetailView(id));
		}

		public async Task GoBack()
		{
			await Application.Current.MainPage.Navigation.PopAsync();
		}
	}
}
