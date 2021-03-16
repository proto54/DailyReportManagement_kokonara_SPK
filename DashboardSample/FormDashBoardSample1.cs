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
    /// スライドメニュー(サイド型)
    /// </summary>
    public partial class FormDashBoardSample1 : Form
    {
        #region "コントロールを掴んでフォームを移動させる"
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private const int WM_SYSCOMMAND = 0x112;
        private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, 0xf012, 0);
        }
        #endregion "コントロールを掴んでフォームを移動させる"

        #region "カスタムSizeGrip"
        private const int WM_NCHITTEST = 132;
        private const int HTBTOONMRIGHT = 17;
        /// <summary>
        /// SizeGripの公差
        /// </summary>
        private int _SizeGripTolerance = 12;
        /// <summary>
        /// SizeGripの四角形を保持します。
        /// </summary>
        private Rectangle _SizeGripRectangle;
        /// <summary>
        /// SizeGripの色を指定します。
        /// </summary>
        private Color _SizeGripColor = Color.FromArgb(200, 0, 0);

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (_SizeGripRectangle.Contains(hitPoint))
                    {
                        m.Result = new IntPtr(HTBTOONMRIGHT);
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }

            //base.WndProc(ref m);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            _SizeGripRectangle = new Rectangle(this.ClientRectangle.Width - _SizeGripTolerance, this.ClientRectangle.Height - _SizeGripTolerance, _SizeGripTolerance, _SizeGripTolerance);
            region.Exclude(_SizeGripRectangle);
            this.panelFormContainer.Region = region;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(_SizeGripColor);
            e.Graphics.FillRectangle(blueBrush, _SizeGripRectangle);
            base.OnPaint(e);
        }
        #endregion "カスタムSizeGrip"

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
        public FormDashBoardSample1()
        {
            InitializeComponent();
        }

        private void FormDashBoardSample1_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void FormDashBoardSample1_Shown(object sender, EventArgs e)
        {

        }

        private void FormDashBoardSample1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialize()
        {
        }

        /// <summary>
        /// メニューをスライド表示するクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSlideMenu_Click(object sender, EventArgs e)
        {
            if (panelSideMenu.MaximumSize.Width <= panelSideMenu.Width)
            {
                // メニュー表示縮小
                Animator.ControlAnimation(200, (frame, frequency) =>
                {
                    if (!this.Visible || this.IsDisposed)
                    {
                        return false;
                    }
                    int x = panelSideMenu.MaximumSize.Width - (int)(panelSideMenu.MaximumSize.Width * (double)frame / frequency);
                    panelSideMenu.Width = x;
                    Application.DoEvents();
                    if (panelSideMenu.MinimumSize.Width >= x)
                    {
                        return false;
                    }
                    return true;
                });
            }
            else
            {
                // メニュー表示拡大
                Animator.ControlAnimation(200, (frame, frequency) =>
                {
                    if (!this.Visible || this.IsDisposed)
                    {
                        return false;
                    }
                    int x = (int)(panelSideMenu.MaximumSize.Width * (double)frame / frequency);
                    panelSideMenu.Width = x;
                    Application.DoEvents();
                    if (panelSideMenu.MaximumSize.Width <= x)
                    {
                        return false;
                    }
                    return true;
                });
            }
        }
        

        private void btnMenu1_Click(object sender, EventArgs e)
        {
            OpenChileForm(new ChildFormSample1());
        }

        private void btnMenu2_Click(object sender, EventArgs e)
        {
            OpenChileForm(new ChildFormSample2());
        }

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
            }
            _ActiveForm = childForm;

            _ActiveForm.TopLevel = false;
            _ActiveForm.FormBorderStyle = FormBorderStyle.None;
            _ActiveForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(_ActiveForm);
            panelChildForm.Tag = _ActiveForm;
            _ActiveForm.BringToFront();   // 最前面へ表示
            _ActiveForm.Show();           // フォームの表示
        }
    }
}
