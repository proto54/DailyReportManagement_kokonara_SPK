using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashboardSample.ChildForm
{
    using Utility;
    using DailyReportModels.Models;
    using DBControlLibrary;
    using DBControlLibrary.Entities;

    /// <summary>
    /// 固定時間編集の画面クラスです
    /// </summary>
    public partial class ChildFormFixedTimeEditor : ChildFormBase
    {
        #region フィールド
        /// <summary>
        /// 固定時間の一覧を保持します。
        /// </summary>
        //private List<FixedTimeModel> _FixedTimeDataList = new List<FixedTimeModel>();
        private SortableBindingList<FixedTimeModel> _FixedTimeDataList = new SortableBindingList<FixedTimeModel>();
        
        #endregion フィールド

        #region プロパティ
        #endregion プロパティ

        #region メソッド
        #endregion メソッド


        /// <summary>
        /// 固定時間編集画面の新しいインスタンスを構築します。
        /// </summary>
        /// 
        public ChildFormFixedTimeEditor()
        {
            InitializeComponent();

            base.lblTitle.Text = "固定時間編集";
            base.btnClose.Visible = false;
        }

        /// <summary>
        /// FormLoadイベント処理します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChildFormFixedTimeEditor_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        /// <summary>
        /// FormClosingイベントを処理します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChildFormFixedTimeEditor_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// フォームが最初に表示された時のイベントを処理します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChildFormFixedTimeEditor_Shown(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 追加ボタンのクリックイベントを処理します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.AddFixedTime();
        }

        /// <summary>
        /// 更新ボタンのクリックイベントを処理します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 削除ボタンのクリックイベントを処理します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初期化処理をします。
        /// </summary>
        private void Initialize()
        {

            // バインドの設定
            fixedTimeModelBindingSource.DataSource = _FixedTimeDataList;


            this.GetFixedTimeAll();
        }

        /// <summary>
        /// 固定時間をDBから全件取得し、リストを更新します。
        /// </summary>
        private void GetFixedTimeAll()
        {
            // カーソルを待機状態にする
            Cursor.Current = Cursors.WaitCursor;

            var result = DataServiceFacade.Instance.GetFixedTimeData().ToList();

            this._FixedTimeDataList.Clear();

            result.ForEach(x => this._FixedTimeDataList.Add(
                            new FixedTimeModel {
                                Id = x.Id,
                                FixedTimeValue = x.FixedTimeValue,
                                Name = x.Name,
                                FixedNumber = x.FixedNumber
                            }));

            this.fixedTimeModelBindingSource.ResetBindings(false);

            // カーソルを元に戻す
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 固定時間をDBに登録します。
        /// </summary>
        private void AddFixedTime()
        {
            // カーソルを待機状態にする
            Cursor.Current = Cursors.WaitCursor;

            DataServiceFacade.Instance.AddFixedTimeData(new FixedTimeModel()
            {
                FixedTimeValue = 30,
                Name = "休憩",
                FixedNumber = 1
            });
            
            // カーソルを元に戻す
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateFixedTimeList()
        {
            // カーソルを待機状態にする
            Cursor.Current = Cursors.WaitCursor;

            // カーソルを元に戻す
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// IDを指定して固定時間 データをDBから削除します。
        /// </summary>
        /// <param name="id"></param>
        private void RemoveFixedTime(int id)
        {
            // カーソルを待機状態にする
            Cursor.Current = Cursors.WaitCursor;

            // カーソルを元に戻す
            Cursor.Current = Cursors.Default;
        }
    }
}
