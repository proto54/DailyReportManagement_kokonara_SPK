using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DashboardSample.Utility
{
    /// <summary>
    /// オブジェクト・メソッドに関する静的メソッドを提供するクラスです。
    /// </summary>
    public static class ObjectHelper
    {
        /// <summary>
        /// ラムダ式によって渡されたメンバ名を取得します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e">ラムダ式</param>
        /// <returns>メンバ名</returns>
        #region NameOf
        public static string NameOf<T>(Expression<Func<T>> e)
        {
            return (e.Body as MemberExpression).Member.Name;
        }
        #endregion NameOf
    }
}
