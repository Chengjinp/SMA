//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository.DAL.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class SMA_Sale_Inventory_Xrf
    {
        public int xrfId { get; set; }
        public Nullable<int> SaleId { get; set; }
        public Nullable<int> ProductionId { get; set; }
        public Nullable<int> EnterUserId { get; set; }
        public Nullable<System.DateTime> EnterDate { get; set; }
    
        public virtual SMA_Inventory SMA_Inventory { get; set; }
        public virtual SMA_Lookup_User SMA_Lookup_User { get; set; }
        public virtual SMA_Sale SMA_Sale { get; set; }
    }
}
