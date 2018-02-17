//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PropertyManagementTool.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Property
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Property()
        {
            this.ParentProperty = new HashSet<Property>();
            this.Features = new HashSet<Feature>();
            this.Owners = new HashSet<Owner>();
        }
    
        public int Id { get; set; }
        public string Address { get; set; }
        public Nullable<double> Size { get; set; }
        public Nullable<double> Bedrooms { get; set; }
        public string Description { get; set; }
        public Nullable<int> PropertyStatusId { get; set; }
        public Nullable<int> ParentPropertyId { get; set; }
        public Nullable<double> Bathrooms { get; set; }
        public int OwnerId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Property> ParentProperty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feature> Features { get; set; }
        public virtual PropertyStatu PropertyStatus { get; set; }
        public virtual Owner Owner { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Owner> Owners { get; set; }
    }
}
