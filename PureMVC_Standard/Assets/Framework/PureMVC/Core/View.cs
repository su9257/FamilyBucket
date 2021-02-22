//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Core
{
    /// <summary>
    /// View 层核心类，持有所有View
    /// </summary>
    /// <seealso cref="PureMVC.Patterns.Mediator.Mediator"/>
    /// <seealso cref="PureMVC.Patterns.Observer.Observer"/>
    /// <seealso cref="PureMVC.Patterns.Observer.Notification"/>
    public class View : IView
    {
        /// <summary>
        /// 构造并初始化View核心类
        /// </summary>
        /// <exception cref="System.Exception">重复构造将会抛出异常</exception>
        public View()
        {
            if (instance != null) throw new Exception(SingletonMsg);
            instance = this;
            mediatorMap = new ConcurrentDictionary<string, IMediator>();
            observerMap = new ConcurrentDictionary<string, IList<IObserver>>();
            InitializeView();
        }

        /// <summary>
        /// View核心初始化函数，被View构造函数调用
        /// </summary>
        protected virtual void InitializeView()
        {
        }

        /// <summary>
        /// <c>View</c> 获取View单例类
        /// </summary>
        /// <param name="factory">实例化IView接口的委托</param>
        /// <returns>View 实例</returns>
        public static IView GetInstance(Func<IView> factory)
        {
            if (instance == null)
            {
                instance = factory();
            }
            return instance;
        }

        /// <summary>
        /// 注册一个 Observer
        /// </summary>
        /// <param name="notificationName">通知消息的名称 of</param>
        /// <param name="observer">Observer 实例</param>
        public virtual void RegisterObserver(string notificationName, IObserver observer)
        {
            if (observerMap.TryGetValue(notificationName, out var observers))
            {
                observers.Add(observer);
            }
            else
            {
                observerMap.TryAdd(notificationName, new List<IObserver> { observer });
            }
        }

        /// <summary>
        /// 通知所有与Notification想关联的Observer
        /// </summary>
        /// <param name="notification">Notification 实例</param>
        public virtual void NotifyObservers(INotification notification)
        {
            if (observerMap.TryGetValue(notification.Name, out var observersRef))
            {
                var observers = new List<IObserver>(observersRef);

                foreach (var observer in observers)
                {
                    observer.NotifyObserver(notification);
                }
            }
        }

        /// <summary>
        /// 移除所有订阅此消息的Mediator
        /// </summary>
        /// <param name="notificationName">消息名称</param>
        /// <param name="notifyContext">对应消息的通知对象（Mediator）</param>
        public virtual void RemoveObserver(string notificationName, object notifyContext)
        {

            if (observerMap.TryGetValue(notificationName, out var observers))
            {

                for (var i = 0; i < observers.Count; i++)
                {
                    if (observers[i].CompareNotifyContext(notifyContext))
                    {
                        observers.RemoveAt(i);
                        break;
                    }
                }

                if (observers.Count == 0)
                    observerMap.TryRemove(notificationName, out _);
            }
        }

        /// <summary>
        /// 注册 Mediator
        /// </summary>
        /// <param name="mediator">IMediator 实例</param>
        public virtual void RegisterMediator(IMediator mediator)
        {

            if (mediatorMap.TryAdd(mediator.MediatorName, mediator))
            {

                var interests = mediator.ListNotificationInterests();


                if (interests.Length > 0)
                {

                    IObserver observer = new Observer(mediator.HandleNotification, mediator);


                    foreach (var interest in interests)
                    {
                        RegisterObserver(interest, observer);
                    }
                }

                mediator.OnRegister();
            }
        }

        /// <summary>
        /// 检索对应的Mediator
        /// </summary>
        /// <param name="mediatorName">检索Mediator的名称</param>
        /// <returns>返回检索Mediator的实例</returns>
        public virtual IMediator RetrieveMediator(string mediatorName)
        {
            return mediatorMap.TryGetValue(mediatorName, out var mediator) ? mediator : null;
        }

        /// <summary>
        /// 注销对应的Mediator
        /// </summary>
        /// <param name="mediatorName">注销Mediator的名称</param>
        /// <returns>返回注销Mediator的实例</returns>
        public virtual IMediator RemoveMediator(string mediatorName)
        {

            if (mediatorMap.TryRemove(mediatorName, out var mediator))
            {

                var interests = mediator.ListNotificationInterests();
                foreach (var interest in interests)
                {
                    RemoveObserver(interest, mediator);
                }

                mediator.OnRemove();
            }
            return mediator;
        }

        /// <summary>
        /// 检查对应的Mediator是否存在
        /// </summary>
        /// <param name="mediator名称"></param>
        /// <returns>此名称的Mediator是否存在的bool值</returns>
        public virtual bool HasMediator(string mediatorName)
        {
            return mediatorMap.ContainsKey(mediatorName);
        }

        /// <summary>所有注册Mediator集合</summary>
        protected readonly ConcurrentDictionary<string, IMediator> mediatorMap;

        /// <summary>所有需要通知的Observer集合</summary>
        protected readonly ConcurrentDictionary<string, IList<IObserver>> observerMap;

        /// <summary>View 单例实例</summary>
        protected static IView instance;

        /// <summary>报错信息</summary>
        protected const string SingletonMsg = "View Singleton already constructed!";
    }
}
