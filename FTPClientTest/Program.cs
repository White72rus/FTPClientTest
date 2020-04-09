using OmsisWebApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace FTPClientTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"X:\DownloadFTP";
            FTPClient fTPClient = new FTPClient();

            fTPClient.Host = "127.0.0.1";
            fTPClient.UserName = "remote";
            fTPClient.Password = "remote";
            fTPClient.DownLoadPath = path;

            var fileList = fTPClient.GetFileList("/", true);

            foreach (var item in fileList)
            {
                Tools.YellowBlue(item + "\n");
                //Console.WriteLine();
            }



            FileWatcher.Path = @"X:\DownloadFTP";
            FileWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size | NotifyFilters.LastWrite | NotifyFilters.LastAccess;

            FileWatcher.Run();

            Console.WriteLine(FileWatcher.Path);
            Console.WriteLine(FileWatcher.NotifyFilter);
            Console.WriteLine(FileWatcher.FileFilter);

            //Run();


            //Console.ReadLine();
        }

        //[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        //public static void Run()
        //{
        //    using (FileSystemWatcher watcher = new FileSystemWatcher())
        //    {
        //        watcher.Path = @"X:\DownloadFTP";

        //        watcher.NotifyFilter = NotifyFilters.FileName
        //                             | NotifyFilters.DirectoryName
        //                             | NotifyFilters.LastWrite
        //                             | NotifyFilters.LastAccess;

        //        watcher.Filter = "*.txt";

        //        watcher.Changed += OnChanged;
        //        watcher.Created += OnChanged;
        //        watcher.Deleted += OnChanged;
        //        watcher.Renamed += OnRenamed;

        //        watcher.EnableRaisingEvents = true;



        //        Console.ReadLine();
        //    }
        //}

        //private static void OnRenamed(object sender, RenamedEventArgs e)
        //{
        //    Console.WriteLine($"File: {e.OldFullPath} renamed {e.FullPath}");
        //}

        //private static void OnChanged(object sender, FileSystemEventArgs e)
        //{
        //    Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        //}
    }
}
