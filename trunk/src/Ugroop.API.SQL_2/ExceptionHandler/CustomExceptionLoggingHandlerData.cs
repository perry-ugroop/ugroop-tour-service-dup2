using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using Ugroop.API.SQL.ExceptionHandler;
using Ugroop.API.SQL.Helper;

namespace CustomExceptionLoggingHandler {
    [ConfigurationElementType(typeof(CustomExceptionLoggingHandlerData))]
    public class CustomExceptionLoggingHandler : IExceptionHandler {
        private readonly string logCategory;
        private readonly int eventId;
        private readonly TraceEventType severity;
        private readonly string defaultTitle;
        private readonly Type formatterType;
        private readonly int minimumPriority;
        private const string callstack = @"CallStack";
        private const string errormessage = @"ErrorMessage";
        private const string innerexception = @"InnerException";

        public CustomExceptionLoggingHandler(
            string logCategory,
            int eventId,
            TraceEventType severity,
            string title,
            int priority,
            Type formatterType
            ) {
            this.logCategory = logCategory;
            this.eventId = eventId;
            this.severity = severity;
            this.defaultTitle = title;
            this.minimumPriority = priority;
            this.formatterType = formatterType;
        }

        protected virtual void WriteToLog(string logMessage, IDictionary exceptionData, Exception exception) {
            LogEntry entry = new LogEntry(
                logMessage,
                logCategory,
                minimumPriority,
                eventId,
                severity,
                defaultTitle,
                null);

            foreach (DictionaryEntry dataEntry in exceptionData) {
                if (dataEntry.Key is string) {
                    entry.ExtendedProperties.Add(dataEntry.Key as string, dataEntry.Value);
                }
            }
            UGLogger.WriteDebugLog(entry.ToString());
        }

        public Exception HandleException(Exception exception, Guid handlingInstanceId) {
            // Add custom data to exception Data which will be added to Extended Properties and logged.

            if (!exception.Data.Contains(callstack)) {
                exception.Data.Add(callstack, exception.StackTrace);
                exception.Data.Add(errormessage, exception.Message);
            }
            if (exception.InnerException != null)
                exception.Data.Add(innerexception, exception.InnerException.Message);
            WriteToLog(CreateMessage(exception, handlingInstanceId), exception.Data, exception);
            return exception;
        }

        private string CreateMessage(Exception exception, Guid handlingInstanceID) {
            StringWriter writer = null;
            StringBuilder stringBuilder = null;
            try {
                writer = CreateStringWriter();
                Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionFormatter formatter = CreateFormatter(writer, exception, handlingInstanceID);
                formatter.Format();
                stringBuilder = writer.GetStringBuilder();
            }
            finally {
                if (writer != null) {
                    writer.Close();
                }
            }

            return stringBuilder.ToString();
        }

        protected virtual StringWriter CreateStringWriter() {
            return new StringWriter(CultureInfo.InvariantCulture);
        }

        private ConstructorInfo GetFormatterConstructor() {
            Type[] types = new Type[] { typeof(TextWriter), typeof(Exception), typeof(Guid) };
            ConstructorInfo constructor = formatterType.GetConstructor(types);
            if (constructor == null) {
                throw new ExceptionHandlingException("Unable to get the constructor.");
            }
            return constructor;
        }

        protected virtual Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionFormatter CreateFormatter(
            StringWriter writer,
            Exception exception,
            Guid handlingInstanceID) {
            ConstructorInfo constructor = GetFormatterConstructor();
            return (Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionFormatter)constructor.Invoke(
                new object[] { writer, exception, handlingInstanceID }
                );
        }
    }
}


