﻿using System;
using System.Collections.Generic;
using System.IO;

namespace KafuuSwitcher
{
    static class Logger
    {
        public static void Log(object o)
        {
            LogInternal(o);
        }

        public static void Fatal(object o)
        {
            FatalIntenral(o);
        }

        static void LogInternal(object o)
        {
            var line = string.Format("{0} {1}", DateTime.Now, o);
            WriteLineToLog(line);
        }

        static void FatalIntenral(object o)
        {
            var line = string.Format("{0} FATAL!\r\n{1}", DateTime.Now, o);
            WriteLineToLog(line);
        }

        static void WriteLineToLog(string line)
        {
            File.AppendAllText(LogPath, line);
        }

        static string LogPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "KafuuSwitcher_log.txt");
            }
        }
    }
}
