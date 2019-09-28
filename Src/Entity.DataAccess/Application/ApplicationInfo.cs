
using GoodToCode.Extensions;
using GoodToCode.Extensions.Data;
using GoodToCode.Framework.Data;
using System;

namespace GoodToCode.Entity.Application
{
    /// <summary>
    /// ApplicationInfo DAO
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ApplicationInfo : ActiveRecordValue<ApplicationInfo>, IApplication
    {
        /// <summary>
        /// Application name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Id of business owning this application
        /// </summary>
        public Guid BusinessKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Url of the privacy policy
        /// </summary>
        public string PrivacyUrl { get; set; } = Defaults.String;

        /// <summary>
        /// Date terms were revised. Must show terms again if user has not accepted current terms.
        /// </summary>
        public string TermsUrl { get; set; } = Defaults.String;

        /// <summary>
        /// Date terms were revised. Must show terms again if user has not accepted current terms.
        /// </summary>
        public DateTime TermsRevisedDate { get; set; } = Defaults.Date;
    }
}
