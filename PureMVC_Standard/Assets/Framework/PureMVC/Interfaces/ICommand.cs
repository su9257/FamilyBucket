//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// PureMVC Command 接口，创建的命令都继承于此接口
    /// </summary>
    /// <seealso cref="INotification"/>
    public interface ICommand : INotifier
    {
        /// <summary>
        /// 接收消息通知时会自动触发此函数
        /// </summary>
        /// <param name="notification">传入INotification通知类型</param>
        void Execute(INotification notification);
    }
}
