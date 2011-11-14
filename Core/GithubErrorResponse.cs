using System;
using System.Collections.Generic;

namespace GithubSharp.Core
{
	public class GithubErrorResponse  : GithubResponseWithModel<GithubErrorResponseModel>
	{
	}
	
	
	public class GithubErrorResponseModel
	{
		public string Message {
			get;
			set;
		}
		
		public IEnumerable<GithubError> Errors {
			get;
			set;
		}
	}
	
	public class GithubError
	{
		public string Resource {
			get;
			set;
		}
		
		public string Field {
			get;
			set;
		}
		
		public string Code {
			get;
			set;
		}
	}
}

