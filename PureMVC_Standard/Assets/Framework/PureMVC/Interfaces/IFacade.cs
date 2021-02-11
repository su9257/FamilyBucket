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
    /// PureMVC Facade 接口
    /// </summary>
    /// <seealso cref="IModel"/>
    /// <seealso cref="IView"/>
    /// <seealso cref="IController"/>
    /// <seealso cref="ICommand"/>
    /// <seealso cref="INotification"/>
    public interface IFacade : INotifier
    {
        /// <summary>
        /// 注册Proxy
        /// </summary>
        /// <param name="proxy"></param>
        void RegisterProxy(IProxy proxy);

        /// <summary>
        /// 检索Proxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        IProxy RetrieveProxy(string proxyName);

        /// <summary>
        /// 注销Proxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        IProxy RemoveProxy(string proxyName);

        /// <summary>
        /// 检查是否还有指定Proxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        bool HasProxy(string proxyName);

        /// <summary>
        /// 注册指定命令
        /// </summary>
        /// <param name="notificationName"></param>
        /// <param name="factory"></param>
        void RegisterCommand(string notificationName, Func<ICommand> factory);

        /// <summary>
        /// 移除指定命令
        /// </summary>
        /// <param name="notificationName"></param>
        void RemoveCommand(string notificationName);

        /// <summary>
        /// 检查是否含有命令
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns></returns>
        bool HasCommand(string notificationName);

        /// <summary>
        /// 注册指定Mediator
        /// </summary>
        /// <param name="mediator"></param>
        void RegisterMediator(IMediator mediator);

        /// <summary>
        /// 检索指定Mediator
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns></returns>
        IMediator RetrieveMediator(string mediatorName);

        /// <summary>
        /// 移除指定Mediator
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns></returns>
        IMediator RemoveMediator(string mediatorName);

        /// <summary>
        /// 是否含有指定Mediator
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns></returns>
        bool HasMediator(string mediatorName);

        /// <summary>
        /// 通知指定的 Observers
        /// </summary>
        /// <param name="notification"></param>
        void NotifyObservers(INotification notification);
    }
}
