using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GithubSharp.Core.Services;
using System.IO;

namespace GithubSharp.Plugins.LogProviders.SimpleLogProvider
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
                WriteToLog(DateTime.Now.ToString() + " " + string.Format(Message, Arguments));
        }
		
		
        public void LogWarning(string Message, params object[] Arguments)
        {
            WriteToLog(DateTime.Now.ToString() + " " + string.Format(Message, Arguments));
        }
		
		
		
        public bool HandleAndReturnIfToThrowError(Exception error)
        {
            WriteToLog(DatePrefix + " " + string.Format("{2}{0}{2}{1}{2}", error.Message, DebugMode ? error.StackTrace : "", Environment.NewLine));
            return DebugMode;
        }

        #endregion

        private void WriteToLog(string Message)
        {
            try
            {
                if (!Directory.Exists(LogDirPath))
                    Directory.CreateDirectory(LogDirPath);
                File.AppendAllText(LogFilePath, Message, Encoding.UTF8);
            }
            catch
            {
            }
        }

        private string LogDirPath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs"); }
        }
        private string LogFilePath
        {
            get { return Path.Combine(LogDirPath, DatePrefix); }
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
