using System;
namespace Hach.Library.Extensions
{
    public static class UriExtension
    {
        /// <summary>
        /// Helper to append a parameter to the given url
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="key">new key</param>
        /// <param name="value">new value</param>
        /// <returns>url with the new parameter</returns>
        public static string AppendParameter(this Uri url, string key, string value)
        {
            bool isParameterPresent = false;
            //In every loop adjust the Query Parameter
            string newUrl = url.AbsolutePath;

            // Split the Query into key value pairs
            foreach (string query in url.Query.Split('&'))
            {
                // Split each key value pair into the parts
                string[] param = query.Split('=');
                if (param.Length != 2)
                {
                    // Error Case no key and value
                    continue;
                }

                string extractedKey = param[0];
                string extractedValue = param[1];

                // Check if the Key is already in the query list
                if (extractedKey.Equals(key))
                {
                    // If it is, take the new value
                    extractedValue = value;
                    isParameterPresent = true;
                }

                newUrl += $"{extractedKey}={extractedValue}&";
            }

            // If the key was not already in the query list, add it
            if (!isParameterPresent)
            {
                newUrl += $"{key}={value}&";
            }

            // Return the appended url
            return newUrl;
        }
    }
}
