using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Services
{
    public interface ILogProvider
    {
        bool DebugMode { get; set; }
        void LogMessage(string Message, params object[] Arguments);
        void HandleError(Exception error);
    }
}
