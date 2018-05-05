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

namespace Home
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void butExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn thoát chương trình?","",MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void butMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void but1_Click(object sender, EventArgs e)
        {
            panelMark.Top = but1.Top;
            panelMark.Height = but1.Height;
            getStringHTML("https://tiki.vn/dien-thoai-may-tinh-bang/c1789");
        }

        private void but2_Click(object sender, EventArgs e)
        {
            panelMark.Top = but2.Top;
            panelMark.Height = but2.Height;
            getStringHTML("https://tiki.vn/laptop-may-vi-tinh/c1846");
        }

        private void but3_Click(object sender, EventArgs e)
        {
            panelMark.Top = but3.Top;
            panelMark.Height = but3.Height;
            getStringHTML("https://tiki.vn/may-anh/c1801");


        }

        private void but4_Click(object sender, EventArgs e)
        {
            panelMark.Top = but4.Top;
            panelMark.Height = but4.Height;
            loadListView(getStringHTML("https://tiki.vn/nha-sach-tiki/c8322"));
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            getStringHTML(@"https://tiki.vn/search?q=" + txtSearch.Text);
        }

        private string getStringHTML(string search) {
            string HTML;
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                HTML = wc.DownloadString(search.Replace(" ", "+"));
            }
            return HTML;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //textBox1.Text = getStringHTML(@"https://tiki.vn/search?q=" + txtSearch.Text); //////////////////////////
            }
        }

        private void loadListView(string HTML) {

            WebRequest request;
            string s = @"class=""product - image img - responsive"" src=""(.+?)"" alt";
            MatchCollection m1 = Regex.Matches(HTML, s, RegexOptions.Singleline);

            //MatchCollection m2 = Regex.Matches(HTML, @"<span class=""final-price"">\s*(.+?)\s* ₫</span>", RegexOptions.Singleline);

            //string[] tenSP = new string[m1.Count];
            for (int i = 0; i < m1.Count; i++)
            {
                //request = WebRequest.Create(m1[i].Groups[1].Value);
                //using (var res = request.GetResponse())
                //using (var str = res.GetResponseStream())
                //{
                //    imageList1.Images.Add(Bitmap.FromStream(str));
                //    ListViewItem item = new ListViewItem();
                //    item.Text = "test";
                //    item.ImageIndex = 0;
                //    listView.Items.Add(item);
                //}
                textBox1.Text = m1[i].Groups[1].Value + "\n";
                //int gia = int.Parse(m2[i].Groups[1].Value.Replace(".", ""));
            }
        }

    }
}
