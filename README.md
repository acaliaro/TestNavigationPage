# TestNavigationPage
This little demo try to explain how NavigationPage works in Xamarin Form (or better, what I have understand about NavigationPage in Xamarin Forms).
It use a Static NavigationPage defined in App.cs so we can use some Events that are rised when a Page is Pushed or Popped in the stack. 
Then, using NavigationStack or ModalStack, we have a counter about Pages currently present in the Stack.

We can use:
- Push
- Pop
- PushModal
- PopToRoot

I have understand that, when I open a Modal Page with a PushModal, I can't then open another NoModal Page with a Push method...
