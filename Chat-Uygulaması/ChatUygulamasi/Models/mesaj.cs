//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatUygulamasi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class mesaj
    {
        public int mesajId { get; set; }
        public Nullable<int> gonderenId { get; set; }
        public string aliciAdi { get; set; }
        public string icerik { get; set; }
        public Nullable<int> rolId { get; set; }
    
        public virtual kullanicilar kullanicilar { get; set; }
        public virtual roller roller { get; set; }
    }
}
