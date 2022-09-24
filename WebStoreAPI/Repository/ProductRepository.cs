using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public BaseResponse<IEnumerable<Product>> getAllProduct()
        {
            var result = new BaseResponse<IEnumerable<Product>>
            {
                Success = true,
                Data = new List<Product>()

            };
            if (_dbcontext.Products.ToList() == null)
            {
                result.ErrorMessage = "error";
                return result;
            }

            result.Data = _dbcontext.Products.ToList();
            return result;
        }

        //public Task<BaseResponse<IEnumerable<Product>>> getAllProduct()
        //{
        //    var result = new BaseResponse<IEnumerable<Product>>
        //    {
        //        Success = true,
        //        Data = new List<Product>()

        //    };
        //    result.Data =  _dbcontext.Products.ToList();
        //    return result;
        //}
    }
}
