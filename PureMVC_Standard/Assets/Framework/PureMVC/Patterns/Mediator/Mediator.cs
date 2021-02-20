//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Mediator
{
    /// <summary>
    /// IMediator 实例类
    /// </summary>
    /// <seealso cref="PureMVC.Core.View"/>
    public class Mediator : Notifier, IMediator
    {
        /// <summary>
        /// 用于区别 IMediator 实例的名称
        /// </summary>
        public static string NAME = "Mediator";

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <param name="viewComponent"></param>
        public Mediator(string mediatorName, object viewComponent = null)
        {
            MediatorName = mediatorName ?? NAME;
            ViewComponent = viewComponent;
        }

        /// <summary>
        /// 此 Mediator 关注的消息列表
        /// </summary>
        /// <returns></returns>
        public virtual string[] ListNotificationInterests()
        {
            return new string[0];
        }

        /// <summary>
        /// 处理此 Mediator 关注消息的回调
        /// </summary>
        /// <param name="notification"></param>
        public virtual void HandleNotification(INotification notification)
        {
        }

        /// <summary>
        /// 注册 Mediator 时的回调
        /// </summary>
        public virtual void OnRegister()
        {
        }

        /// <summary>
        /// 注销 Mediator 时的回调
        /// </summary>
        public virtual void OnRemove()
        {
        }

        /// <summary>Mediator 名称</summary>
        public string MediatorName { get; protected set; }

        /// <summary>Mediator 持有的 view component</summary>
        public object ViewComponent { get; set; }
    }
}
