//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// PureMVC Mediator 接口
    /// </summary>
    /// <seealso cref="INotification"/>
    public interface IMediator : INotifier
    {
        /// <summary>
        /// 对应Mediator 的名称
        /// </summary>
        string MediatorName { get; }

        /// <summary>
        /// Mediator 对应的 UI 
        /// </summary>
        object ViewComponent { get; set; }

        /// <summary>
        /// 此Mediator需要接受的消息数组
        /// </summary>
        /// <returns></returns>
        string[] ListNotificationInterests();

        /// <summary>
        /// 处理此Mediator 接受所有消息的函数
        /// </summary>
        /// <param name="notification"></param>
        void HandleNotification(INotification notification);

        /// <summary>
        /// Mediaotor被注册时触发的函数
        /// </summary>
        void OnRegister();

        /// <summary>
        /// Mediator被注销时触发的函数
        /// </summary>
        void OnRemove();
    }
}
