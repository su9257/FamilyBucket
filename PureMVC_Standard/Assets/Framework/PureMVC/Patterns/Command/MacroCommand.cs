//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Command
{
    /// <summary>
    /// 多个命令绑定的命令
    /// </summary>
    /// <seealso cref="PureMVC.Core.Controller"/>
    /// <seealso cref="PureMVC.Patterns.Observer.Notification"/>
    /// <seealso cref="PureMVC.Patterns.Command.SimpleCommand"/>
    public class MacroCommand : Notifier, ICommand
    {
        /// <summary>
        /// 初始化命令列表，并执行初始化函数
        /// </summary>
        public MacroCommand()
        {
            subcommands = new List<Func<ICommand>>();
            InitializeMacroCommand();
        }

        /// <summary>
        /// 初始化此命令的函数，一般执行多个命令的绑定
        /// override void InitializeMacroCommand() 
        /// {
        ///     AddSubCommand(() => new com.me.myapp.controller.FirstCommand());
        ///     AddSubCommand(() => new com.me.myapp.controller.SecondCommand());
        ///     AddSubCommand(() => new com.me.myapp.controller.ThirdCommand());
        /// }
        /// </summary>
        protected virtual void InitializeMacroCommand()
        {
        }

        /// <summary>
        /// 用于向此命令添加多个命的函数
        /// </summary>
        /// <param name="factory"></param>
        protected void AddSubCommand(Func<ICommand> factory)
        {
            subcommands.Add(factory);
        }

        /// <summary>
        /// 执行此命令绑定的所有命令
        /// </summary>
        /// <param name="notification"></param>
        public virtual void Execute(INotification notification)
        {
            while (subcommands.Count > 0)
            {
                var factory = subcommands[0];
                var commandInstance = factory();
                commandInstance.Execute(notification);
                subcommands.RemoveAt(0);
            }
        }

        /// <summary>
        /// 此命令绑定的所有命令列表
        /// </summary>
        public readonly IList<Func<ICommand>> subcommands;
    }
}
