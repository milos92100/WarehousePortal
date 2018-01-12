using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousePortal.Core
{
    class Logger
    {

        private const String LOG_FILE = "log.txt";

        private const String LogLevelDebug = "Debug";
        private const String LogLevelWarn = "Warn ";
        private const String LogLevelError = "Error";

        private static Logger _instance = null;

        public static Logger getInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }

            return _instance;
        }

        public void Debug(String text)
        {
            log(LogLevelDebug, text);
        }

        public void Warn(String text)
        {
            log(LogLevelWarn, text);
        }

        public void Error(String text)
        {
            log(LogLevelError, text);
        }

        private void log(String level, String text)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            sb.Append(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.Append(" ]");
            sb.Append("[ ");
            sb.Append(level);
            sb.Append(" ] ");
            sb.Append(text);

            writeToFile(sb.ToString());
        }

        private void writeToFile(String content)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(LOG_FILE))
                {
                    sw.WriteLine(content);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
