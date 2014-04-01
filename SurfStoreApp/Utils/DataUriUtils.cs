using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SurfStoreApp.Utils
{
    public static class DataUriUtils
    {
        public static bool CanBrowserHandleDataUris()
        {
            float browserVersion = -1;

            HttpRequest httpRequest = HttpContext.Current.Request;
            HttpBrowserCapabilities browser = httpRequest.Browser;

            if (browser.Browser == "IE")
            {
                browserVersion = (float)(browser.MajorVersion + browser.MinorVersion);
            }

            if (browserVersion > 8 || browserVersion == -1)
            {
                // IE8+ or other browser
                return true;
            }

            return false;
        }

        public static MvcHtmlString DrawImage(this HtmlHelper helper, string imageUrl, string alt)
        {
            if (CanBrowserHandleDataUris() && IsFileSizeCorrect(imageUrl))
            {
                string fileType = Path.GetExtension(imageUrl);

                if (fileType != null)
                {
                    fileType = fileType.Replace(".", "");
                }

                string imageBase64Url = ConvertImageToBase64String(imageUrl);

                return new MvcHtmlString(String.Format("<img alt=\"{0}\" " +
                                     "src=\"data:image/{1};base64,{2}\" />", alt,
                                     fileType, imageBase64Url));
            }

            return new MvcHtmlString(String.Format("<img alt=\"{0}\" src=\"{1}\" />", alt, imageUrl));
        }

        private static bool IsFileSizeCorrect(string imageUrl)
        {
            string imagePath = HttpContext.Current.Server.MapPath(imageUrl);

            long fileLength = new FileInfo(imagePath).Length;

            //32 KB
            return fileLength < 32768;
        }

        private static string ConvertImageToBase64String(string imageUrl)
        {
            string imagePath = HttpContext.Current.Server.MapPath(imageUrl);

            using (Image image = Image.FromFile(imagePath))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, image.RawFormat);
                    byte[] imageBytes = memoryStream.ToArray();

                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
    }
}