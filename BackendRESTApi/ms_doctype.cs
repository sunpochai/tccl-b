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
    
    public partial class ms_doctype
    {
        public ms_doctype()
        {
            this.cf_route = new HashSet<cf_route>();
        }
    
        public string doc_type_code { get; set; }
        public string doc_type_desc { get; set; }
        public string create_user { get; set; }
        public string create_username { get; set; }
        public Nullable<System.DateTime> create_datetime { get; set; }
        public string update_user { get; set; }
        public string update_username { get; set; }
        public Nullable<System.DateTime> update_datetime { get; set; }
    
        public virtual ICollection<cf_route> cf_route { get; set; }
    }
}