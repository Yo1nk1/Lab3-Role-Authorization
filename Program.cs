using System;
using System.Windows.Forms;
using RoleAuthorizationLab3.Forms;

namespace RoleAuthorizationLab3
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormAutorization());
        }
    }
}
