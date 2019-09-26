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
using System;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Flat and thin event model used for view only pages
    /// </summary>
    /// <remarks></remarks>
    public class EventDetailDto : EntityDto<EventDetailDto>, IEventDetail
    {
        /// <summary>
        /// EventId
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// DetailTypeId
        /// </summary>
        public Guid DetailTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Detail (Type) Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Detail (Type) Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Detail Data
        /// </summary>
        public string DetailData { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks></remarks>
        public EventDetailDto() : base() { }
    }
}