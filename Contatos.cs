using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
            Mostrar();
        }

        private void btnCadastrarTelefone_Click(object sender, EventArgs e)
        {
            CadastrarTelefone cdT = new CadastrarTelefone();          
            cdT.Show();

            // cdT = cadastrar telefone
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                using(MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = agendacompleta; uid = root; pwd =; port = 3306;Convert Zero datetime = true" ;
                    cnx.Open();                    
                    string sql;
                    if (rbMasculino.Checked)
                    {
                        sql = "insert into pessoa (nome,cpf,dataNascimento,email,sexo,numeroCasa,complemento) values ('" + txtNome.Text + "','" + txtCPF.Text + "','" + txtData.Text + "','" + txtEmail.Text + "','" + rbMasculino.Text + "','" + txtNumeroCasa.Text + "','" + txtComplemento.Text + "')";

                    }
                    else
                    {
                        sql = "insert into pessoa (nome,cpf,dataNascimento,email,sexo,numeroCasa,complemento) values ('" + txtNome.Text + "','" + txtCPF.Text + "','" + txtData.Text + "','" + txtEmail.Text + "','" + rbFeminino.Text + "','" + txtNumeroCasa.Text + "','" + txtComplemento.Text + "')";

                    }
                    MessageBox.Show("Dados pessoais inseridos com sucesso!!!");
                    MySqlCommand cmd = new MySqlCommand(sql, cnx);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            try
            {
                addEndereco();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

     
        }
        void addEndereco()
        {

            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = agendacompleta; uid = root; pwd =; port = 3306; Convert Zero Datetime = true";
                    cnx.Open();
                    string sql2 = "insert into endereco (logradouro,bairro,cidade,cep,estadoUF) values ('" + txtLogradouro.Text + "','" + txtBairro.Text + "','" + txtCidade.Text + "','" + txtCEP.Text + "','" + cbUF.Text + "')";
                    MessageBox.Show("Endereco adicionado com sucesso !!!");
                    MySqlCommand cmd = new MySqlCommand(sql2, cnx);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            Mostrar();
        }
        void Mostrar()
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = agendacompleta; uid = root; pwd =; port = 3306; Convert Zero Datetime = true";
                    cnx.Open();
                    string sql = "select * from pessoa inner join endereco on endereco.idEndereco = pessoa.fkEndereco;";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cnx);
                    adapter.Fill(table);
                    dgwTabela.DataSource = table;
                    dgwTabela.AutoGenerateColumns = false;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
           /* try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = agendacompleta; uid = root; pwd =; port = 3306";
                    cnx.Open();
                    string sql = "insert into endereco (logradouro,bairro,cidade,cep,estadoUF) values ('" + txtLogradouro.Text + "','" + txtBairro.Text + "','" + txtCidade.Text + "','" + txtCEP.Text + "','" + cbUF.Text + "')";
                    MessageBox.Show("Endereco adicionado com sucesso !!!");
                    MySqlCommand cmd = new MySqlCommand(sql, cnx);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           */
        }

        private void dgwTabela_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgwTabela.CurrentRow.Index != -1)
            {
                txtID.Text = dgwTabela.CurrentRow.Cells[0].Value.ToString();               
                txtNome.Text = dgwTabela.CurrentRow.Cells[1].Value.ToString();             
                txtEmail.Text = dgwTabela.CurrentRow.Cells[2].Value.ToString();
                txtData.Text = dgwTabela.CurrentRow.Cells[3].Value.ToString();
                txtCPF.Text = dgwTabela.CurrentRow.Cells[4].Value.ToString();
                rbMasculino.Text = dgwTabela.CurrentRow.Cells[5].Value.ToString();
                rbFeminino.Text = dgwTabela.CurrentRow.Cells[6].Value.ToString();
                txtCEP.Text = dgwTabela.CurrentRow.Cells[7].Value.ToString();
                txtCidade.Text = dgwTabela.CurrentRow.Cells[8].Value.ToString();
                txtBairro.Text = dgwTabela.CurrentRow.Cells[9].Value.ToString();
                txtNumeroCasa.Text = dgwTabela.CurrentRow.Cells[10].Value.ToString();
                txtComplemento.Text = dgwTabela.CurrentRow.Cells[11].Value.ToString();
                cbUF.Text = dgwTabela.CurrentRow.Cells[12].Value.ToString();


            }
        }
    }
}
