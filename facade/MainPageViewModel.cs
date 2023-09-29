using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace facade
{
	public partial class MainPageViewModel: ObservableObject 
	{
        public bool DidWin { get; set; } = true;

        [ObservableProperty]
		private string secretColor;

		[ObservableProperty]
		private string currentGuess;

        



        public ObservableCollection<ColorGuess> Guesses { get; set; }

		//public string SecretColor { get; set; }

		public MainPageViewModel()
		{
			secretColor = "FACADE";
			currentGuess = "";
			
			

			Guesses = new ObservableCollection<ColorGuess>();

			//Guesses.Add( new ColorGuess("#beaded")  );
   //         Guesses.Add( new ColorGuess("#efaced") );

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
        async void Guess()
		{
			

			// if correct, then go to game over (DidWin=true)
			if (CurrentGuess == SecretColor)
			{
				
                await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={DidWin}");
                CurrentGuess = string.Empty;
                Guesses.Clear();

            }
			else if (Guesses.Count >= 5){
                
                await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={DidWin == false}");
				Guesses.Clear();
                CurrentGuess = string.Empty;

            }

			else
			{
                Guesses.Add(new ColorGuess(CurrentGuess));
                CurrentGuess = string.Empty;
            }

			// else if this is the 6th guess (and it's wrong)
			// then go to game over (DidWin=false)


			// Add this guess to the Guesses
			
           
        }

        



    }
}

