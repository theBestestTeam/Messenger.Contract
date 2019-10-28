using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Messenger.Contract.Domain
{
    public class User
    {
        //User information
        public User()
        {
            UserId = Guid.NewGuid().ToString().Split('-')[4];
        }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime TimeCreated { get; set; }
        public ObservableCollection<Message> UserMessages { get; set; }
    }
}