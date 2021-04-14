using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using DailyReportModels.Models;
using DBControlLibrary.Entities;
using DBControlLibrary.Converters;
using DBControlLibrary.Context;
using System.Data.SqlClient;

namespace DBControlLibrary
{
    /// <summary>
    /// DBへのデータアクセスへの窓口を提供します
    /// </summary>
    public class DataServiceFacade : IDisposable
    {
        #region フィールド
        private readonly string Log_Key = "DG";

        /// <summary>
        /// データソースへの接続文字列を取得します。
        /// </summary>
        private string _ConnectionString = string.Empty;

        /// <summary>
        /// DBを操作するオブジェクトを保持します。
        /// </summary>
        private DapperMapper _Connection;

        /// <summary>
        /// 固定時間テーブルを操作するインスタンスを保持します。
        /// </summary>
        private ContextFixedTime _ContextFixedTime;

        /// <summary>
        /// 同期制御オブジェクト
        /// </summary>
        private readonly object _Lock = new object();

        #endregion フィールド

        #region プロパティ
        /// <summary>
        /// 初期化済み有無を取得します。
        /// </summary>
        public bool IsInitialized { get; private set; }

        /// <summary>
        /// 唯一のインスタンスを取得します。
        /// </summary>
        public static DataServiceFacade Instance { get; } = new DataServiceFacade();

        #endregion プロパティ

        /// <summary>
        /// 非公開コンストラクタ―です。
        /// </summary>
        private DataServiceFacade()
            : base()
        {
        }

        /// <summary>
        /// 初期化処理を実施します
        /// </summary>
        public void Initialize(string connectionString)
        {
            if (this.IsInitialized) return;

            this._ConnectionString = connectionString;

            // 接続クラスの初期化
            var conection = new SqlConnection(this._ConnectionString);
            _Connection = new DapperMapper(conection);

            // 各インスタンスの初期化
            this._ContextFixedTime = new ContextFixedTime(_Connection);
            // TODO:以下にテーブルを操作するインスタンスを初期化するコードを記述する



            this.IsInitialized = true;
        }

        /// <summary>
        /// DBとの接続を開きます。
        /// </summary>
        public void Open()
        {
            this.ThrowIfUnInitialized();
            try
            {
                _Connection.Open();
            }
            catch(Exception ex)
            {
                this.WriteLog(MethodBase.GetCurrentMethod(), ex.Message);
                throw;
            }
        }

        /// <summary>
        /// DBとの接続を切断します。
        /// </summary>
        public void Close()
        {
            this.ThrowIfUnInitialized();
            try
            {
                _Connection.Close();
            }
            catch (Exception ex)
            {
                this.WriteLog(MethodBase.GetCurrentMethod(), ex.Message);
                throw;
            }
        }

        #region "追加"
        /// <summary>
        /// 固定時間 データを DB に登録します。
        /// </summary>
        /// <param name="data"></param>
        public void AddFixedTimeData(FixedTimeModel data)
        {
            this.ThrowIfUnInitialized();

            try
            {
                int ret = 0;
                Lock(() => ret = _ContextFixedTime.Add(data.ToFixedTimeEntitie()));

                var msg = String.Format("{0}を{1}件追加しました。", nameof(FixedTimeModel), ret);
                this.WriteLog(MethodBase.GetCurrentMethod(), msg);
            }
            catch (Exception ex)
            {
                this.WriteLog(MethodBase.GetCurrentMethod(), ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 固定時間 データを DB に登録します。
        /// </summary>
        /// <param name="datas"></param>
        public void AddFixedTimeData(IEnumerable<FixedTimeModel> datas)
        {
            this.ThrowIfUnInitialized();

            try
            {
                int ret = 0;
                Lock(() => ret = _ContextFixedTime.Add(datas.ToFixedTimeEntitie()));

                var msg = String.Format("{0}を{1}件追加しました。", nameof(FixedTimeModel), ret);
                this.WriteLog(MethodBase.GetCurrentMethod(), msg);
            }
            catch (Exception ex)
            {
                this.WriteLog(MethodBase.GetCurrentMethod(), ex.Message);
                throw;
            }
        }

        #endregion "追加"

        #region "更新"
        /// <summary>
        /// 固定時間 テーブルを更新します。
        /// </summary>
        /// <param name="data"></param>
        public void UpdateFixedTimeData(FixedTimeModel data)
        {
            this.ThrowIfUnInitialized();

            try
            {
                int ret = 0;
                Lock(() => _ContextFixedTime.Update(data.ToFixedTimeEntitie()));

                var msg = String.Format("{0}を{1}件更新しました。", nameof(FixedTimeModel), ret);
                this.WriteLog(MethodBase.GetCurrentMethod(), msg);
            }
            catch (Exception ex)
            {
                this.WriteLog(MethodBase.GetCurrentMethod(), ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 固定時間 テーブルを更新します。
        /// </summary>
        /// <param name="data"></param>
        public void UpdateFixedTimeData(IEnumerable<FixedTimeModel> datas)
        {
            this.ThrowIfUnInitialized();

            try
            {
                int ret = 0;
                Lock(() => ret = _ContextFixedTime.Update(datas.ToFixedTimeEntitie()));

                var msg = String.Format("{0}を{1}件更新しました。", nameof(FixedTimeModel), ret);
                this.WriteLog(MethodBase.GetCurrentMethod(), msg);
            }
            catch (Exception ex)
            {
                this.WriteLog(MethodBase.GetCurrentMethod(), ex.Message);
                throw;
            }
        }

        #endregion "更新"

        #region "取得"
        /// <summary>
        /// 固定時間 データを全件データを取得します。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FixedTimeModel> GetFixedTimeData()
        {
            this.ThrowIfUnInitialized();

            try
            {
                this.Open();

                return _ContextFixedTime.GetAll()
                    .ToList()
                    .ToFixedTimeModel();
            }
            catch(Exception ex)
            {
                this.WriteLog(MethodBase.GetCurrentMethod(), ex.Message);
                throw;
            }
            finally
            {
                this.Close();
            }
        }
        #endregion "取得"

        #region "削除"
        /// <summary>
        /// IDを指定して 固定時間 データを削除します。
        /// </summary>
        public void RemoveFixedTime(int id)
        {
            this.ThrowIfUnInitialized();
            try
            {
                int ret = 0;
                Lock(() => ret = _ContextFixedTime.RemoveAt(id) );

                var msg = String.Format("{0}を{1}件削除しました。", nameof(FixedTimeModel), ret);
                this.WriteLog(MethodBase.GetCurrentMethod(), msg);
            }
            catch (Exception ex)
            {
                this.WriteLog(MethodBase.GetCurrentMethod(), ex.Message);
                throw;
            }
        }
        #endregion "削除"

        #region "Lock"
        /// <summary>
        /// ロックを囲って処理を制御します。
        /// </summary>
        /// <param name="action">実施する処理を指定します。</param>
        /// <returns></returns>
        private bool Lock(Action action)
        {
            lock (this._Lock)
            {
                try
                {
                    this.Open();

                    action();

                    return true;
                }
                catch(Exception ex)
                {
                    this.WriteLog(MethodBase.GetCurrentMethod(), ex.Message);
                    throw;
                    //return false;
                }
                finally
                {
                    this.Close();
                }
            }
        }
        #endregion "Lock"

        /// <summary>
        /// 初期化済みをチェックします。
        /// </summary>
        private void ThrowIfUnInitialized()
        {
            if (this.IsInitialized == false) throw new Exception(nameof(DataServiceFacade) + " 未初期化");
        }

        private void WriteLog(MethodBase methodBase, string msg)
        {
            var outMsg = String.Format("{0},{1},{2}(),{3},{4}", DateTime.Now.ToString("HH:mm:ss.fff"), methodBase.DeclaringType.FullName, methodBase.Name, Log_Key, msg);
            Console.WriteLine(outMsg);
        }

        public void Dispose()
        {
            ((IDisposable)_Connection).Dispose();
        }
    }
}
