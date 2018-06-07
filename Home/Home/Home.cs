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
    public partial class Home : Form
    {
        
        public Home()
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
            string s = getStringHTML(@"https://tiki.vn/dien-thoai-may-tinh-bang/c1789");
            loadLinkProduct(s);
            loadLinkImage(s);
            loadIDProduct(s);
            loadListView(s);
            navi(s);
            
        }

        private void but2_Click(object sender, EventArgs e)
        {
            panelMark.Top = but2.Top;
            panelMark.Height = but2.Height;
            string s = getStringHTML(@"https://tiki.vn/laptop-may-vi-tinh/c1846");
            loadLinkProduct(s);
            loadLinkImage(s);
            loadIDProduct(s);
            loadListView(s);
            navi(s);
        }

        private void but3_Click(object sender, EventArgs e)
        {
            panelMark.Top = but3.Top;
            panelMark.Height = but3.Height;
            string s = getStringHTML(@"https://tiki.vn/may-anh/c1801");
            loadLinkProduct(s);
            loadLinkImage(s);
            loadIDProduct(s);
            loadListView(s);
            navi(s);
        }

        private void but4_Click(object sender, EventArgs e)
        {
          
            panelMark.Top = but4.Top;
            panelMark.Height = but4.Height;
            string s = getStringHTML(@"https://tiki.vn/nha-sach-tiki/c8322");
            loadLinkProduct(s);
            loadLinkImage(s);
            loadIDProduct(s);
            loadListView(s);
            navi(s);
        }

        private void markDefault()
        {
            panelMark.Location = new System.Drawing.Point(145, 74);
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            
            imageListLarge.Images.Clear();
            string s = getStringHTML(@"https://tiki.vn/search?q=" + txtSearch.Text.Replace(" ","+"));
            loadLinkProduct(s);
            loadLinkImage(s);
            loadIDProduct(s);
            loadListView(s);
            navi(s);


            markDefault();
            
        }
        string back, next;
        bool isBack(string html)
        {
            string s = @"class=""prev"" href=""\s*(.*?)\s*"">";
            Match m = null;
            m = Regex.Match(html,s,RegexOptions.Singleline);
            if (m.Groups[1].Value == "")
            {
                return false;
            }
            else {
                back = m.Groups[1].Value;
                return true;
                    }
        }
        bool isNext(string html)
        {
            string s = @"class=""next"" href=""\s*(.*?)\s*"">";
            Match m = null;
            m = Regex.Match(html, s, RegexOptions.Singleline);
            if (m.Groups[1].Value == "")
            {
                return false;
            }
            else
            {
                next = m.Groups[1].Value;
                return true;
            }
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

            return getSourceProductList(HTML);
            
        }

        private string getSourceProductList(string html) {
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

        string[] productName;
        string[] productPrice;
        private void loadListView(string HTML) {
            string s = @"data-title=""\s*(.*?)\s*""";
            MatchCollection m1 = null;
            m1 = Regex.Matches(HTML, s, RegexOptions.Singleline);

            MatchCollection m2 = Regex.Matches(HTML, @"<span class=""final-price"">\s*(.+?)\s* ₫</span>", RegexOptions.Singleline);
            List<string> tmpName = new List<string>();
            List<string> tmpPrice = new List<string>();

            //string[] tenSP = new string[m1.Count];
            for (int i = 0; i < m1.Count; i++)
            {
                
                ListViewItem item = new ListViewItem();
                string price = m2[i].Groups[1].Value;
                tmpName.Add(m1[i].Groups[1].Value);
                tmpPrice.Add(price);
                item.Text = m1[i].Groups[1].Value +"\r\n"+ price;
                item.ImageIndex = i;
                listView.Items.Add(item);
            }
            productName = tmpName.ToArray();
            productPrice = tmpPrice.ToArray();

        }

        string[] productID;
        private void loadIDProduct(string HTML)
        {
            productID = null;
            string s = @"data-seller-product-id=""\s*(.*?)\s*""";
            MatchCollection m1 = null;
            m1 = Regex.Matches(HTML, s, RegexOptions.Singleline);
            srcTmp.Clear();
            for (int i = 0; i < m1.Count; i++)
            {
                srcTmp.Add(m1[i].Groups[1].Value);
            }
            productID = srcTmp.ToArray();
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
            
        }
        
        public string[] srcLink;
        private void loadLinkProduct(string HTML)
        {
            string s = @"href=""\s*(.+?)\s*"" title";
            MatchCollection m = null;
            m = Regex.Matches(HTML, s, RegexOptions.Singleline);
            
            srcTmp = new List<string>();
            for (int i = 0; i < m.Count; i++)
            {
                if (m[i].Groups[1].Value.IndexOf("banner") < 0)
                    srcTmp.Add(m[i].Groups[1].Value);
            }

            this.srcLink = srcTmp.ToArray();
           
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
                    using (Bitmap resizedBitmap = new Bitmap(bitmap, 64, 64))
                    {            
                        imageListLarge.Images.Add(resizedBitmap);
                    }
                }
            }
        }
        private string url;
        ProductView pv;
        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pv.Show();
        }

        private void loadPageNumber(string HTML)
        {
            string s = @"href=""\s*(.+?)\s*"" title";
            MatchCollection m = null;
            m = Regex.Matches(HTML, s, RegexOptions.Singleline);
            srcTmp = new List<string>();
            for (int i = 0; i < m.Count; i++)
            {
                if (m[i].Groups[1].Value.IndexOf("banner") < 0)
                    srcTmp.Add(m[i].Groups[1].Value);
            }
            this.srcLink = srcTmp.ToArray();
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (listView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    pv = new ProductView();
                    int index = listView.SelectedItems[0].Index;
                    url = srcLink[index];
                    pv.Url = url;
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int index = listView.SelectedItems[0].Index;
            string s;
            bool available = false;
            StreamReader sr = new StreamReader("..//..//FavouritesList.txt");
            while (null != (s = sr.ReadLine())) {
                if (s.Split('|')[0] == productID[index])
                {
                    MessageBox.Show("Sản phẩm đã có trong danh sách ưa thích");
                    available = true;
                    break;
                }
            }
            sr.Close();

            if (!available)
            {
                try
                {
                    File.AppendAllText("..//..//FavouritesList.txt", productID[index]+"|" + srcLink[index] + Environment.NewLine);
                    //imageListLarge.Images[index].Save(@"..\\..\\FavouritesImage\"+productID[index]+".jpg");
                    MessageBox.Show("Đã thêm vào danh sách ưa thích");
                }
                catch (Exception ex) {
                    MessageBox.Show("Lỗi"+ex);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FavouritesView fv = new FavouritesView();
            fv.Show();
        }

        private void butBack_Click(object sender, EventArgs e)
        {
            string s = getStringHTML(@"https://tiki.vn"+back);
            loadLinkProduct(s);
            loadLinkImage(s);
            loadIDProduct(s);
            loadListView(s);
            navi(s);
        }

        private void butNext_Click(object sender, EventArgs e)
        {
            string s = getStringHTML(@"https://tiki.vn"+next);
            loadLinkProduct(s);
            loadLinkImage(s);
            loadIDProduct(s);
            loadListView(s);
            navi(s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelMark.Top = button3.Top;
            panelMark.Height = button3.Height;
            string s = getStringHTML(@"https://tiki.vn/thiet-bi-kts-phu-kien-so/c1815");
            loadLinkProduct(s);
            loadLinkImage(s);
            loadIDProduct(s);
            loadListView(s);
            navi(s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelMark.Top = button2.Top;
            panelMark.Height = button2.Height;
            string s = getStringHTML(@"https://tiki.vn/tivi-thiet-bi-nghe-nhin/c4221");
            loadLinkProduct(s);
            loadLinkImage(s);
            loadIDProduct(s);
            loadListView(s);
            navi(s);
        }

        void navi(string s)
        {
            if (isBack(s))
            {
                butBack.Visible = true;
                
            }
            else { butBack.Visible = false; }
            if (isNext(s))
            {
                butNext.Visible = true;
            }
            else { butNext.Visible = false; }
        }
    }
}
