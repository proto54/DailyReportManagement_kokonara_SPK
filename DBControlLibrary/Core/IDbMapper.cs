using System;
using System.Collections.Generic;
using System.Data;

namespace DBControlLibrary.Core
{
    /// <summary>
    /// SQL ステートメントを直接扱う Micro-ORM のインターフェイスを提供します。
    /// </summary>
    public interface IDbMapper : IDisposable
    {
        #region "プロパティ"
        /// <summary>
        /// データソースへ接続するオブジェクトを取得します。
        /// </summary>
        IDbConnection Connection { get; }
        #endregion "プロパティ"

        #region "メソッド"
        /// <summary>
        /// データベース接続を開きます。
        /// </summary>
        void Open();

        /// <summary>
        /// データベース接続を閉じます。
        /// </summary>
        void Close();
        /// <summary>
        /// 指定した SQL ステートメントを実行して、その結果を取得します。
        /// </summary>
        /// <typeparam name="T">戻り値の型を指定します。</typeparam>
        /// <param name="commandText">SQL ステートメントを指定します。</param>
        /// <param name="parameter">実行時のパラメーター オブジェクトを指定します。</param>
        /// <param name="commandType"><paramref name="commandText"/> の解釈方法を指定します。</param>
        /// <returns>実行結果を返します。</returns>
        T ExecuteScalar<T>(string commandText, object parameter = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 指定した SQL ステートメントを実行して、その結果を取得します。
        /// </summary>
        /// <param name="commandText">SQL ステートメントを指定します。</param>
        /// <param name="parameter">実行時のパラメーター オブジェクトを指定します。</param>
        /// <param name="commandType"><paramref name="commandText"/> の解釈方法を指定します。</param>
        /// <returns>実行結果を返します。</returns>
        int Execute(string commandText, object parameter = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 指定した SQL ステートメントを実行して、その結果を取得します。
        /// </summary>
        /// <typeparam name="T">エンティティの型を指定します。</typeparam>
        /// <param name="commandText">SQL ステートメントを指定します。</param>
        /// <param name="parameter">実行時のパラメーター オブジェクトを指定します。</param>
        /// <param name="commandType"><paramref name="commandText"/> の解釈方法を指定します。</param>
        /// <returns>実行結果を返します。</returns>
        IEnumerable<T> Query<T>(string commandText, object parameter = null, CommandType commandType = CommandType.Text)
            where T : new();

        #endregion "メソッド"
    }
}
