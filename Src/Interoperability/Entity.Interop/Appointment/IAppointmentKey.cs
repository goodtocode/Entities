﻿//-----------------------------------------------------------------------
// <copyright file="IAppointmentKey.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace GoodToCode.Entity.Appointment
{
    /// <summary>
    /// Appointment record
    /// </summary>
    public interface IAppointmentKey
    {
        /// <summary>
        /// AppointmentKey
        /// </summary>
        Guid AppointmentKey { get; set; }
    }
}
