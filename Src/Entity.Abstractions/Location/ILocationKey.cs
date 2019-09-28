﻿
using System;

namespace GoodToCode.Entity.Location
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface ILocationKey
    {
        /// <summary>
        /// Location Key
        /// </summary>
        Guid LocationKey { get; set; }
    }
}
