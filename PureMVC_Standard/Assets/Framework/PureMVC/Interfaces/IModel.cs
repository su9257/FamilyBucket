//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// PureMVC Model 接口
    /// </summary>
    /// </remarks>
    public interface IModel
    {
        /// <summary>
        /// 注册 Proxy
        /// </summary>
        /// <param name="proxy"></param>
        void RegisterProxy(IProxy proxy);

        /// <summary>
        /// 检测对应的Proxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        IProxy RetrieveProxy(string proxyName);

        /// <summary>
        /// 注销对应的Proxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        IProxy RemoveProxy(string proxyName);

        /// <summary>
        /// 检查是否含有指定的Proxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        bool HasProxy(string proxyName);
    }
}
