using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linha_producao
{
    internal class Produtos:Conexao
    {
        public int id;

        public int id_empresa;

        public string nome;

        public DateTime data_cadastro;

        public List<Produtos> GetListaProdutos()
        {
            List<Produtos> produtos = new List<Produtos>();

            try
            {
                OpenConnection();

                string query = "SELECT * FROM produtos";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())

                        while (reader.Read())
                        {
                            Produtos novoProdutos = new Produtos();

                            novoProdutos.id = Convert.ToInt32(reader.GetString("id"));
                            novoProdutos.id_empresa = Convert.ToInt32(reader.GetString("id_empresa"));
                            novoProdutos.nome = reader.GetString("nome");
                            novoProdutos.data_cadastro = DateTime.Parse(reader.GetString("data_cadastro"));

                            produtos.Add(novoProdutos);
                        }
                }

                CloseConnection();

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return produtos;
        }

        public bool Insert()
        {

            try
            {

                string query = "INSERT INTO `produtos` (`id_empresa`,`nome`) VALUES (@id_empresa, @nome;";

                MySqlParameter[] param = new MySqlParameter[]
                {
                new MySqlParameter("@id_empresa", this.id_empresa),
                new MySqlParameter("@nome", this.nome),
                };

                this.ExecuteQueryWithParameters(query, param);

                return true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}