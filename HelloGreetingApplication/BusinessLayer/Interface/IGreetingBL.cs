using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IGreetingBL
    {
        public string printHelloWorldBL();
        public string UserAttributeMsgBL(UserModel userModel);

        public bool AddMessageBL(GreetingModel greetingModel);

        public GreetingModel FindMessageBL(RequestMessageId requestMessageId);
        public List<GreetingEntity> messageListBL();
        public MsgResponseModel GreetingMsgEditBL(MsgResponseModel msgResponseModel);

        public DeleteMsgModel GreetingMsgDeleteBL(DeleteMsgModel deleteMsgModel);
    }
}
