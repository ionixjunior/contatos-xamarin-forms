using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Core.Helpers
{
	public class MessageHelper
	{
		public async Task ShowMessage(string title, string message, string button)
		{
			await Application.Current.MainPage.DisplayAlert(title, message, button);
		}
	}
}
