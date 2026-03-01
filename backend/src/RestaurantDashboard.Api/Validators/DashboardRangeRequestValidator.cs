using FluentValidation;
using RestaurantDashboard.Api.DTOs.Requests;

namespace RestaurantDashboard.Api.Validators
{
    public class DashboardRangeRequestValidator : AbstractValidator<DashboardRangeRequest>
    {
        public DashboardRangeRequestValidator()
        {
            RuleFor(x => x.To).GreaterThanOrEqualTo(x => x.From).When(x => x.From.HasValue && x.To.HasValue)
                .WithMessage("The 'To' date must be greater than or equal to 'From'.");

            RuleFor(x => x.From).LessThanOrEqualTo(x => x.To).When(x => x.From.HasValue && x.To.HasValue);
        }
    }
}
