using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneYonetimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKitap_Click(object sender, EventArgs e)
        {
            new KitapForm().Show();
        }

        private void btnUye_Click(object sender, EventArgs e)
        {
            new UyeForm().Show();
        }

        private void btnOdunc_Click(object sender, EventArgs e)
        {
            new OduncForm().Show();
        }
    }
}
