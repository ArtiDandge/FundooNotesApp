using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooMSMQ
{
    public class Receiver
    {
        public string receiverMessage()
        {
            MessageQueue reciever = new MessageQueue(@".\Private$\MyQueue");
            var recieving = reciever.Receive();
            recieving.Formatter = new BinaryMessageFormatter();
            string linkToBeSend = recieving.Body.ToString();
            return linkToBeSend;
        }
    }
}
