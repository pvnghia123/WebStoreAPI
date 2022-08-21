using System.Collections.Generic;
using System.Linq;
using WebStoreAPI.Interface;
using WebStoreAPI.Models;
using WebStoreAPI.Models.DatebaseContext;

namespace WebStoreAPI.Repository
{
    public class UserInfoRepository : IUserInfo
    {
        readonly DatabaseContext context; 
        public UserInfoRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public List<UserInfo> GetList()
        {
            try
            {
                return context.UserInfos.ToList();
            }
            catch
            {
                throw;
            }
            
        }
    }
}

