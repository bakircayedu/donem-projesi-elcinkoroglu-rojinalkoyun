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
    using System.Collections.Generic;
    
    public partial class Randevu
    {
        public int randevu_id { get; set; }
        public int musteri_id { get; set; }
        public System.DateTime randevu_tarih { get; set; }
        public int ıslem_id { get; set; }
        public Nullable<int> randevu_sayac { get; set; }
    
        public virtual Islem Islem { get; set; }
        public virtual Musteri Musteri { get; set; }
    }
}