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
    
    public partial class SMA_Sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SMA_Sale()
        {
            this.SMA_Sale_Detail = new HashSet<SMA_Sale_Detail>();
            this.SMA_Sale_Inventory_Xrf = new HashSet<SMA_Sale_Inventory_Xrf>();
        }
    
        public int SaleId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> DesignerId { get; set; }
        public Nullable<int> SalesRepId { get; set; }
        public Nullable<short> InvYear { get; set; }
        public Nullable<byte> InvMonth { get; set; }
        public Nullable<System.DateTime> TransationDate { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string Status { get; set; }
        public Nullable<int> EnterUserId { get; set; }
        public Nullable<System.DateTime> EnterDate { get; set; }
    
        public virtual SMA_Lookup_Customer SMA_Lookup_Customer { get; set; }
        public virtual SMA_Lookup_Designer SMA_Lookup_Designer { get; set; }
        public virtual SMA_Lookup_SalesRep SMA_Lookup_SalesRep { get; set; }
        public virtual SMA_Lookup_User SMA_Lookup_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SMA_Sale_Detail> SMA_Sale_Detail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SMA_Sale_Inventory_Xrf> SMA_Sale_Inventory_Xrf { get; set; }
    }
}
