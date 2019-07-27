//-----------------------------------------------------------------------
// <copyright file="Config.cs" company="No Company">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace TestWcfService
{
    using System.Configuration;

    /// <summary>
    /// Класс хранящий данные из конфига.
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Забираем Connection String из конфига.
        /// </summary>
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        
        /// <summary>
        /// Отдаём Connection String
        /// </summary>
        public static string GetConnectionString
        {
            get { return connectionString; }
        }
    }
}