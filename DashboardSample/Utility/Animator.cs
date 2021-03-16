using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardSample.Utility
{
    /// <summary>
    /// コントロールにアニメションを機能を提供するクラスです
    /// </summary>
    public static class Animator
    {
        /// <summary>
        /// 1フレームの時間とフレーム数を指定してアニメーション機能を提供します。
        /// </summary>
        /// <param name="interval">1フレームの時間をミリ秒で指定します。</param>
        /// <param name="frequency">
        /// コールバックが呼ばれる回数から 1 を引いたものです。例えば frequency が 10 の時には 11 回呼ばれます。
        /// </param>
        /// <param name="callback">
        /// bool callback(int frame, int frequency) の形でコールバックを指定します。
        /// frame は 0 から frequency の値まで 1 ずつ増加します。
        /// frequency は引数と同じものです。
        /// </param>
        /// <remarks>Formをフェードアウトさせるさせる場合は'ControlAnimation()'を使用してください。</remarks>
        public static void Animation(int interval, int frequency, Func<int, int, bool> callback)
        {
            var timer = new System.Windows.Forms.Timer();

            var method = System.Reflection.MethodBase.GetCurrentMethod();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Restart();

            timer.Interval = interval;
            int frame = 0;
            timer.Tick += (sender, e) =>
            {
                if (callback(frame, frequency) == false || frame >= frequency)
                {
                    timer.Stop();
                    sw.Stop();
                    Console.WriteLine("{0}\t{1},{2}(),{3}[ms]", DateTime.Now.ToString("HH:mm:ss.fff"), method.DeclaringType.FullName, method.Name, sw.ElapsedMilliseconds);
                }
                frame++;
            };
            timer.Start();
            Console.WriteLine("{0}\t{1},{2}(),", DateTime.Now.ToString("HH:mm:ss.fff"), method.DeclaringType.FullName, method.Name);
        }

        /// <summary>
        /// 持続時間を指定してアニメーションを提供します。
        /// </summary>
        /// <param name="period">持続時間をミリ秒で指定します。</param>
        /// <param name="callback">
        /// bool callback(int frame, int frequency) の形でコールバックを指定します。
        /// frame は 0 から frequency の値まで 1 ずつ増加します。
        /// frequency はコールバックが呼ばれる回数から 1 を引いたものです。例えば frequency が 10 の時には 11 回呼ばれます。
        /// </param>
        /// <remarks>Formをフェードアウトさせるさせる場合は'ControlAnimation()'を使用してください。</remarks>
        [Obsolete("このメソッドは`System.Windows.Forms.Timer’クラスを使用しておりオーバヘッドが大きいため時間は正確ではない為’ControlAnimation()'を使用して下さい。")]
        public static void Animation(int period, Func<int, int, bool> callback)
        {
            const int interval = 25;

            if (period < interval)
            {
                period = interval;
            }

            Animation(interval, period / interval, callback);
        }

        /// <summary>
        ///  1フレームの時間とフレーム数を指定してコントロールにアニメーション機能を提供します。
        /// </summary>
        /// <param name="interval">1フレームの時間をミリ秒で指定します。</param>
        /// <param name="frequency">コールバックが呼ばれる回数と同じです。</param>
        /// <param name="callback">
        /// bool callback(int frame, int frequency) の形でコールバックを指定します。
        /// frame は 0 から frequency の値まで 1 ずつ増加します。
        /// frequency は引数と同じものです。
        /// </param>
        /// <remars>Formをフェードインさせる場合は、'Shown'イベント内でApplication.DoEvents()を呼出し語、呼び出してください。</remarks>>
        public static void ControlAnimation(int interval, int frequency, Func<int, int, bool> callback)
        {
            int frame = 0;
            var method = System.Reflection.MethodBase.GetCurrentMethod();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Restart();

            while (frame != frequency)
            {
                frame++;
                if (callback(frame, frequency) == false || frame >= frequency)
                {
                    System.Diagnostics.Debug.WriteLine("{0}\t{1},{2}(),{3}[ms]", DateTime.Now.ToString("HH:mm:ss.fff"), method.DeclaringType.FullName, method.Name, sw.ElapsedMilliseconds);
                    return;
                }
                System.Threading.Thread.Sleep(interval);
            }
        }

        /// <summary>
        /// 持続時間を指定してコントロールにアニメーションを提供します。
        /// </summary>
        /// <param name="period">持続時間をミリ秒で指定します。</param>
        /// <param name="callback">
        /// bool callback(int frame, int frequency) の形でコールバックを指定します。
        /// frame は 0 から frequency の値まで 1 ずつ増加します。
        /// frequency はコールバックが呼ばれる回数から 1 を引いたものです。例えば frequency が 10 の時には 11 回呼ばれます。
        /// </param>
        /// <remars>Formをフェードインさせる場合は、'Shown'イベント内でApplication.DoEvents()を呼出し語、呼び出してください。</remarks>>
        /// <example>
        /// フェードインサンプル
        /// <code>
        /// Animator.ControlAnimation(500, (frame, frequency) =>
        /// {
        ///     if (!this.Visible || this.IsDisposed)
        ///     {
        ///         return false;
        ///     }
        ///     this.Opacity = (double)frame / frequency;
        ///     return true;
        /// });
        /// </code>
        /// </example>
        public static void ControlAnimation(int period, Func<int, int, bool> callback)
        {

            const int interval = 25;

            if (period < interval)
            {
                period = interval;
            }

            ControlAnimation(interval, period / interval, callback);
        }

        /// <summary>
        /// フォームのアニメーションタイプの定義
        /// </summary>
        public enum FormAnimationType
        {
            /// <summary>
            /// フェードイン
            /// </summary>
            FadeIn,
            /// <summary>
            /// フェードアウト
            /// </summary>
            FadeOut,
        }

        /// <summary>
        ///  1フレームの時間とフレーム数を指定してコントロールにアニメーション機能を提供します。
        /// </summary>
        /// <param name="interval">1フレームの時間をミリ秒で指定します。</param>
        /// <param name="frequency">コールバックが呼ばれる回数と同じです。</param>
        /// <param name="callback">
        /// bool callback(int frame, int frequency) の形でコールバックを指定します。
        /// frame は 0 から frequency の値まで 1 ずつ増加します。
        /// frequency は引数と同じものです。
        /// </param>
        /// <remars>Formをフェードインさせる場合は、'Shown'イベント内でApplication.DoEvents()を呼出し語、呼び出してください。</remarks>>
        public static void ControlAnimation(int interval, int frequency, System.Windows.Forms.Form form, FormAnimationType animationType)
        {
            int frame = 0;
            var method = System.Reflection.MethodBase.GetCurrentMethod();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Restart();

            while (frame != frequency)
            {
                frame++;
                if ((!form.Visible || form.IsDisposed) || frame >= frequency)
                {
                    Console.WriteLine("{0}\t{1},{2}(),{3}[ms]", DateTime.Now.ToString("HH:mm:ss.fff"), method.DeclaringType.FullName, method.Name, sw.ElapsedMilliseconds);
                    return;
                }

                switch (animationType )
                {
                    case FormAnimationType.FadeIn:
                        form.Opacity = (double)frame / frequency;
                        break;
                    case FormAnimationType.FadeOut:
                        form.Opacity = 1.0f - (double)frame / frequency;
                        break;
                    default:
                        break;
                }
                System.Threading.Thread.Sleep(interval);
            }
        }

        /// <summary>
        /// 持続時間を指定してコントロールにアニメーションを提供します。
        /// </summary>
        /// <param name="period">持続時間をミリ秒で指定します。</param>
        /// <param name="callback">
        /// bool callback(int frame, int frequency) の形でコールバックを指定します。
        /// frame は 0 から frequency の値まで 1 ずつ増加します。
        /// frequency はコールバックが呼ばれる回数から 1 を引いたものです。例えば frequency が 10 の時には 11 回呼ばれます。
        /// </param>
        /// <remars>Formをフェードインさせる場合は、'Shown'イベント内でApplication.DoEvents()を呼出し語、呼び出してください。</remarks>>
        public static void ControlAnimation(int period, System.Windows.Forms.Form form, FormAnimationType animationType)
        {

            const int interval = 25;

            if (period < interval)
            {
                period = interval;
            }

            ControlAnimation(interval, period / interval, form, animationType);
        }
    }
}
