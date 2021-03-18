using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBControlLibrary.Converters;
using DBControlLibrary.Entities;

namespace DBControlLibrary.Context
{
    using Core;

    /// <summary>
    /// Entity Frameworkを使った[固定時間]を操作する機能を提供します。
    /// </summary>
    public sealed class ContextFixedTime
    {
        /// <summary>
        /// エンティテイを追加します
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Add(FixedTimeEntitie data)
        {
            int ret = 0;

            using (var context = new FixedTimesDbContext())
            {
                context.FixedTimeEntities.Add(data);
                ret = context.SaveChanges();
                //context.Dispose();
            }

            return ret;
        }

        /// <summary>
        /// エンティテイを追加します
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public int Add(IEnumerable<FixedTimeEntitie> datas)
        {
            int ret = 0;

            using (var context = new FixedTimesDbContext())
            {
                datas.ForEach(x =>
                {
                    context.FixedTimeEntities.Add(x);
                });
                ret = context.SaveChanges();
            }

            return ret;
        }


        /// <summary>
        /// エンティテイを全件取得します。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FixedTimeEntitie> GetAll()
        {
            return GetAll(false);
        }

        /// <summary>
        /// エンティテイを全件取得します。
        /// </summary>
        /// <param name="isNoTracking">トラッキング無しで読み取るかのフラグ。
        /// 大量のデータを読み出すと、メモリ不足に陥る場合は、tureにするとパフォーマンスが向上する場合があります。但し読み出し専用となる</param>
        /// <returns></returns>
        public IEnumerable<FixedTimeEntitie> GetAll(bool isNoTracking)
        {
            IEnumerable<FixedTimeEntitie> result;

            var context = new FixedTimesDbContext();
            try
            {
                if (isNoTracking)
                {
                    result = context.FixedTimeEntities
                        .AsNoTracking()
                        .ToList();
                }
                else
                {
                    result = context.FixedTimeEntities
                        .ToList();
                }

                //foreach (var x in result)
                //{
                //    Console.WriteLine("{0},{1},{2},{3}", x.Id, x.Name, x.FixedTimeValue, x.FixedNumber);
                //}
            }
            finally
            {
                context.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 指定したIDのエンティティを削除します。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RemoveAt(int id)
        {
            int ret = 0;

            using (var context = new FixedTimesDbContext())
            {
                //var entitie = context.FixedTimeEntities.Single(x => x.Id == id);
                //context.FixedTimeEntities.Remove(entitie);
                var removeEntitie = new FixedTimeEntitie { Id = id };
                context.FixedTimeEntities.Attach(removeEntitie);
                context.FixedTimeEntities.Remove(removeEntitie);
                ret = context.SaveChanges();
            }

            return ret;
        }

        /// <summary>
        /// 全てのエンティティを削除します。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RemoveAll()
        {
            int ret = 0;

            using (var context = new FixedTimesDbContext())
            {
                var data = context.FixedTimeEntities.ToArray();
                context.FixedTimeEntities.RemoveRange(data);
                ret = context.SaveChanges();
            }

            return ret;
        }
    }
}
