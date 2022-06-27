using System;
using System.Text.RegularExpressions;
using FluentValidation;
using JuniperSample.ViewModels;

namespace JuniperSample.Validations
{
	public class LocationValidation : AbstractValidator<LocationViewModel>
	{
        private string usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";

        public LocationValidation()
		{
            RuleFor(x => x.ZipCode).Must(IsAValidZipCode);

        }

        //Could move validation to a separate service to make it more Unit testable.

        //Can easily add addtional expressions for other international zip codes.
        private bool IsAValidZipCode(string zipCode)
        {
            var validZipCode = true;
            if ((!Regex.Match(zipCode, usZipRegEx).Success))
            {
                validZipCode = false;
            }
            return validZipCode;
        }
    }
}

