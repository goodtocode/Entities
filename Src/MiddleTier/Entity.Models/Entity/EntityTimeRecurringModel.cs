//-----------------------------------------------------------------------
// <copyright file="EntityTimeRecurringModel.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Entity
{
    /// <summary>
    /// Events
    /// </summary>
    public class EntityTimeRecurringModel : EntityModel<EntityTimeRecurringModel>, IEntityTimeRecurring
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<EntityTimeRecurringModel>> Rules()
        {
            return new List<IValidationRule<EntityTimeRecurringModel>>()
            {
                new ValidationRule<EntityTimeRecurringModel>(x => x.EntityName.Length > 0, "EntityName is required")
            };
        }

        /// <summary>
        /// Entity that supports the days
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Entity where the event will be held
        /// </summary>
        public string EntityName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Entity where the event will be held
        /// </summary>
        public string EntityDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Beginning day of any 'term'
        /// </summary>
        public int BeginDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Ending day of any 'term'
        /// </summary>
        public int EndDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Event + Entity begin date
        /// </summary>
        public DateTime BeginTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Event + Entity end date
        /// </summary>
        public DateTime EndTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Iterval of the recurrance
        /// </summary>
        public int Interval { get; set; } = Defaults.Integer;

        /// <summary>
        /// Type of time this Entity is expressing (open, closed, etc.)
        /// </summary>
        public Guid TimeTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntityTimeRecurringModel() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return EntityName;
        }
    }
}