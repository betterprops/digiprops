
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
    
public partial class PropertyStatu
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public PropertyStatu()
    {

        this.Properties = new HashSet<Property>();

    }


    public int PropertyStatusId { get; set; }

    public string Status { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Property> Properties { get; set; }

}

}
