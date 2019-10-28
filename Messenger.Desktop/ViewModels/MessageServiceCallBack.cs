using System.Collections.ObjectModel;
using Messenger.Contract.Contract;
using Messenger.Contract.Domain;

namespace Messenger.Desktop.ViewModels
{
    public class MessageServiceCallBack : IMessageServiceCallBack
    {
        public void ForwardToClient(Message message)
        {
            throw new System.NotImplementedException();
        }

        public void UserConnected(ObservableCollection<User> users)
        {
            throw new System.NotImplementedException();
        }
    }
}
