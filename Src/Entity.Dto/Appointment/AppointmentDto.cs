﻿

using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Appointment
{
    /// <summary>
    /// Event location and time
    /// </summary>    
    public class AppointmentDto : EntityDto<AppointmentDto>, IAppointment
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<AppointmentDto>> Rules()
        { return new List<IValidationRule<AppointmentDto>>()
            {
                new ValidationRule<AppointmentDto>(x => x.EventKey != Defaults.Guid, "EventKey is required"),
                new ValidationRule<AppointmentDto>(x => x.Name.Length > 0, "Name is required"),
                new ValidationRule<AppointmentDto>(x => x.BeginDate != Defaults.Date, "BeginDate is required")
            };
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// BeginDate
        /// </summary>
        public DateTime BeginDate { get; set; } = Defaults.Date;

        /// <summary>
        /// EndDate
        /// </summary>
        public DateTime EndDate { get; set; } = Defaults.Date;

        /// <summary>
        /// EventKey
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// SlotLocationKey
        /// </summary>
        public Guid SlotLocationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// SlotResourceKey
        /// </summary>
        public Guid SlotResourceKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// TimeRangeKey
        /// </summary>
        public Guid TimeRangeKey { get; set; } = Defaults.Guid;
    }
}