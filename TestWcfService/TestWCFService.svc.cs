//-----------------------------------------------------------------------
// <copyright file="TestWCFService.svc.cs" company="No Company">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace TestWcfService
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using Dapper;

    /// <summary>
    /// Класс, реализующий интерфейс службы.
    /// </summary>
    public class TestWCFService : ITestWCFService, ITestWCFServiceF
    {
        //// Методы, отвечающие за добавление чека в БД.
        #region Insert Method;

        /// <summary>
        /// Метод формирующий SQL запрос и отправляющий его в БД.
        /// </summary>
        /// <param name="che">Чеки, пришедшие из службы Windows</param>
        public void InsertCheques(Cheque che)
        {
            //// Проверка на дубли.
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Logger.InitLogger();
            
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                List<ExportCheque> test = db.Query<ExportCheque>($"SELECT CONVERT(nvarchar(MAX), Id) AS Id, Number, Summ, Discount, Articles FROM [Cheques] WHERE Number = {che.Number};").ToList();
                Logger.Log.Info(test);
                if (test.Count == 0)
                {
                    var articles = this.ArticlesToString(che.Articles);
                    db.Execute($"INSERT INTO [Cheques] ([Id], [Number], [Summ], [Discount], [Articles]) VALUES(NEWID(), '{che.Number}', {che.Summ}, {che.Discount}, '{articles}');");
                    Logger.Log.Info($"Чек №{che.Number} занесён в базу");
                }
                else
                {
                    Logger.Log.Info($"Дубль чека №{che.Number}");
                }
            }
        }

        /// <summary>
        /// Вспомогательный метод, преобразующий артикли в указанный в ТЗ вид.
        /// </summary>
        /// <param name="art">art</param>
        /// <returns>Товары чека в формате для переноса в БД.</returns>
        public string ArticlesToString(List<string> art)
        {
            string result = art[0].Replace("[", string.Empty).Replace("]", string.Empty).Replace(" ", string.Empty).Replace("\r\n", string.Empty).Replace(",", "; ").Replace("\"", string.Empty);
            return result;
        }

        #endregion

        /// <summary>
        /// Метод, отвечающий за выгрузку последних чеков из БД.
        /// </summary>
        /// <param name="n">n</param>
        /// <returns>Последние чеки БД.</returns>
        #region Select Method
        public List<ExportCheque> GetN(int n)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            List<ExportCheque> result = new List<ExportCheque>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                result = db.Query<ExportCheque>($"SELECT TOP({n}) CONVERT(nvarchar(MAX), Id) AS Id, Number, Summ, Discount, Articles FROM [Cheques] ORDER BY [Number] DESC;").ToList();
            }

            Logger.Log.Info("Чеки выгружены");
            return result;
        }
        #endregion

        /// <summary>
        /// Метод, отвечающий за выгрузку первых чеков из БД.
        /// </summary>
        /// <param name="n">n</param>
        /// <returns>Первые чеки БД.</returns>
        #region SelectMethod2
        public List<ExportCheque> GetNF(int n)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            List<ExportCheque> result = new List<ExportCheque>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                result = db.Query<ExportCheque>($"SELECT TOP({n}) CONVERT(nvarchar(MAX), Id) AS Id, Number, Summ, Discount, Articles FROM [Cheques] ORDER BY [Number] ASC;").ToList();
            }

            Logger.Log.Info("Чеки выгружены");
            return result;
        }
        #endregion
    }
}
