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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Clientes clientes = new Clientes();

                clientes.nome = "Nicolas";
                clientes.id_empresa = 1;
                clientes.telefone = "19987654321";
                clientes.SetDocumento("48536274X");
                clientes.email = "nicolas@gmail.com";

                clientes.Insert();

                MessageBox.Show("Cliente adicionado com sucesso!");

                Empresas empresas = new Empresas();

                empresas.nome = "Suco de lalau";
                empresas.cnpj = "7737131";
                empresas.email = "socodelalau@gmail.com";

                empresas.Insert();

                MessageBox.Show("Empresas adicionado com sucesso!");

                Etapas etapas = new Etapas();

                etapas.nome = "Expremer lalaus";
                etapas.ordem = 1;
                etapas.id_processo = 1;

                etapas.Insert();

                MessageBox.Show("Etapas adicionado com sucesso!");

                Funcionarios funcionarios = new Funcionarios();

                funcionarios.email = "bruh@gmail.com";
                funcionarios.SetSenha("123");
                funcionarios.id_empresa = 2;
                funcionarios.nome = "Kemel Leite";
                funcionarios.SetNivel(1);

                funcionarios.Insert();

                MessageBox.Show("Funcionario adicionado com sucesso!");

                Insumos insumos = new Insumos();

                insumos.id_produto = 1;
                insumos.nome = "Lalau";
                insumos.quantidade = 23;
                insumos.unidade = "Toneladas";

                insumos.Insert();

                MessageBox.Show("Insumo adicionado com sucesso!");

                Linha_producao linha_producao = new Linha_producao();

                linha_producao.nome = "Amaçar isso ai";
                linha_producao.id_responsavel = 2;
                linha_producao.id_empresa = 1;
                linha_producao.id_setor = 2;

                linha_producao.Insert();

                MessageBox.Show("Linha de produção adicionado com sucesso!");

                Ordem_producao ordem_producao = new Ordem_producao(); //id_impresa`,`id_setor`,`id_cliente

                ordem_producao.id_empresa = 2;
                ordem_producao.id_setor = 2;
                ordem_producao.id_cliente = 2;

                ordem_producao.Insert();

                MessageBox.Show("Ordem de produção adicionado com sucesso!");

                Ordem_producao_tem_produtos ordem_Producao_tem_produtos = new Ordem_producao_tem_produtos();

                ordem_Producao_tem_produtos.id_ordem = 2;
                ordem_Producao_tem_produtos.id_produto = 2;
                ordem_Producao_tem_produtos.quantidade = 5;

                ordem_Producao_tem_produtos.Insert();

                MessageBox.Show("Ordem de produção que tem produto adicionado com sucesso!");

                Processos processos = new Processos(); // id_setor`,`nome`

                processos.id_setor = 2;
                processos.nome = "iMPLANATR UM PARTIDO";

                processos.Insert();

                MessageBox.Show("Processo adicionado com sucesso!");

                Produtos produtos = new Produtos(); // `id_empresa`,`nome`

                produtos.id_empresa = 2;
                produtos.nome = "Suco de laualu concentrado";

                produtos.Insert();

                MessageBox.Show("Produto adicionado com sucesso!");

                Setores setores = new Setores(); // id_empresa`,`id_responsavel`,`nome

                setores.id_empresa = 2;
                setores.id_responsavel = 2;
                setores.nome = "zzz";

                setores.Insert();

                MessageBox.Show("Setor adicionado com sucesso!");

            }

            catch (Exception ex) { 

            MessageBox.Show(ex.Message);

            }
        }
    }
}
