namespace facade;

[QueryProperty("DidWin", "DidWin")]
[QueryProperty("SecretColor", "SecretColor")]
public partial class GameOverPage : ContentPage
{
	private string secretColor;
	public string SecretColor { get => secretColor; set { secretColor = value; ColorLabel.Text = value; } }

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


	public GameOverPage()
	{
		InitializeComponent();
	}

	async void Button_Clicked_1(System.Object sender, System.EventArgs e)
	{
		await Shell.Current.GoToAsync($"..");
	}

}
