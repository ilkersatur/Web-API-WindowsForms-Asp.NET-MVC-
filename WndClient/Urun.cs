using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WndClient
{
    internal class Urun
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int KategoriId { get; set; }
        public decimal Fiyat { get; set; }
    }
}
