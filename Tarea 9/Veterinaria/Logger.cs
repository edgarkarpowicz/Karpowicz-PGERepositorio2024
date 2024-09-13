using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Logger
{
    internal class Logging
    {
        private static Logging _instance;
        private static readonly object _lock = new object();
        private static string logFilePath = "log.txt";

        private Logging()
        {
            using (StreamWriter logWriter = new StreamWriter(logFilePath, true))
            {
                logWriter.WriteLine("----- Log Inicio -----");
            }
        }

        public static Logging Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Logging();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Log(string message)
        {
            using (StreamWriter logWriter = new StreamWriter(logFilePath, true))
            {
                logWriter.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
