
using System;

namespace GithubSharp.Core.Models
{
	public class BlobItem
	{
		public string Sha { get; set; }
		public string Name { get; set; }
		public BlobItemType Type { get; set; }
	}
	
	public enum BlobItemType
	{
		Blob,
		Tree
	}
}
