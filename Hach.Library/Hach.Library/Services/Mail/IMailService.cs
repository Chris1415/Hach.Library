﻿using Hach.Library.Repositories;

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
        /// <param name="sendEmptyMail">Flag to determine if the mail shall be send even if its empty</param>
        /// <returns>true if the mail sending was successfull, otherwise false</returns>
        bool SendMail(string subject, string body, string to, bool sendEmptyMail = true);

        /// <summary>
        /// Sends a Mail
        /// </summary>
        /// <param name="subject">Subject</param>
        /// <param name="to">To</param>
        /// <param name="identifier">The identifier of the composed mail</param>
        /// <param name="sendEmptyMail">Flag to determine if the mail shall be send even if its empty</param>
        /// <returns>true if the mail sending was successfull, otherwise false</returns>
        bool SendComposedMail(string subject, string to, string identifier, bool sendEmptyMail = true);

        /// <summary>
        /// Adds an Entry to the built mail and caches it
        /// </summary>
        void AddMailEntry(string entry, string identifier);

        /// <summary>
        /// Get the Mail Body for a speciic mail identified by the identifier
        /// </summary>
        /// <param name="identifier">the mail identifier</param>
        /// <returns>Body of the mail</returns>
        string GetMailBody(string identifier);

        #endregion
    }
}
