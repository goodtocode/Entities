using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Name;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// EntityGender
    /// </summary>    
    public class GenderDto : EntityDto<GenderDto>, IFormattable, INameCode
    {
        /// <summary>
        /// List of Genders, bindable to int Id and string Name
        /// </summary>
        public List<Tuple<int, string, string>> GenderSelections()
        {
            return new List<Tuple<int, string, string>>() { Person.Genders.NotSet, Person.Genders.Male, Person.Genders.Female };
        }

        /// <summary>
        /// Friendly name of the Gender
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Gender code: M, F, N, U, A
        /// </summary>
        public string Code { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public GenderDto()
            : base()
        {
        }

        /// <summary>
        /// Concatenates name field into common combinations (G, cn)
        /// </summary>
        /// <param name="format">G (Name), cn (Code - Name)</param>
        /// <param name="formatProvider">ICustomFormatter compatible class</param>
        /// <returns>Name field formatted in common combinations</returns>
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (formatProvider != null)
            {
                if (formatProvider.GetFormat(GetType()) is ICustomFormatter formatter) { return formatter.Format(format, this, formatProvider); }
            }
            switch (format)
            {
                case "cn": return $"{Code} - {Name}";
                case "G":
                default: return this.Name;
            }
        }
    }
}
