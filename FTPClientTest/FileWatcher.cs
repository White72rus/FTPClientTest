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
    public class FileWatcher
    {
        public static string Path { get; set; }
        public static NotifyFilters NotifyFilter { get; set; }
        public static string FileFilter { get; set; } = "*.*";

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = Path;
                watcher.NotifyFilter = NotifyFilter;
                watcher.Filter = FileFilter;

                watcher.Changed += OnChanged;
                watcher.Created += OnCreated;
                watcher.Deleted += OnDeleted;
                watcher.Renamed += OnRenamed;

                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;

                Console.ReadLine();
            }
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (Tools.IsDerectory(e.FullPath))
            {
                Tools.Yellow($"Directory: {e.OldFullPath} renamed {e.FullPath} {e.ChangeType}");
            }
            else
            {
                Tools.Yellow($"File: {e.OldFullPath} renamed {e.FullPath} {e.ChangeType}");
            }
            //Console.WriteLine($"File: {e.OldFullPath} renamed {e.FullPath}");
            
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (Tools.IsDerectory(e.FullPath))
            {
                Tools.Yellow($"Directory: {e.FullPath} {e.ChangeType}");
            }
            else
            {
                Tools.Yellow($"File: {e.FullPath} {e.ChangeType}");
            }
            //Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            if (Tools.IsDerectory(e.FullPath))
            {
                Tools.Yellow($"Directory: {e.FullPath} {e.ChangeType}");
            }
            else
            {
                Tools.Yellow($"File: {e.FullPath} {e.ChangeType}");
            }
            //Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            if (false || string.IsNullOrEmpty(System.IO.Path.GetExtension(e.FullPath)))
            {
                Tools.Yellow($"Directory: {e.FullPath} {e.ChangeType}");
            }
            else
            {
                Tools.Yellow($"File: {e.FullPath} {e.ChangeType}");
            }
            //Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }
    }
}
