using CrossPlatformThreadOnly;
using System;
using System.Runtime.InteropServices;

namespace NugetThreadOnly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region 实例唯一
            if (!new FileLocks().CheckSingleInstance())
            {
                Console.WriteLine("Another instance of application is running. Closing.");
                Environment.Exit(0);
            }
            #endregion

            Console.WriteLine("End World!");

            Console.ReadKey();

        }
    }
}
