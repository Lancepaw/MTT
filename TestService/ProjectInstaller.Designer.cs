//-----------------------------------------------------------------------
// <copyright file="ProjectInstaller.Designer.cs" company="No Company">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace TestService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TestServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.testServiceInstaller = new System.ServiceProcess.ServiceInstaller();

            //// TestServiceProcessInstaller.
            this.TestServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.TestServiceProcessInstaller.Password = null;
            this.TestServiceProcessInstaller.Username = null;

            //// testServiceInstaller.
            this.testServiceInstaller.Description = "Test";
            this.testServiceInstaller.DisplayName = "Test Service";
            this.testServiceInstaller.ServiceName = "TestService";
            this.testServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;

            // ProjectInstaller.
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.TestServiceProcessInstaller,
            this.testServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller TestServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller testServiceInstaller;
    }
}