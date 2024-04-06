using System;
using IWshRuntimeLibrary;
using System.Windows.Forms;

namespace installer_test
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
            string zipPath = Environment.CurrentDirectory + @"\test.zip";
            string extractPath = @"c:\test";
            System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
            System.IO.File.Copy(Environment.CurrentDirectory + @"\auth.txt", @"c:\test\auth.txt");
            CreateShortcut();
            Environment.Exit(0);
        }
        private static void CreateShortcut()
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\test.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Shortcut for a test";
            shortcut.TargetPath = @"c:\test\test.exe";
            shortcut.WorkingDirectory = @"c:\test";
            shortcut.Save();
        }
    }
}