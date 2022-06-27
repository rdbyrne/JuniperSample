using System.Threading.Tasks;
using JuniperSample.Models;
using JuniperSample.TaxCalculators;

namespace JuniperSample.Services
{
    public class TaxService : ITaxService
	{
        private ITaxCalculator taxCalculator;

        //In the future can inject different calculators based on requirements or
        //create a service that can return needed calculator based on needs.

        //Once thing I would add here based on requirments is some kind of local cache storage.
        public TaxService(ITaxCalculator _taxCalculator)
        {
            taxCalculator = _taxCalculator;
        }

        public async Task<double> GetSalesTax(double saleTotal, double shippingTotal)
        {
            return await taxCalculator.GetSalesTax(saleTotal, shippingTotal);
        }

        public async Task<TaxRate> GetTaxRateForLocation(string zipCode)
        {
            return await taxCalculator.GetTaxRateForLocation(zipCode);
        }
    }
}

