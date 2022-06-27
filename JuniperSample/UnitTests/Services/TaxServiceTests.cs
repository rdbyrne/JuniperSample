using NUnit.Framework;
using Moq;
using JuniperSample.Services;
using JuniperSample.TaxCalculators;
using System.Threading.Tasks;

namespace UnitTests.Services
{
	[TestFixture]
	public class TaxServiceTests
	{
        private TaxService _taxService;
        private Mock<ITaxCalculator> _taxCalculatorMock;

        [SetUp]
        public void Setup()
        {
            _taxCalculatorMock = new Mock<ITaxCalculator>();
            _taxCalculatorMock.Setup(x => x.GetSalesTax(It.IsAny<double>(), It.IsAny<double>()));
            _taxCalculatorMock.Setup(x => x.GetTaxRateForLocation(It.IsAny<string>()));
            _taxService = new TaxService(_taxCalculatorMock.Object);
        }

        [Test]
        public async Task GetSalesTaxShouldCallTaxCalculator()
        {
            await _taxService.GetSalesTax(120, 15);
            _taxCalculatorMock.Verify(x => x.GetSalesTax(120, 15), Times.Once);
        }

        [Test]
        public async Task GetTaxRateForLocationShouldCallTaxCalculator()
        {
            await _taxService.GetTaxRateForLocation("90210");
            _taxCalculatorMock.Verify(x => x.GetTaxRateForLocation("90210"), Times.Once);
        }
    }
}

