using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashboardSample
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // DBアクセスの初期化
            DBControlLibrary.DataServiceFacade.Instance.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormDashBoardSample1());
            Application.Run(new FormDropDownMenuSample());
            //Application.Run(new FormDragAndResizeSample());
        }
    }
}
