namespace facade;

[QueryProperty("DidWin", "DidWin")]
public partial class GameOverPage : ContentPage
{
	private bool didWin;
	public bool DidWin
	{
		get => didWin;
		set
		{
			didWin = value;
			if (didWin)
			{
				ResultLabel.Text = "You Won!";

			}
			else
			{
				ResultLabel.Text = "You Lost!";
			}
		}
	}

	async void Button_Clicked(System.Object sender, System.EventArgs e)
	{

		await Shell.Current.GoToAsync($"{nameof(MainPage)}");
	}

	//private string result;
	//public string Result
	//{
	//	get => result;
	//	set
	//	{
	//		result = value;
	//		ResultLabel.Text = "You " + result;
	//	}
	//}

	public GameOverPage()
	{
		InitializeComponent();
	}

	async void Button_Clicked_1(System.Object sender, System.EventArgs e)
	{
		await Shell.Current.GoToAsync($"..");
	}

}
