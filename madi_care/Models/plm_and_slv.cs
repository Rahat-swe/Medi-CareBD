//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace madi_care.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class plm_and_slv
    {
        public int plm_id { get; set; }
        public string plm_details { get; set; }
        public string plm_slv { get; set; }
        public Nullable<int> pid { get; set; }
        public Nullable<int> did { get; set; }
    
        public virtual doctor doctor { get; set; }
    }
}