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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void contatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contatos contato = new Contatos();
            contato.MdiParent = this;
            contato.Show();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agenda agenda = new Agenda();
            agenda.MdiParent = this;
            agenda.Show();
        }
    }
}
