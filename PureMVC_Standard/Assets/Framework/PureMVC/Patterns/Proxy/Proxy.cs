//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Proxy
{
    /// <summary>
    /// IProxy 实例
    /// <seealso cref="PureMVC.Core.Model"/>
    public class Proxy : Notifier, IProxy
    {
        /// <summary> Name of the proxy</summary>
        public const string NAME = "Proxy";

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="proxyName"></param>
        /// <param name="data"></param>
        public Proxy(string proxyName, object data = null)
        {
            ProxyName = proxyName ?? NAME;
            if (data != null) Data = data;
        }

        /// <summary>
        /// 注册Proxy时的回调
        /// </summary>
        public virtual void OnRegister()
        {
        }

        /// <summary>
        /// 注销Proxy时的回调
        /// </summary>
        public virtual void OnRemove()
        {
        }

        /// <summary>Proxy 名称</summary>
        public string ProxyName { get; protected set; }

        /// <summary>Proxy 持有的数据</summary>
        public object Data { get; set; }
    }
}
