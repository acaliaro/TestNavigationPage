using System;

using Xamarin.Forms;
using Acr.UserDialogs;

namespace TestNavigationPage
{
	public class App : Application
	{
		public static NavigationPage MyNavigationPage = null;

		public App ()
		{

			//App.MyNavigationPage = new NavigationPage(new PageInNavigation (0, false));
			App.MyNavigationPage = new NavigationPage(new PageLogin());
			App.MyNavigationPage.Pushed += (object sender1, NavigationEventArgs e1) => UserDialogs.Instance.Toast (e1.Page.Title + " pushed", new TimeSpan (0, 0, 3));
			App.MyNavigationPage.Popped += (object sender1, NavigationEventArgs e1) => UserDialogs.Instance.Toast (e1.Page.Title + " popped", new TimeSpan (0, 0, 3));
			App.MyNavigationPage.PoppedToRoot += (object sender1, NavigationEventArgs e1) => UserDialogs.Instance.Toast (e1.Page.Title + " popped to root", new TimeSpan (0, 0, 3));
			//Application.Current.MainPage = App.MyNavigationPage;

			// The root page of your application
			MainPage = App.MyNavigationPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

