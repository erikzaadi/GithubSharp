namespace GithubSharp.Core
{
    public class GithubURLs
    {
        public static string GithubApiBaseUrl
        {
            get { return "https://api.github.com"; }
        }


        public Models.GithubUser User { get; set; }
        private string _LoginString
        {
            get
            {
                return User != null && !string.IsNullOrEmpty(User.Name) && !string.IsNullOrEmpty(User.APIToken) ?
                    string.Format("?login={0}&token={1}", User.Name, User.APIToken)
                    : string.Empty;
            }
        }

        public string Repositories(string User)
        {
            return string.Format("http://github.com/api/v2/xml/repos/show/{0}{1}", User, _LoginString);
        }
        public string Repository(string User, string Repository)
        {
            return string.Format("http://github.com/api/v2/xml/repos/show/{0}/{1}{2}", User, Repository, _LoginString);
        }

        public string RawFile(string User, string Repository, string File)
        {
            return RawFile(User, Repository, File, "master");
        }

        public string RawFile(string User, string Repository, string File, string TreeShaOrBranchName)
        {
            return string.Format("http://github.com/{0}/{1}/raw/{2}/{3}{4}", User, Repository, File, TreeShaOrBranchName, _LoginString);
        }

        public string Commits(string User, string Repository)
        {
            return Commits(User, Repository, "master");
        }

        public string Commits(string User, string Repository, string BranchName)
        {
            return string.Format("http://github.com/api/v2/xml/commits/list/{0}/{1}/{2}{3}", User, Repository, BranchName, _LoginString);
        }

        public string BlobOrTree(string User, string Repository, string BlobOrThreeSha)
        {
            return string.Format("http://github.com/api/v2/xml/blob/show/{0}/{1}/{2}{3}", User, Repository, BlobOrThreeSha, _LoginString);
        }
    }
}
