namespace Arib_Task.Areas.Admin.Helpers
{
    public static class YouTubeHelper
    {
        public static string ConvertYouTubeUrlToEmbed(string url)
        {
            if(string.IsNullOrEmpty(url))
                return string.Empty;

            Uri uri;

            if(!Uri.TryCreate(url, UriKind.Absolute, out uri))
                return string.Empty;

            string videoId = null;
            if (uri.Host.Contains("youtube.com"))
            {
                var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
                videoId = query["v"];
            }
            else if (uri.Host.Contains("youtu.be"))
            {
                videoId = uri.AbsolutePath.Trim('/');
            }

            if (string.IsNullOrEmpty(videoId))
                return string.Empty;

            return $"https://www.youtube.com/embed/{videoId}";
        }

    }
}
