using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

class Program
{
    static void Main()
    {
        string tempHtml = Path.Combine(Path.GetTempPath(), "index.html");

        var assembly = Assembly.GetExecutingAssembly();
        using (Stream s = assembly.GetManifestResourceStream("nogginfreeze.index.html"))
        using (FileStream fs = new FileStream(tempHtml, FileMode.Create))
        {
            s.CopyTo(fs);
        }

        string chrome = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
        string chrome86 = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
        string edge = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

        string browser = File.Exists(chrome) ? chrome :
                         File.Exists(chrome86) ? chrome86 :
                         File.Exists(edge) ? edge : null;

        if (browser == null)
        {
            Console.WriteLine("no browser found");
            return;
        }

        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = browser,
            Arguments = $"--headless --disable-gpu \"{tempHtml}\"",
            CreateNoWindow = true,
            UseShellExecute = false
        };

        Process.Start(psi);
    }
}