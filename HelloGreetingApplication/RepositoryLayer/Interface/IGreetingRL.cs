using ModelLayer.Model;
using RepositoryLayer.Entity;
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

        public bool MessageAddRL(GreetingModel greetingModel);

        public GreetingEntity FindMessageRL(RequestMessageId requestMessageId);
        public List<GreetingEntity> messageListRL();
        public MsgResponseModel GreetingMsgEditRL(MsgResponseModel msgResponseModel);
        public DeleteMsgModel GreetingMsgDeleteRL(DeleteMsgModel deleteMsgModel);
    }
}
