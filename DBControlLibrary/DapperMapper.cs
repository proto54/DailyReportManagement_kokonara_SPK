using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using static Dapper.SqlMapper;

namespace DBControlLibrary
{
    using Core;
    using Dapper;

    /// <summary>
    /// Dapper を使用する Micro-ORM を提供します。
    /// </summary>
    public sealed class DapperMapper : IDapperMapper
    {
        #region "フィールド"
        /// <summary>
        /// データソースへ接続するオブジェクトを取得します。
        /// </summary>
        private readonly IDbConnection _Connection = null;

        /// <summary>
        /// データソースで実行するトランザクションを表します。
        /// </summary>
        private IDbTransaction _Transaction = null;

        /// <summary>
        /// コマンドを実行する試みを終了してエラーが生成されるまでの待機時間 (秒) を表します。
        /// <para>
        /// (既定値は 30 秒です)
        /// </para>
        /// </summary>
        private int _CommandTimeout = 30;
        #endregion "フィールド"

        #region "プロパティ"
        /// <summary>
        /// データ ソースへ接続するオブジェクトを取得します。
        /// </summary>
        public IDbConnection Connection { get { return this._Connection; } }
        #endregion "プロパティ"

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="connectionString"></param>
        public DapperMapper(IDbConnection connection)
        {

            this._Connection = connection;
        }

        /// <summary>
        /// リソースを開放します。
        /// </summary>
        #region "Dispose"
        public void Dispose()
        {
            if (this._Connection != null)
            {
                this._Connection.Close();
                this._Connection.Dispose();
            }

            if (this._Transaction != null)
            {
                this._Transaction.Dispose();
            }
        }
        #endregion "Dispose"

        #region "メソッド"
        /// <summary>
        /// データベース接続を開きます。
        /// </summary>
        public void Open()
        {
            this._Connection.Open();
        }

        /// <summary>
        /// データベース接続を閉じます。
        /// </summary>
        public void Close()
        {
            this._Connection.Close();
        }

        /// <summary>
        /// 指定した SQL ステートメントを実行して、その結果を取得します。
        /// </summary>
        /// <typeparam name="T">戻り値の型を指定します。</typeparam>
        /// <param name="commandText">SQL ステートメントを指定します。</param>
        /// <param name="parameter">実行時のパラメーター オブジェクトを指定します。</param>
        /// <param name="commandType"><paramref name="commandText"/> の解釈方法を指定します。</param>
        /// <returns>実行結果を返します。</returns>
        public T ExecuteScalar<T>(string commandText, object parameter = null, CommandType commandType = CommandType.Text)
        {
            if (string.IsNullOrWhiteSpace(commandText))
            {
                return default(T);
            }

            var result = this._Connection.ExecuteScalar<T>(
                  commandText
                , parameter
                , this._Transaction
                , this._CommandTimeout
                , commandType
                );
            return result;
        }

        /// <summary>
        /// 指定した SQL ステートメントを実行して、その結果を取得します。
        /// </summary>
        /// <param name="commandText">SQL ステートメントを指定します。</param>
        /// <param name="parameter">実行時のパラメーター オブジェクトを指定します。</param>
        /// <param name="commandType"><paramref name="commandText"/> の解釈方法を指定します。</param>
        /// <returns>実行結果を返します。</returns>
        public int Execute(string commandText, object parameter = null, CommandType commandType = CommandType.Text)
        {
            if(string.IsNullOrWhiteSpace(commandText))
            {
                return 0;
            }

            var result = this._Connection.Execute(
                  commandText
                , parameter
                , this._Transaction
                , this._CommandTimeout
                , commandType
                );
            return result;
        }

        /// <summary>
        /// 指定した SQL ステートメントを実行して、その結果を取得します。
        /// </summary>
        /// <param name="commandText">SQL ステートメントを指定します。</param>
        /// <param name="parameter">実行時のパラメーター オブジェクトを指定します。</param>
        /// <param name="commandType"><paramref name="commandText"/> の解釈方法を指定します。</param>
        public int ExecuteTransaction(string commandText, object parameter = null, CommandType commandType = CommandType.Text)
        {
            if (string.IsNullOrWhiteSpace(commandText))
            {
                return 0;
            }

            int result = 0; 
            // トランザクション開始
            using (var transaction = this._Connection.BeginTransaction())
            {
                try
                {
                    // 実行
                    result = this._Connection.Execute(
                            commandText
                        , parameter
                        , transaction
                        , this._CommandTimeout
                        , commandType
                        );

                    // コミット
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // ロールバック
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
            return result;
        }

        /// <summary>
        /// 指定した SQL ステートメントを実行して、その結果を取得します。
        /// </summary>
        /// <typeparam name="T">エンティティの型を指定します</typeparam>
        /// <param name="commandText">SQL ステートメントを指定します</param>
        /// <param name="parameter">実行時のパラメーター オブジェクトを指定します</param>
        /// <param name="commandType"><paramref name="commandText"/> の解釈方法を指定します</param>
        /// <returns>実行結果を返します</returns>
        public IEnumerable<T> Query<T>(string commandText, object parameter = null, CommandType commandType = CommandType.Text) where T : new()
        { 
            if (string.IsNullOrWhiteSpace(commandText))
            {
                return Enumerable.Empty<T>();
            }

            var result = this._Connection.Query<T>(
                  commandText
                , parameter
                , this._Transaction
                , commandTimeout: this._CommandTimeout
                , commandType: commandType
            );
            return result;
        }
        #endregion "メソッド"
    }
}
