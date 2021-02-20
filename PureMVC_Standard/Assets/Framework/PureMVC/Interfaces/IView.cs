//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// PureMVC View 核心类接口
    /// </summary>
    /// <seealso cref="IMediator"/>
    /// <seealso cref="IObserver"/>
    /// <seealso cref="INotification"/>
    public interface IView
    {
        /// <summary>
        /// 注册对应的 Observer 类型通知类
        /// </summary>
        /// <param name="notificationName">对应通知消息名称</param>
        /// <param name="observer">Observer 实例</param>
        void RegisterObserver(string notificationName, IObserver observer);

        /// <summary>
        /// 注销对应的 Observer 通知
        /// </summary>
        /// <param name="notificationName">消息名称</param>
        /// <param name="notifyContext">对应 Observer 实例</param>
        void RemoveObserver(string notificationName, object notifyContext);

        /// <summary>
        /// 通知所有订阅此通知的观察者
        /// </summary>
        /// <param name="notification"></param>
        void NotifyObservers(INotification notification);

        /// <summary>
        /// 注册指定的Mediator
        /// </summary>
        /// <param name="mediator"></param>
        void RegisterMediator(IMediator mediator);

        /// <summary>
        /// 检索指定的Mediator
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns></returns>
        IMediator RetrieveMediator(string mediatorName);

        /// <summary>
        /// 移除指定的Mediator
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns></returns>
        IMediator RemoveMediator(string mediatorName);

        /// <summary>
        /// 检查是否含有对应的Mediator
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns></returns>
        bool HasMediator(string mediatorName);
    }
}
