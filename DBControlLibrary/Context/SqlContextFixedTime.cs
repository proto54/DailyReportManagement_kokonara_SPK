using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using DBControlLibrary.Entities;

namespace DBControlLibrary.Context
{
    using DBControlLibrary.Dapper;
    using Utility;

    /// <summary>
    /// SqlClientを使った[固定時間テーブル]を操作する機能を提供します。
    /// </summary>

    public sealed class SqlContextFixedTime
    {
        /// <summary>
        /// DBを操作するオブジェクトを保持します。
        /// </summary>
        private readonly IDapperMapper _Connection = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="connection"></param>
        public SqlContextFixedTime(DapperMapper connection)
        {
            _Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        /// <summary>
        /// エンティテイを全件取得します。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FixedTimeEntitie> GetAll()
        {
            // TODO:SQLクエリーを記載
            var query = @"
                SELECT *
                FROM
                    dbo.FixedTimeEntities
                ";

            var result = this._Connection.Query<FixedTimeEntitie>(query);

            return result;
        }

        /// <summary>
        /// エンティテイを追加します
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Add(FixedTimeEntitie data)
        {
            // TODO:SQLクエリーを記載
            var query = @"
                INSERT INTO
                    dbo.FixedTimeEntities
                    values(@FixedTimeValue, @Name, @FixedNumber)
                ";


            var result = this._Connection.Execute(query, data);

            return result;
        }

        /// <summary>
        /// エンティテイを追加します
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public int Add(IEnumerable<FixedTimeEntitie> datas)
        {
            int result = 0;

            datas.ForEach(x =>
            {
                // TODO:SQLクエリーを記載
                var query = @"
                INSERT INTO
                    dbo.FixedTimeEntities
                    values(@FixedTimeValue, @Name, @FixedNumber)
                ";

                result += this._Connection.Execute(query, x);
            });

            return result;
        }

        public int Update(FixedTimeEntitie data)
        {
            int result = 0;

            // TODO:SQLクエリーを記載
            var query = @"
                ";

            return result;
        }

        /// <summary>
        /// エンティティを更新します。
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public int Update(IEnumerable<FixedTimeEntitie> datas)
        {
            int result = 0;

            // TODO:SQLクエリーを記載
            var query = @"
                ";

            return result;
        }

        /// <summary>
        /// 指定したIDのエンティティを削除します。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RemoveAt(int id)
        {
            int result = 0;

            // TODO:SQLクエリーを記載
            var query = @"
                ";

            return result;
        }

        /// <summary>
        /// 全てのエンティティを削除します。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RemoveAll()
        {
            var query = @"
                DELETE FROM
                    dbo.FixedTimeEntities a
                where 1 = 1
                ";

            var result = this._Connection.Execute(query);
            return result;
        }
    }
}
