//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// Notifier 接口
    /// </summary>

    /// <seealso cref="IFacade"/>
    /// <seealso cref="INotification"/>
    public interface INotifier
    {
        /// <summary>
        /// 用于发送 INotification
        /// </summary>
        /// <param name="notificationName"></param>
        /// <param name="body"></param>
        /// <param name="type"></param>
        void SendNotification(string notificationName, object body = null, string type = null);
    }
}
