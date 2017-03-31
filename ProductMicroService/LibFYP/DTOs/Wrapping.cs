﻿namespace LibFYP.DTOs
{
    /// <summary>
    /// Class Wrapping.
    /// </summary>
    /// <seealso cref="LibFYP.Dto" />
    public class Wrapping : Dto
    {
        public virtual int RangeId { get; set; }
        public virtual string RangeName { get; set; }
        public virtual int TypeId { get; set; }
        public virtual string TypeName { get; set; }
        public virtual double Size { get; set; }
        public virtual double Price { get; set; }
        public virtual string StoreName { get; set; }
    }
}