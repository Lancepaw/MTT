//-----------------------------------------------------------------------
// <copyright file="Logger.cs" company="No Company">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace TestWcfService
{
    using log4net;
    using log4net.Config;

    /// <summary>
    /// Класс логгера log4net.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Поле, отвечающее за запись лога.
        /// </summary>
        private static ILog log = LogManager.GetLogger("LOGGER");

        /// <summary>
        /// Свойство, вызывающее поле createlog.
        /// </summary>
        public static ILog Log
        {
            get { return log; }
        }

        /// <summary>
        /// Метод, настраивающий логгер согласно прописанным в App.config настройкам.
        /// </summary>
        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
