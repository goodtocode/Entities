//-----------------------------------------------------------------------
// <copyright file="IEventAppointment.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Entity.Appointment;

namespace Genesys.Entity.Event
{
    /// <summary>
    /// Event created by a user
    /// </summary>	
    public interface IEventAppointment : IEventInfo, IAppointmentInfo
    {        
	}
}