using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace facade
{
	public partial class MainPageViewModel: ObservableObject
	{

        [ObservableProperty]
        private string secretColor;


        [ObservableProperty]
        private string currentGuess;


        public ObservableCollection<ColorGuess> Guesses { get; set; }


        //private string SecretColor { get; set; }

        public MainPageViewModel() {
            secretColor = "FACADE";
            currentGuess = "";

            Guesses = new ObservableCollection<ColorGuess>();

            Guesses.Add(new ColorGuess("#beaded"));
            Guesses.Add(new ColorGuess("#efaced"));

        }

        [RelayCommand]
        void AddLetter(string letter)
        {
            if(CurrentGuess.Length < 6)
            {
                CurrentGuess += letter;
            }
            

        }

        //void Guess()
        //{
        //    //if correct, go to game over (DidWin=true)

        //    //else if this is the 6th guess(and it's)
        //    //then go to game over (DidWin=false)

        //    //add this guess to the guesses
        //    Guesses.Add(CurrentGuess);
        //}


       

        //public object Name { get; set; }
        //      public MainPageViewModel()
        //{
        //	Name = "Autin";
        //}
    }
}

