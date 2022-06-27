using System;
using JuniperSample.ViewModels;
using FluentValidation;

namespace JuniperSample.Validations
{
	public class OrderValidation : AbstractValidator<OrderViewModel>
	{
		public OrderValidation()
		{
			RuleFor(x => x.Total).NotEmpty();
			RuleFor(x => x.Total).GreaterThanOrEqualTo(0.01);

			RuleFor(x => x.ShippingTotal).NotEmpty();
			RuleFor(x => x.ShippingTotal).GreaterThanOrEqualTo(0.01);
		}
	}
}

