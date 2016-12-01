using log4net;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ugroop.API.SQL.Helper {

    public class UGLogger {

        private static readonly ILog _debugLogger;
        private static readonly ILog _errorLogger;
        private static readonly ILog _infoLogger;

        private static ILog GetLogger(string logName) {
            ILog log = LogManager.GetLogger(logName);
            return log;
        }

        static UGLogger() {
            //logger names are mentioned in <log4net> section of config file
            _debugLogger = GetLogger("DebugLoggerName");
            _errorLogger = GetLogger("ErrorLoggerName");
            _infoLogger = GetLogger("InfoLoggerName");
        }

        public static void WriteDebugLog(string message) {
            _debugLogger.DebugFormat(message);
        }

        public static void WriteErrorLog(string message) {
            _errorLogger.ErrorFormat(message);
        }

        public static void WriteInfoLog(string message) {
            _errorLogger.InfoFormat(message);
        }

        public static void WriteDebugLog(LogEntry message) {
            _debugLogger.Debug(message.ErrorMessages);
        }

        public static void WriteErrorLog(LogEntry message) {
            _debugLogger.Error(message.ErrorMessages);
        }

        public static void WriteInfoLog(LogEntry message) {
            _debugLogger.Info(message.ErrorMessages);
        }

    }

}