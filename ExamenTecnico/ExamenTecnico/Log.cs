using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenTecnico
{
    public static class Log
    {
        public static Logger Instance { get; private set; }
        static Log()
        {
            LogManager.ReconfigExistingLoggers();
            Instance = LogManager.GetCurrentClassLogger();
        }
    }
}
