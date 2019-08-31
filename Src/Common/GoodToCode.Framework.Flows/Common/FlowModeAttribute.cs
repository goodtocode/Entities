﻿//-----------------------------------------------------------------------
// <copyright file="FlowMode.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace GoodToCode.Entity.Common
{
    /// <summary>
    /// Mode of a workflow (creating a new entity, etc.)
    /// </summary>

    [AttributeUsage(AttributeTargets.All)]
    public class FlowMode : System.Attribute
    {
        /// <summary>
        /// Attribute value
        /// </summary>
        public FlowModes Value { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Value</param>
        public FlowMode(FlowModes value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// The modes a workflow supports
    /// </summary>    
    public enum FlowModes
    {
        /// <summary>
        /// Default. Sets workflow to validate and save data
        /// </summary>
        ValidationAndSave = -1,

        /// <summary>
        /// Saves with no validation
        /// </summary>
        SaveOnly = 1,

        /// <summary>
        /// Validates and does not commit any data
        /// </summary>
        ValidationOnly = 2
    }

}
