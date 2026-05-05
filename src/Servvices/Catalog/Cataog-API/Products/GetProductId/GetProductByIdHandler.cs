namespace Cataog_API.Products.GetProductId
{
    //public record GetProductRequest(int? pageNumbr=1 , int? pageSize=20);
    public record GetProductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    public class GetProductByIdqueryHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {

            var product = await session.LoadAsync<Product>(query.id, cancellationToken);
            if (product == null)
            {

                throw new ProductNotFoundException(query.id);

            }

            return new GetProductByIdResult(product);
        }
    }
}
