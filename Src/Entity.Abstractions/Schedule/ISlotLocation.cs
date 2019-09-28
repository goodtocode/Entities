﻿
using GoodToCode.Entity.Location;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// A slot in a schedule + location
    /// </summary>
    public interface ISlotLocation : ISlotKey, ILocationInfo, ILocationTypeKey
    {
    }
}
