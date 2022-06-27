using System;
using System.Threading.Tasks;
using JuniperSample.TaxCalculators;
using JuniperSample.TaxCalculators.Exceptions;
using NUnit.Framework;

namespace UnitTests.TaxCalculators
{
	[TestFixture]
	public class TaxJarCalculatorTests
	{
		[Test]
		public void CalculatorInitializes()
        {
			var calculator = new TaxJarCalculator();
			Assert.IsNotNull(calculator);
        }


        [Test]
        public async Task GetSalesTaxPassInValidTotalShouldRetrunCorrectTax()
        {
            var calculator = new TaxJarCalculator();
            var result = await calculator.GetSalesTax(120, 5);

            Assert.That(9.3, Is.EqualTo(result));

        }

        [Test]
        public async Task GetSalesTaxPassInZeroShouldRerturnZero()
        {
            var calculator = new TaxJarCalculator();
            var result = await calculator.GetSalesTax(0, 0);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public async Task GetSalesTaxPassInLargeNumberShoudBeGreaterThanZero()
        {
            var calculator = new TaxJarCalculator();
            var result = await calculator.GetSalesTax(10000000000000000000, 10000000000);

            Assert.Greater(result, 0);
        }

        [Test]
        public async Task GetSalesTaxPassInNegativeValueShoulReturnNegativeValue()
        {
            var calculator = new TaxJarCalculator();

            var result = await calculator.GetSalesTax(-5, -5);

            Assert.Less(result, 0);
        }

        [Test]
        public async Task GetTaxRateForLocationReturnsCorrectRateFor55378()
        {
            var calculator = new TaxJarCalculator();
            var result = await calculator.GetTaxRateForLocation("55378");

            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(result.City);
                Assert.IsNotEmpty(result.CityRate);
                Assert.IsNotEmpty(result.CombinedDistrictRate);
                Assert.IsNotEmpty(result.Country);
                Assert.IsNotEmpty(result.CountryRate);
                Assert.IsNotEmpty(result.County);
                Assert.IsNotEmpty(result.CountyRate);
                Assert.IsNotEmpty(result.State);
                Assert.IsNotEmpty(result.StateRate);
            });
        }

        [Test]
        public async Task GetTaxRateForLocationReturnsCorrectRateFor90210()
        {
            var calculator = new TaxJarCalculator();
            var result = await calculator.GetTaxRateForLocation("90210");

            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(result.City);
                Assert.IsNotEmpty(result.CityRate);
                Assert.IsNotEmpty(result.CombinedDistrictRate);
                Assert.IsNotEmpty(result.Country);
                Assert.IsNotEmpty(result.CountryRate);
                Assert.IsNotEmpty(result.County);
                Assert.IsNotEmpty(result.CountyRate);
                Assert.IsNotEmpty(result.State);
                Assert.IsNotEmpty(result.StateRate);
            });
        }

        //If I was going further with this app I would open the hardcoded values to be modified
        //so we can set different inputs and create addtional tests
        [Test]
        public async Task GetTaxRateForLocationReturnValuesForLongetZipCode()
        {
            var calculator = new TaxJarCalculator();
            var result = await calculator.GetTaxRateForLocation("12201-7050");

            Assert.IsNotEmpty(result.CombinedRate);
        }

        [Test]
        public void GetTaxRateForLocationInvalidZipCodeShouldThrowException()
        {
            var calculator = new TaxJarCalculator();
            Assert.ThrowsAsync<CalculationException>(async () => await calculator.GetTaxRateForLocation("NOT A ZIP CODE"));
        }
    }
}

