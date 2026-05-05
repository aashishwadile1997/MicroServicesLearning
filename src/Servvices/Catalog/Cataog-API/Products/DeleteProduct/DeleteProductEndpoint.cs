namespace Cataog_API.Products.DeleteProduct
{
    public record DeleteProductResponse(bool IsSuceess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(id));

                var response = result.Adapt<DeleteProductResponse>();

                return Results.Ok(response);

            }).WithName("DeleteProductById").Produces<DeleteProductResponse>(StatusCodes.Status200OK).ProducesProblem(StatusCodes.Status400BadRequest).WithName("Delete Product By Id").WithDescription("Delete Product By Id"); ;
        }
    }
}
