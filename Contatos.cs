using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaCompleta
{
    public partial class Contatos : Form
    {
        public Contatos()
        {
            InitializeComponent();
        }

        private void btnCadastrarTelefone_Click(object sender, EventArgs e)
        {
            CadastrarTelefone cdT = new CadastrarTelefone();          
            cdT.Show();
        }
    }
}
