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
        public BlackJackData blackJackData = new BlackJackData();

        public BlackJackHitOrStand()
        {
            InitializeComponent();

            lblHand.Text = blackJackData.HitOrStandHand;

            if (blackJackData.HitOrStandIsFirstCard)
            {
                btnDoubleDown.Visible = true;
            }
        }

        private void btnHit_Click(object sender, EventArgs e)
        {

        }

        private void btnStand_Click(object sender, EventArgs e)
        {

        }

        private void btnDoubleDown_Click(object sender, EventArgs e)
        {

        }
    }
}
