using System.Threading.Tasks;
using JuniperSample.Api;
using JuniperSample.Models;
using JuniperSample.TaxCalculators.Exceptions;
using Refit;

namespace JuniperSample.TaxCalculators
{
	public class TaxJarCalculator : ITaxCalculator
	{
        private ITaxJarApi taxJarClient;
        //In prod would have api url in a config 
        private const string BASE_API = "https://api.taxjar.com/v2";

        public TaxJarCalculator()
        {
            //In prod API key wouldnt be stored in code. Get from app server.
            taxJarClient = RestService.For<ITaxJarApi>(BASE_API, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult("5da2f821eee4035db4771edab942a4cc")
            }) ;
        }

        public async Task<double> GetSalesTax(double saleTotal, double shippingTotal)
        {

            SalesTaxResponse salesTax;
            try
            {
                salesTax = await taxJarClient.GetSalesTax(new SalesTaxRequest() { amount = saleTotal, shipping = shippingTotal});
            }
            catch (ApiException e)
            {
                throw new CalculationException(e.Content, e);
            }

            return salesTax.tax.amount_to_collect;
        }

        public async Task<TaxRate> GetTaxRateForLocation(string zipCode)
        {
            GetTaxRateResponse response;
            try
            {
                response = await taxJarClient.GetTaxRateForLocation(zipCode);
            }catch (ApiException e)
            {
                throw new CalculationException(e.Content, e);
            }

            return response.rate;
        }
    }
}

