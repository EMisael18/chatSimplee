using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChatSimple
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void cREARSERVIDORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServidor servidor = new frmServidor();
            servidor.Show();
        }

        private void uNIRSEASERVIDORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente cliente = new frmCliente();
            cliente.Show();
        }
    }
}
