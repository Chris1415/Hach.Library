using Hach.Library.Services.Caching;

namespace Hach.Library.Repositories
{
    /// <summary>
    /// Mail Repository to access specific mail functionality
    /// </summary>
    /// <author>
    /// Christian Hahn, Okt-2016
    /// </author>
    public interface IMailRepository
    {
        #region Properties

        /// <summary>
        /// Predefined Service Facade
        /// </summary>
        ICachingService CachingService { get; }

        #endregion

        #region Interface 

        /// <summary>
        /// Adds an Entry to the built mail and caches it
        /// </summary>
        void AddMailEntry(string entry, string identifier);

        /// <summary>
        /// Clears all cached entries
        /// </summary>
        void ClearMail(string identifier);

        /// <summary>
        /// Gets the cached Mail
        /// </summary>
        /// <returns>mail as string</returns>
        string GetMail(string separator, string identifier);

        #endregion
    }
}
