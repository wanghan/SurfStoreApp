using System;
using System.Configuration;
using System.IO;
using System.Web.Mvc;

namespace SurfStoreApp.Utils
{
    public static class CDNUtils
    {
        public static MvcHtmlString CDNUrl(this HtmlHelper helper, string contentPath)
        {
            contentPath = Path.GetFileName(contentPath);

            string cdnEndpoint = ConfigurationManager.AppSettings["CDNUrl"];

            Uri combinedUri = new Uri(new Uri(cdnEndpoint), contentPath);

            var url = new UrlHelper(helper.ViewContext.RequestContext);

            return new MvcHtmlString(url.Content(combinedUri.ToString()));
        }
    }
}