using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NLog.Config;

namespace Gravitybox.GeoLocation.LocationService
{
    public static class Logger
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public static System.Collections.ObjectModel.ReadOnlyCollection<NLog.Targets.Target> Targets
        {
            get { return _logger.Factory.Configuration.AllTargets; }
        }

        public static void LogWarnException(string text, System.Exception exception)
        {
            LogWarnException(text, exception, false);
        }

        public static void LogWarnException(string text, System.Exception exception, bool ingoreTimeout)
        {
            if (exception is System.Threading.ThreadAbortException)
                return;

            LogEvent(NLog.LogLevel.Warn, string.Empty, text, exception, null);

            if (exception.InnerException != null)
                LogWarnException("Inner Exception", exception.InnerException);
        }

        public static void LogInfo(string text)
        {
            LogInfo(text, null);
        }

        public static void LogInfo(string text, params object[] args)
        {
            LogEvent(NLog.LogLevel.Info, string.Empty, text, null, args);
        }

        public static void LogDebug(Exception ex)
        {
            LogEvent(NLog.LogLevel.Debug, string.Empty, string.Empty, ex, null);
        }

        public static void LogDebug(string text, System.Exception ex)
        {
            LogEvent(NLog.LogLevel.Debug, string.Empty, text, ex, null);
        }

        public static void LogDebug(string text)
        {
            LogEvent(NLog.LogLevel.Debug, string.Empty, text, null, null);
        }

        public static void LogDebug(string text, params object[] args)
        {
            LogEvent(NLog.LogLevel.Debug, string.Empty, text, null, args);
        }

        public static void LogWarning(string text)
        {
            LogEvent(NLog.LogLevel.Warn, string.Empty, text, null, null);
        }

        public static void LogWarning(string text, params object[] args)
        {
            LogEvent(NLog.LogLevel.Warn, string.Empty, text, null, args);
        }

        public static void LogError(string text)
        {
            _logger.Error(text);
        }

        public static void LogError(System.Exception exception)
        {
            LogError(string.Empty, exception);
        }

        public static void LogError(string text, System.Exception exception)
        {
            LogError(text, exception, false);
        }

        public static void LogError(string text, System.Exception exception, bool ingoreTimeout)
        {
            if (exception is System.Threading.ThreadAbortException)
                return;

            LogEvent(NLog.LogLevel.Error, string.Empty, text, exception, null);

            if (exception.InnerException != null)
                LogError("Inner Exception", exception.InnerException);
        }

        private static void LogEvent(NLog.LogLevel logLevel, string loggerName, string message, Exception exception, params object[] args)
        {
            NLog.LogEventInfo logEventInfo = new NLog.LogEventInfo(logLevel, loggerName, message);

            if (exception != null)
            {
                // Get any additional data that might have been passed into the exception.Data collection
                System.Text.StringBuilder sbAdditionalData = new System.Text.StringBuilder();

                foreach (object key in exception.Data.Keys)
                {
                    sbAdditionalData.AppendFormat("{0}: {1} ~ ", key.ToString(), exception.Data[key].ToString());
                }

                logEventInfo.Exception = exception;
                logEventInfo.Properties["AdditionalData"] = sbAdditionalData.ToString();
            }

            if (args != null)
            {
                logEventInfo.Parameters = args;
            }

            _logger.Log(logEventInfo);
        }
    }
}