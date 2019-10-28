using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Text;
using Messenger.Contract.Domain;
namespace Messenger.Contract.Contract
{
    //Establishing a connection between users
    //Having the user connect and sending a message
    [ServiceContract(CallbackContract = typeof(IMessageServiceCallBack), SessionMode = SessionMode.Required)]
    public interface IMessageService
    {
        [OperationContract(IsOneWay = true)]
        void Connect(User user);

        [OperationContract(IsOneWay = true)]
        void SendMessage(Message message);

        [OperationContract(IsOneWay = false)]
        ObservableCollection<User> GetConnectedUsers();
    }
}
