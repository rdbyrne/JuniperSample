using System.Text.Json.Serialization;

namespace JuniperSample.Api
{
	public class SalesTaxResponse
	{
		[JsonPropertyName("tax")]
		public Tax tax { get; set; }
	}

	public class Tax
    {
		[JsonPropertyName("amount_to_collect")]
		public double amount_to_collect { get; set; }
	}
}

