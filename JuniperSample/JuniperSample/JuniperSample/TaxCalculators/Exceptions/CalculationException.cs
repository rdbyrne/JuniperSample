using System;
namespace JuniperSample.TaxCalculators.Exceptions
{
	public class CalculationException : Exception
	{
		public CalculationException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}

