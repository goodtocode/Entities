﻿//-----------------------------------------------------------------------
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
//using System;
//using GoodToCode.Entity.Flow;
//using GoodToCode.Framework.Session;

//namespace GoodToCode.Entity.Person
//{
//    /// <summary>
//    /// Interop instructions
//    /// </summary>

//    public sealed class PersonManager : FlowInteropManager<IPerson>
//    {
//        /// <summary>
//        /// External Route to this workflow's endpoint for native apps and distributed systems
//        /// </summary>
//        public override IFlowRoute WebServicesRoute { get; protected set; } = new WorkfloRoute("Person", "Person");

//        /// <summary>
//        /// In-domain Route to this workflow's endpoint for WebServices, MVC apps and any other presentation tier functionality.
//        /// </summary>
//        public override IFlowRoute MidServicesRoute { get; protected set; } = new WorkfloRoute("Person", "Person");

//        /// <summary>
//        /// Constructor
//        /// </summary>
//        public PersonManager() : base() { }

//        /// <summary>
//        /// Constructor
//        /// </summary>
//        public PersonManager(ISessionContext context, IPerson dataIn) : base(context, dataIn) { }

//        /// <summary>
//        /// Constructor with hydration
//        /// </summary>
//        /// <param name="rootUrl">Root Url of the service without trailing slash</param>
//        /// <param name="context">User, device and app context</param>
//        /// <param name="dataIn">Data to be sent</param>
//        public PersonManager(string rootUrl, ISessionContext context, IPerson dataIn) : base(rootUrl, context, dataIn) { }
//    }
//}
