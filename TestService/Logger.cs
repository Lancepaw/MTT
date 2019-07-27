//-----------------------------------------------------------------------
// <copyright file="Logger.cs" company="No Company">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace TestService
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
        private static ILog createlog = LogManager.GetLogger("LOGGER");

        /// <summary>
        /// Свойство, вызывающее поле createlog.
        /// </summary>
        public static ILog Log
        {
            get { return createlog; }
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
