//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace veriprojesi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbGuzellikSalonuEntities : DbContext
    {
        public DbGuzellikSalonuEntities()
            : base("name=DbGuzellikSalonuEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Islem> Islem { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Randevu> Randevu { get; set; }
        public virtual DbSet<SistemAdmini> SistemAdmini { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Yonetici> Yonetici { get; set; }
        public virtual DbSet<Salon> Salon { get; set; }
    }
}
