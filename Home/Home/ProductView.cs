using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home
{
    public partial class ProductView : Form
    {
        public ProductView()
        {
            InitializeComponent();
            
        }

        string url;

        public string Url { get => url; set => url = value; }

        private void ProductView_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Url);
        }
    }
}
