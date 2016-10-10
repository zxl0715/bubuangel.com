using Zxl.DAL;
using Zxl.IBLL;
using Zxl.Models;
using System.Linq;
namespace Zxl.BLL
{
    public class UserService : BaseService<User>, InterfaceUserService
    {
        public UserService() : base(RepositoryFactory.UserRepository) { }

        public bool Exist(string username)
        {
            return CurrentRepostitory.Exist(u => u.UserName == username);
        }

        public User Find(int UserID)
        {
            return CurrentRepostitory.Find(u => u.UserID == UserID);
        }

        public User Find(string userName)
        {
            return CurrentRepostitory.Find(u => u.UserName == userName);
        }

        public IQueryable<User> FindPageList(int pageIndex, int pageSize, out int totalRecord, int order)
        {
            bool _isAsc = true;
            string _orderName = string.Empty;
            switch (order)
            {
                case 0:
                    _isAsc = true;
                    _orderName = "userID";
                    break;
                case 1:
                    _isAsc = false;
                    _orderName = "userID";
                    break;
                case 2:
                    _isAsc = true;
                    _orderName = "RegistrationTime";
                    break;
                case 3:
                    _isAsc = false;
                    _orderName = "RegistrationTime";
                    break;
                case 4:
                    _isAsc = true;
                    _orderName = "LoginTime";
                    break;
                case 5:
                    _isAsc = false;
                    _orderName = "LoginTime";
                    break;
                default:
                    _isAsc = false;
                    _orderName = "userID";
                    break;
            }
            return CurrentRepostitory.FindPageList(pageIndex, pageSize, out totalRecord, u => true, _orderName, _isAsc);
        }
    }
}
