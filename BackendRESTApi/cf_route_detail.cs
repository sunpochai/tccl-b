//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackendRESTApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class cf_route_detail
    {
        public int route_d_id { get; set; }
        public int route_id { get; set; }
        public Nullable<int> route_level { get; set; }
        public string ad_user { get; set; }
        public string ad_fullname { get; set; }
        public string create_user { get; set; }
        public string create_username { get; set; }
        public System.DateTime create_datetime { get; set; }
    
        public virtual cf_route cf_route { get; set; }
    }
}
