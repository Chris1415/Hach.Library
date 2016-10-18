using Hach.Library.Repositories;

namespace Hach.Library.Services.Mail
{
    /// <summary>
    /// General Mail Service
    /// </summary>
    /// <author>
    /// Christian Hahn, Okt-2016
    /// </author>
    public interface IMailService
    {
        #region Properties

        /// <summary>
        /// Mail Repository
        /// </summary>
        IMailRepository MailRepository { get; }

        #endregion

        #region Interface

        /// <summary>
        /// Sends a Mail
        /// </summary>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <param name="to">To</param>
        /// <returns>true if the mail sending was successfull, otherwise false</returns>
        bool SendMail(string subject, string body, string to);

        /// <summary>
        /// Sends a Mail
        /// </summary>
        /// <param name="subject">Subject</param>
        /// <param name="to">To</param>
        /// <param name="identifier">The identifier of the composed mail</param>
        /// <returns>true if the mail sending was successfull, otherwise false</returns>
        bool SendComposedMail(string subject, string to, string identifier);

        /// <summary>
        /// Adds an Entry to the built mail and caches it
        /// </summary>
        void AddMailEntry(string entry, string identifier);

        #endregion
    }
}
