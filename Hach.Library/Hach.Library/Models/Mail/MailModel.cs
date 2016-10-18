using System.Collections.Generic;
using Hach.Library.Models.Base;

namespace Hach.Library.Models.Mail
{
    /// <summary>
    /// Model to store information about mail
    /// </summary>
    /// <author>
    /// Christian Hahn, Okt-2016
    /// </author>
    public class MailModel : IModel
    {
        #region Properties

        /// <summary>
        /// Lines of Body as string
        /// </summary>
        public IDictionary<string, IList<string>> BodyLines { get; set; }

        #endregion

        #region Helper

        /// <summary>
        /// Adds an entry to the mail for the speicif identifier
        /// </summary>
        /// <param name="identifier">identifier</param>
        /// <param name="entry">entry to be safed</param>
        public void AddEntry(string identifier, string entry)
        {
            IList<string> lines;
            if(!this.BodyLines.TryGetValue(identifier, out lines))
            {
                this.BodyLines.Add(identifier, new List<string>()
                {
                    entry
                });

                return;
            }

            lines.Add(entry);
        }

        /// <summary>
        /// Clears the mail from a specific identifier
        /// </summary>
        /// <param name="identifier">identifier</param>
        public void ClearMail(string identifier)
        {
            this.BodyLines.Remove(identifier);
        }

        /// <summary>
        /// Gets the current status of the mail for an identifier as combined string
        /// </summary>
        /// <param name="identifier">identifier</param>
        /// <param name="separator">separator for the join of the lines</param>
        /// <returns>mail body as string </returns>
        public string GetMailBody(string identifier, string separator)
        {
            IList<string> lines;
            return !this.BodyLines.TryGetValue(identifier, out lines) 
                ? string.Empty 
                : string.Join(separator, lines);
        }

        #endregion

        #region c'tor

        /// <summary>
        /// c'tor
        /// </summary>
        public MailModel()
        {
            BodyLines = new Dictionary<string, IList<string>>();
        }

        #endregion
    }
}
