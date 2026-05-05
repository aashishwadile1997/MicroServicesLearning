using Marten.Pagination;

namespace Cataog_API.Products.GetProduct
{
    public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 20) : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);

    public class GetProductsQueryHandler(IDocumentSession session) : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {


            var products = await session.Query<Product>().ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 20, cancellationToken);

            return new GetProductsResult(products);

            throw new NotImplementedException();
        }
    }
}
