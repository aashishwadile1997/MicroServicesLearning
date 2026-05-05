
namespace Cataog_API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

    public record DeleteProductResult(bool IsSuceess);

    public class DeleteCommandValidate : AbstractValidator<DeleteProductCommand>
    {
        public DeleteCommandValidate()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id is Required");

        }
    }


    public class DeleteProductHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand query, CancellationToken cancellationToken)
        {



            session.Delete<Product>(query.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);


        }
    }
}
