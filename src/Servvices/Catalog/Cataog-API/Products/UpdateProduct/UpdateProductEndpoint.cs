
using Cataog_API.Products.CreateProduct;

namespace Cataog_API.Products.UpdateProduct
{
    public record UpdateProductCommandRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record UpdateProductResponse(bool IsSuccess);

    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (UpdateProductCommandRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateProductResponse>();

                return Results.Ok(response);

            }).WithName("Update Product").Produces<CreateProductResponse>(StatusCodes.Status201Created).ProducesProblem(StatusCodes.Status400BadRequest).WithSummary("Update Product").WithDescription("Update Product");
        }
    }
}
