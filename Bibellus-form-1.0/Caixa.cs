using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibellus_form_1._0
{
    public partial class Vendas_panel : Form
    {
        public Vendas_panel()
        {
            InitializeComponent();
        }

        private void Vendas_panel_Shown(object sender, EventArgs e)
        {
            new Login().ShowDialog();
        }
    }
}
