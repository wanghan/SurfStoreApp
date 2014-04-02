using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfStoreApp.Utils
{
    public class ETagUtils : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            // Occurs when ASP.NET has completed executing all request event handlers and the request state data has been stored.
            context.PostReleaseRequestState += Application_PostReleaseRequestState;
        }

        void Application_PostReleaseRequestState(object sneder, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Remove("ETag");
        }
    }
}