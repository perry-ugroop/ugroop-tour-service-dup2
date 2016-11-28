﻿using log4net;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Ugroop.API.SQL.ExceptionHandler {

    public class LogInterceptionBehavior : IInterceptionBehavior {

        public IEnumerable<Type> GetRequiredInterfaces() {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext) {
            // Execute the rest of the pipeline and get the return value
            IMethodReturn value = getNext()(input, getNext);
            // Deal with tasks, if needed
            var method = input.MethodBase as MethodInfo;
            if (value.ReturnValue != null && method != null && typeof(Task) == method.ReturnType) {
                // If this method returns a Task, override the original return value
                var task = (Task)value.ReturnValue;
                return input.CreateMethodReturn(CreateWrapperTask(task, input),
                  value.Outputs);
            }
            return value;
        }

        private async Task CreateWrapperTask(Task task, IMethodInvocation input) {
            try {
                await task.ConfigureAwait(false);
                //Trace.TraceInformation("Successfully finished async operation {0}",
                //input.MethodBase.Name);
            }
            catch (Exception e) {
                //Trace.TraceWarning("Async operation {0} threw: {1}",
                //input.MethodBase.Name, e);
                throw e;
            }
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
            _debugLogger.Debug(message.ErrorMessages);
        }

    }

}