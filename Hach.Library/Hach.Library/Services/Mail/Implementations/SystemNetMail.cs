using System;
using System.Net.Mail;
using Hach.Library.Configuration.Reader;
using Hach.Library.Repositories;
using Hach.Library.Repositories.Implementation;
using Hach.Library.Services.Facade;
using Hach.Library.Services.Facade.Implementations;
using NLog;

namespace Hach.Library.Services.Mail.Implementations
{
    /// <summary>
    /// General Mail Service
    /// </summary>
    /// <author>
    /// Christian Hahn, Okt-2016
    /// </author>
    public class SystemNetMail : IMailService
    {
        #region Properties

        /// <summary>
        /// Reference to the mail repository
        /// </summary>
        public IMailRepository MailRepository { get; }

        /// <summary>
        /// NLog
        /// </summary>
        private static readonly Logger Logger = Settings.Base.Logging ? LogManager.GetCurrentClassLogger() : LogManager.CreateNullLogger();

        #endregion

        #region c'tor

        /// <summary>
        /// Default c'tor
        /// </summary>
        public SystemNetMail()
        {
            MailRepository = new MailRepository();
        }

        #endregion

        #region Interface

        /// <summary>
        /// Sends a Mail
        /// </summary>
        /// <param name="subject">Subject</param>
        /// <param name="to">To</param>
        /// <param name="identifier">The identifier of the composed mail</param>
        /// <returns>true if the mail sending was successfull, otherwise false</returns>
        public bool SendComposedMail(string subject, string to, string identifier)
        {
            bool success = SendMail(subject, MailRepository.GetMail("<br />", identifier), to);
            this.MailRepository.ClearMail(identifier);
            return success;
        }

        /// <summary>
        /// Adds an Entry to the built mail and caches it
        /// </summary>
        public void AddMailEntry(string entry, string identifier)
        {
            this.MailRepository.AddMailEntry(entry, identifier);
        }


        /// <summary>
        /// Sends a Mail
        /// </summary>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <param name="to">To</param>
        /// <returns>true if the mail sending was successfull, otherwise false</returns>
        public bool SendMail(string subject, string body, string to)
        {
            string from = Settings.Mail.From;
            string host = Settings.Mail.Host;
            bool useDefaultCredentials = Settings.Mail.UseDefaultCredentials;
            string username = Settings.Mail.Username;
            string password = Settings.Mail.Password;
            int port = Settings.Mail.Port;
            bool enableSsl = Settings.Mail.EnableSsl;

            try
            {
                MailMessage mail = new MailMessage(from, to)
                {
                    IsBodyHtml = true,
                    Subject = subject,
                    Body = body
                };

                SmtpClient client = new SmtpClient
                {
                    Port = port,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = useDefaultCredentials,
                    Credentials = new System.Net.NetworkCredential(username, password),
                    Host = host,
                    EnableSsl = enableSsl
                };

                client.Send(mail);
            }
            catch (Exception e)
            {
                LogError(e);
                return false;
            }

            return true;
        }

        #endregion

        #region Helper

        /// <summary>
        /// Helper to log a complete Error
        /// </summary>
        /// <param name="e">Exception</param>
        private static void LogError(Exception e)
        {
            while (true)
            {
                if (e == null)
                {
                    return;
                }

                Logger.Error("SendMail: " + e.Message);
                e = e.InnerException;
            }
        }

        #endregion
    }
}
