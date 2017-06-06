using System;
using System.Collections.Generic;

namespace Sediment.Event
{
    /// <summary>
    /// 事件订阅器接口
    /// </summary>
    public interface IEventSubscriber
    {
        void Subscribe();
    }

    /// <summary>
    /// 单事件订阅器，使用此订阅器只能订阅实体的单一事件
    /// </summary>
    /// <typeparam name="TSender">触发事件的实体泛型</typeparam>
    public abstract class EventSubscriber<TSender>: IEventSubscriber
    {
        /// <summary>
        /// 事件名称
        /// </summary>
        protected abstract string EventName { get; }

        /// <summary>
        /// 订阅事件
        /// </summary>
        public void Subscribe()
        {
            if (EventPublisher.Handlers == null)
            {
                EventPublisher.Handlers = new Dictionary<string, EventHandler<EventArgs>>();
            }

            var handlerKey = (typeof(TSender)).FullName + "." + EventName;
            EventPublisher.Handlers[handlerKey] += Handle;
        }

        /// <summary>
        /// 事件处理方法
        /// </summary>
        /// <param name="sender">触发事件的实体</param>
        /// <param name="args">事件参数</param>
        protected abstract void Handle(object sender, EventArgs args);
    }

    /// <summary>
    /// 多事件订阅器，使用此订阅器可订阅实体的多个事件
    /// </summary>
    /// <typeparam name="TSender">触发事件的实体泛型</typeparam>
    public abstract class MultiEventSubscriber<TSender> : IEventSubscriber
    {
        /// <summary>
        /// 事件名称、事件处理方法集合
        /// 同一事件可添加多个事件处理方法
        /// </summary>
        protected abstract Tuple<string, EventHandler<EventArgs>>[] Maps { get; }

        /// <summary>
        /// 订阅事件
        /// </summary>
        public void Subscribe()
        {
            if (EventPublisher.Handlers == null)
            {
                EventPublisher.Handlers = new Dictionary<string, EventHandler<EventArgs>>();
            }

            if (Maps == null || Maps.Length == 0)
            {
                throw new Exception("事件，事件处理方法映射集合不能为空");
            }

            foreach (var map in Maps)
            {
                var handlerKey = (typeof(TSender)).FullName + "." + map.Item1;

                if (EventPublisher.Handlers.ContainsKey(handlerKey))
                {
                    EventPublisher.Handlers[handlerKey] += map.Item2;
                }
                else
                {
                    EventPublisher.Handlers.Add(handlerKey, map.Item2);
                }
            }
        }
    }

    /// <summary>
    /// 用于订阅所有初始事件的静态订阅器
    /// </summary>
    public static class EventSubscriber
    {
        /// <summary>
        /// 订阅所有初始事件
        /// </summary>
        public static void SubscribAll()
        {
            // 通过IoC解析所有订阅器，并调用其订阅方法
            //var subscribers = DIContainer.ResolveAll<IEventSubscriber>();
            //if (subscribers != null)
            //{
            //    foreach (var subscriber in subscribers)
            //    {
            //        subscriber.Subscribe();
            //    }
            //}
        }
    }
}
