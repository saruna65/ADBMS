//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MEMBERSHIP
    {
        public decimal MEMBERSHIP_NO { get; set; }
        public string MEMBERSHIP_TYPE { get; set; }
        public Nullable<decimal> MEM_PERIOD { get; set; }
        public string STATUS { get; set; }
        public Nullable<System.DateTime> PAY_DATE { get; set; }
        public Nullable<decimal> PRICE { get; set; }
    }
}
