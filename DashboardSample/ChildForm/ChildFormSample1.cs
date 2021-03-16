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
    public partial class ChildFormSample1 : ChildFormBase
    {
        /// <summary>
        /// クラスの新しいインスタンスを構築します。
        /// </summary>
        public ChildFormSample1()
        {
            InitializeComponent();

            base.lblTitle.Text = "PRODUCT";

        }
    }
}
