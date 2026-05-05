

namespace Cataog_API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccess);

    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id is Required");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name is Required").Length(2, 150).WithMessage(" Length should be between 2 to 150");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price should be greater than 0");
        }
    }
    public class UpdateProductHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand query, CancellationToken cancellationToken)
        {

            var result = await session.LoadAsync<Product>(query.Id, cancellationToken);
            if (result == null)
            {
                throw new ProductNotFoundException(query.Id);
            }

            result.Name = query.Name;
            result.Category = query.Category;
            result.Description = query.Description;
            result.Imagefile = query.ImageFile;
            result.Price = query.Price;

            session.Update(result);
            session.SaveChangesAsync();
            return new UpdateProductResult(true);

        }
    }

}
