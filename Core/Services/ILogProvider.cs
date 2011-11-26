using System;

namespace GithubSharp.Core.Services
{
    public interface ILogProvider
    {
        bool DebugMode { get; set; }
        void LogMessage(string Message, params object[] Arguments);
        void LogWarning(string Message, params object[] Arguments);
        bool HandleAndReturnIfToThrowError(Exception error);
    }
}
