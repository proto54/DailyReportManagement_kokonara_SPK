using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DashboardSample
{
    using Utility;
    using ChildForm;

    /// <summary>
    /// ドロップダウンメニュー方式の画面クラスです(サンプル)
    /// </summary>
    public partial class FormDropDownMenuSample : Form
    {
        #region "コントロールを掴んでフォームを移動させる"
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private const int WM_SYSCOMMAND = 0x112;

        private IReadOnlyList<Panel> _SubMenuList;


        private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, 0xf012, 0);
        }
        #endregion "コントロールを掴んでフォームを移動させる"

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximized_Click(object sender, EventArgs e)
        {
            btnRestorWindow.Visible = true;
            btnMaximized.Visible = false;
            this.WindowState = FormWindowState.Maximized;
        }
        private void btnRestorWindow_Click(object sender, EventArgs e)
        {
            btnRestorWindow.Visible = false;
            btnMaximized.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// クラスの新しいインスタンスを構築します。
        /// </summary>
        public FormDropDownMenuSample()
        {
            InitializeComponent();

            //サブメニューのリストを作成
            _SubMenuList = new List<Panel>() { panelSubMenu1, panelSubMenu3, panelSubMenu4 };

            this.Opacity = 0;
        }

        private void FormDropDownMenuSample_Load(object sender, EventArgs e)
        {
            var method = System.Reflection.MethodBase.GetCurrentMethod();

            Console.WriteLine("{0}\t{1},{2}(),", DateTime.Now.ToString("HH:mm:ss.fff"), method.DeclaringType.FullName, method.Name);

            Initialize();

            Console.WriteLine("{0}\t{1},{2}(),", DateTime.Now.ToString("HH:mm:ss.fff"), method.DeclaringType.FullName, method.Name);
        }

        private void FormDropDownMenuSample_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            var method = System.Reflection.MethodBase.GetCurrentMethod();

            // フェードイン
            Animator.ControlAnimation(300, (frame, frequency) =>
            {
                if (!this.Visible || this.IsDisposed)
                {
                    return false;
                }
                this.Opacity = (double)frame / frequency;
                return true;
            });
            //Animator.ControlAnimation(300, this, Animator.FormAnimationType.FadeIn);

            Console.WriteLine("{0}\t{1},{2}(),", DateTime.Now.ToString("HH:mm:ss.fff"), method.DeclaringType.FullName, method.Name);

        }

        private void FormDropDownMenuSample_FormClosed(object sender, FormClosedEventArgs e)
        {
            // フェードアウト
            Animator.ControlAnimation(300, (frame, frequency) =>
            {
                if (!this.Visible || this.IsDisposed)
                {
                    return false;
                }
                this.Opacity = 1.0f - (double)frame / frequency;
                return true;
            });
            //Animator.ControlAnimation(300, this, Animator.FormAnimationType.FadeOut);
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialize()
        {
            InitCustomaizeDesing();

        }

        private void InitCustomaizeDesing()
        {
            panelSubMenu1.Visible = false;
            panelSubMenu3.Visible = false;
            panelSubMenu4.Visible = false;

            // アクティブバーの紐づけ
            panelSubMenu1.Tag = panelSubMenuActiveBar1;
            panelSubMenu3.Tag = panelSubMenuActiveBar3;
            panelSubMenu4.Tag = panelSubMenuActiveBar4;
            panelSubMenuActiveBar1.Visible = false;
            panelSubMenuActiveBar3.Visible = false;
            panelSubMenuActiveBar3.Visible = false;
        }

        /// <summary>
        /// サブメニューの非表示
        /// </summary>
        private void HideSubMenu()
        {
            var subMenuList = _SubMenuList.ToList();
            if (subMenuList == null) return;

            subMenuList.ForEach(x =>
            {
                if (x.Visible)
                {
                    x.Visible = false;
                }
            });
        }

        /// <summary>
        /// サブメニューの表示
        /// </summary>
        /// <param name="subMenu"></param>
        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible)
            {
                subMenu.Visible = false;
            }
            else
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
        }

        private void btnMenu1_Click(object sender, EventArgs e)
        {
            ShowSubMenu(_SubMenuList[0]);
        }

        #region "Menu1 SubMenu"
        private void btnMenu1SubMenu1_Click(object sender, EventArgs e)
        {
            //
            // ユーザーコードをここに書く
            //
            OpenChileForm(new ChildFormSample1());
            ActivateButton(sender);
            // サブメニューを閉じる(非表示)
            //HideSubMenu();
        }

        private void btnMenu1SubMenu2_Click(object sender, EventArgs e)
        {
            //
            // ユーザーコードをここに書く
            //
            OpenChileForm(null);
            ActivateButton(sender);

            // サブメニューを閉じる(非表示)
            HideSubMenu();
        }

        private void btnMenu1SubMenu3_Click(object sender, EventArgs e)
        {
            //
            // ユーザーコードをここに書く
            //
            OpenChileForm(null);
            ActivateButton(sender);

            // サブメニューを閉じる(非表示)
            HideSubMenu();
        }

        private void btnMenu1SubMenu4_Click(object sender, EventArgs e)
        {
            //
            // ユーザーコードをここに書く
            //
            OpenChileForm(null);
            ActivateButton(sender);

            // サブメニューを閉じる(非表示)
            HideSubMenu();
        }
        #endregion "Menu1 SubMenu"


        private void btnMenu2_Click(object sender, EventArgs e)
        {

        }

        #region "Menu2 SubMenu"
        #endregion "Menu2 SubMenu"

        private void btnMenu3_Click(object sender, EventArgs e)
        {
            ShowSubMenu(_SubMenuList[1]);
        }
        #region "Menu3 SubMenu"
        private void btnMenu3SubMenu1_Click(object sender, EventArgs e)
        {
            //
            // ユーザーコードをここに書く
            //
            OpenChileForm(new ChildFormSample2());
            ActivateButton(sender);
        }

        private void btnMenu3SubMenu2_Click(object sender, EventArgs e)
        {
            //
            // ユーザーコードをここに書く
            //
            OpenChileForm(null);
            ActivateButton(sender);
        }

        private void btnMenu3SubMenu3_Click(object sender, EventArgs e)
        {
            //
            // ユーザーコードをここに書く
            //
            OpenChileForm(null);
            ActivateButton(sender);
        }

        private void btnMenu3SubMenu4_Click(object sender, EventArgs e)
        {
            //
            // ユーザーコードをここに書く
            //
            OpenChileForm(null);
            ActivateButton(sender);
        }
        #endregion "Menu3 SubMenu"


        private void btnMenu4_Click(object sender, EventArgs e)
        {
            ShowSubMenu(_SubMenuList[2]);
        }
        #region "Menu4 SubMenu"

        private void btnMenu4SubMenu1_Click(object sender, EventArgs e)
        {
            //
            // ユーザーコードをここに書く
            //
            OpenChileForm(null);
            ActivateButton(sender);
        }

        private void btnMenu4SubMenu2_Click(object sender, EventArgs e)
        {
            //
            // ユーザーコードをここに書く
            //
            OpenChileForm(null);
            ActivateButton(sender);
        }

        private void btnMenu4SubMenu3_Click(object sender, EventArgs e)
        {
            //
            // ユーザーコードをここに書く
            //
            OpenChileForm(null);
            ActivateButton(sender);
        }

        private void btnMenu4SubMenu4_Click(object sender, EventArgs e)
        {
            //
            // ユーザーコードをここに書く
            //
            OpenChileForm(null);
            ActivateButton(sender);
        }
        #endregion "Menu4 SubMenu"

        /// <summary>
        /// アクティブなFormのインスタンスを保持します。
        /// </summary>
        private Form _ActiveForm = null;
        /// <summary>
        /// 子フォームを表示する
        /// </summary>
        /// <param name="childForm"></param>
        private void OpenChileForm(Form childForm)
        {
            if (_ActiveForm != null)
            {
                _ActiveForm.Close();
                NoneActivateButton();
            }
            _ActiveForm = childForm;

            if (childForm != null)
            {
                _ActiveForm.TopLevel = false;
                _ActiveForm.FormBorderStyle = FormBorderStyle.None;
                _ActiveForm.Dock = DockStyle.Fill;
                panelChildForm.Controls.Add(_ActiveForm);
                panelChildForm.Tag = _ActiveForm;
                // フォームが閉じた後のイベント処理
                _ActiveForm.FormClosed += (s, e) => 
                {
                    NoneActivateButton();
                };

                _ActiveForm.BringToFront();   // 最前面へ表示
                _ActiveForm.Show();           // フォームの表示
            }
        }

        /// <summary>
        /// アクティブなButtonのインスタンスを保持します。
        /// </summary>
        private Button _ActivateBtn = null;
        /// <summary>
        /// ボタンをアクティブにする処理をします。
        /// </summary>
        /// <param name="sender"></param>
        private void ActivateButton(object sender)
        {
            if (sender == null) return;

            _ActivateBtn = sender as Button;
            var avtiveBar = _ActivateBtn.Parent.Tag as Panel;
            if (avtiveBar != null)
            {
                // ボタンの位置にバーを移動
                avtiveBar.Top = _ActivateBtn.Top;
                avtiveBar.Visible = true;
            }
        }

        /// <summary>
        /// アクティブなボタンを非アクティブにする処理をします。
        /// </summary>
        private void NoneActivateButton()
        {
            if (_ActivateBtn == null) return;

            var avtiveBar = _ActivateBtn.Parent.Tag as Panel;
            if (avtiveBar != null)
            {
                avtiveBar.Visible = false;
            }
        }
    }
}

