using System;
using System.Collections.Generic;

namespace RESTful_Web_Services.Models
{
    public partial class Kategori
    {
        public Kategori()
        {
            Uruns = new HashSet<Urun>();
        }

        public int KategoriId { get; set; }
        public string? KategoriAdi { get; set; }

        public virtual ICollection<Urun> Uruns { get; set; }
    }
}
