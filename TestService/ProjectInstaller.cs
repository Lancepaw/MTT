//-----------------------------------------------------------------------
// <copyright file="ProjectInstaller.cs" company="No Company">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace TestService
{
    using System.ComponentModel;

    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
