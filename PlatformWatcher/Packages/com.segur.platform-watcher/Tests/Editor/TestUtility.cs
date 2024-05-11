using System.IO;
using UnityEditor.PackageManager;

// ReSharper disable once CheckNamespace
namespace Segur.PlatformWatcher.Tests.Editor
{
    public static class TestUtility
    {
        private const string PackageName = "com.segur.platform-watcher";


        public static string GetPackagePath()
        {
            var request = Client.List();
            while (!request.IsCompleted)
            {
            }

            foreach (var package in request.Result)
            {
                if (package.name == PackageName)
                {
                    return package.resolvedPath;
                }
            }

            return "";
        }


        public static string GetTempFolderPath()
        {
            var tempPath = Path.GetTempPath();
            var folderPath = Path.Combine(tempPath, PackageName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return folderPath;
        }
    }
}