

namespace JuniperSample.Api
{

    //Used hardcoded values for most of the fields for simplicity sake in this demo.
    //This was the trickiest part of the challenge as I found the Tax Jar api doc to be
    //lacking. It indication only country and shipping were required, but after reading more
    //discovered more fields were condiationally required. Event after that more fields were
    //needed to get the API to acually do the calculation.
    public class SalesTaxRequest
	{
		public string To_country => "us";
		public double shipping { get; set; }
        public double amount { get; set; }
        public string to_zip => "92093";
        public string to_state => "ca";
        public string to_city => "Los Angeles";
        public string to_street => "1335 E 103rd St";
        public string from_country => "us";
        public string from_state => "ca";
        public string from_city => "La Jolla";
        public string from_street => "9500 Gilman Drive";
        public string from_zip => "92093";
		
	}
}

