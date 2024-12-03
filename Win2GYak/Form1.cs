using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win2GYak

{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
            button1.Click += buttonClick;
        }

        async void Start()
        {
            HttpClient client = new HttpClient();
            string url = "http://127.1.1.1:3000/kecskek";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string message = await response.Content.ReadAsStringAsync();
                List<KecskeClass> data = JsonConvert.DeserializeObject<List<KecskeClass>>(message);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        async void buttonClick(object s, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "http://127.1.1.1:3000/kecskek";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string message = await response.Content.ReadAsStringAsync();
                List<KecskeClass> data = JsonConvert.DeserializeObject<List<KecskeClass>>(message);
                listBox1.Items.Clear();
                foreach (KecskeClass item in data)
                {
                    listBox1.Items.Add($"Kecske neve: {item.neve}, kora: {item.kora}, súlya: {item.sulya}, magassága: {item.magassag}, neme: {item.neme}");

                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
