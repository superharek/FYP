﻿using System.Collections.Generic;

namespace LibFYP.DTOs
{
    /// <summary>
    /// Class Giftbox.
    /// </summary>
    /// <seealso cref="LibFYP.Dto" />
    public class Giftbox : Dto
    {
        public virtual double Total { get; set; }
        public virtual int WrappingId { get; set; }
        public virtual int WrappingTypeId { get; set; }
        public virtual string WrappingTypeName { get; set; }
        public virtual int WrappingRangeId { get; set; }
        public virtual string WrappingRangeName { get; set; }
        public virtual bool Removed { get; set; }
        public virtual bool Visible { get; set; }
        public virtual bool Available { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}