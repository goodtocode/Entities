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
using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// EntityPerson
    /// </summary>
    public class ResourcePersonDto : EntityDto<ResourcePersonDto>, IFormattable, IPerson, IEntity
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ResourcePersonDto>> Rules()
        {
            return new List<IValidationRule<ResourcePersonDto>>()
            {
                new ValidationRule<ResourcePersonDto>(x => x.FirstName.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// ResourceKey
        /// </summary>
        public Guid ResourceKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// PersonKey
        /// </summary>
        public Guid PersonKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; } = Defaults.String;

        /// <summary>
        /// MiddleName
        /// </summary>
        public string MiddleName { get; set; } = Defaults.String;

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; } = Defaults.String;

        /// <summary>
        /// BirthDate
        /// </summary>
        public DateTime BirthDate { get; set; } = Defaults.Date;

        /// <summary>
        /// Gender Id (ISO/IEC 5218)
        /// </summary>
        public string GenderCode { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourcePersonDto()
            : base()
        {
        }

        /// <summary>
        /// Creates unsaved object with data
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthDate"></param>
        public ResourcePersonDto(string firstName, string middleName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        /// <summary>
        /// Concatenates name field into common combinations (lfm, lfMI, fMIl, fl, fml)
        /// </summary>
        /// <param name="format">lfm, lfMI, fMIl, fl, fml</param>
        /// <param name="formatProvider">ICustomFormatter compatible class</param>
        /// <returns>Name field formatted in common combinations (lfm, lfMI, fMIl, fl, fml)</returns>
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (formatProvider != null)
            {
                if (formatProvider.GetFormat(this.GetType()) is ICustomFormatter formatter) { return formatter.Format(format, this, formatProvider); }
            }
            switch (format)
            {
                case "lfm": return $"{this.LastName}, {this.FirstName} {this.MiddleName}";
                case "lfMI": return $"{this.LastName}, {this.FirstName} {this.MiddleName}.";
                case "fMIl": return $"{this.FirstName} {this.MiddleName}. {this.LastName}";
                case "fl": return $"{this.FirstName} {this.LastName}";
                case "fml":
                case "G":
                default: return $"{this.FirstName} {this.MiddleName} {this.LastName}";
            }
        }
    }
}
