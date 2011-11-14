using System;

namespace GithubSharp.Plugins.LogProviders.NullLogger
{
	public class NullLogger : GithubSharp.Core.Services.ILogProvider
	{
		public NullLogger ()
			:this(false)
		{
		}

		public NullLogger (bool Debug)
		{
			DebugMode = Debug;
		}

		public void LogMessage (string Message, params object[] Arguments)
		{
		}

		public void LogWarning (string Message, params object[] Arguments)
		{
		}

		public bool HandleAndReturnIfToThrowError (Exception error)
		{
			return DebugMode;
		}

		public bool DebugMode {
			get;set;
		}
	}
}

