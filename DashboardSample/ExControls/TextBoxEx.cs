using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace DashboardSample.ExControls
{
    /// <summary>
    /// TextBoxを拡張した機能を提供するクラスです。
    /// </summary>
    public class TextBoxEx : TextBox
    {
        private const int WM_PAINT = 0xF;

        /// <summary>
        /// 枠線のデフォルト色を指定します。
        /// </summary>
        private static readonly Color DEFAULT_BODER_COLOR = Color.FromArgb(0, 0, 0);

        /// <summary>
        /// TextBoxの枠線の色を指定します。
        /// </summary>
        #region "CustomBorderColor"
        [Description("コントロールの枠線の色を指定します。")]
        public Color CustomBorderColor
        {
            get
            {
                return _CustomBorderColor;
            }
            set
            {
                if (_CustomBorderColor != value)
                {
                    _CustomBorderColor = value;
                    this.Refresh();
                }
            }
        }
        private Color _CustomBorderColor = DEFAULT_BODER_COLOR;
        #endregion "CustomBorderColor"

        /// <summary>
        /// WndProcメソッドオーバーライド
        /// </summary>
        /// <param name="m"></param>
        #region "WndProc"
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);

            if ((m.Msg == WM_PAINT))
            {
                using (Graphics g = CreateGraphics())
                {
                    if(_CustomBorderColor == Color.Empty)
                    {
                        return;
                    }
                    else if (_CustomBorderColor != DEFAULT_BODER_COLOR)
                    {
                        // 標準カラーでない場合は指定色で描画する
                        System.Drawing.Pen p = new System.Drawing.Pen(_CustomBorderColor);
                        g.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);
                    }
                    else
                    {
                        ControlPaint.DrawVisualStyleBorder(g, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                    }
                }
            }
        }
        #endregion "WndProc"


        /// <summary>
        /// アクティブ状態のデフォルトの背景色を指定します
        /// </summary>
        private static readonly Color DEFAULT_ACTIVE_COLOR = Color.FromArgb(204, 255, 255);

        /// <summary>
        /// 非アクティブ状態のデフォルトの背景色を指定します
        /// </summary>
        private static readonly Color DEFAULT_NONEACTIVE_COLOR = Color.Empty;

        /// <summary>
        /// コントロールがアクティブになったときの背景色を指定します。
        /// </summary>
        #region "CustomActiveColor"
        [Description("コントロールがアクティブになったときの背景色を指定します。")]
        public Color CustomActiveColor
        {
            get { return _CustomActiveColor; }
            set { _CustomActiveColor = value; }
        }
        private Color _CustomActiveColor = DEFAULT_ACTIVE_COLOR;
        #endregion "CustomActiveColor"

        /// <summary>
        /// コントロールがアクティブでなくなったときの背景色を指定します。
        /// </summary>
        #region "CustomNoneActiveColor"
        [Description("コントロールがアクティブでなくなったときの背景色を指定します。")]
        public Color CustomNoneActiveColor
        {
            get { return _CustomNoneActiveColor; }
            set { _CustomNoneActiveColor = value; }
        }
        private Color _CustomNoneActiveColor = DEFAULT_NONEACTIVE_COLOR;
        #endregion "CustomNoneActiveColor"

        /// <summary>
        /// コントロールがアクティブになった時に発生します。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            base.BackColor = this.CustomActiveColor;
        }

        /// <summary>
        /// コントロールがアクティブでなくなった時に発生します。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            base.BackColor = this.CustomNoneActiveColor;
        }
    }
}
