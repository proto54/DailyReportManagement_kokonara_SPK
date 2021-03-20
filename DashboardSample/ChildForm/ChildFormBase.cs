using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using DashboardSample.Utility;

namespace DashboardSample.ChildForm
{
    /// <summary>
    /// 子フォームのベースクラスです。
    /// </summary>
    public partial class ChildFormBase : Form
    {
        protected string Log_Key = "UI";

        /// <summary>
        /// クラスの新しいインスタンスを構築します。
        /// </summary>
        public ChildFormBase()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void WriteLog(MethodBase methodBase, string msg)
        {
            var outMsg = String.Format("{0},{1},{2}(),{3},{4}",
                DateTime.Now.ToString("HH:mm:ss.fff"), methodBase.DeclaringType.FullName, methodBase.Name, Log_Key, msg);
            Console.WriteLine(outMsg);
        }

        /// <summary>
        /// ラムダ式によって渡されたメンバ名を取得します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e">ラムダ式</param>
        /// <returns>メンバ名</returns>
        #region NameOf
        protected string NameOf<T>(Expression<Func<T>> e)
        {
            return ObjectHelper.NameOf(e);
        }
        #endregion NameOf

    }
}
