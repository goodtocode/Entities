//-----------------------------------------------------------------------
// <copyright file="ActivityQueryflowDto.cs" company="GoodToCode">
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

namespace GoodToCode.Entity.Activity
{
    /// <summary>
    /// Activity data on a transactional Queryflow. Main activity record for any data committed to the system.
    /// </summary>
    public class ActivityQueryflowDto : EntityDto<ActivityQueryflowDto>, IActivityQueryflow
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ActivityQueryflowDto>> Rules()
        { return new List<IValidationRule<ActivityQueryflowDto>>()
            {
                new ValidationRule<ActivityQueryflowDto>(x => x.ApplicationKey != Defaults.Guid, "ApplicationKey is required and cannot be emtpy (00000000-0000-0000-0000-000000000000)"),
                new ValidationRule<ActivityQueryflowDto>(x => x.EntityKey != Defaults.Guid, "EntityKey is required and cannot be emtpy (00000000-0000-0000-0000-000000000000)"),
                new ValidationRule<ActivityQueryflowDto>(x => x.FlowKey != Defaults.Guid, "FlowKey is required and cannot be emtpy (00000000-0000-0000-0000-000000000000)")
            };
        }

        /// <summary>
        /// Application
        /// </summary>
        public Guid ApplicationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Entity
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Flow being executed
        /// </summary>
        public Guid FlowKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Sql statement executed in this Queryflow
        /// </summary>
        public string SqlStatement { get; set; } = Defaults.String;

        /// <summary>
        /// Identity (username) of the entity inserting this record
        /// Readonly
        /// </summary>
        public string IdentityUserName { get; internal set; } = Defaults.String;

        /// <summary>
        /// Device Universal Id that is requesting the insert of this record
        /// Readonly
        /// </summary>
        public string DeviceUuid { get; internal set; } = Defaults.String;

        /// <summary>
        /// Application Universal Id that is requesting the insert of this record
        /// Readonly
        /// </summary>
        public string ApplicationUuid { get; internal set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public ActivityQueryflowDto() : base() { }

        /// <summary>
        /// Determines if this flow can be processed
        /// </summary>
        public bool CanExecute()
        {
            return true;
        }

        /// <summary>
        /// Can insert to DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool CanInsert(IActivityFlow entity)
        {
            return true;
        }

        /// <summary>
        /// Can update DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool CanUpdate(IActivityFlow entity)
        {
            return true;
        }
    }
}
