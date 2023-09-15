using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace facade
{
	public partial class MainPageViewModel: ObservableObject
	{
		[ObservableProperty]
		private string name;
        //public object Name { get; set; }
        public MainPageViewModel()
		{
			Name = "Autin";
		}
	}
}

