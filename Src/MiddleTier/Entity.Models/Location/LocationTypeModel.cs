//-----------------------------------------------------------------------
// <copyright file="LocationTypeModel.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Location
{
    /// <summary>
    /// Type of Location
    /// </summary>    
    public class LocationTypeModel : ValueModel<LocationTypeModel>, ILocationType
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public LocationTypeModel()
            : base()
        { }
    }
}
