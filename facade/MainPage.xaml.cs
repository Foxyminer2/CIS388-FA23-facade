using System;

namespace facade;

public partial class MainPage : ContentPage
{
	int count = 0;

	public bool DidWin { get; set; } = false;

	public MainPage()
	{
		InitializeComponent();
	}

	//private void OnCounterClicked(object sender, EventArgs e)
	//{
		
	//}

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {

		await Shell.Current.GoToAsync("GameOverPage");
    }
}


