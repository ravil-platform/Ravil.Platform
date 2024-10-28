namespace Application.Features.Users.Commands.GenerateToken;

public class GenerateTokenCommandValidator : AbstractValidator<GenerateTokenCommand>
{
    public GenerateTokenCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull();
    }
}