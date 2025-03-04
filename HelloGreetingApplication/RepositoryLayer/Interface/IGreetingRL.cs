using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IGreetingRL
    {
        public List<UserModel> userList { get; set; }
        public string PrintHelloWorldRL();
        public string UserAttributeMsgRL(UserModel userModel);
    }
}
