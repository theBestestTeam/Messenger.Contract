using System.Collections.ObjectModel;
using System.ServiceModel;
using Messenger.Contract.Domain;

namespace Messenger.Contract.Contract
{
    public interface IMessageServiceCallBack
    {
        //Making sure the message is appropriately forwarded to the other users
        [OperationContract(IsOneWay = true)]
        void ForwardToClient(Message message);

        [OperationContract(IsOneWay = true)]
        void UserConnected(ObservableCollection<User> users);
    }
}