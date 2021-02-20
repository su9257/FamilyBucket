//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using PureMVC.Interfaces;

namespace PureMVC.Patterns.Observer
{
    /// <summary>
    /// INotifier 实现类
    /// </summary>
    /// <seealso cref="PureMVC.Patterns.Proxy.Proxy"/>
    /// <seealso cref="PureMVC.Patterns.Facade.Facade"/>
    /// <seealso cref="PureMVC.Patterns.Mediator.Mediator"/>
    /// <seealso cref="PureMVC.Patterns.Command.MacroCommand"/>
    /// <seealso cref="PureMVC.Patterns.Command.SimpleCommand"/>
    public class Notifier : INotifier
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="notificationName"></param>
        /// <param name="body"></param>
        /// <param name="type"></param>
        public virtual void SendNotification(string notificationName, object body = null, string type = null)
        {
            Facade.SendNotification(notificationName, body, type);
        }

        /// <summary>Return the Singleton Facade instance</summary>
        protected IFacade Facade
        {
            get
            {
                return Patterns.Facade.Facade.GetInstance(() => new Facade.Facade());
            }
        }
    }
}
