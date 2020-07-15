using System.Diagnostics;

namespace A
{
    public class Class1
    {
        public string GetHelloB()
        {
#if NET48
            var executableB = typeof(B.Program).Assembly.Location;
#elif NETCOREAPP3_1
            var libraryB = typeof(B.Program).Assembly.Location;
            var executableB = System.IO.Path.ChangeExtension(libraryB, "exe");
#endif

            var info = new ProcessStartInfo(executableB)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
            };

            using (var p = Process.Start(info))
            {
                var hello = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                return hello;
            }
        }
    }
}
