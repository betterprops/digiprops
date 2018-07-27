
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
    
public partial class ExpenseIncomeCategory
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public ExpenseIncomeCategory()
    {

        this.Transactions = new HashSet<Transaction>();

        this.Bills = new HashSet<Bill>();

    }


    public int CategoryId { get; set; }

    public string Label { get; set; }

    public string Description { get; set; }

    public bool IsTaxDeductible { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Transaction> Transactions { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Bill> Bills { get; set; }

}

}
