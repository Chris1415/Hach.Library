using Hach.Library.Models.Mail;
using Hach.Library.Services.Caching;
using Hach.Library.Services.Caching.Implementations;

namespace Hach.Library.Repositories.Implementation
{
    /// <summary>
    /// Mail Repository to access specific mail functionality
    /// </summary>
    /// <author>
    /// Christian Hahn, Okt-2016
    /// </author>
    public class MailRepository : IMailRepository
    {
        #region Properties

        /// <summary>
        /// Predefined Service Facade
        /// </summary>
        public ICachingService CachingService { get; }

        #endregion

        #region c'tor

        /// <summary>
        /// Default c'tor
        /// </summary>
        public MailRepository()
        {
            CachingService = new CachingService();
        }

        #endregion

        /// <summary>
        /// Adds an Entry to the built mail and caches it
        /// </summary>
        public void AddMailEntry(string entry, string identifier)
        {
            MailModel mail = (MailModel)this.CachingService.GetModel<MailModel>() ?? new MailModel();
            mail.AddEntry(identifier, entry);
            this.CachingService.SetModel<MailModel>(mail);
        }

        /// <summary>
        /// Clears all cached entries
        /// </summary>
        public void ClearMail(string identifier)
        {
            MailModel mail = (MailModel)this.CachingService.GetModel<MailModel>() ?? new MailModel();
            mail.ClearMail(identifier);
        }

        /// <summary>
        /// gets the cached mail
        /// </summary>
        public string GetMail(string separator, string identifier)
        {
            MailModel mail = (MailModel)this.CachingService.GetModel<MailModel>();
            return mail == null
                ? string.Empty 
                : mail.GetMailBody(identifier, separator);
        }
    }
}
