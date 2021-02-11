//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// PureMVC Proxy 接口
    /// </summary>
    public interface IProxy : INotifier
    {
        /// <summary>
        /// Proxy 名称
        /// </summary>
        string ProxyName { get; }

        /// <summary>
        /// Proxy 持有对应的数据
        /// </summary>
        object Data { get; set; }

        /// <summary>
        /// 注册 Proxy 时触发此函数
        /// </summary>
        void OnRegister();

        /// <summary>
        /// 注销 Proxy 时触发此函数
        /// </summary>
        void OnRemove();
    }
}
