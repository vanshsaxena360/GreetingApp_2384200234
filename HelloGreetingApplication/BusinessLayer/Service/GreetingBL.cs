using BusinessLayer.Interface;
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
    }
}
