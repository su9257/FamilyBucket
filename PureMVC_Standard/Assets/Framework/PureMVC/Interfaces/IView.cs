//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// The interface definition for a PureMVC View.
    /// </summary>
    /// <remarks>
    ///     <para>In PureMVC, the <c>View</c> class assumes these responsibilities:</para>
    ///     <list type="bullet">
    ///         <item>Maintain a cache of <c>IMediator</c> instances</item>
    ///         <item>Provide methods for registering, retrieving, and removing <c>IMediators</c></item>
    ///         <item>Managing the observer lists for each <c>INotification</c> in the application</item>
    ///         <item>Providing a method for attaching <c>IObservers</c> to an <c>INotification</c>'s observer list</item>
    ///         <item>Providing a method for broadcasting an <c>INotification</c></item>
    ///         <item>Notifying the <c>IObservers</c> of a given <c>INotification</c> when it broadcast</item>
    ///     </list>
    /// </remarks>
    /// <seealso cref="IMediator"/>
    /// <seealso cref="IObserver"/>
    /// <seealso cref="INotification"/>
    public interface IView
    {
        /// <summary>
        /// Register an <c>IObserver</c> to be notified
        /// of <c>INotifications</c> with a given name.
        /// </summary>
        /// <param name="notificationName">the name of the <c>INotifications</c> to notify this <c>IObserver</c> of</param>
        /// <param name="observer">the <c>IObserver</c> to register</param>
        void RegisterObserver(string notificationName, IObserver observer);

        /// <summary>
        /// Remove a group of observers from the observer list for a given Notification name.
        /// </summary>
        /// <param name="notificationName">which observer list to remove from </param>
        /// <param name="notifyContext">removed the observers with this object as their notifyContext</param>
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
