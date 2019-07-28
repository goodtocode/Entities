//-----------------------------------------------------------------------
// <copyright file="VentureEntityOptionModel.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using Genesys.Entity.Option;
using Genesys.Extensions;
using Genesys.Framework.Data;

namespace Genesys.Entity.Venture
{
    /// <summary>
    /// For one selection in a OptionGroup's properties
    /// </summary>
    public class VentureEntityOptionModel : EntityModel<VentureEntityOptionModel>, IVentureEntityOption
    {
        private readonly OptionGroupModel _group = new OptionGroupModel();
        private readonly IQueryable<OptionModel> _selections;

        /// <summary>
        /// VentureKey regarding this Option
        /// </summary>
        public Guid VentureKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Entity regarding this Option
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Possible selections
        /// </summary>
        public IQueryable<OptionModel> Selections
        {
            get { return _selections; }
        }
        
        /// <summary>
        /// Group
        /// </summary>
        public OptionGroupModel Group
        {
            get { return _group; }
        }

        /// <summary>
        /// Option whose value is being selected
        /// </summary>
        public Guid OptionKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Selected value
        /// </summary>
        public string Value
        {
            get { return Selections.Where(x => x.Key == this.OptionKey).FirstOrDefault().Name; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public VentureEntityOptionModel()
            : base()
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        public VentureEntityOptionModel(IQueryable<OptionModel> selections)
            : base()
        {
            _selections = selections;
        }    }   
}