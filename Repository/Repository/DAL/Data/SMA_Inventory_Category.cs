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
    
    public partial class SMA_Inventory_Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SMA_Inventory_Category()
        {
            this.SMA_Inventory = new HashSet<SMA_Inventory>();
            this.SMA_Inventory_Category_Type = new HashSet<SMA_Inventory_Category_Type>();
        }
    
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SMA_Inventory> SMA_Inventory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SMA_Inventory_Category_Type> SMA_Inventory_Category_Type { get; set; }
    }
}
