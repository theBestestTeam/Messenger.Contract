using System;

namespace Messenger.Contract.Domain
{
    //Store information of the messages between user - and time sent
    public class Message
    {
        public DateTime TimeSent { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public string MessageSent { get; set; }
    }
}