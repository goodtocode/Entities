//-----------------------------------------------------------------------
// <copyright file="OptionInfo.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Extensions;
using GoodToCode.Extras.Data;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodToCode.Entity.Option
{
    /// <summary>
    /// OptionInfo
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class OptionInfo : ActiveRecordValue<OptionInfo>, IOption
	{
        /// <summary>
        /// Grouping of properties
        /// </summary>
        public Guid OptionGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Full name of the Option
        /// </summary>
        public string FullName { get; set; } = Defaults.String;

        /// <summary>
        /// Option code
        /// </summary>
        public string Code { get; set; } = Defaults.String;

        /// <summary>
        /// Full code of the Option
        /// </summary>
        public string FullCode { get; set; } = Defaults.String;

        /// <summary>
        /// Option name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public OptionInfo() : base()
		{
		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">Id</param>
        /// <param name="OptionGroupKey">OptionGroupId</param>
        /// <param name="name">Name</param>
        public OptionInfo(Guid key, Guid OptionGroupKey, string name) : this()
		{
			this.Key = key;
			this.OptionGroupKey = OptionGroupKey;
			this.Name = name;
		}

        /// <summary>
        /// Pulls only properties with a specific groupId
        /// </summary>
        /// <param name="OptionGroupKey">Option Group Key</param>
        public static IQueryable<OptionInfo> GetByGroup(Guid OptionGroupKey)
		{
            var reader = new ValueReader<OptionInfo>();
            var returnValue = reader.GetByWhere(x => x.OptionGroupKey == OptionGroupKey);
			return returnValue;
		}
		
	}
}
