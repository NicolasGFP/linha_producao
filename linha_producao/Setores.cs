using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linha_producao
{
    internal class Setores:Conexao
    {
        public int id;

        public int id_empresa;

        public int id_responsavel;

        public string nome;

        public DateTime data_cadastro;

        public List<Setores> GetListaSetores()
        {
            List<Setores> setores = new List<Setores>();

            try
            {
                OpenConnection();

                string query = "SELECT * FROM setores;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())

                        while (reader.Read())
                        {
                            Setores novoSetores = new Setores();

                            novoSetores.id = Convert.ToInt32(reader.GetString("id"));
                            novoSetores.id_empresa = Convert.ToInt32(reader.GetString("id_empresa"));
                            novoSetores.id_responsavel = Convert.ToInt32(reader.GetString("id_responsavel"));
                            novoSetores.nome = reader.GetString("nome");
                            novoSetores.data_cadastro = DateTime.Parse(reader.GetString("data_cadastro"));

                            setores.Add(novoSetores);
                        }
                }

                CloseConnection();

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return setores;
        }
        public bool Insert()
        {

            try
            {

                string query = "INSERT INTO `setores` (`id_empresa`,`id_responsavel`,`nome`) VALUES (@id_empresa, @id_responsavel, @nome);";

                MySqlParameter[] param = new MySqlParameter[]
                {
                new MySqlParameter("@id_empresa", this.id_empresa),
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
