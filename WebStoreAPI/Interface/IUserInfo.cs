using System.Collections.Generic;
using WebStoreAPI.Models;

namespace WebStoreAPI.Interface
{
    public interface IUserInfo
    {
        public List<UserInfo> GetList();
    }
}
