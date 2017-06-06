using System;
using System.Collections.Generic;

namespace Sediment.Event
{
    /// <summary>
    /// 事件发布器
    /// </summary>
    public class EventPublisher
    {
        /// <summary>
        /// 订阅的事件集合（事件名称、事件处理方法映射集合）
        /// </summary>
        public static Dictionary<string, EventHandler<EventArgs>> Handlers;

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TSender">触发事件的实体泛型</typeparam>
        /// <param name="eventName">事件名称</param>
        /// <param name="sender">触发事件的实体</param>
        /// <param name="args">事件参数</param>
        public static void Publish<TSender>(string eventName, TSender sender, EventArgs args = null)
        {
            var handlerKey = sender.GetType().FullName + "." + eventName;
            if (Handlers != null && Handlers[handlerKey] != null)
            {
                Handlers[handlerKey](sender, args);
            }
        }
    }
}
