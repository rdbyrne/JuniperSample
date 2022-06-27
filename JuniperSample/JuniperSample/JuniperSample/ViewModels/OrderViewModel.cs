using JuniperSample.Services;
using JuniperSample.TaxCalculators.Exceptions;
using JuniperSample.Validations;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JuniperSample.ViewModels
{
    public class OrderViewModel : BaseViewModel
	{
		private string salesTaxStringFormat = "Calculated Sales Tax: ${0}";
		private OrderValidation orderValidation;
		private ITaxService taxService;

		public OrderViewModel(ITaxService _taxService)
		{
			Title = "Order";
			CalculateCommand = new Command(OnCalculateClicked);
			orderValidation = new OrderValidation();
			taxService = _taxService;
		}

		private string calculatedSalesTaxText;
		public string CalculatedSalesTaxText
		{
			get => calculatedSalesTaxText;
			set => SetProperty(ref calculatedSalesTaxText, value);
		}

		private double total;
		public double Total
		{
			get => total;
			set => SetProperty(ref total, value);
		}

		private double shippingTotal;
		public double ShippingTotal
        {
			get => shippingTotal;
			set => SetProperty(ref shippingTotal, value);
		}

		private string calculateError;
		public string CalcuateError
        {
			get => calculateError;
			set => SetProperty(ref calculateError, value);

		}

		public Command CalculateCommand { get; }
		private async void OnCalculateClicked(object obj)
		{
			//This could be refacored a bit. IsBusy and network checks
			//should probably be moved to BaseViewModel
			//Network and Exception message would probably make more sene to use an AlerDialog.
			//Used error label for simplicity.

			if (IsBusy) return;

			if (Connectivity.NetworkAccess != NetworkAccess.Internet)
			{
				CalcuateError = "No internet connection";
				return;
			}

			var result = orderValidation.Validate(this);
			if (!result.IsValid)
			{
				CalcuateError = "Please enter a valid total";
				return;
			}

			IsBusy = true;

			try
			{
				CalcuateError = string.Empty;

				var salesTax = await taxService.GetSalesTax(total, shippingTotal);
				
				CalculatedSalesTaxText = string.Format(salesTaxStringFormat, salesTax);

			} catch(CalculationException e)
            {
				CalcuateError = e.Message;
            }

			IsBusy = false;
		}
    }
}

