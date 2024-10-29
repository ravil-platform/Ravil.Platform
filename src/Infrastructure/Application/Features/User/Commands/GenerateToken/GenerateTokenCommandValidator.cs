namespace Application.Features.User.Commands.GenerateToken;

public class GenerateTokenCommandValidator : AbstractValidator<GenerateTokenCommand>
{
    public GenerateTokenCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull();
    }
}