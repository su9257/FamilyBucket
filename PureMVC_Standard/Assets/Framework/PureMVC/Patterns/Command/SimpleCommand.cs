//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Command
{
    /// <summary>
    /// 单命令类
    /// </summary>
    public class SimpleCommand : Notifier, ICommand
    {
        /// <summary>
        /// 此命令被调用时执行的函数
        /// </summary>
        /// <param name="notification"></param>
        public virtual void Execute(INotification notification)
        {
        }
    }
}
