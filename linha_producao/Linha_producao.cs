using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linha_producao
{
    internal class Linha_producao:Conexao
    {
        public int id;

        public int id_empresa;

        public int id_setor;

        public int id_responsavel;

        public string nome;

        public DateTime data_cadastro;

        public List<Linha_producao> GetListaLinha_producao()
        {
            List<Linha_producao> linha_producao = new List<Linha_producao>();

            try
            {
                OpenConnection();

                string query = "SELECT * FROM linha_producao";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())

                        while (reader.Read())
                        {
                            Linha_producao novoLinha_producao = new Linha_producao();

                            novoLinha_producao.id = Convert.ToInt32(reader.GetString("id"));
                            novoLinha_producao.id_empresa = Convert.ToInt32(reader.GetString("id_empresa"));
                            novoLinha_producao.id_setor = Convert.ToInt32(reader.GetString("id_setor"));
                            novoLinha_producao.id_responsavel = Convert.ToInt32(reader.GetString("id_responsavel"));
                            novoLinha_producao.nome = reader.GetString("nome");
                            novoLinha_producao.data_cadastro = DateTime.Parse(reader.GetString("data_cadastro"));

                            linha_producao.Add(novoLinha_producao);
                        }
                }

                CloseConnection();

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return linha_producao;
        }
        public bool Insert()
        {

            try
            {

                string query = "INSERT INTO `linha_producao` (`id_empresa`,`id_setor`,`id_responsavel`,`nome`) VALUES (@id_empresa, @id_setor, @id_responsavel, @nome);";

                MySqlParameter[] param = new MySqlParameter[]
                {
                new MySqlParameter("@id_empresa", this.id_empresa),
                new MySqlParameter("@id_setor", this.id_setor),
                new MySqlParameter("@id_responsavel", this.id_responsavel),
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
