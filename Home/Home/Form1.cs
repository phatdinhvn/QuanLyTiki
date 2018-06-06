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
            //textBox1.Text = "";
            //textBox1.Text = getStringHTML(@"https://tiki.vn/dien-thoai-may-tinh-bang/c1789");
            panelMark.Top = but1.Top;
            panelMark.Height = but1.Height;
            string s = getStringHTML(@"https://tiki.vn/dien-thoai-may-tinh-bang/c1789");
            loadLinkProduct(s);
            loadLinkImage(s);
            loadListView(s);
        }

        private void but2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            panelMark.Top = but2.Top;
            panelMark.Height = but2.Height;
            string s = getStringHTML(@"https://tiki.vn/laptop-may-vi-tinh/c1846");
            loadLinkProduct(s);
            loadLinkImage(s);
            loadListView(s);
        }

        private void but3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            panelMark.Top = but3.Top;
            panelMark.Height = but3.Height;
            string s = getStringHTML(@"https://tiki.vn/may-anh/c1801");
            loadLinkProduct(s);
            loadLinkImage(s);
            loadListView(s);

        }

        private void but4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            panelMark.Top = but4.Top;
            panelMark.Height = but4.Height;
            string s = getStringHTML(@"https://tiki.vn/nha-sach-tiki/c8322");
            loadLinkProduct(s);
            loadLinkImage(s);
            loadListView(s);
        }

        private void markDefault()
        {
            panelMark.Location = new System.Drawing.Point(145, 74);
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            imageListLarge.Images.Clear();
            string s = getStringHTML(@"https://tiki.vn/search?q=" + txtSearch.Text.Replace(" ","+"));
            loadLinkProduct(s);
            loadLinkImage(s);
            loadListView(s);
            
            
            markDefault();
            
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
                int posEnd = html.LastIndexOf(@"<div class=""box-recentlyviewed-product""");
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
                butSearch.PerformClick();
            }
        }

        private void loadListView(string HTML) {
            string s = @"data-title=""\s*(.*?)\s*""";
            MatchCollection m1 = null;
            m1 = Regex.Matches(HTML, s, RegexOptions.Singleline);

            MatchCollection m2 = Regex.Matches(HTML, @"<span class=""final-price"">\s*(.+?)\s* ₫</span>", RegexOptions.Singleline);

            //string[] tenSP = new string[m1.Count];
            for (int i = 0; i < m1.Count; i++)
            {
                
                ListViewItem item = new ListViewItem();
                string price = m2[i].Groups[1].Value;
                item.Text = m1[i].Groups[1].Value +"\r\n"+ price;
                item.ImageIndex = i;
                listView.Items.Add(item);
                
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView.View = View.LargeIcon;
            
            listView.SmallImageList = imageListSmall;
            listView.LargeImageList = imageListLarge;
            //listView.TileSize = new Size(listView.Width/4, 200);
        }

        private List<string> srcTmp;
        public string[] srcImg;
        private void loadLinkImage(string HTML) {
            string s = @"src=""\s*(.+?)\s*""";
            MatchCollection m = null;
            m = Regex.Matches(HTML, s, RegexOptions.Singleline);
            //srcImg = new string[m.Count];
            srcTmp = new List<string>();
            for (int i = 0; i < m.Count; i++)
            {
                if (m[i].Groups[1].Value.IndexOf("banner") < 0)
                    srcTmp.Add(m[i].Groups[1].Value);
            }

            this.srcImg = srcTmp.ToArray();
            loadImageToList();
            //foreach(string url in srcImg)
            //{
            //    textBox1.Text += url + "\r\n";
            //}
        }
        
        public string[] srcLink;
        private void loadLinkProduct(string HTML)
        {
            string s = @"href=""\s*(.+?)\s*"" title";
            MatchCollection m = null;
            m = Regex.Matches(HTML, s, RegexOptions.Singleline);
            //srcImg = new string[m.Count];
            srcTmp = new List<string>();
            for (int i = 0; i < m.Count; i++)
            {
                if (m[i].Groups[1].Value.IndexOf("banner") < 0)
                    srcTmp.Add(m[i].Groups[1].Value);
            }

            this.srcLink = srcTmp.ToArray();
            //loadImageToList();
            foreach (string url in srcLink)
            {
                textBox1.Text += url + "\r\n";
            }
        }

        private void loadImageToList()
        {
            imageListLarge.Images.Clear();
            using (WebClient webClient = new WebClient())
            {
                foreach (var url in this.srcImg)
                {
                    byte[] bitmapData;
                    bitmapData = webClient.DownloadData(url);

                    // Bitmap data => bitmap => resized bitmap.            
                    using (MemoryStream memoryStream = new MemoryStream(bitmapData))
                    using (Bitmap bitmap = new Bitmap(memoryStream))
                    using (Bitmap resizedBitmap = new Bitmap(bitmap, 50, 50))
                    {            
                        imageListLarge.Images.Add(resizedBitmap);
                    }
                }
            }
        }
        private string url;
        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ProductView pv = new ProductView();
            int index = listView.SelectedItems[0].Index;
            url = srcLink[index];
            pv.Url = url;
            pv.Show();
        }

        private void loadPageNumber(string HTML)
        {
            string s = @"href=""\s*(.+?)\s*"" title";
            MatchCollection m = null;
            m = Regex.Matches(HTML, s, RegexOptions.Singleline);
            //srcImg = new string[m.Count];
            srcTmp = new List<string>();
            for (int i = 0; i < m.Count; i++)
            {
                if (m[i].Groups[1].Value.IndexOf("banner") < 0)
                    srcTmp.Add(m[i].Groups[1].Value);
            }

            this.srcLink = srcTmp.ToArray();
            //loadImageToList();
            foreach (string url in srcLink)
            {
                textBox1.Text += url + "\r\n";
            }
        }
    }
}
