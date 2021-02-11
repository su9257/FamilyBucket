//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// Notification 对应的接口
    /// </summary>
    /// <seealso cref="IView"/>
    /// <seealso cref="IObserver"/>
    public interface INotification
    {
        /// <summary>
        /// 消息的名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 消息体（此消息需要传递的参数）
        /// </summary>
        object Body { get; set; }

        /// <summary>
        /// 消息类别，用于鉴别消息的唯一ID
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// 消息体对应的信息
        /// </summary>
        /// <returns>String representation</returns>
        string ToString();
    }
}
