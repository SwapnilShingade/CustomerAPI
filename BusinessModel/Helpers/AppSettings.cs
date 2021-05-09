using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModel.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string SiteURL { get; set; }
        public string PlasmaConnectionString { get; set; }
        public string RequestNotificationurl { get; set; }
        public string RequestReceivedNotification { get; set; }
        public string ResponseSentNotification { get; set; }
        public string[] AllowedOriginUrl { get; set; }

    }
}
