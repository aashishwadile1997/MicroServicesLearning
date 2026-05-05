namespace Cataog_API.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is Required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is Required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price should be greater than 0");

        }
    }

    public class CreateProductHandler(IDocumentSession session, IValidator<CreateProductCommand> commandvalidator) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // implement buissness logic here 
            //Create Product entity from command object
            // sabe to db
            //return guid result new added product id

            var result = await commandvalidator.ValidateAsync(command, cancellationToken);
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

            if (errors.Any())
            {
                throw new ValidationException(errors.FirstOrDefault());
            }

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                Imagefile = command.ImageFile,
                Price = command.Price

            };

            // save to database

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);





        }
    }
}
