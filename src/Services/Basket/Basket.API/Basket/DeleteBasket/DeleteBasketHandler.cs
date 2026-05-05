using Basket.API.Basket.Data;
using FluentValidation;

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName): ICommand<DeleteBasketResult>;

    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");

        }
    }
    public class DeleteBasketCommandHandler(IBasketRepository repository) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            // TODO : delete basket from database and cache
            // session.Delete<Product>(command.Id);

            await repository.DeleteBasket(request.UserName, cancellationToken);

            return new DeleteBasketResult(true);
        }
    }
}
