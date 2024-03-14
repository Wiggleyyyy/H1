using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_gambling
{
    public partial class BlackJackHitOrStand : Form
    {
        public BlackJackHitOrStand()
        {
            InitializeComponent();
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            

            this.Close();
        }

        private void btnStand_Click(object sender, EventArgs e)
        {


            this.Close();
        }

        private void btnDoubleDown_Click(object sender, EventArgs e)
        {


            this.Close();
        }
    }
}
