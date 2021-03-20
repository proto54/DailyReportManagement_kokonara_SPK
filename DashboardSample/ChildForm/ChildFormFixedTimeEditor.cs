using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
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

        /// <summary>
        /// 入力モデルを保持します。
        /// </summary>
        private FixedTimeModel _InputModel = new FixedTimeModel();


        /// <summary>
        /// ファイル開くダイアログのインスタンスを保持します。
        /// </summary>
        private OpenFileDialog _openFileDialog = new OpenFileDialog() { CheckFileExists = true, CheckPathExists = true };

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
            Application.DoEvents();

            // リストを更新します
            this.GetFixedTimeAll();
        }

        /// <summary>
        /// 追加ボタンのクリックイベントを処理します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // DBに登録
            this.AddFixedTime(_InputModel.FixedTimeValue, _InputModel.Name, _InputModel.FixedNumber);
        }

        /// <summary>
        /// 更新ボタンのクリックイベントを処理します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.UpdateFixedTimeList(this._FixedTimeDataList.ToList());
        }

        /// <summary>
        /// 削除ボタンのクリックイベントを処理します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var model = fixedTimeModelBindingSource.CurrencyManager.Current as FixedTimeModel;
            
            if(model != null)
            {
                this.RemoveFixedTime(model.Id);
            }
        }

        /// <summary>
        /// インポートボタンのクリックイベントを処理します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            this.ImportFixedTimeList();
        }

        /// <summary>
        /// 初期化処理をします。
        /// </summary>
        private void Initialize()
        {
            // バインド設定
            this.txtFixedTimeValue.DataBindings.Add(NameOf(() => txtFixedTimeValue.Text), this._InputModel, NameOf(() => _InputModel.FixedTimeValue), false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtName.DataBindings.Add(NameOf(() => txtName.Text), this._InputModel, NameOf(() => _InputModel.Name), false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtFixedNumber.DataBindings.Add(NameOf(() => txtFixedNumber.Text), this._InputModel, NameOf(() => _InputModel.FixedNumber), false, DataSourceUpdateMode.OnPropertyChanged);

            // バインドの設定
            fixedTimeModelBindingSource.DataSource = _FixedTimeDataList;

            //// リストを更新します
            //this.GetFixedTimeAll();
        }

        /// <summary>
        /// 固定時間をDBから全件取得し、リストを更新します。
        /// </summary>
        private void GetFixedTimeAll()
        {
            // カーソルを待機状態にする
            Cursor.Current = Cursors.WaitCursor;

            // DB から取得
            var result = DataServiceFacade.Instance.GetFixedTimeData().ToList();

            this._FixedTimeDataList.Clear();

            // リストの更新
            result.ForEach(x => this._FixedTimeDataList.Add(
                            new FixedTimeModel {
                                Id = x.Id,
                                FixedTimeValue = x.FixedTimeValue,
                                Name = x.Name,
                                FixedNumber = x.FixedNumber
                            }));

            // バインドの更新通知
            this.fixedTimeModelBindingSource.ResetBindings(false);

            // カーソルを元に戻す
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 固定時間をDBに登録します。
        /// </summary>
        /// <param name="fixedTimeValue"></param>
        /// <param name="name"></param>
        /// <param name="fixedNumber"></param>
        private void AddFixedTime(int fixedTimeValue, string name, int fixedNumber)
        {
            // カーソルを待機状態にする
            Cursor.Current = Cursors.WaitCursor;

            DataServiceFacade.Instance.AddFixedTimeData(new FixedTimeModel()
            {
                FixedTimeValue = fixedTimeValue,
                Name = name,
                FixedNumber = fixedNumber
            });

            // 表示の更新
            this.GetFixedTimeAll();

            // カーソルを元に戻す
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 固定時間リストを更新します。
        /// </summary>
        private void UpdateFixedTimeList(IEnumerable<FixedTimeModel> datas)
        {
            // カーソルを待機状態にする
            Cursor.Current = Cursors.WaitCursor;

            // 更新
            DataServiceFacade.Instance.UpdateFixedTimeData(datas);

            // 表示の更新
            this.GetFixedTimeAll();

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

            // DB から削除
            DataServiceFacade.Instance.RemoveFixedTime(id);

            // 表示の更新
            this.GetFixedTimeAll();

            // カーソルを元に戻す
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 固定時間リストをインポートして DB に登録します。
        /// </summary>
        /// <param name="fileName"></param>
        private void ImportFixedTimeListCore(string fileName)
        {
            // カーソルを待機状態にする
            Cursor.Current = Cursors.WaitCursor;

            List<FixedTimeModel> importList = new List<FixedTimeModel>();

            // csvファイルをインポート(固定時間,名称,固定番号のデータを前提とする)
            using (var paser = new Microsoft.VisualBasic.FileIO.TextFieldParser(fileName, Encoding.GetEncoding("Shift_JIS")))
            {
                paser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                paser.SetDelimiters(",");
                while(!paser.EndOfData)
                {
                    try
                    {
                        var fields = paser.ReadFields();
                        if (fields.Length != 3)
                        {
                            continue;
                        }

                        var item = new FixedTimeModel()
                        {
                            FixedTimeValue = int.Parse(fields[0]),  // 固定時間
                            Name = fields[1],                       // 名称
                            FixedNumber = int.Parse(fields[2])      // 固定番号
                        };

                        importList.Add(item);
                    }
                    catch (Exception ex)
                    {
                        var method = MethodBase.GetCurrentMethod();
                        base.WriteLog(method, ex.Message);
                    }
                }
            }

            // DBへ登録
            DataServiceFacade.Instance.AddFixedTimeData(importList);

            // 表示の更新
            this.GetFixedTimeAll();

            // カーソルを元に戻す
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 固定時間リストをインポート(csvファイル)します。
        /// </summary>
        private void ImportFixedTimeList()
        {
            _openFileDialog.Filter = "固定時間ファイル (*.csv)|*.csv";
            _openFileDialog.Title = "固定時間リストを選択してくだい。";
            _openFileDialog.RestoreDirectory = true;
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.ImportFixedTimeListCore(_openFileDialog.FileName);
            }
        }
    }
}
