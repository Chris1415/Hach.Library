using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Hach.Library.Configuration.Reader
{
    /// <summary>
    /// Class to handle config Settings
    /// </summary>
    /// <author>
    /// Christian Hahn, Jun-2016
    /// </author>
    public static class Settings
    {
        /// <summary>
        /// Base Settings
        /// </summary>
        public static class Base
        {
            /// <summary>
            /// Get the Flag for logging as bool
            /// </summary>
            public static bool Logging
            {
                get
                {
                    const bool defaultValue = false;
                    try
                    {
                        string loggingValue = ConfigurationManager.AppSettings["Logging"] ?? string.Empty;
                        return Convert.ToBoolean(loggingValue);
                    }
                    catch (Exception)
                    {
                        return defaultValue;
                    }
                }
            }
        }

        /// <summary>
        /// Mail Settings
        /// </summary>
        public static class Mail
        {
            /// <summary>
            /// From
            /// </summary>
            public static string From
            {
                get
                {
                    try
                    {
                        return ConfigurationManager.AppSettings["From"] ?? string.Empty;
                    }
                    catch (ConfigurationErrorsException)
                    {
                        return string.Empty;
                    }
                }
            }

            /// <summary>
            /// From
            /// </summary>
            public static string To
            {
                get
                {
                    try
                    {
                        return ConfigurationManager.AppSettings["To"] ?? string.Empty;
                    }
                    catch (ConfigurationErrorsException)
                    {
                        return string.Empty;
                    }
                }
            }

            /// <summary>
            /// Host
            /// </summary>
            public static string Host
            {
                get
                {
                    try
                    {
                        return ConfigurationManager.AppSettings["Host"] ?? string.Empty;
                    }
                    catch (ConfigurationErrorsException)
                    {
                        return string.Empty;
                    }
                }
            }

            /// <summary>
            /// Port
            /// </summary>
            public static int Port
            {
                get
                {
                    try
                    {
                        string entry = ConfigurationManager.AppSettings["Port"] ?? string.Empty;
                        return int.Parse(entry);
                    }
                    catch (ConfigurationErrorsException)
                    {
                        return 587;
                    }
                }
            }

            /// <summary>
            /// Flag to determine if Default Credentials shall be used
            /// </summary>
            public static bool UseDefaultCredentials
            {
                get
                {
                    try
                    {
                        string entry = ConfigurationManager.AppSettings["UseDefaultCredentials"] ?? string.Empty;
                        return bool.Parse(entry);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }

            /// <summary>
            /// Flag to determine if Default Credentials shall be used
            /// </summary>
            public static bool EnableSsl
            {
                get
                {
                    try
                    {
                        string entry = ConfigurationManager.AppSettings["EnableSsl"] ?? string.Empty;
                        return bool.Parse(entry);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }

            /// <summary>
            /// Username 
            /// </summary>
            public static string Username
            {
                get
                {
                    try
                    {
                        return ConfigurationManager.AppSettings["Username"] ?? string.Empty;
                    }
                    catch (ConfigurationErrorsException)
                    {
                        return string.Empty;
                    }
                }
            }

            /// <summary>
            /// Password
            /// </summary>
            public static string Password
            {
                get
                {
                    try
                    {
                        return ConfigurationManager.AppSettings["Password"] ?? string.Empty;
                    }
                    catch (ConfigurationErrorsException)
                    {
                        return string.Empty;
                    }
                }
            }
        }

        /// <summary>
        /// Web Settings
        /// </summary>
        public static class Web
        {
            /// <summary>
            /// The Step With for Paging
            /// </summary>
            public static int ElementsPerPage
            {
                get
                {
                    const int defaultValue = 20;
                    try
                    {
                        string elements = ConfigurationManager.AppSettings["ElementsPerPage"] ?? string.Empty;
                        int elementsInInt = int.Parse(elements);
                        return elementsInInt <= 0 ? defaultValue : elementsInInt;
                    }
                    catch (Exception)
                    {
                        return defaultValue;
                    }
                }
            }

            /// <summary>
            /// The Number of Paging Elements to be printed
            /// </summary>
            public static int NumberOfPaingElements
            {
                get
                {
                    const int defaultValue = 5;
                    try
                    {
                        string distance = ConfigurationManager.AppSettings["NumberOfPaingElements"] ?? string.Empty;
                        int distanceInInt = int.Parse(distance);
                        return distanceInInt <= 0 ? defaultValue : distanceInInt;
                    }
                    catch (Exception)
                    {
                        return defaultValue;
                    }
                }
            }
        }

        public static class Google
        {
            /// <summary>
            /// Access the Google Maps Api Key
            /// </summary>
            public static string GoogleMapsApiKey
            {
                get
                {
                    try
                    {
                        return ConfigurationManager.AppSettings["GoogleMapsApiKey"] ?? string.Empty;
                    }
                    catch (ConfigurationErrorsException)
                    {
                        return string.Empty;
                    }
                }
            }

            /// <summary>
            /// Access the Base Price Url
            /// </summary>
            public static string BaseGoolgeGeolocationServiceUrl
            {
                get
                {
                    try
                    {
                        return ConfigurationManager.AppSettings["BaseGoogleGeolocationService"] ?? string.Empty;
                    }
                    catch (ConfigurationErrorsException)
                    {
                        return string.Empty;
                    }
                }
            }
        }

        public static string Repository
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["Repository"] ?? string.Empty;
                }
                catch (ConfigurationErrorsException)
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Access Caching Time
        /// </summary>
        public static int CachingTime
        {
            get
            {
                try
                {
                    string cachingTime = ConfigurationManager.AppSettings["CachingTime"] ?? string.Empty;
                    return int.Parse(cachingTime);
                }
                catch (Exception)
                {
                    return 1440;
                }
            }
        }
    }
}
