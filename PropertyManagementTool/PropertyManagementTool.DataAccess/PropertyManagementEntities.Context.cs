﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PropertyManagementDbEntities : DbContext
    {
        public PropertyManagementDbEntities()
            : base("name=PropertyManagementDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<PropertyStatu> PropertyStatus { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<OwnerType> OwnerTypes { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
    }
}
