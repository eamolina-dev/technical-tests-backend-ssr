using FluentValidation;
using technical_tests_backend_ssr.Dtos;

public class SaveProductDtoValidator : AbstractValidator<SaveProductDto>
{
    public SaveProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("The name cannot exceed 100 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("The price must be greater than 0.");
    }
}
