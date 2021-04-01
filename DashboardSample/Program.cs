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
            var connectionString = "Server=localhost,1433; initial catalog=TestDB;user id=sa;password=saPassword1234";
            // DBアクセスの初期化
            DBControlLibrary.DataServiceFacade.Instance.Initialize(connectionString);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormDashBoardSample1());
            Application.Run(new FormDropDownMenuSample());
            //Application.Run(new FormDragAndResizeSample());

            DBControlLibrary.DataServiceFacade.Instance.Dispose();
        }
    }
}
