using HM_webapi_5.Models;
using HM_webapi_5.Interfeses;

namespace HM_webapi_5.Servises
{
    public class ProductsServis : IProductsServises
    {
        private List<products> _products;

        public ProductsServis()
        {
            _products = new List<products>();
        }

        public List<products> get_product_by_indexes(int? startWith, int? endWith)
        {
            try
            {
                if (startWith == null && endWith == null)
                {
                    return _products;
                }

                if (startWith < 0 || startWith >= _products.Count)
                {
                    return null; 
                }

                if (endWith < 0 || endWith >= _products.Count)
                {
                    return null;
                }

                if (startWith != null && endWith != null)
                {
                    if (startWith > endWith)
                    {
                        return null;
                    }
                }

                int start = startWith ?? 0;
                int end = endWith ?? (_products.Count - 1);

                int count = end - start + 1;

                return _products.GetRange(start, count);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<products>();
            }

        }

        public void add_product(products product)
        {
            _products.Add(product);
        } 


        public void remove_product(Guid productId)
        {
            _products.RemoveAll(p => p.Id == productId); 
             
        } 
    }
}
