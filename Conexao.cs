using MySql.Data.MySqlClient;

namespace Projeto_teste
{
    class Conexao
    {
        public static MySqlConnection conectar()
        {
            string str = "server=localhost;database=mercado;uid=root;pwd=;";
            MySqlConnection con = new MySqlConnection(str);
            return con;
        }
    }
}
