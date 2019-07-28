//-----------------------------------------------------------------------
// <copyright file="ApplicationSetting.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Entity.Setting;
using Genesys.Extensions;
using Genesys.Extras.Data;
using Genesys.Framework.Data;
using Genesys.Framework.Repository;
using System;
using System.Linq;

namespace Genesys.Entity.Application
{
    /// <summary>
    /// Application DAO
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ApplicationSetting : ActiveRecordValue<ApplicationSetting>, IApplicationSetting
	{
        /// <summary>
        /// ApplicationId
        /// </summary>
        public Guid ApplicationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string SettingName { get; set; } = Defaults.String;

        /// <summary>
        /// Setting Id
        /// </summary>
        public Guid SettingKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Setting Type
        /// </summary>
        public Guid SettingTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Module's Setting value
        /// </summary>
        public string SettingValue { get; set; } = Defaults.String;

        /// <summary>
        /// Gets one setting for the application
        /// </summary>
        /// <param name="applicationKey">App Id to get settings</param>
        public static IQueryable<ApplicationSetting>GetByApplication(Guid applicationKey)
        {
            var reader = new ValueReader<ApplicationSetting>();
            return reader.GetByWhere(x => x.Key == applicationKey);
        }

        /// <summary>
        /// Gets one setting for the application
        /// </summary>
        /// <param name="applicationKey">App Id to get settings</param>
        /// <param name="settingTypeKey">Type of setting</param>
        
        public static ApplicationSetting GetByAll(Guid applicationKey, Guid settingTypeKey)
        {
            var reader = new ValueReader<ApplicationSetting>();
            var returnValue = reader.GetByWhere(x => x.Key == applicationKey & x.SettingTypeKey == settingTypeKey);
            return returnValue.FirstOrDefaultSafe();
        }
	}
}
