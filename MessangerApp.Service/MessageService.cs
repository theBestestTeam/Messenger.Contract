using Messenger.Contract.Contract;
using Messenger.Contract.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MessangerApp.Service
{
    //Attribute related to the reaction of the messages
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class MessageService : IMessageService
    {
        private IMessageServiceCallBack _callBack = null;
        private ObservableCollection<User> _users;
        private Dictionary<string, IMessageServiceCallBack> _clients;

        public MessageService()
        {
            _users = new ObservableCollection<User>();
            _clients = new Dictionary<string, IMessageServiceCallBack>();
        }
        public void Connect(User user)
        {
            _callBack = OperationContext.Current.GetCallbackChannel<IMessageServiceCallBack>();
            if(_callBack != null)
            {
                _clients.Add(user.UserId, _callBack);
                _users.Add(user);
                _clients?.ToList().ForEach(c => c.Value.UserConnected(_users));
                Console.WriteLine($"{user.Name} just connected");
            }
        }

        public ObservableCollection<User> GetConnectedUsers()
        {
            return _users;
        }

        public void SendMessage(Message message)
        {
            var sendTo = _clients?.First(c => c.Key == message.ToUserId).Value;
            if(sendTo !=null)
            {
                sendTo.ForwardToClient(message);
            }
        }
    }
}
