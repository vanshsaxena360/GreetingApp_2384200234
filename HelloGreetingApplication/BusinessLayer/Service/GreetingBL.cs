﻿using BusinessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public  class GreetingBL :IGreetingBL
    {
        private readonly IGreetingRL greetingRL;

        public GreetingBL(IGreetingRL greetingRL) {
            this.greetingRL = greetingRL;
        }

        public string printHelloWorldBL() {
            var message = greetingRL.PrintHelloWorldRL();
            return message;
        }
        public string UserAttributeMsgBL(UserModel userModel) {
            var message = greetingRL.UserAttributeMsgRL(userModel);
            if (message == null)
            {
                return "Hello World!";
            }
            else if (message == userModel.FirstName)
            {
                return userModel.FirstName + " Hello";
            }
            else {
                return "Hello " + userModel.LastName;
            }
        }

        public bool AddMessageBL(GreetingModel greetingModel)
        {
            var result = greetingRL.MessageAddRL(greetingModel);
            if (result)
            {
                return true;
            }
            return false;
        }

        public GreetingModel FindMessageBL(RequestMessageId requestMessageId)
        {
            GreetingModel greetingModel = new GreetingModel();
            var result = greetingRL.FindMessageRL(requestMessageId);
            if (result != null)
            {
                greetingModel.GreetingMsg = result.GreetingMsg;
                return greetingModel;
            }
            return greetingModel;
        }
        public List<GreetingEntity> messageListBL() {
            return greetingRL.messageListRL();
        }
        public MsgResponseModel GreetingMsgEditBL(MsgResponseModel msgResponseModel) {
            var output = greetingRL.GreetingMsgEditRL(msgResponseModel);
            return output;
        }

        public DeleteMsgModel GreetingMsgDeleteBL(DeleteMsgModel deleteMsgModel) {
            MsgResponseModel msgResponseModel = new MsgResponseModel();
            var output = greetingRL.GreetingMsgDeleteRL(deleteMsgModel);
            return output;
        }
    }
}
