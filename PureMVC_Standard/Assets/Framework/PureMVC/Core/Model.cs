//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using System.Collections.Concurrent;
using PureMVC.Interfaces;

namespace PureMVC.Core
{
    /// <summary>
    /// Model 核心类，所有Proxy 的持有者
    /// </summary>
    /// <seealso cref="PureMVC.Patterns.Proxy"/>
    /// <seealso cref="PureMVC.Interfaces.IProxy" />
    public class Model : IModel
    {
        /// <summary>
        /// Model构造函数，初始化持有Proxy对应的Map 并执行 InitializeModel函数
        /// </summary>
        public Model()
        {
            if (instance != null) throw new Exception(SingletonMsg);
            instance = this;
            proxyMap = new ConcurrentDictionary<string, IProxy>();
            InitializeModel();
        }

        /// <summary>
        /// Model 初始化函数
        /// </summary>
        protected virtual void InitializeModel()
        {
        }

        /// <summary>
        /// 获取Model的单例实例
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static IModel GetInstance(Func<IModel> factory)
        {
            if (instance == null)
            {
                instance = factory();
            }
            return instance;
        }

        /// <summary>
        /// 注册对应的Proxy
        /// </summary>
        /// <param name="proxy"></param>
        public virtual void RegisterProxy(IProxy proxy)
        {
            proxyMap[proxy.ProxyName] = proxy;
            proxy.OnRegister();
        }

        /// <summary>
        /// 检索对应的Proxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        public virtual IProxy RetrieveProxy(string proxyName)
        {
            return proxyMap.TryGetValue(proxyName, out var proxy) ? proxy : null;
        }

        /// <summary>
        /// 移除对应的Proxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        public virtual IProxy RemoveProxy(string proxyName)
        {
            if (proxyMap.TryRemove(proxyName, out var proxy))
            {
                proxy.OnRemove();
            }
            return proxy;
        }

        /// <summary>
        /// 检查是否含有指定的Proxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        public virtual bool HasProxy(string proxyName)
        {
            return proxyMap.ContainsKey(proxyName);
        }

        /// <summary>
        /// 持有所有Proxy的map
        /// </summary>
        protected readonly ConcurrentDictionary<string, IProxy> proxyMap;

        /// <summary>
        /// Modle单例对应的实例
        /// </summary>
        protected static IModel instance;

        /// <summary>Modle单例检测错误返回的信息</summary>
        protected const string SingletonMsg = "Model Singleton already constructed!";
    }
}
