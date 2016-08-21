using System;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace TestNavigationPage
{
	public class PageLogin : ContentPage
	{
		public PageLogin ()
		{
			Label l = new Label{ Text = "This is the first page OUTSIDE navigation.. as it was a Login page"}; 
			Button b = new Button{ Text = "Press to start a Navigation" };
			b.Clicked += async (object sender, EventArgs e) => {
				/*
				App.MyNavigationPage = new NavigationPage(new PageInNavigation (0, false));
				App.MyNavigationPage.Pushed += async (object sender1, NavigationEventArgs e1) => UserDialogs.Instance.Toast (e1.Page.Title + " pushed", new TimeSpan (0, 0, 3));
				App.MyNavigationPage.Popped += async (object sender1, NavigationEventArgs e1) => UserDialogs.Instance.Toast (e1.Page.Title + " popped", new TimeSpan (0, 0, 3));
				App.MyNavigationPage.PoppedToRoot += async (object sender1, NavigationEventArgs e1) => UserDialogs.Instance.Toast (e1.Page.Title + " popped to root", new TimeSpan (0, 0, 3));
				Application.Current.MainPage = App.MyNavigationPage;
*/
				Navigation.PushAsync (new PageInNavigation (0, false));
				Navigation.RemovePage (Navigation.NavigationStack[0]);
			};
			StackLayout sl = new StackLayout {Children = {l, b}, Padding = new Thickness(20,20,20,20) };
			Content = sl;



		
		}
	}
}

