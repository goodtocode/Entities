using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    public class SlotLocationDto : EntityDto<SlotLocationDto>, ISlotLocation
    {        
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<SlotLocationDto>> Rules()
            { return new List<IValidationRule<SlotLocationDto>>()
            {
                new ValidationRule<SlotLocationDto>(x => x.SlotName.Length > 0, "SlotName is required"),
                new ValidationRule<SlotLocationDto>(x => x.LocationName.Length > 0, "LocationName is required")
            };
        }

        /// <summary>
        /// Slot used
        /// </summary>
        public Guid SlotKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Slot
        /// </summary>
        public string SlotName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Slot
        /// </summary>
        public string SlotDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Location used in this slot
        /// </summary>
        public Guid LocationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Location where the event will be held
        /// </summary>
        public string LocationName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the event will be held
        /// </summary>
        public string LocationDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Location Type (forms a unique key with LocationKey)
        /// </summary>
        public Guid LocationTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public SlotLocationDto() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return LocationName;
        }
    }
}