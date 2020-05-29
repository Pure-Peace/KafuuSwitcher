using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace KafuuSwitcher.Helpers
{
    static class HostsFile
    {
        private static string filePath;

        static HostsFile()
        {
            filePath = GetHostsPath();
        }

        public static List<string> ReadAllLines()
        {
            var lines = File.ReadAllLines(filePath);
            return lines.ToList();
        }

        public static void WriteAllLines(IEnumerable<string> lines)
        {
            bool roFlag = GetReadOnlyFlag(filePath);
            if (roFlag) DisableReadOnlyFlag(filePath);
            File.WriteAllLines(filePath, lines);
            if (roFlag) EnableReadOnlyFlag(filePath);
        }

        private static string GetHostsPath()
        {
            string windir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string result = Path.Combine(windir, "System32", "drivers", "etc", "hosts");
            CreateFileIfNotExists(result);

            return result;
        }

        private static void CreateFileIfNotExists(string filename)
        {
            if (!File.Exists(filename))
            {
                File.AppendAllText(filename, "#	127.0.0.1       localhost\r\n");
            }
        }

        private static bool GetReadOnlyFlag(string filepath)
        {
            var attr = File.GetAttributes(filepath);
            return attr.HasFlag(FileAttributes.ReadOnly);
        }

        private static void DisableReadOnlyFlag(string filepath)
        {
            var attr = File.GetAttributes(filepath);
            var a = attr ^ FileAttributes.ReadOnly;
            File.SetAttributes(filepath, a);
        }

        private static void EnableReadOnlyFlag(string filepath)
        {
            var attr = File.GetAttributes(filepath);
            var a = attr | FileAttributes.ReadOnly;
            File.SetAttributes(filepath, a);
        }
    }
}
