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

        //[ObservableProperty]
        //private ColorGuess endResult;

        [ObservableProperty]
		private string currentGuess;

        [ObservableProperty]
        private string hexColor;

        //[ObservableProperty]
        //private string end;


        public ObservableCollection<ColorGuess> Guesses { get; set; }
        

        //public string SecretColor { get; set; }

        public MainPageViewModel()
		{
            Guesses = new ObservableCollection<ColorGuess>();
            ResetGame();
        }

        void ResetGame() {
            Guesses.Clear();
            HexColor = "";
            CurrentGuess = "";

            Random rnd = new Random();

            String str = "ABCDEF";
            int Size = 6;

            for (int i = 0; i < Size; i++)
            {
                int x = rnd.Next(str.Length);
                HexColor = HexColor + str[x];
            }

            SecretColor = new ColorGuess(HexColor);
            Console.WriteLine(SecretColor.Guess);

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
        async Task Guess()
		{
			

			
			if (CurrentGuess == HexColor)
			{
                DidWin = true;

                await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={DidWin}&SecretColor={SecretColor.Guess}");
                ResetGame();
                

            }
			else if (Guesses.Count >= 5){
                DidWin = false;
                await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={DidWin}&SecretColor={SecretColor.Guess}");
                ResetGame();
                


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
			
           
        }

   
		

    }
}

