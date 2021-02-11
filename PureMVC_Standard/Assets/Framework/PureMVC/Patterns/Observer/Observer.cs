//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using PureMVC.Interfaces;

namespace PureMVC.Patterns.Observer
{
    /// <summary>
    /// Observer核心类
    /// </summary>
    /// <seealso cref="PureMVC.Core.View"/>
    /// <seealso cref="PureMVC.Patterns.Observer.Notification"/>
    public class Observer : IObserver
    {
        /// <summary>
        /// Observer 构造函数
        /// </summary>
        /// <param name="notifyMethod">对应Mediator中执行的函数</param>
        /// <param name="notifyContext">对应的Mediator</param>
        public Observer(Action<INotification> notifyMethod, object notifyContext)
        {
            NotifyMethod = notifyMethod;
            NotifyContext = notifyContext;
        }

        /// <summary>
        /// 执行此Observer持有的回调
        /// </summary>
        /// <param name="notification">the <c>INotification</c> to pass to the interested object's notification method.</param>
        public virtual void NotifyObserver(INotification notification)
        {
            NotifyMethod(notification);
        }

        /// <summary>
        /// 比较持有的Mediator是否相同
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual bool CompareNotifyContext(object obj)
        {
            return NotifyContext.Equals(obj);
        }

        /// <summary>此观察者对应的回调函数</summary>
        public Action<INotification> NotifyMethod { get; set; }

        /// <summary>Context object</summary>
        public object NotifyContext { get; set; }
    }
}
