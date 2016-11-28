using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Diagnostics;
using UGroopData.Utilities.String;

namespace Ugroop.API.SQL.ExceptionHandler {

    public class ExceptionManagerSinglton {
        private static readonly ExceptionManagerSinglton instance = new ExceptionManagerSinglton();
        private const string Debug_cate = "Debug";
        private const string Error_cate = "Error";
        private const string Info_cate = "Information";
        private ExceptionManager exManager;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static ExceptionManagerSinglton() {
        }

        private ExceptionManagerSinglton() {
            this.createExceptionPolicy();
        }

        private void createExceptionPolicy() {
            var policies = new List<ExceptionPolicyDefinition>();
            var LogAndReThrowExceptionPolicy = new List<ExceptionPolicyEntry>
             {
                {
                    new ExceptionPolicyEntry(typeof (FormatException),
                    PostHandlingAction.NotifyRethrow,
                    new IExceptionHandler[]
                    {
                        new CustomExceptionLoggingHandler.CustomExceptionLoggingHandler(
                          Error_cate, 1,TraceEventType.Error,
                             "FormatException", 1,
                             typeof(TextExceptionFormatter))
                    })
                },

                  {
                    new ExceptionPolicyEntry(typeof (ValidationException),
                    PostHandlingAction.NotifyRethrow,
                    new IExceptionHandler[]
                    {
                        new CustomExceptionLoggingHandler.CustomExceptionLoggingHandler(
                          Info_cate, 1,TraceEventType.Information,
                             "ValidationException", 1,
                             typeof(TextExceptionFormatter))
                    })
                },
                {
                    new ExceptionPolicyEntry(typeof (SqlException),
                    PostHandlingAction.NotifyRethrow,
                    new IExceptionHandler[]
                    {
                        new CustomExceptionLoggingHandler.CustomExceptionLoggingHandler(
                          Error_cate, 1,TraceEventType.Error,
                             "SQLException", 1,
                             typeof(TextExceptionFormatter))
                    })
                },
                   {
                    new ExceptionPolicyEntry(typeof (InvalidCastException),
                    PostHandlingAction.NotifyRethrow,
                    new IExceptionHandler[]
                    {
                        new CustomExceptionLoggingHandler.CustomExceptionLoggingHandler(
                          Error_cate, 1,TraceEventType.Error,
                             "InvalidCastException", 1,
                             typeof(TextExceptionFormatter))
                    })
                },
            };
            policies.Add(new ExceptionPolicyDefinition(
                AppSettingsConstant.LogReThrowExceptionPolicy, LogAndReThrowExceptionPolicy));

            exManager = new ExceptionManager(policies);
        }

        public static ExceptionManagerSinglton Instance {
            get {
                return instance;
            }
        }

        public ExceptionManager exceptionManager() {
            return exManager;
        }

    }

}
