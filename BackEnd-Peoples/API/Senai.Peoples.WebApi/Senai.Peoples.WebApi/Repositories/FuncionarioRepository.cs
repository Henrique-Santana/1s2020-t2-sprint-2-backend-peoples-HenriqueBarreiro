using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string stringConexao = "Data Source=DEV17\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132";

        public FuncionarioDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader fazer a leitura no banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Caso a o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Cria um objeto funcionario
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            // Atribui à propriedade IdFuncionario o valor da coluna "IdFuncionario" da tabela do banco
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"])

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            ,
                            Nome = rdr["Nome"].ToString()
                            ,
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        // Retorna o Funcionario com os dados obtidos
                        return funcionario;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        public void Cadastrar(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                // Declara a query que será executada passando o valor como parâmetro, evitando assim os problemas acima
                string queryInsert = "INSERT INTO Funcionarios(Nome,Sobrenome) VALUES (@Nome, @Sobrenome)";

                // Declara o comando passando a query e a conexão
                SqlCommand cmd = new SqlCommand(queryInsert, con);

                // Passa o valor do parâmetro
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome); //AddWithValue;
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                // Abre a conexão com o banco de dados
                con.Open();

                // Executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> Funcionarios = new List<FuncionarioDomain>();

            /// Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryListFuncionario = "SELECT * FROM Funcionarios;";

                con.Open();

                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryListFuncionario, con))
                {
                    //Executa a queryListFuncionario 
                    rdr = cmd.ExecuteReader();

                    //Laço de repetição que se repitira enquanto tiver linhas para ler;
                    while (rdr.Read())
                    {
                        //Cria um Funcionario para armazenar o Funcionario da linha lida 
                        FuncionarioDomain Funcionario = new FuncionarioDomain
                        {

                            //// Atribui à propriedade IdFuncionario o valor da primeira coluna da tabela do banco
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            Nome = rdr["Nome"].ToString(),

                            // Atribui à propriedade Sobrenome o valor da coluna "Sobrenome" da tabela do banco
                            Sobrenome = rdr["Sobrenome"].ToString(),
                        };

                        //Adiciona os dados armazendo em Funcionario em Funcionarios
                        Funcionarios.Add(Funcionario);
                    }
                }
            }
            return Funcionarios;
        }

        public void AtualizarIdUrl(int id, FuncionarioDomain funcionario)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome ,Sobrenome = @Sobrenome WHERE IdFuncionario = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @ID";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
