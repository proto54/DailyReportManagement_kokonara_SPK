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
    /// <summary>
    /// 子フォームのベースクラスです。
    /// </summary>
    public partial class ChildFormBase : Form
    {
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
    }
}
