﻿//-----------------------------------------------------------------------
// <copyright file="ILocationTimeRecurring.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Entity.Schedule;

namespace Genesys.Entity.Location
{
    /// <summary>
    /// A schedule. Schedule = Resource + TimeRecurring + Location
    /// </summary>    
    public interface ILocationTimeRecurring : ILocationInfo, ITimeRecurring, ITimeTypeKey
    {
    }
}
