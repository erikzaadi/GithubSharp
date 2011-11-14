using System;

namespace GithubSharp.Core
{
	public interface IGithubRequestWithBinaryFileToSend : IGithubRequest
	{	
		System.IO.Stream BinaryToSend {get;set;}
	}
	
	public interface IGithubRequestWithBinaryFileToSendWithReturnType<TReturnType> : IGithubRequestWithBinaryFileToSend
		where TReturnType : class
	{	
	}
	
	//TODO : Implement if needed
	public class GithubRequestWithBinaryFileToSend
	{
		public GithubRequestWithBinaryFileToSend ()
		{
		}
	}
}

