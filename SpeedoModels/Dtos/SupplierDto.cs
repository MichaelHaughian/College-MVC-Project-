// ***********************************************************************
// Assembly         : SpeedoModels
// Author           : Michael Haughian
// Created          : 04-27-2018
//
// Last Modified By : Michael Haughian
// Last Modified On : 05-29-2018
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedoModels.Dtos
{
    /// <summary>
    /// Class SupplierDto.
    /// </summary>
    public class SupplierDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
    }
}