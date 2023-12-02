using linha_producao.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linha_producao
{
    public partial class PaginaLogin : Form
    {
        public PaginaLogin()
        {
            InitializeComponent();
        }

        private void buttonLogar_Click(object sender, EventArgs e)
        {
            try
            {       
                Funcionarios funcionarios = new Funcionarios(); 

                string email = textBoxEmail.Text;
                string senha = textBoxSenha.Text;
                
                funcionarios.email = email;
                funcionarios.SetSenha(senha);

                funcionarios.getFuncionariosPorEmailESenha();

                MessageBox.Show("Seja bem vindo(a), " + funcionarios.nome);

                if (funcionarios.logado)
                {
                    this.Hide();

                    PaginaPrincipal paginaPrincipal = new PaginaPrincipal();

                    paginaPrincipal.Show();
                }
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
