
namespace Cataog_API.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(Guid id) : base("product not found", id)
        {

        }
    }
}
