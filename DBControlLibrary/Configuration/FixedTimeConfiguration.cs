using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace DBControlLibrary.Configuration
{
    using DBControlLibrary.Entities;

    /// <summary>
    /// 固定時間のデータベースを自動マイグレーションの動作を構成するクラスです
    /// </summary>
    class FixedTimeConfiguration : DbMigrationsConfiguration<FixedTimesDbContext>
    {
        public FixedTimeConfiguration()
        {
            // 自動マイグレーションの有効化
            AutomaticMigrationsEnabled = true;
            // データロスを伴う更新を許可
            AutomaticMigrationDataLossAllowed = true;
            //ContextKey = "FixedTimesDbContext";
        }
    }
}
