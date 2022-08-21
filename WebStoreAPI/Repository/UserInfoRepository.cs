using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public UserInfo GetUser(string Email, string Password)
        {
            // throw new System.NotImplementedException();
            return context.UserInfos.FirstOrDefault(c => c.Email == Email && c.Password == Password);
        }
    }
}

