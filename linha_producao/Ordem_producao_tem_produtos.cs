using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linha_producao
{
    internal class Ordem_producao_tem_produtos:Conexao
    {
        public int id;

        public int id_ordem;

        public int id_produto;

        public double quantidade;

        public DateTime data_cadastro;

        public List<Ordem_producao_tem_produtos> GetListaOrdem_producao_tem_produtos()
        {
            List<Ordem_producao_tem_produtos> ordem_producao_tem_produtos = new List<Ordem_producao_tem_produtos>();

            try
            {
                OpenConnection();

                string query = "SELECT * FROM ordem_producao_tem_produtos;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())

                        while (reader.Read())
                        {
                            Ordem_producao_tem_produtos novoOrdem_producao_tem_produtos = new Ordem_producao_tem_produtos();

                            novoOrdem_producao_tem_produtos.id = Convert.ToInt32(reader.GetString("id"));
                            novoOrdem_producao_tem_produtos.id_ordem = Convert.ToInt32(reader.GetString("id_ordem"));
                            novoOrdem_producao_tem_produtos.id_produto = Convert.ToInt32(reader.GetString("id_produto"));
                            novoOrdem_producao_tem_produtos.quantidade = Convert.ToDouble(reader.GetString("quantidade"));
                            novoOrdem_producao_tem_produtos.data_cadastro = DateTime.Parse(reader.GetString("data_cadastro"));

                            ordem_producao_tem_produtos.Add(novoOrdem_producao_tem_produtos);
                        }
                }

                CloseConnection();

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return ordem_producao_tem_produtos;
        }
        public bool Insert()
        {

            try
            {

                string query = "INSERT INTO `ordem_producao_tem_produtos` (`id_ordem`,`id_produto`,`quantidade`) VALUES (@id_ordem, @id_produto, @quantidade);";

                MySqlParameter[] param = new MySqlParameter[]
                {
                new MySqlParameter("@id_ordem", this.id_ordem),
                new MySqlParameter("@id_produto", this.id_produto),
                new MySqlParameter("@quantidade", this.quantidade),
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
