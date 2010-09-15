namespace GithubSharp.MvcSample.MvcApplication.Models.ViewModels
{
    public class BaseViewModel<T> : IBaseViewModel where T : class
    {
        public Core.Models.GithubUser CurrentUser { get; set; }
        public T ModelParameter { get; set; }
        public string Notification { get; set; }
    }
	
	public interface IBaseViewModel
	{
		Core.Models.GithubUser CurrentUser { get; set; }
        string Notification { get; set; }        
    }
}
