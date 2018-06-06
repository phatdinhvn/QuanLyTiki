using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;


namespace Home
{
    public partial class FavouritesView : Form
    {
        public FavouritesView()
        {
            InitializeComponent();
            
            listView.LargeImageList = imageList1;
            
        }

        //load link
        string[] tmp;
        private List<string> srcTmp = new List<string>();
        private string[] srcImg;

        private string getStringHTML(string url)
        {

            listView.Clear();
            string HTML = "";

            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                try
                {
                    HTML = wc.DownloadString(url);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi ket noi Internet." + ex);
                }
            }

            return HTML;

        }

        private void loadLinkImage(string HTML)
        {
            string s = @"alt=""Product"" src=""\s*(.+?)\s*""";
            Match m = null;
            m = Regex.Match(HTML,s,RegexOptions.Singleline);
            srcTmp.Add(m.Groups[1].Value);
        }

        private void loadImageToList()
        {
            imageList1.Images.Clear();
            srcImg = srcTmp.ToArray();
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
                        imageList1.Images.Add(resizedBitmap);
                    }
                }
            }
        }
        string[] url;
        private void FavouritesView_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("..//..//FavouritesList.txt");
            List<string> productURL = new List<string>();
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                productURL.Add(s.Split('|')[1]);
            }
            sr.Close();
            url = productURL.ToArray();
            foreach (string u in url)
            {
                loadProductName(getStringHTML(u));
                loadProductPrice(getStringHTML(u));
                loadLinkImage(getStringHTML(u));
            }
            productName = tmpName.ToArray();
            productPrice = tmpPrice.ToArray();
            loadImageToList();
            //load items
            for (int i = 0; i < File.ReadAllLines("..//..//FavouritesList.txt").Count(); i++)
            {
                listView.Items.Add(productName[i] + "\r\n" + productPrice[i], i);
            }
        }

        List<string> tmpName = new List<string>();
        List<string> tmpPrice = new List<string>();
        string[] productName;
        string[] productPrice;
        private void loadProductName(string HTML)
        {
            string s = @"id=""product-name"">\n\s*(.*?)\s*</h1>";
            Match m = null;
            m = Regex.Match(HTML, s, RegexOptions.Singleline);
            tmpName.Add(m.Groups[1].Value);
        }

        private void loadProductPrice(string HTML)
        {
            string s = @"id=""span-price"">\s*(.+?)\s*</span>";
            Match m = null;
            m = Regex.Match(HTML, s, RegexOptions.Singleline);
            tmpPrice.Add(m.Groups[1].Value);
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listView.SelectedItems[0].Index;
            ProductView pv = new ProductView(url[index]);
            pv.Show();
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
