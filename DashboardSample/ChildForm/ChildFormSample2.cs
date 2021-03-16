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
    public partial class ChildFormSample2 : ChildFormBase
    {
        /// <summary>
        /// クラスの新しいインスタンスを構築します。
        /// </summary>
        public ChildFormSample2()
        {
            InitializeComponent();

            base.lblTitle.Text = "DASHBOARD";

            foreach( var s in chart1.Series)
            {
                s.Points.Clear();
            }

            Random rnd = new Random();

            for (int i = 1; i <= 10; i++)
            {
                var y = rnd.Next(0, 100);
                chart1.Series[0].Points.AddXY(i, y);
                y = rnd.Next(0, 100);
                chart1.Series[1].Points.AddXY(i, y);
                y = rnd.Next(0, 100);
                chart1.Series[2].Points.AddXY(i, y);
            }

            for (int i = 1; i <= 10; i++)
            {
                var y = rnd.Next(0, 100);
                chart2.Series[0].Points.AddXY(i, y);
            }
        }
    }
}
