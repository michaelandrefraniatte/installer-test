using System;
using System.Windows.Forms;

namespace uninstaller_test
{
    class Program
    {
        static void OnKeyDown(Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                const string message = "• Author: Michaël André Franiatte.\n\r\n\r• Contact: michael.franiatte@gmail.com.\n\r\n\r• Publisher: https://github.com/michaelandrefraniatte.\n\r\n\r• Copyrights: All rights reserved, no permissions granted.\n\r\n\r• License: Not open source, not free of charge to use.";
                const string caption = "About";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        static void Main(string[] args)
        {
            string path = @"c:\test";
            System.IO.Directory.Delete(path, true);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            System.IO.File.Delete(System.IO.Path.Combine(desktopPath, "test.lnk"));
            Environment.Exit(0);
        }
    }
}