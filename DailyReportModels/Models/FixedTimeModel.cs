using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyReportModels.Models
{
    /// <summary>
    /// 固定時間 データの情報を提供します
    /// </summary>
    public sealed class FixedTimeModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 固定時間値
        /// </summary>
        public int FixedTimeValue { set; get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 固定番号
        /// </summary>
        public int FixedNumber { set; get; }
    }
}
