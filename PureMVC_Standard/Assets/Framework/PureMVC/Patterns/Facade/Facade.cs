//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using PureMVC.Interfaces;
using PureMVC.Core;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Facade
{
    /// <summary>
    /// Facade 实例 负责 Model、View、Controller 三个核心类对外接口的调用
    /// </summary>
    /// <seealso cref="PureMVC.Core.Model"/>
    /// <seealso cref="PureMVC.Core.View"/>
    /// <seealso cref="PureMVC.Core.Controller"/>
    public class Facade : IFacade
    {
        /// <summary>
        /// 构造函数，会以M、C、V的顺序初始化对应的核心类
        /// </summary>
        /// <exception cref="System.Exception">如果重复构造了这个单例类，则抛出异常</exception>
        public Facade()
        {
            if (instance != null) throw new Exception(SingletonMsg);
            instance = this;
            InitializeFacade();
        }

        /// <summary>
        /// 会以M、C、V的顺序初始化对应的核心类
        /// </summary>
        protected virtual void InitializeFacade()
        {
            InitializeModel();
            InitializeController();
            InitializeView();
        }

        /// <summary>
        /// 获取Faced单例类
        /// </summary>
        /// <param name="facadeFunc">实例化 IFacade 的Func委托</param>
        /// <returns>返回IFacade实例</returns>
        public static IFacade GetInstance(Func<IFacade> facadeFunc)
        {
            if (instance == null)
            {
                instance = facadeFunc();
            }
            return instance;
        }

        /// <summary>
        /// 初始化并获取 Controller 核心类引用
        /// </summary>
        protected virtual void InitializeController()
        {
            controller = Controller.GetInstance(() => new Controller());
        }

        /// <summary>
        /// 初始化并获取 Model 核心类引用
        /// </summary>
        protected virtual void InitializeModel()
        {
            model = Model.GetInstance(() => new Model());
        }

        /// <summary>
        /// 初始化并获取 View 核心类引用
        /// </summary>
        protected virtual void InitializeView()
        {
            view = View.GetInstance(() => new View());
        }

        /// <summary>
        /// 注册 对应消息的 Command 
        /// </summary>
        /// <param name="notificationName">消息名称</param>
        /// <param name="factory">构造 Command 的Fun委托</param>
        public virtual void RegisterCommand(string notificationName, Func<ICommand> factory)
        {
            controller.RegisterCommand(notificationName, factory);
        }

        /// <summary>
        /// 主要对应的消息的Command
        /// </summary>
        /// <param name="notificationName">消息名称</param>
        public virtual void RemoveCommand(string notificationName)
        {
            controller.RemoveCommand(notificationName);
        }

        /// <summary>
        /// 检测对应的消息时候含有对应的Command
        /// </summary>
        /// <param name="notificationName">消息名称</param>
        /// <returns>返回是否含有Command的bool值</returns>
        public virtual bool HasCommand(string notificationName)
        {
            return controller.HasCommand(notificationName);
        }

        /// <summary>
        /// 注册对应的 Proxy
        /// </summary>
        /// <param name="proxy">IProxy实例</param>
        public virtual void RegisterProxy(IProxy proxy)
        {
            model.RegisterProxy(proxy);
        }

        /// <summary>
        /// 检索对应Proxy
        /// </summary>
        /// <param name="proxyName">Proxy名称</param>
        /// <returns>返回Proxy实例</returns>
        public virtual IProxy RetrieveProxy(string proxyName)
        {
            return model.RetrieveProxy(proxyName);
        }

        /// <summary>
        /// 注销对应的Proxy
        /// </summary>
        /// <param name="proxyName">Proxy名称</param>
        /// <returns>返回Proxy实例</returns>
        public virtual IProxy RemoveProxy(string proxyName)
        {
            return model.RemoveProxy(proxyName);
        }

        /// <summary>
        /// 检查是否含有对应的Proxy
        /// </summary>
        /// <param name="proxyName">Proxy名称</param>
        /// <returns>返回是否含有bool值</returns>
        public virtual bool HasProxy(string proxyName)
        {
            return model.HasProxy(proxyName);
        }

        /// <summary>
        /// 注册对应的Mediator
        /// </summary>
        /// <param name="mediator">Mediator名称</param>
        public virtual void RegisterMediator(IMediator mediator)
        {
            view.RegisterMediator(mediator);
        }

        /// <summary>
        /// 检索对应的Mediator
        /// </summary>
        /// <param name="mediatorName">Mediator名称</param>
        /// <returns>返回Mediator实例</returns>
        public virtual IMediator RetrieveMediator(string mediatorName)
        {
            return view.RetrieveMediator(mediatorName);
        }

        /// <summary>
        /// 移除对应的Mediator
        /// </summary>
        /// <param name="mediatorName">Mediator名称</param>
        /// <returns>返回Mediator实例</returns>
        public virtual IMediator RemoveMediator(string mediatorName)
        {
            return view.RemoveMediator(mediatorName);
        }

        /// <summary>
        /// 检查是否含有对应的Mediator
        /// </summary>
        /// <param name="Mediator名称"></param>
        /// <returns>返回是否含有Mediator的bool值</returns>
        public virtual bool HasMediator(string mediatorName)
        {
            return view.HasMediator(mediatorName);
        }

        /// <summary>
        /// 创一个Notification并发送
        /// </summary>
        /// <param name="notificationName">notification名称</param>
        /// <param name="body">传输的数据结构</param>
        /// <param name="type">用于区分对应的Notification的类别</param>
        public virtual void SendNotification(string notificationName, object body = null, string type = null)
        {
            NotifyObservers(new Notification(notificationName, body, type));
        }

        /// <summary>
        /// 通知所有订阅此消息体的观察者
        /// </summary>
        /// <param name="notification"></param>
        public virtual void NotifyObservers(INotification notification)
        {
            view.NotifyObservers(notification);
        }

        /// <summary>Controller 引用</summary>
        protected IController controller;
        /// <summary>Model 引用</summary>
        protected IModel model;
        /// <summary>View 引用</summary>
        protected IView view;

        /// <summary>单例实例</summary>
        protected static IFacade instance;

        /// <summary>报错信息</summary>
        protected const string SingletonMsg = "Facade Singleton already constructed!";
    }
}
