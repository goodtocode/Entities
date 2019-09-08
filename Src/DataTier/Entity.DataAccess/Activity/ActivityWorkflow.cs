//-----------------------------------------------------------------------
// <copyright file="" company="GoodToCode">
//      Copyright (c) 2017-2020 GoodToCode. All rights reserved.
//      Licensed to the Apache Software Foundation (ASF) under one or more 
//      contributor license agreements.  See the NOTICE file distributed with 
//      this work for additional information regarding copyright ownership.
//      The ASF licenses this file to You under the Apache License, Version 2.0 
//      (the 'License'); you may not use this file except in compliance with 
//      the License.  You may obtain a copy of the License at 
//       
//        http://www.apache.org/licenses/LICENSE-2.0 
//       
//       Unless required by applicable law or agreed to in writing, software  
//       distributed under the License is distributed on an 'AS IS' BASIS, 
//       WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  
//       See the License for the specific language governing permissions and  
//       limitations under the License. 
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Extensions;
using GoodToCode.Extensions.Data;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Activity
{
    /// <summary>
    /// Activity data on a transactional Workflow. Main activity record for any data committed to the system.
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode"), DataAccessBehavior(DataAccessBehaviors.NoDelete)]
    public class ActivityWorkflow : ActiveRecordEntity<ActivityWorkflow>, IActivityWorkflow
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ActivityWorkflow> CreateStoredProcedure
        => new StoredProcedure<ActivityWorkflow>()
        {
            StoredProcedureName = "ActivityWorkflowInsert",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Key", Key),
                new SqlParameter("@FlowKey", FlowKey),
                new SqlParameter("@ApplicationKey", ApplicationKey),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@FlowStepKey", FlowStepKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ActivityWorkflow> UpdateStoredProcedure
        => new StoredProcedure<ActivityWorkflow>()
        {
            StoredProcedureName = "ActivityWorkflowUpdate",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@FlowKey", FlowKey),
                new SqlParameter("@ApplicationKey", ApplicationKey),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@FlowStepKey", FlowStepKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Does not support deletes
        /// </summary>
        public override StoredProcedure<ActivityWorkflow> DeleteStoredProcedure => throw new NotImplementedException();

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ActivityWorkflow>> Rules()
        {
            return new List<IValidationRule<ActivityWorkflow>>()
            {
                new ValidationRule<ActivityWorkflow>(x => x.ApplicationKey != Defaults.Guid, "ApplicationKey is required and cannot be emtpy (00000000-0000-0000-0000-000000000000)"),
                new ValidationRule<ActivityWorkflow>(x => x.EntityKey != Defaults.Guid, "EntityKey is required and cannot be emtpy (00000000-0000-0000-0000-000000000000)"),
                new ValidationRule<ActivityWorkflow>(x => x.FlowKey != Defaults.Guid, "FlowKey is required and cannot be emtpy (00000000-0000-0000-0000-000000000000)")
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
        /// FlowStepKey
        /// </summary>
        public Guid FlowStepKey { get; set; } = Defaults.Guid;

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
        public ActivityWorkflow() : base() { }

        /// <summary>
        /// Saves data
        /// </summary>
        public new ActivityWorkflow Save()
        {
            var returnValue = new ActivityWorkflow();
            var writer = new StoredProcedureWriter<ActivityWorkflow>();

            if (this.CanExecute() == true)
            {
                returnValue = writer.Save(this);
            }
            else
            {
                throw new System.Exception("Workflow can not be processed.");
            }

            return returnValue;
        }

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
