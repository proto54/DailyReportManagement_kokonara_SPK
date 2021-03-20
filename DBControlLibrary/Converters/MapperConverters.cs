using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyReportModels.Models;
using DBControlLibrary.Entities;

namespace DBControlLibrary.Converters
{
    using Core;
    public static class MapperConverters
    {
        /// <summary>
        /// 固定時間のデータオブジェクトを固定時間エンティティのオブジェクトに変換する機能を提供します。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static FixedTimeEntitie ToFixedTimeEntitie(this FixedTimeModel data)
        {
            if (data == null) throw new ArgumentNullException(nameof(MapperConverters) + "." + nameof(data));

            return new FixedTimeEntitie()
                        {
                            Id = data.Id,
                            FixedTimeValue = data.FixedTimeValue,
                            Name = data.Name,
                            FixedNumber = data.FixedNumber
                        };
        }

        /// <summary>
        /// 固定時間のエンティティオブジェクトを 固定時間のデータオブジェクトをに変換する機能を提供します。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IEnumerable<FixedTimeEntitie> ToFixedTimeEntitie(this IEnumerable<FixedTimeModel> data)
        {
            List<FixedTimeEntitie> result = new List<FixedTimeEntitie>();

            data.ForEach(x =>
            {
                result.Add(new FixedTimeEntitie
                {
                    Id = x.Id,
                    FixedTimeValue = x.FixedTimeValue,
                    Name = x.Name,
                    FixedNumber = x.FixedNumber
                });
            });

            return result.ToArray();
        }

        /// <summary>
        /// 固定時間のエンティティオブジェクトを 固定時間のデータオブジェクトをに変換する機能を提供します。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IEnumerable<FixedTimeModel> ToFixedTimeModel(this IEnumerable<FixedTimeEntitie> data)
        {
            List<FixedTimeModel> result = new List<FixedTimeModel>();

            data.ForEach(x =>
            {
                result.Add(new FixedTimeModel
                {
                    Id = x.Id,
                    FixedTimeValue = x.FixedTimeValue,
                    Name = x.Name,
                    FixedNumber = x.FixedNumber
                });
            });

            return result.ToArray();
        }
    }
}
