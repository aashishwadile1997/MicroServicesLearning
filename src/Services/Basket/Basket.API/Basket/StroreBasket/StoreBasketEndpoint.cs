
namespace Basket.API.Basket.StroreBasket
{
    public record StoreBasketRequest(ShoppingCart Cart);

    public record StoreBasketResponse(string UserName);

    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async(StoreBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<StoreBasketCommand>();
                var reuslt = await sender.Send(command);
                var response = reuslt.Adapt<StoreBasketResponse>();

                return Results.Created($"/basket/{response.UserName}", response);

            }).WithName("CreateBasket").Produces<StoreBasketResponse>(StatusCodes.Status201Created).ProducesProblem(StatusCodes.Status400BadRequest).WithSummary("Store Basket").WithDescription("Store Basket");
        }
    }
}
