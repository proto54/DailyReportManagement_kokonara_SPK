using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBControlLibrary.Converters;
using DBControlLibrary.Entities;

namespace DBControlLibrary.Context
{
    using System.Data.Entity.Infrastructure;
    using Utility;

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
                context.FixedTimeEntities.AddRange(datas);
                ret = context.SaveChanges();
            }

            return ret;
        }

        /// <summary>
        /// エンティティを更新します。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Update(FixedTimeEntitie data)
        {
            int ret = 0;

            using (var context = new FixedTimesDbContext())
            {
                var fixedTime = context.FixedTimeEntities.Single(x => x.Id == data.Id);
                fixedTime.FixedTimeValue = data.FixedTimeValue;
                fixedTime.Name = data.Name;
                fixedTime.FixedNumber = data.FixedNumber;
                
                ret = context.SaveChanges();
            }

            return ret;
        }

        /// <summary>
        /// エンティティを更新します。
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public int Update(IEnumerable<FixedTimeEntitie> datas)
        {
            int ret = 0;

            using (var context = new FixedTimesDbContext())
            {
                datas.ForEach(data =>
                {
                   var fixedTime = context.FixedTimeEntities.Single(x => x.Id == data.Id);
                    if (fixedTime != null)
                    {
                        fixedTime.FixedTimeValue = data.FixedTimeValue;
                        fixedTime.Name = data.Name;
                        fixedTime.FixedNumber = data.FixedNumber;
                    }

                });
                ret += context.SaveChanges();
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
            IEnumerable<FixedTimeEntitie> result = null;

            using (var context = new FixedTimesDbContext())
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

        /// <summary>
        /// SqlQueryを実行します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DbRawSqlQuery<T> SqlQuery<T>(string sql, object[] parameters)
        {
            var context = new FixedTimesDbContext();
            try
            {
                return context.Database.SqlQuery<T>(sql, parameters);
            }
            finally
            {
                context.Dispose();
            }
        }

        /// <summary>
        /// ExecuteSqlCommandを実行します。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteSqlCommand(string sql, object[] parameters)
        {
            int ret = 0;

            using (var context = new FixedTimesDbContext())
            {

                ret = context.Database.ExecuteSqlCommand(sql, parameters);
            }

            return ret;
        }
    }
}
