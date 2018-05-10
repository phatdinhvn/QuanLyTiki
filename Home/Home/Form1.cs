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
using System.IO;
using System.Web;

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
            textBox1.Text = "";

            panelMark.Top = but1.Top;
            panelMark.Height = but1.Height;
            loadListView(getStringHTML(@"https://tiki.vn/dien-thoai-may-tinh-bang/c1789"));
        }

        private void but2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            panelMark.Top = but2.Top;
            panelMark.Height = but2.Height;
            loadListView(getStringHTML(@"https://tiki.vn/laptop-may-vi-tinh/c1846"));
        }

        private void but3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            panelMark.Top = but3.Top;
            panelMark.Height = but3.Height;
            loadListView(getStringHTML(@"https://tiki.vn/may-anh/c1801"));


        }

        private void but4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            panelMark.Top = but4.Top;
            panelMark.Height = but4.Height;
            loadListView(getStringHTML(@"https://tiki.vn/nha-sach-tiki/c8322"));
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            loadListView(getStringHTML(@"https://tiki.vn/search?q=" + txtSearch.Text + "&ref=categorySearch"));
        }

        private string getStringHTML(string url) {

            listView.Clear();
            string HTML="";
            
            using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                try
                {
                    HTML = wc.DownloadString(url);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi ket noi Internet." +ex);
                }
            }

            return getProductList(HTML);
            
        }

        private string getProductList(string html) {
            try
            {
                int posStart = html.IndexOf(@"<div class=""product-box-list""");
                int posEnd = html.LastIndexOf(@"<div class=""list-pager"">");
                return html.Substring(posStart, posEnd - posStart);
            }

            catch {
                MessageBox.Show("Khong tim thay san pham");
                return "";
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Text = "";
                loadListView(getStringHTML(@"https://tiki.vn/search?q=" + txtSearch.Text+ "&ref=categorySearch"));
            }
        }

        private void loadListView(string HTML) {

            //WebRequest request; /html/body/div[6]/div/div[2]/div[4]

            //HtmlDocument doc = new HtmlDocument();

            string s = @"data-title=""\s*(.*?)\s*""";
            MatchCollection m1 = null;
            m1 = Regex.Matches(HTML, s, RegexOptions.Singleline);

            MatchCollection m2 = Regex.Matches(HTML, @"<span class=""final-price"">\s*(.+?)\s* ₫</span>", RegexOptions.Singleline);

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

                ListViewItem item = new ListViewItem();
                string price = m2[i].Groups[1].Value;
                item.Text = m1[i].Groups[1].Value +"\r\n"+ price;
                item.ImageIndex = 0;
                listView.Items.Add(item);
                //listView.Items.Add(i+1, m1[i].Groups[1].Value, m2[i].Groups[1].Value,0);
                //textBox1.Text = textBox1.Text +"\r\n"+ (i+1) +". " + m1[i].Groups[1].Value + "\r\n";
                //int gia = int.Parse(m2[i].Groups[1].Value.Replace(".", ""));
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView.View = View.LargeIcon;
            //listView.Columns.Add("Icon");
            //listView.Columns.Add("Names");
            //listView.Columns.Add("Price");
            listView.SmallImageList = imageListSmall;
            listView.LargeImageList = imageListLarge;
            //listView.TileSize = new Size(listView.Width/4, 200);
            
            
        }
    }
}
