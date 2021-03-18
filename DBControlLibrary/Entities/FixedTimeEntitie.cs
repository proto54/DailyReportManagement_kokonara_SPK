using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBControlLibrary.Entities
{
    /// <summary>
    /// 固定時間のエンティティを提供します
    /// </summary>
    public sealed class FixedTimeEntitie
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 固定時間値
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required]
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
