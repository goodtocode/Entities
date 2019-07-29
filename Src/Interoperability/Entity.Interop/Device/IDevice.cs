﻿//-----------------------------------------------------------------------
// <copyright file="Idevice.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using GoodToCode.Framework.Device;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Device
{
    /// <summary>
    /// Device
    /// </summary>    
    
    public interface IDevice : IName, IDeviceUuid, IApplicationUuid
    {
        /// <summary>
        /// Model
        /// </summary>
        string Model { get; set; }

        /// <summary>
        /// Manufacturer
        /// </summary>
        string Manufacturer { get; set; }

        /// <summary>
        /// OSName
        /// </summary>
        string OSName { get; set; }
    }
}
