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
        /// 推送控制消息
        /// </summary>
        /// <param name="message">消息内容</param>
        void PushControl(string message);

        /// <summary>
        /// 推送状态反馈消息
        /// </summary>
        /// <param name="message">消息内容</param>
        void PushFeedback(string message);

        /// <summary>
        /// 推送特殊指令
        /// </summary>
        /// <param name="message">消息内容</param>
        void PushSpecial(string message);
    }
}
