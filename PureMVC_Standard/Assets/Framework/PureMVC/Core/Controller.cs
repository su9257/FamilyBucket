//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using System.Collections.Concurrent;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Core
{
    /// <summary>
    /// Controller 核心类，持有所有Command与消息之间的映射
    /// </summary>
    /// <seealso cref="PureMVC.Core.View"/>
    /// <seealso cref="PureMVC.Patterns.Observer.Observer"/>
    /// <seealso cref="PureMVC.Patterns.Observer.Notification"/>
    /// <seealso cref="PureMVC.Patterns.Command.SimpleCommand"/>
    /// <seealso cref="PureMVC.Patterns.Command.MacroCommand"/>
    public class Controller : IController
    {
        /// <summary>
        /// 构造函数，初始化 commandMap 及自己持有的View
        /// </summary>
        public Controller()
        {
            if (instance != null) throw new Exception(SingletonMsg);
            instance = this;
            commandMap = new ConcurrentDictionary<string, Func<ICommand>>();
            InitializeController();
        }

        /// <summary>
        /// 初始化自己持有的View
        /// </summary>
        protected virtual void InitializeController()
        {
            view = View.GetInstance(() => new View());
        }

        /// <summary>
        /// 获取对应Controller的单例实例
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static IController GetInstance(Func<IController> factory)
        {
            if (instance == null)
            {
                instance = factory();
            }
            return instance;
        }

        /// <summary>
        /// 执行command时调用的函数，为内部调用函数
        /// </summary>
        /// <param name="notification">note an <c>INotification</c></param>
        public virtual void ExecuteCommand(INotification notification)
        {
            if (commandMap.TryGetValue(notification.Name, out var factory))
            {
                var commandInstance = factory();
                commandInstance.Execute(notification);
            }
        }

        /// <summary>
        /// 注册对应的Command
        /// </summary>
        /// <param name="notificationName">通知消息名称</param>
        /// <param name="factory">创建对应Command的委托或lambda表达式</param>
        public virtual void RegisterCommand(string notificationName, Func<ICommand> factory)
        {
            if (commandMap.TryGetValue(notificationName, out _) == false)
            {
                view.RegisterObserver(notificationName, new Observer(ExecuteCommand, this));
            }
            commandMap[notificationName] = factory;
        }

        /// <summary>
        /// 移除对应的命名消息
        /// </summary>
        /// <param name="notificationName"></param>
        public virtual void RemoveCommand(string notificationName)
        {
            if (commandMap.TryRemove(notificationName, out _))
            {
                view.RemoveObserver(notificationName, this);
            }
        }

        /// <summary>
        /// 检测是否含有对应命令的消息
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns></returns>
        public virtual bool HasCommand(string notificationName)
        {
            return commandMap.ContainsKey(notificationName);
        }

        /// <summary>
        /// 对应的View核心
        /// </summary>
        protected IView view;

        /// <summary>
        /// 所有消息与命令映射的Map
        /// </summary>
        protected readonly ConcurrentDictionary<string, Func<ICommand>> commandMap;

        /// <summary>
        /// 单例类
        /// </summary>
        protected static IController instance;

        /// <summary>
        /// 单例检测消息
        /// </summary>
        protected const string SingletonMsg = "Controller Singleton already constructed!";
    }
}
