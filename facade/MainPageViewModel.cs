using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace facade
{
	public partial class MainPageViewModel: ObservableObject 
	{
        public bool DidWin { get; set; } = true;

        [ObservableProperty]
		private ColorGuess secretColor;

        [ObservableProperty]
        private ColorGuess endResult;

        [ObservableProperty]
		private string currentGuess;

        [ObservableProperty]
        private string hexColor;

        [ObservableProperty]
        private string end;

       

        public ObservableCollection<ColorGuess> Guesses { get; set; }
        

        //public string SecretColor { get; set; }

        public MainPageViewModel()
		{
            hexColor = "";
            currentGuess = "";

            Random rnd = new Random();

            String str = "ABCDEF";
            int Size = 6;

            for (int i = 0; i < Size; i++)
            {

                // Selecting a index randomly
                int x = rnd.Next(str.Length);

                // Appending the character at the 
                // index to the random alphanumeric string.
                hexColor = hexColor + str[x];
            }

            secretColor = new ColorGuess(hexColor);

            SecretColor = secretColor;

            Guesses = new ObservableCollection<ColorGuess>();

        }

        [RelayCommand]
		void AddLetter(string letter)
		{
			if( CurrentGuess.Length < 6)
			{
				CurrentGuess += letter;
			}
		}

        [RelayCommand]
        void BackSpace()
        {
            CurrentGuess = CurrentGuess.Substring(0, CurrentGuess.Length-1);
        }

        [RelayCommand]
        async void Guess()
		{
			

			// if correct, then go to game over (DidWin=true)
			if (CurrentGuess == hexColor)
			{
                
                
                //System.Threading.Thread.Sleep(3000);
                await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={DidWin}");
                CurrentGuess = string.Empty;
                Guesses.Clear();


            }
			else if (Guesses.Count >= 5){

                
                //System.Threading.Thread.Sleep(3000);
                await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={DidWin == false}");
				Guesses.Clear();
                CurrentGuess = string.Empty;

            }

			else
			{
				if(CurrentGuess.Length!=6){
					Console.WriteLine("Finish writing");
				}
				else
				{
                    Guesses.Add(new ColorGuess(CurrentGuess));
                    CurrentGuess = string.Empty;
                }
                
            }

			// else if this is the 6th guess (and it's wrong)
			// then go to game over (DidWin=false)


			// Add this guess to the Guesses
			
           
        }

    

		[RelayCommand]
		async Task NewPage()
		{
			await Shell.Current.GoToAsync($"..");

		}
		

    }
}

