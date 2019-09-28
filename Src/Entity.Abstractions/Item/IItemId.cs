﻿
using System;

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface IItemId
    {
        /// <summary>
        /// ItemId
        /// </summary>
        int ItemId { get; set; }
    }
}
