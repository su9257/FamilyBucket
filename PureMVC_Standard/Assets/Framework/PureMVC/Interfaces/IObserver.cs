//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;

namespace PureMVC.Interfaces
{
    /// <summary>
    /// PureMVC Observer 接口
    /// </summary>
    /// <seealso cref="IView"/>
    /// <seealso cref="INotification"/>
    public interface IObserver
    {
        /// <summary>
        /// 执行消息时对应的回调函数
        /// </summary>
        Action<INotification> NotifyMethod { set; }

        /// <summary>
        /// 传递的参数
        /// </summary>
        object NotifyContext { set; }

        /// <summary>
        /// Notify the interested object.
        /// </summary>
        /// <param name="notification">the <c>INotification</c> to pass to the interested object's notification method</param>
        void NotifyObserver(INotification notification);

        /// <summary>
        /// 比较是否为同一个 Notify内容（Mediator）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool CompareNotifyContext(object obj);
    }
}
