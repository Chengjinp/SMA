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
    
    public partial class SMA_Lookup_Designer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SMA_Lookup_Designer()
        {
            this.SMA_Sale = new HashSet<SMA_Sale>();
        }
    
        public int DesignerId { get; set; }
        public string DesignerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<decimal> DiscountRate { get; set; }
        public Nullable<int> ContactId { get; set; }
        public Nullable<int> EnterUserId { get; set; }
        public Nullable<System.DateTime> EnterDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual SMA_Lookup_Contact SMA_Lookup_Contact { get; set; }
        public virtual SMA_Lookup_User SMA_Lookup_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SMA_Sale> SMA_Sale { get; set; }
    }
}