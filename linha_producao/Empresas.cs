using linha_producao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linha_producao
{
    internal class Empresas:Conexao
    {
        public int id;

        public string nome;

        public string cnpj;

        public string email;

        public DateTime data_cadastro;
        public List<Empresas> GetListaEmpresas()
        {
            List<Empresas> empresas = new List<Empresas>();

            try
            {
                OpenConnection();

                string query = "SELECT * FROM empresas;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())

                        while (reader.Read())
                        {
                            Empresas novoEmpresa = new Empresas();

                            novoEmpresa.id = Convert.ToInt32(reader.GetString("id"));
                            novoEmpresa.nome = reader.GetString("nome");
                            novoEmpresa.cnpj = reader.GetString("cnpj");
                            novoEmpresa.email = reader.GetString("email");
                            novoEmpresa.data_cadastro = DateTime.Parse(reader.GetString("data_cadastro"));

                            empresas.Add(novoEmpresa);
                        }
                }

                CloseConnection();

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return empresas;
        }

        public bool Insert()
        {

            try
            {

                string query = "INSERT INTO `empresas` (`nome`, `cnpj`, `email`) VALUES (@nome, @cnpj, @email);";

                MySqlParameter[] param = new MySqlParameter[]
                {
                new MySqlParameter("@nome", this.nome),
                new MySqlParameter("@cnpj", this.cnpj),
                new MySqlParameter("@email", this.email),
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