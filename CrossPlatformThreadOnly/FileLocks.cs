using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CrossPlatformThreadOnly
{
    /// <summary>
    /// 文件锁
    /// </summary>
    public class FileLocks
    {
        static FileStream _lockFile;

        /// <summary>
        /// 检测实例唯一
        /// </summary>
        /// <returns></returns>
        public bool CheckSingleInstance()
        {
            //判断  MacOS系统自带实例检测， 只考虑 Windows和linux下的实例唯一 检测
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return true;
            }

            var dir = AppDomain.CurrentDomain.BaseDirectory;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            try
            {
                //Console.WriteLine("Check File Lock");
                _lockFile = File.Open(Path.Combine(dir, ".lock"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                _lockFile.Lock(0, 0);
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("error:" + ex.Message);
                return false;
            }
        }
    }
}
