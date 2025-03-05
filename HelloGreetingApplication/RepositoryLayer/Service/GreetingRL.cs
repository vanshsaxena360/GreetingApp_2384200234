using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Context;

namespace RepositoryLayer.Service
{
    
    public class GreetingRL : IGreetingRL
    {
        HelloGreetingContext helloGreetingContext;
        public GreetingRL(HelloGreetingContext helloGreetingContext) {
            this.helloGreetingContext = helloGreetingContext;
        }
        public List<UserModel> userList = new() {
            new UserModel {FirstName = "Rahul1", LastName = "Kumar1"},
            new UserModel {FirstName = "Rahul2", LastName = "Kumar2"},
            new UserModel {FirstName = "Rahul3", LastName = "Kumar3"},
            new UserModel {FirstName = "Rahul4", LastName = "Kumar4"},
            new UserModel {FirstName = "Rahul5", LastName = "Kumar5"},
            new UserModel {FirstName = "Rahul6", LastName = "Kumar6"},
            new UserModel {FirstName = "Rahul7", LastName = "Kumar7"},
            new UserModel {FirstName = "Rahul8", LastName = "Kumar8"},
            new UserModel {FirstName = "Rahul9", LastName = "Kumar9"},
            new UserModel {FirstName = "Rahul10", LastName = "Kumar10"}
        };

        List<UserModel> IGreetingRL.userList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PrintHelloWorldRL() {
            return "Hello World! RL";
        }

        public string UserAttributeMsgRL(UserModel userModel) {
            foreach (var user in userList) {
                if (userModel.FirstName == user.FirstName)
                {
                    return userModel.FirstName;
                }
                else if (userModel.LastName == user.LastName)
                {
                    return userModel.LastName;
                }
                else {
                    return null;
                }
            }
            return null;
        }

        public bool MessageAddRL(GreetingModel greetingModel) {
            if (greetingModel == null)
            {
                return false;
            }
            GreetingEntity greetingEntity = new GreetingEntity()
            {
                GreetingMsg = greetingModel.GreetingMsg
            };

            helloGreetingContext.Greetings.Add(greetingEntity);
            helloGreetingContext.SaveChanges();
            return true;
        }

        public GreetingEntity FindMessageRL(RequestMessageId requestMessageId)
        {
            var result = helloGreetingContext.Greetings.FirstOrDefault(e => e.Id == requestMessageId.Id);
            return result;
        }

    }
}
