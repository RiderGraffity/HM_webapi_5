using HM_webapi_5.Models; 
namespace HM_webapi_5.Interfeses
{
    public interface IProductsServises
    {
        public List<products> get_product_by_indexes(int? startWith, int? endWith);
        public void add_product(products product); 
        public void remove_product(Guid productId); 
    }
}
