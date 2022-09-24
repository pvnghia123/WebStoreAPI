using System.Collections.Generic;
using System.Threading.Tasks;
using WebStoreAPI.Models;
namespace WebStoreAPI.Interface
{
    public interface IProduct
    {
        public BaseResponse<IEnumerable<Product>> getAllProduct();
        //public Product GetProductById(int id);
        //public bool AddProduct(Product product);
        //public bool UpdateProduct(Product product);
        //public bool DeleteProduct(int id);
    }
}
