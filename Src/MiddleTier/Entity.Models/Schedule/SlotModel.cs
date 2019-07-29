//-----------------------------------------------------------------------
// <copyright file="SlotModel.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Validation;
using System.Collections.Generic;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    public class SlotModel : EntityModel<SlotModel>, ISlot
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<SlotModel>> Rules()
            { return new List<IValidationRule<SlotModel>>()
            {
                new ValidationRule<SlotModel>(x => x.Name.Length > 0, "LocationName is required")
            };
        }

        /// <summary>
        /// Name of Location where the event will be held
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the event will be held
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public SlotModel() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}