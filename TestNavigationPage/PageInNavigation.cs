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

			StackLayout sl = new StackLayout{Children = {l, bNext, bPrev, bJumpToRoot, bNextAsModal, bLogin},  Padding = new Thickness(20,20,20,20) };
			Content = sl;
		}
			
	}
}

