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
using GoodToCode.Extensions.Text.Cleansing;
using GoodToCode.Framework.Activity;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EventInfo : ActiveRecordEntity<EventInfo>, IEvent
    {
        private readonly string name = Defaults.String;

        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EventInfo> CreateStoredProcedure
        => new StoredProcedure<EventInfo>()
        {
            StoredProcedureName = "EventInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EventGroupKey", EventGroupKey),
                new SqlParameter("@EventTypeKey", EventTypeKey),
                new SqlParameter("@EventCreatorKey", EventCreatorKey),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Description", Description),
                new SqlParameter("@Slogan", Slogan),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EventInfo> UpdateStoredProcedure
        => new StoredProcedure<EventInfo>()
        {
            StoredProcedureName = "EventInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EventGroupKey", EventGroupKey),
                new SqlParameter("@EventTypeKey", EventTypeKey),
                new SqlParameter("@EventCreatorKey", EventCreatorKey),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Description", Description),
                new SqlParameter("@Slogan", Slogan),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EventInfo> DeleteStoredProcedure
        => new StoredProcedure<EventInfo>()
        {
            StoredProcedureName = "EventInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// EventGroupId
        /// </summary>
        public Guid EventGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// EventTypeId
        /// </summary>
        public Guid EventTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// CreatorId
        /// </summary>
        public Guid EventCreatorKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Slogan
        /// </summary>
        public string Slogan { get; set; } = Defaults.String;

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<EventInfo>> Rules()
        {
            return new List<IValidationRule<EventInfo>>()
            {
                new ValidationRule<EventInfo>(x => x.Name.Length > 0, "Name is required"),
                new ValidationRule<EventInfo>(x => x.EventCreatorKey != Defaults.Guid, "CreatorKey is required")
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public EventInfo() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new EventInfo Save()
        {
            var writer = new StoredProcedureWriter<EventInfo>();
            Name = new HtmlUnsafeCleanser(Name).Cleanse().ToPascalCase();
            Description = new HtmlUnsafeCleanser(Description).Cleanse();
            return writer.Save(this);
        }

        /// <summary>
        /// Commits to database
        /// </summary>
        /// <param name="creatorKey">RequestingEntityId of creator</param>
        /// <param name="activity">Activity responsible for tracking this process</param>        
        public EventInfo Save(Guid creatorKey, IActivityContext activity)
        {
            EventCreatorKey = creatorKey;
            ActivityContextKey = activity.ActivityContextKey;
            return Save();
        }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}