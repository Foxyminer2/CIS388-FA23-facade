using System;

namespace facade;

public partial class MainPage: ContentPage
{
	int count = 0;


    public Uri Navigate { get; private set; }
    public MainPage()
	{
		InitializeComponent();

		BindingContext = new MainPageViewModel();
	}

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {

		//await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={DidWin}");
    }


    



}


