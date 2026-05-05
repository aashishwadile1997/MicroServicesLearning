namespace Cataog_API.Products.GetProductCategory
{
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    public class GetProductHandlerEndpoint() : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCatrgoryQuery(category));
                var response = result.Adapt<GetProductByCategoryResult>();

                return Results.Ok(response);
            }).WithName("GetProductByCategoryResult").Produces<GetProductByCategoryResult>(StatusCodes.Status200OK).ProducesProblem(StatusCodes.Status400BadRequest).WithName("Get ProductBy Category Result").WithDescription("Get ProductBy Category Result");
        }
    }
}
