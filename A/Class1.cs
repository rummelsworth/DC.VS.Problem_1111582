using System;
using System.Diagnostics;

namespace A
{
    public class Class1
    {
        public string GetHelloB()
        {
            var executableB = typeof(B.Program).Assembly.Location;
            var info = new ProcessStartInfo(executableB)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
            };
            using var p = Process.Start(info);
            var hello = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return hello;
        }
    }
}
