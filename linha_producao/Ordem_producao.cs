using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linha_producao
{
    internal class Ordem_producao:Conexao
    {
        public int id;

        public int id_empresa;

        public int id_setor;

        public int id_cliente;

        public DateTime data_cadastro;

        public List<Ordem_producao> GetListaOrdem_producao()
        {
            List<Ordem_producao> ordem_producao = new List<Ordem_producao>();

            try
            {
                OpenConnection();

                string query = "SELECT * FROM ordem_producao";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())

                        while (reader.Read())
                        {
                            Ordem_producao novoOrdem_producao = new Ordem_producao();

                            novoOrdem_producao.id = Convert.ToInt32(reader.GetString("id"));
                            novoOrdem_producao.id_empresa = Convert.ToInt32(reader.GetString("id_empresa"));
                            novoOrdem_producao.id_setor = Convert.ToInt32(reader.GetString("id_setor"));
                            novoOrdem_producao.id_cliente = Convert.ToInt32(reader.GetString("id_cliente"));
                            novoOrdem_producao.data_cadastro = DateTime.Parse(reader.GetString("data_cadastro"));

                            ordem_producao.Add(novoOrdem_producao);
                        }
                }

                CloseConnection();

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return ordem_producao;
        }

        public bool Insert()
        {

            try
            {

                string query = "INSERT INTO `ordem_producao` (`id_impresa`,`id_setor`,`id_cliente`) VALUES (@id_empresa, @id_setor, @id_cliente);";

                MySqlParameter[] param = new MySqlParameter[]
                {
                new MySqlParameter("@id_empresa", this.id_empresa),
                new MySqlParameter("@id_setor", this.id_setor),
                new MySqlParameter("@id_cliente", this.id_cliente),
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
