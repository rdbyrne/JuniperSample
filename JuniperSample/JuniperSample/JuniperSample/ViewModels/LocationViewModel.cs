using System;
using JuniperSample.Services;
using JuniperSample.Validations;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JuniperSample.ViewModels
{
    public class LocationViewModel : BaseViewModel
	{
		private LocationValidation locationValidation;
		private ITaxService taxService;

		public LocationViewModel(ITaxService _taxService)
		{
			Title = "Location";
			CalculateCommand = new Command(OnCalculateClicked);
			locationValidation = new LocationValidation();
			taxService = _taxService;
		}


		private string zipCode;
		public string ZipCode
		{
			get => zipCode;
			set => SetProperty(ref zipCode, value);

		}

		private bool hasResult;
		public bool HasResult
        {
			get => hasResult;
			set => SetProperty(ref hasResult, value);
        }

		private string calculateError;
		public string CalcuateError
		{
			get => calculateError;
			set => SetProperty(ref calculateError, value);

		}

		private string combinedDistrictRate;
		public string CombinedDistrictRate
		{
			get => combinedDistrictRate;
			set => SetProperty(ref combinedDistrictRate, value);

		}

		private string combinedRate;
		public string CombinedRate
		{
			get => combinedRate;
			set => SetProperty(ref combinedRate, value);

		}

		private string countryRate;
		public string CountryRate
		{
			get => countryRate;
			set => SetProperty(ref countryRate, value);

		}

		private string countyRate;
		public string CountyRate
		{
			get => countyRate;
			set => SetProperty(ref countyRate, value);

		}

		private string stateRate;
		public string StateRate
		{
			get => stateRate;
			set => SetProperty(ref stateRate, value);

		}

		private string cityRate;
		public string CityRate
		{
			get => cityRate;
			set => SetProperty(ref cityRate, value);

		}

		/*{"rate":{"city":"PRIOR LAKE","city_rate":"0.0","combined_district_rate":"0.0","combined_rate":"0.07375",
		"country":"US","country_rate":"0.0","county":"SCOTT","county_rate":"0.005","freight_taxable":true,"state":"MN","state_rate":"0.06875","zip":"55378"}}*/
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


			
			HasResult = false;

			var output = locationValidation.Validate(this);
			if(!output.IsValid)
            {
				CalcuateError = "Please enter a valid zip code";
				return;
			}
			
			IsBusy = true;

			try {
				CalcuateError = string.Empty;

				var taxRate = await taxService.GetTaxRateForLocation(zipCode);
				
				CombinedDistrictRate = taxRate.CombinedDistrictRate;
				CombinedRate = taxRate.CombinedRate;
				CountryRate = taxRate.CountryRate;
				CountyRate = taxRate.CountyRate;
				StateRate = taxRate.StateRate;
				CityRate = taxRate.CityRate;
				HasResult = true;
			}
			catch (Exception e)
			{
				CalcuateError = e.Message;
			}

			IsBusy = false;
		}


	}
}

