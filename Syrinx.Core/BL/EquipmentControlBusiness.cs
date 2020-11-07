using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Syrinx.Core.BL
{
    using Syrinx.Core.Entity;

    /// <summary>
    /// 设备控制对象业务类
    /// </summary>
    public class EquipmentControlBusiness
    {
        #region Methodd
        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public string Serialize(EquipmentControl entity)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return JsonSerializer.Serialize<EquipmentControl>(entity, serializeOptions);
        }
        #endregion //Method
    }
}
