using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GithubSharp.Core.Services;

namespace SimpleLogProvider
{
    public class SimpleLogProvider : ILogProvider
    {
        #region ILogProvider Members

        public bool DebugMode
        {
            get;
            set;
        }

        public void LogMessage(string Message, params object[] Arguments)
        {
            if (DebugMode)
                WriteToLog(DatePrefix + " " + string.Format(Message, Arguments));
        }

        public void HandleError(Exception error)
        {
            if (!DebugMode)
                return;
            WriteToLog(DatePrefix + " " + string.Format("\n{0}\n{1}\n", error.Message, DebugMode ? error.StackTrace : ""));
            throw error;
        }

        #endregion

        private void WriteToLog(string Message)
        {
            try
            {
                System.IO.File.AppendAllText(LogFilePath, Message);
            }
            catch
            {
            }
        }

        private string LogFilePath
        {
            get
            {
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DatePrefix);
            }
        }

        private string DatePrefix
        {
            get
            {
                var now = DateTime.Now;
                return string.Format("{0}-{1}-{2}.log", now.Day, now.Month, now.Year);
            }
        }
    }
}
