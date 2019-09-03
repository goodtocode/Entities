﻿//-----------------------------------------------------------------------
// <copyright file="IEventDetail.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace GoodToCode.Entity.Detail
{
    /// <summary>
    /// Detail of an event, like parking, tickets, etc.
    /// </summary>
    
    public interface IDetailTypeKey
    {
        /// <summary>
        /// DetailType
        /// </summary>
        Guid DetailTypeKey { get; set; }
    }
}