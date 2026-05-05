namespace Cataog_API.Products.GetProductCategory
{

    public record GetProductByCatrgoryQuery(string Category) : IQuery<GetProductByCategoryResponse>;

    public record GetProductByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductByCategoryHandler(IDocumentSession session) : IQueryHandler<GetProductByCatrgoryQuery, GetProductByCategoryResponse>
    {
        public async Task<GetProductByCategoryResponse> Handle(GetProductByCatrgoryQuery query, CancellationToken cancellationToken)
        {
            var result = await session.Query<Product>().Where(p => p.Category.Contains(query.Category)).ToListAsync();


            return new GetProductByCategoryResponse(result);


        }
    }

}
