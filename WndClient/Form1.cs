using Newtonsoft.Json;
using System.Net.Http.Json;

namespace WndClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient istemci = new HttpClient();
            string data=istemci.GetStringAsync("http://localhost:5184/api/Urun").Result;
            //MessageBox.Show(data);
            var urunler = JsonConvert.DeserializeObject<List<Urun>>(data);
            dataGridView1.DataSource=urunler;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HttpClient istemci = new HttpClient();
            Urun urun = new Urun() { 
                UrunAdi=textBox1.Text,
                KategoriId=Convert.ToInt32(textBox2.Text),
                Fiyat=Convert.ToDecimal(textBox3.Text)
            };

            var resp = istemci.PostAsJsonAsync("http://localhost:5184/api/Urun", urun).Result;
            if (resp.IsSuccessStatusCode)
            {
                MessageBox.Show("Ýþlem baþarýyla gerçekleþtirildi");
            }
            else
            {
                MessageBox.Show(resp.Content.ReadAsStringAsync().Result);
            }
        }
    }
}