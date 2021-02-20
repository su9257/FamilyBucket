//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using PureMVC.Interfaces;

namespace PureMVC.Patterns.Observer
{
    /// <summary>
    /// INotification 实例
    /// </summary>
    /// <seealso cref="PureMVC.Patterns.Observer.Observer"/>
    public class Notification: INotification
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="body"></param>
        /// <param name="type"></param>
        public Notification(string name, object body = null, string type = null)
        {
            Name = name;
            Body = body;
            Type = type;
        }

        /// <summary>
        /// 获取此 Notification 信息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var msg = "Notification Name: " + Name;
            msg += "\nBody:" + ((Body == null) ? "null" : Body.ToString());
            msg += "\nType:" + ((Type == null) ? "null" : Type);
            return msg;
        }

        /// <summary>消息体 名称</summary>
        public string Name { get; }

        /// <summary>消息体 需要传的参数</summary>
        public object Body { get; set; }

        /// <summary>消息体 类别</summary>
        public string Type { get; set; }
    }
}
