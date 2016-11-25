using log4net;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UGroopData.Sql.Service2.UGroopWeb.Helper.ExceptionHelper;
using UGroopData.Utilities.String;

namespace WebTester.ExceptionHandler {

    public class LogInterceptionBehavior : IInterceptionBehavior {

        public IEnumerable<Type> GetRequiredInterfaces() {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext) {
            // Before invoking the method on the original target.
            LogDebug(string.Format(
              "Invoking method {0} at {1}",
              input.MethodBase, DateTime.Now.ToLongTimeString()));

            // Invoke the next behaviour in the chain.
            var result = getNext()(input, getNext);
            //   After invoking the method on the original target.
            if (result.Exception != null) {
                throw result.Exception;
            }
            else {
                LogDebug(string.Format(
                  "Method {0} returned {1} at {2}",
                  input.MethodBase, result.ReturnValue,
                  DateTime.Now.ToLongTimeString()));
            }

            return result;
        }

        public bool WillExecute {
            get { return true; }
        }

        private void LogDebug(string message) {
            Console.WriteLine(message);
        }

    }

    public class LoggerHelper {

        private static readonly ILog _debugLogger;

        private static ILog GetLogger(string logName) {
            ILog log = LogManager.GetLogger(logName);
            return log;
        }

        static LoggerHelper() {
            //logger names are mentioned in <log4net> section of config file
            _debugLogger = GetLogger("DebugLoggerName");
        }

        public static void WriteDebugLog(string message) {
            _debugLogger.DebugFormat(message);
        }

        public static void WriteDebugLog(LogEntry message) {
            _debugLogger.Debug(message);
        }

    }

}