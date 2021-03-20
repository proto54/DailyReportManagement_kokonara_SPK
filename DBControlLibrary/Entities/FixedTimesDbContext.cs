namespace DBControlLibrary.Entities
{
    using System.Data.Entity;
    using DBControlLibrary.Configuration;

    public class FixedTimesDbContext : DbContext
    {
        // コンテキストは、アプリケーションの構成ファイル (App.config または Web.config) から 'FixedTimesDbContext' 
        // 接続文字列を使用するように構成されています。既定では、この接続文字列は LocalDb インスタンス上
        // の 'DBControlLibrary.Models.FixedTimesDbContext' データベースを対象としています。 
        // 
        // 別のデータベースとデータベース プロバイダーまたはそのいずれかを対象とする場合は、
        // アプリケーション構成ファイルで 'FixedTimesDbContext' 接続文字列を変更してください。
        public FixedTimesDbContext()
            : base("name=FixedTimesDbContext")
        {
            // 自動マイグレーション
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FixedTimesDbContext, FixedTimeConfiguration>());
        }

        /// <summary>
        /// 破棄
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // モデルに含めるエンティティ型ごとに DbSet を追加します。Code First モデルの構成および使用の
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=390109 を参照してください。

        public virtual DbSet<FixedTimeEntitie> FixedTimeEntities { get; set; }
    }

}