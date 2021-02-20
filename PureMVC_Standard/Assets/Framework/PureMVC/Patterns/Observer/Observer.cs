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
        /// <param name="notifyMethod">通知 Observer 时需要执行的函数</param>
        /// <param name="notifyContext">执行 notifyMethod 函数的实例</param>
        public Observer(Action<INotification> notifyMethod, object notifyContext)
        {
            NotifyMethod = notifyMethod;
            NotifyContext = notifyContext;
        }

        /// <summary>
        /// 执行此Observer持有的回调
        /// </summary>
        /// <param name="notification">INotification 实例</param>
        public virtual void NotifyObserver(INotification notification)
        {
            NotifyMethod(notification);
        }

        /// <summary>
        /// 需要比较函数是否出自同一实例
        /// </summary>
        /// <param name="obj">需要比较的实例</param>
        /// <returns></returns>
        public virtual bool CompareNotifyContext(object obj)
        {
            return NotifyContext.Equals(obj);
        }

        /// <summary>通知 Observer 时需要执行的函数</summary>
        public Action<INotification> NotifyMethod { get; set; }

        /// <summary>执行 notifyMethod 函数的实例</summary>
        public object NotifyContext { get; set; }
    }
}
