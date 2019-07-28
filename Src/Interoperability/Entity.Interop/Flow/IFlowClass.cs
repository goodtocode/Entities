﻿//-----------------------------------------------------------------------
// <copyright file="IFlowClass.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------

using Genesys.Entity.Activity;
using Genesys.Framework.Session;

namespace Genesys.Entity.Flow
{
    /// <summary>
    /// Flow class
    /// </summary>
    public interface IFlowClass : IActivityFlow
    {
        /// <summary>
        /// Context
        /// </summary>
        ISessionContext Context { get; }

        /// <summary>
        /// Activity
        /// </summary>
        IActivityFlow Activity { get; }
    }
}
