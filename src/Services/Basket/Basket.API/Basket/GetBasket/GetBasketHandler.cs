
using Basket.API.Basket.Data;
using System.Runtime.InteropServices;

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

    public record GetBasketResult(ShoppingCart Cart);
    public class GetBasketQueryHandler(IBasketRepository repository
        ) : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            var basket = await repository.GetBasket(query.UserName,cancellationToken);



            //var basket = await _repository.GetBasket(request.UserName);
            return new GetBasketResult(basket);
        }
    }
}
