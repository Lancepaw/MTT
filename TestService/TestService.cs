//-----------------------------------------------------------------------
// <copyright file="TestService.cs" company="No Company">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace TestService
{
    using System.ServiceProcess;
    using System.Threading;

    /// <summary>
    /// Основной класс службы.
    /// </summary>
    public partial class TestService : ServiceBase
    {
        /// <summary>
        /// Инициализация jsonSeeker.
        /// </summary>
        private JsonSeeker ts;

        /// <summary>
        /// Инициализация службы.
        /// </summary>
        public TestService()
        {
            this.InitializeComponent();
            Logger.InitLogger();
        }

        /// <summary>
        /// Действия при запуске службы.
        /// </summary>
        /// <param name="args">args</param>
        protected override void OnStart(string[] args)
        {
            this.ts = new JsonSeeker();
            Thread loggerThread = new Thread(new ThreadStart(this.ts.Start));
            loggerThread.Start();
            Logger.Log.Info("Служба v2 запущена");
        }

        /// <summary>
        /// Действия при остановке службы.
        /// </summary>
        protected override void OnStop()
        {
            this.ts.Stop();
            Logger.Log.Info("Служба остановлена");
        }
    }
}
