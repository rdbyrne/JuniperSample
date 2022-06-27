using JuniperSample.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace JuniperSample.Views
{
    public partial class OrderPage : ContentPage
	{	
		public OrderPage ()
		{
			InitializeComponent ();
			BindingContext = App.ServiceProvider.GetService<OrderViewModel>();
        }
	}
}

