using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace facade
{
	public partial class GameOverPageViewModel: ObservableObject
	{
		[RelayCommand]
		async void newPage()
		{
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
        }


		public GameOverPageViewModel()
		{
		}
	}
}

