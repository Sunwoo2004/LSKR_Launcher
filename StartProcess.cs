using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKR_Launcher
{
    internal class StartProcess
    {
        public static void OnStart(string szPath , string szArgs)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = szPath;
            psi.Arguments = szArgs;
            Process.Start(psi);
        }

        public static void OnCmdStart(string szKey)
        {
            ProcessStartInfo pri = new ProcessStartInfo();
            Process pro = new Process();

            pri.FileName = @"cmd.exe";
            pri.CreateNoWindow = true;
            pri.UseShellExecute = false;

            pri.RedirectStandardInput = true;
            pri.RedirectStandardOutput = true;
            pri.RedirectStandardError = true;

            pro.StartInfo = pri;
            pro.Start();

            pro.StandardInput.WriteLine(szKey);
            pro.StandardInput.Close();

            System.IO.StreamReader sr = pro.StandardOutput;

            string resultValue = sr.ReadToEnd();
            pro.WaitForExit();
            pro.Close();
        }
    }
}
