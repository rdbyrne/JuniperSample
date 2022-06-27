using System.Threading.Tasks;
using JuniperSample.Models;
using Refit;

namespace JuniperSample.TaxCalculators
{
	public interface ITaxCalculator
	{
		[Get("/resources")]
		Task<TaxRate> GetTaxRateForLocation(string zipCode);

		[Get("/resources")]
		Task<double> GetSalesTax(double saleTotal, double shippingTotal);
	}
}

