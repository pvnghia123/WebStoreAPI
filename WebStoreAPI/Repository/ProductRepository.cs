using System.Collections.Generic;
using System.Linq;
using WebStoreAPI.Interface;
using WebStoreAPI.Models;
using WebStoreAPI.Models.DatebaseContext;

namespace WebStoreAPI.Repository
{
    public class ProductRepository : IProduct
    {
        readonly DatabaseContext _dbcontext;
        public ProductRepository(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

       public bool AddProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteProduct(int id)
        {
            throw new System.NotImplementedException();
        }

       public List<Product> getAllProduct()
        {
            //throw new System.NotImplementedException();
            // viet cau lenh truy van sql o day
            try
            {
                return _dbcontext.Products.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Product GetProductById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
