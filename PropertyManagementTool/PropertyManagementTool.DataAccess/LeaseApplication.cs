
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
    
public partial class LeaseApplication
{

    public int LeaseApplicationId { get; set; }

    public int TenantId { get; set; }

    public int LeaseTermsId { get; set; }

    public int PropertyId { get; set; }

    public System.DateTime DateCreated { get; set; }

    public int LeaseApplicationStatusId { get; set; }



    public virtual LeaseTerm LeaseTerm { get; set; }

    public virtual Property Property { get; set; }

    public virtual Tenant Tenant { get; set; }

    public virtual LeaseApplicationStatu LeaseApplicationStatu { get; set; }

}

}
