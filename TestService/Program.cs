//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="No Company">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace TestService
{
    using System.ServiceProcess;

    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        private static void Main()
        {
            ServiceBase[] servicesToRun;
            servicesToRun = new ServiceBase[]
            {
                new TestService()
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
