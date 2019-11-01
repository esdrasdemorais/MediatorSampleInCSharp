using Internal;
using System;

namespace Mediator
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsumeApi consumeApi = new ConsumeApi();
            Consume consume = new Consume(consumeApi, new Api());
            String r = consume.ReturnString("A");
            Console.Write(r);
        }
    }

    public class Api {
        public String ReturnString(String a) {
            return a + " - A";
        }
    }

    public interface IMediator {
        String Notify(Api sender, String @event);
    }
 
    public class ConsumeApi : IMediator {
        
        private String message = "";

        public ConsumeApi()
        {
            
        }

        public String Notify(Api sender, String @event) {
            if (sender.GetType().Name == "Api" && @event == "ReturnString") {
                return sender.ReturnString("A");
            }
            return null;
        }
    }

    public class Consume {
        private IMediator mediator;
        private Api api;

        public Consume(IMediator mediator, Api api)
        {
            this.mediator = mediator;
            this.api = api;
        }

        public String ReturnString(String a) {
            return mediator.Notify(this.api, "ReturnString");
        }
    }
}
