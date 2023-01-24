﻿using Core.Utils.LogerConfiguration;

namespace Core.Utils.Helpers
{
    public class LoggerHelper
    {
        private LoggerHelper() { }

        public static void Error(string message)
        {
            ErrorLogger.Instance.LogMessage(message);
        }

        public static void Info(Action action)
        {
            InfoLogger.Instance.LogMessage(() => action());
        }
    }
}