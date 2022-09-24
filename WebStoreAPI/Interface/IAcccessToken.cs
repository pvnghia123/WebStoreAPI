using Microsoft.Extensions.Configuration;
using WebStoreAPI.Models;

namespace WebStoreAPI.Interface
{
    public interface IAcccessToken
    {
        public string GenerationToken(UserInfo user, IConfiguration _configuration);
    }
}
