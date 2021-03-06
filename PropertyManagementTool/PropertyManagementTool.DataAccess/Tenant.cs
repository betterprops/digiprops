
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
    
public partial class Tenant
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Tenant()
    {

        this.Leases = new HashSet<Lease>();

        this.LeaseApplications = new HashSet<LeaseApplication>();

        this.Bills = new HashSet<Bill>();

    }


    public int TenantId { get; set; }

    public string Name { get; set; }

    public System.DateTime DateOfBirth { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Lease> Leases { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<LeaseApplication> LeaseApplications { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Bill> Bills { get; set; }

}

}
