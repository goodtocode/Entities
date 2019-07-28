//-----------------------------------------------------------------------
// <copyright file="IAppointmentInfo.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Framework.Data;
using Genesys.Entity.Location;
using Genesys.Entity.Schedule;

namespace Genesys.Entity.Event
{
	/// <summary>
	/// Event and a location at a time
	/// </summary>	
	
	public interface IAppointment : IKey, IEventKey, ILocationKey, ITimeRange
	{
	}
}
