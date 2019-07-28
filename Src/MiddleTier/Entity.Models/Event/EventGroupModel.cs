//-----------------------------------------------------------------------
// <copyright file="EventGroup.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Framework.Data;

namespace Genesys.Entity.Event
{
    /// <summary>
    /// Type of event
    /// </summary>    
    public class EventGroupModel : ValueModel<EventGroupModel>, IEventGroup
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public EventGroupModel()
            : base()
        { }
    }
}
