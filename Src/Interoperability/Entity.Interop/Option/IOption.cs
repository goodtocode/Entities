//-----------------------------------------------------------------------
// <copyright file="IOption.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Option
{
	/// <summary>
	/// Option that is selectable for any entity
	/// </summary>
	public interface IOption : INameKey
	{
        /// <summary>
        /// OptionGroupId
        /// </summary>
		Guid OptionGroupKey { get; set; }

        /// <summary>
        /// FullName
        /// </summary>
        string FullName { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// FullCode
        /// </summary>
        string FullCode { get; set; }
    }
}
