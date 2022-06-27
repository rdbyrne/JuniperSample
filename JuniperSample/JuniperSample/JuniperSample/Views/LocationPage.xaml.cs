using JuniperSample.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace JuniperSample.Views
{
    public partial class LocationPage : ContentPage
	{	
		public LocationPage ()
		{
			InitializeComponent ();
			BindingContext = App.ServiceProvider.GetService<LocationViewModel>();
		}
	}
}

