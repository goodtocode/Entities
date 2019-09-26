﻿//-----------------------------------------------------------------------
// <copyright file="CustomerModel.cs" company="GoodToCode">
//      Copyright (c) 2017-2018 GoodToCode. All rights reserved.
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
using System.Collections.Generic;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Customer screen model for binding and transport
    /// </summary>
    /// <remarks></remarks>
    public class GenderList : IGenderList
    {        

        /// <summary>
        /// List of Genders, bindable to int Id and string Name
        /// </summary>
        public List<Tuple<int, string, string>> Genders
        {
            get
            {
                return GenderList.GetAll();
            }
        }

        /// <summary>
        /// List of Genders, bindable to int Id and string Name
        /// </summary>
        public static List<Tuple<int, string, string>> GetAll()
        {
            return new List<Tuple<int, string, string>>() { Person.Genders.NotSet, Person.Genders.Male, Person.Genders.Female };
        }
    }
}