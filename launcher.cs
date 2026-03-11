using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string chrome = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
        string chrome86 = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
        string edge = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

        string browser = null;

        if (File.Exists(chrome))
            browser = chrome;
        else if (File.Exists(chrome86))
            browser = chrome86;
        else if (File.Exists(edge))
            browser = edge;
        else
        {
            Console.WriteLine("No Chromium browser found.");
            return;
        }

        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = browser,
            Arguments = "--headless --disable-gpu --allow-file-access-from-files \"C:\\path\\to\\file.html\"",
            CreateNoWindow = true,
            UseShellExecute = false,
            WindowStyle = ProcessWindowStyle.Hidden
        };

        Process.Start(psi);
    }
}