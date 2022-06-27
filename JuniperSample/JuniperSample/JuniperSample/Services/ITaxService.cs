using System.Threading.Tasks;
using JuniperSample.Models;

namespace JuniperSample.Services
{
	public interface ITaxService
	{
		Task<TaxRate> GetTaxRateForLocation(string zipCode);
		Task<double> GetSalesTax(double saleTotal, double shippingTotal);
	}
}

