using System.Collections.Generic;
using System.Threading.Tasks;
using WebStoreAPI.Models;

namespace WebStoreAPI.Interface
{
    public interface IUserInfo
    {
        public List<UserInfo> GetList();
        public UserInfo GetUser(string Email, string Password);
    }
}
