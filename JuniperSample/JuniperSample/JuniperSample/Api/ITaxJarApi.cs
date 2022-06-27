using System.Threading.Tasks;
using Refit;

namespace JuniperSample.Api
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
	public interface ITaxJarApi
	{
        [Get("/rates/{zipCode}")]
        Task<GetTaxRateResponse> GetTaxRateForLocation(string zipCode);

		[Post("/taxes")]
        Task<SalesTaxResponse> GetSalesTax([Body] SalesTaxRequest request);
	}
}
