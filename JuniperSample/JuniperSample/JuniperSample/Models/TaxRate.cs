using System.Text.Json.Serialization;

namespace JuniperSample.Models
{
	public class TaxRate
	{
		[JsonPropertyName("country")]
		public string Country { get; set; }

		[JsonPropertyName("country_rate")]
		public string CountryRate { get; set; }

		[JsonPropertyName("state")]
		public string State { get; set; }

		[JsonPropertyName("state_rate")]
		public string StateRate { get; set; }

		[JsonPropertyName("county")]
		public string County { get; set; }

		[JsonPropertyName("county_rate")]
		public string CountyRate { get; set; }

		[JsonPropertyName("city")]
		public string City { get; set; }

		[JsonPropertyName("city_rate")]
		public string CityRate { get; set; }

		[JsonPropertyName("combined_rate")]
		public string CombinedRate { get; set; }

		[JsonPropertyName("combined_district_rate")]
		public string CombinedDistrictRate { get; set; }
	}
}

