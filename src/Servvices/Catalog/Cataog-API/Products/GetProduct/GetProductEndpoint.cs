
namespace Cataog_API.Products.GetProduct
{
    public record GetProductRequest(int? PageNumber = 1, int? PageSize = 20);
    public record GetProductsResponse(IEnumerable<Product> products);
    public class GetProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductsQuery>();
                var result = await sender.Send(query);
                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            }).WithName("Get Products").Produces<GetProductsResponse>(StatusCodes.Status200OK).ProducesProblem(StatusCodes.Status400BadRequest).WithName("Get Products").WithDescription("Get Products");

        }
    }
}
