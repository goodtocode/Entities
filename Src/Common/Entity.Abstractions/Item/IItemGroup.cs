//-----------------------------------------------------------------------
// <copyright file="IItemGroup.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Item
{
	/// <summary>
	/// Item Group
	/// </summary>	
	
	public interface IItemGroup : INameKey
	{
        /// <summary>
        /// ItemGroupId
        /// </summary>
		Guid ItemGroupKey { get; set; }
	}
}
