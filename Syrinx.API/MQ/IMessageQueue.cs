using System;
using System.Collections.Generic;
using System.Text;

namespace Syrinx.API.MQ
{
    /// <summary>
    /// 消息队列接口
    /// </summary>
    public interface IMessageQueue
    {
        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="message">消息内容</param>
        void Push(string message);
    }
}
