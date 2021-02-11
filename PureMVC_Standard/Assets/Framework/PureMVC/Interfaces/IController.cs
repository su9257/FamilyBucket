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
    /// PureMVC Controller 接口，负责注册、注销、检测是否含有command 操作
    /// </summary>
    /// <seealso cref="INotification"/>
    /// <seealso cref="ICommand"/>
    public interface IController
    {
        /// <summary>
        /// 注册命名
        /// </summary>
        /// <param name="notificationName">the name of the <c>INotification</c></param>
        /// <param name="factory">the FuncDelegate of the <c>ICommand</c></param>
        void RegisterCommand(string notificationName, Func<ICommand> factory);

        /// <summary>
        /// Execute the <c>ICommand</c> previously registered as the
        /// handler for <c>INotification</c>s with the given notification name.
        /// </summary>
        /// <param name="notification">the <c>INotification</c> to execute the associated <c>ICommand</c> for</param>
        void ExecuteCommand(INotification notification);

        /// <summary>
        /// 注销命名
        /// </summary>
        /// <param name="notificationName">the name of the <c>INotification</c> to remove the <c>ICommand</c> mapping for</param>
        void RemoveCommand(string notificationName);

        /// <summary>
        /// 检车是否有指定命令消息已经注册
        /// </summary>
        /// <param name="notificationName">需要检测对应的命令的消息名称</param>
        /// <returns></returns>
        bool HasCommand(string notificationName);
    }
}
