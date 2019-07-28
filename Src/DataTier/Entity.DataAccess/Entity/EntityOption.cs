//-----------------------------------------------------------------------
// <copyright file="EntityOption.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Entity.Flow;
using Genesys.Entity.Option;
using Genesys.Extensions;
using Genesys.Extras.Data;
using Genesys.Framework.Data;
using Genesys.Framework.Repository;
using Genesys.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Genesys.Entity
{
    /// <summary>
    /// EntityOption 
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode"), DataAccessBehavior(DataAccessBehaviors.NoUpdate)]
    public class EntityOption : ActiveRecordEntity<EntityOption>, IEntityOption
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityOption> CreateStoredProcedure
        => new StoredProcedure<EntityOption>()
        {
            StoredProcedureName = "EntityOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@OptionKey", OptionKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityOption> UpdateStoredProcedure
        => new StoredProcedure<EntityOption>()
        {
            StoredProcedureName = "EntityOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@OptionKey", OptionKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityOption> DeleteStoredProcedure
        => new StoredProcedure<EntityOption>()
        {
            StoredProcedureName = "EntityOptionDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Key", Key),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<EntityOption>> Rules()
        {
            return new List<IValidationRule<EntityOption>>()
            { };
        }

        /// <summary>
        /// EntityId regarding this Option
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Option key
        /// </summary>
        public Guid OptionKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string OptionName { get; set; } = Defaults.String;

        /// <summary>
        /// Option Description
        /// </summary>
        public string OptionDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Option Group key
        /// </summary>
        public Guid OptionGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntityOption() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="optionKey">OptionId</param>
        /// <param name="entityKey">EntityId</param>
        public EntityOption(Guid entityKey, Guid optionKey)
            : base()
        {
            EntityKey = entityKey;
            OptionKey = optionKey;
        }

        /// <summary>
        /// Instantiates and saves one record
        /// </summary>
        /// <param name="OptionKey">OptionId</param>
        /// <param name="workflow">Workflow</param>
        public static EntityOption Create(Guid OptionKey, IFlowClass workflow)
        {
            var returnValue = new EntityOption(workflow.Context.EntityKey, OptionKey);
            returnValue.Save(workflow);
            return returnValue;
        }

        /// <summary>
        /// Instantiates and saves one record
        /// </summary>
        /// <param name="OptionKey">OptionId</param> 
        /// <param name="workflow">Workflow</param>

        public static EntityOption CreateOnePerGroup(Guid OptionKey, IFlowClass workflow)
        {
            var returnValue = new EntityOption(workflow.Context.EntityKey, OptionKey);
            EntityOption.Create(OptionKey, workflow);
            return returnValue;
        }

        /// <summary>
        /// Gets properties per entity
        /// </summary>
        /// <param name="EntityKey">EntityId</param>

        public static IQueryable<EntityOption> GetByEntity(Guid EntityKey)
        {
            var reader = new EntityReader<EntityOption>();
            return reader.GetByWhere(x => x.EntityKey == EntityKey);
        }

        /// <summary>
        /// Gets by Option and entity
        /// </summary>
        /// <param name="EntityKey">EntityId</param>
        /// <param name="OptionKey">OptionId</param>

        public static EntityOption GetByEntityOption(Guid EntityKey, Guid OptionKey)
        {
            var returnValue = new EntityOption();
            var reader = new EntityReader<EntityOption>();
            var dataSelection = reader.GetByWhere(x => x.EntityKey == EntityKey && x.OptionKey == OptionKey);
            returnValue = dataSelection.FirstOrDefaultSafe();
            returnValue.EntityKey = EntityKey;
            returnValue.OptionKey = OptionKey;
            return returnValue;
        }

        /// <summary>
        /// Gets by entity and group
        /// </summary>
        /// <param name="entityKey">EntityId</param>
        /// <param name="OptionGroupKey">OptionGroupId</param>
        public static IQueryable<EntityOption> GetByEntityOptionGroup(Guid entityKey, Guid OptionGroupKey)
        {
            var reader = new EntityReader<EntityOption>();
            return reader.GetByWhere(x => x.EntityKey == entityKey & x.OptionGroupKey == OptionGroupKey);
        }

        /// <summary>
        /// This resets and saves only 1 group of properties. 
        /// This will clear entire list if nothing is selected and fall-back to default
        /// </summary>
        /// <param name="OptionGroupKey">OptionGroupId</param>
        /// <param name="selectedProperties">SelectedProperties</param>
        /// <param name="workflow">Workflow processing this record</param>
        public static void Save(Guid OptionGroupKey,
            IEnumerable<EntityOption> selectedProperties, IFlowClass workflow)
        {
            // Start clean
            foreach (var conOption in EntityOption.GetByEntity(workflow.Activity.EntityKey).Where(x => x.OptionGroupKey == OptionGroupKey))
            {
                conOption.Delete(workflow);
            }
            // Add all selections
            foreach (var SelectedItem in selectedProperties)
            {
                EntityOption.Create(SelectedItem.OptionKey, workflow);
            }
        }

        /// <summary>
        /// This resets and saves only 1 group of properties
        /// This REQUIRES one Option to be selected for the group (i.e. Male/Female)
        /// </summary>
        /// <param name="workflow">Workflow processing this record</param>
        public void Save(IFlowClass workflow)
        {
            var reader = new EntityReader<EntityOption>();
            var groupKey = reader.GetByKey(OptionKey).OptionGroupKey;
            foreach (var conOption in EntityOption.GetByEntity(workflow.Activity.EntityKey).Where(x => x.OptionGroupKey == groupKey))
            {
                conOption.Delete(workflow);
            }
            EntityOption.Create(OptionKey, workflow);
        }

        /// <summary>
        /// This resets and saves only 1 group of properties
        /// This REQUIRES one Option to be selected for the group (i.e. Male/Female)
        /// </summary>
        /// <param name="workflow">Workflow processing this record</param>
        public void Delete(IFlowClass workflow)
        {
            var writer = new StoredProcedureWriter<EntityOption>();
            var reader = new EntityReader<EntityOption>();
            var groupKey = reader.GetByKey(OptionKey).OptionGroupKey;
            foreach (var conOption in EntityOption.GetByEntity(workflow.Activity.EntityKey).Where(x => x.OptionGroupKey == groupKey))
            {
                conOption.ActivityContextKey = workflow.Activity.Key;
                writer.Delete(conOption);
            }
            EntityOption.Create(OptionKey, workflow);
        }
    }
}