using MySql.Data.MySqlClient;
using Projeto_teste;
using System;

namespace Projeto_teste
{
    class Program
    {
        static void Main()
        {
            int op;

            do
            {
                Console.Clear();

                Console.WriteLine("================================");
                Console.WriteLine("        SISTEMA DE PRODUTOS      ");
                Console.WriteLine("================================");
                Console.WriteLine();
                Console.WriteLine("1 - Cadastrar produto");
                Console.WriteLine("2 - Listar produtos");
                Console.WriteLine("3 - Atualizar produto");
                Console.WriteLine("4 - Excluir produto");
                Console.WriteLine("0 - Sair");
                Console.WriteLine();
                Console.Write("Escolha uma opção: ");

                op = int.Parse(Console.ReadLine());

                Console.Clear();

                if (op == 1) cadastrar();
                if (op == 2) listar();
                if (op == 3) atualizar();
                if (op == 4) excluir();

                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            while (op != 0);
        }

        static void cadastrar()
        {
            Console.WriteLine("=== CADASTRAR PRODUTO ===");
            Console.WriteLine();

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine());

            Console.Write("Quantidade: ");
            int qtd = int.Parse(Console.ReadLine());

            MySqlConnection con = Conexao.conectar();
            con.Open();

            string sql = "INSERT INTO produtos (nome, preco, quantidade) VALUES ('" + nome + "', '" + preco + "', '" + qtd + "')";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();

            Console.WriteLine();
            Console.WriteLine("Produto cadastrado com sucesso");
        }

        static void listar()
        {
            Console.WriteLine("=== LISTA DE PRODUTOS ===");
            Console.WriteLine();

            MySqlConnection con = Conexao.conectar();
            con.Open();

            string sql = "SELECT * FROM produtos";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine(
                    dr["id"] + " - " +
                    dr["nome"] + " | " +
                    dr["preco"] + " | " +
                    dr["quantidade"]
                );
            }

            con.Close();
        }

        static void atualizar()
        {
            Console.WriteLine("=== ATUALIZAR PRODUTO ===");
            Console.WriteLine();

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Novo nome: ");
            string nome = Console.ReadLine();

            Console.Write("Novo preço: ");
            double preco = double.Parse(Console.ReadLine());

            Console.Write("Nova quantidade: ");
            int qtd = int.Parse(Console.ReadLine());

            MySqlConnection con = Conexao.conectar();
            con.Open();

            string sql = "UPDATE produtos SET nome='" + nome + "', preco='" + preco + "', quantidade='" + qtd + "' WHERE id=" + id;
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();

            Console.WriteLine();
            Console.WriteLine("Produto atualizado com sucesso");
        }

        static void excluir()
        {
            Console.WriteLine("=== EXCLUIR PRODUTO ===");
            Console.WriteLine();

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            MySqlConnection con = Conexao.conectar();
            con.Open();

            string sql = "DELETE FROM produtos WHERE id=" + id;
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();

            Console.WriteLine();
            Console.WriteLine("Produto excluído com sucesso");
        }
    }
}
