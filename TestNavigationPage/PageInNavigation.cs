using System;
using Xamarin.Forms;

namespace TestNavigationPage
{
	public class PageInNavigation : ContentPage
	{
		
		public PageInNavigation (int counter, bool isModal)
		{

			this.Title = "Page " + counter;

			Label l = new Label{ Text = isModal ? "MODAL " + this.Title : this.Title };
			l.BindingContext = isModal;
			l.SetBinding (VisualElement.IsVisibleProperty, ".");

			Button bNext = new Button{ Text = "Next (Push)" };
			bNext.Clicked += async (object sender, EventArgs e) => {
				try {
					await Navigation.PushAsync (new PageInNavigation(Navigation.NavigationStack.Count, false));
				}catch(Exception ex){
					await DisplayAlert ("Error", ex.Message, "Ok");
				}
			};
			bNext.BindingContext = !isModal;
			//bNext.SetBinding (VisualElement.IsVisibleProperty,".");

			Button bPrev = new Button{ Text = "Prev (Pop)"};
			bPrev.Clicked += async (object sender, EventArgs e) => {
				try{
					if(isModal)
						await Navigation.PopModalAsync ();
					else
						await Navigation.PopAsync ();
				}catch(Exception ex){
					await DisplayAlert ("Error", ex.Message, "Ok");
				}
			};
			Button bJumpToRoot = new Button{Text = "Jump to root (PopToRoot)" };
			bJumpToRoot.Clicked += async (object sender, EventArgs e) => {
				try{
					await Navigation.PopToRootAsync ();
				}catch(Exception ex){
					await DisplayAlert ("Error", ex.Message, "Ok");
				}
			};
			bJumpToRoot.BindingContext = !isModal;
			bJumpToRoot.SetBinding (VisualElement.IsVisibleProperty,".");

			Button bNextAsModal = new Button{ Text = "Next modal (PushModal)"};
			bNextAsModal.Clicked += async (object sender, EventArgs e) => {
				try {
					await Navigation.PushModalAsync (new PageInNavigation(Navigation.ModalStack.Count, true));
				}catch(Exception ex){
					await DisplayAlert ("Error", ex.Message, "Ok");
				}
			};
			Button bLogin = new Button{Text = "Close nav and open Login" };
			bLogin.Clicked += async (object sender, EventArgs e) => {
				try {
					Application.Current.MainPage = new PageLogin();
				}catch(Exception ex){
					await DisplayAlert ("Error", ex.Message, "Ok");
				}
			};

			// Set nav bar
			Label lHasNavBar = new Label { Text = "Has nav bar",
			VerticalTextAlignment = TextAlignment.End};
			Switch switchHasNavBar = new Switch { IsToggled = true, HorizontalOptions = LayoutOptions.StartAndExpand};
			switchHasNavBar.Toggled += (sender, e) => { 
				NavigationPage.SetHasNavigationBar(this, e.Value);
			};
			StackLayout slHasNavBar = new StackLayout { 
				Orientation = StackOrientation.Horizontal,
				Children = {
					lHasNavBar,
					switchHasNavBar
				}
			};

			// Set back button
			Label lHasBackButton = new Label
			{
				Text = "Has back button",
				VerticalTextAlignment = TextAlignment.End
			};
			Switch switchHasBackButton = new Switch { IsToggled = true, HorizontalOptions = LayoutOptions.StartAndExpand };
			switchHasBackButton.Toggled += (sender, e) => { 
				NavigationPage.SetHasBackButton(this, e.Value);
			};
			StackLayout slHasBackButton = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Children = {
					lHasBackButton,
					switchHasBackButton
				}
			};



			StackLayout sl = new StackLayout{
				Children = {
					l, 
					bNext,
					bPrev,
					bJumpToRoot,
					bNextAsModal,
					bLogin,
					slHasNavBar,
					slHasBackButton},  
				Padding = new Thickness(20,20,20,20) };
			
			Content = sl;
		}
			
	}
}

