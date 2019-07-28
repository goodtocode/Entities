﻿//-----------------------------------------------------------------------
// <copyright file="IFlowRoute.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------

namespace Genesys.Entity.Flow
{
    /// <summary>
    /// Flow route info
    /// </summary>
    public interface IFlowRoute
    {
        /// <summary>
        /// Name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ControllerName
        /// </summary>
        string ControllerName { get; }

        /// <summary>
        /// Path
        /// </summary>
        string Path { get; }

        /// <summary>
        /// RootUrl
        /// </summary>
        string RootUrl { get; set; }
    }
}
