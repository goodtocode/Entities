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
using GoodToCode.Entity.Item;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// EntityItem
    /// </summary>
    public class ResourceItemDto : EntityDto<ResourceItemDto>, IItemInfo, IResourceInfo
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ResourceItemDto>> Rules()
        {
            return new List<IValidationRule<ResourceItemDto>>()
            {
                new ValidationRule<ResourceItemDto>(x => x.ResourceName.Length > 0, "ResourceName is required"),
                new ValidationRule<ResourceItemDto>(x => x.ItemName.Length > 0, "ItemName is required")
            };
        }

        /// <summary>
        /// ResourceKey
        /// </summary>
        public Guid ResourceKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// ResourceName
        /// </summary>
        public string ResourceName { get; set; } = Defaults.String;

        /// <summary>
        /// ResourceDescription
        /// </summary>
        public string ResourceDescription { get; set; } = Defaults.String;

        /// <summary>
        /// ItemKey
        /// </summary>
        public Guid ItemKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// ItemName
        /// </summary>
        public string ItemName { get; set; } = Defaults.String;

        /// <summary>
        /// ItemDescription
        /// </summary>
        public string ItemDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceItemDto()
            : base()
        {
        }
    }
}
