using System;
using System.Windows.Forms;
using StationeryShopManagementSystem.Forms;

namespace StationeryShopManagementSystem
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
