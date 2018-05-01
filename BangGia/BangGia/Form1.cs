using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Globalization;

namespace BangGia
{
    public partial class Form1 : Form
    {
        string HTML;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[1].DefaultCellStyle.Format = "c0";
            dataGridView1.Columns[1].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-VN", "VND");
        }

        private void butGet_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                HTML = wc.DownloadString("https://tiki.vn/laptop-may-vi-tinh/c1846");
            }

            //textBox1.Text = HTML;

            MatchCollection m1 = Regex.Matches(HTML, @"data-title=""\s*(.+?)\s*""", RegexOptions.Singleline);

            MatchCollection m2 = Regex.Matches(HTML, @"<span class=""final-price"">\s*(.+?)\s* ₫</span>", RegexOptions.Singleline);

            string[] tenSP = new string[m1.Count];
            for (int i = 0; i<m1.Count;i++)
            {
                string name = m1[i].Groups[1].Value;
                int gia = int.Parse(m2[i].Groups[1].Value.Replace(".",""));
                dataGridView1.Rows.Add(name, gia);
            }
        }
    }
}
