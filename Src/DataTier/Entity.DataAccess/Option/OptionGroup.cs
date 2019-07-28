//-----------------------------------------------------------------------
// <copyright file="PropertyGroup.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extras.Data;
using Genesys.Framework.Data;

namespace Genesys.Entity.Option
{
    /// <summary>
    /// PropertyGroup
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class OptionGroup : ActiveRecordValue<OptionGroup>
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public OptionGroup() : base()
		{
		}
	}
}
