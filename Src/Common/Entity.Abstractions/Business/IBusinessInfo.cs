﻿//-----------------------------------------------------------------------
// <copyright file="IBusiness.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Framework.Name;
using System;

namespace GoodToCode.Entity.Business
{
    /// <summary>
    /// Business record
    /// </summary>
    public interface IBusinessInfo : IBusinessKey
    {
        /// <summary>
        /// TaxNumber
        /// </summary>
        string BusinessName { get; }

        /// <summary>
        /// TaxNumber
        /// </summary>
        string TaxNumber { get; set; }
    }
}