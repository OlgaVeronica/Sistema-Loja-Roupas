using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LojaRoupa.DAOs;
using LojaRoupa.Database;
using LojaRoupa.Helpers;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;

namespace LojaRoupa.DAOs
{
    class FuncionarioDAO : AbstractDAO<FuncionarioModel>
    {
        public override void Delete(FuncionarioModel func)
        {
            try
            {
                var command = conn.Query();
                command.CommandText = "update funcionario set status_func = 'inativo' where (id_func = @id)";

                command.Parameters.AddWithValue("@id", func.Id);

                var resultado = command.ExecuteNonQuery();

                if(resultado == 0)
                {
                    throw new Exception("Erro ao deletar funcionário");
                }

            } catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override void Insert(FuncionarioModel func)
        {
            try
            {

                var command = conn.Query();
                command.CommandText = "insert into funcionario values(null, @nome, @telefone, @endereco, @cpf, " +
                    "@sexo, @email, @rg, @funcao, @salario, @status);";

                command.Parameters.AddWithValue("@telefone", func.Telefone);
                command.Parameters.AddWithValue("@endereco", func.Endereco);
                command.Parameters.AddWithValue("@cpf", func.Cpf);
                command.Parameters.AddWithValue("@sexo", func.Sexo);
                command.Parameters.AddWithValue("@email", func.Email);
                command.Parameters.AddWithValue("@rg", func.RG);
                command.Parameters.AddWithValue("@funcao", func.Funcao);
                command.Parameters.AddWithValue("@salario", func.Salario);
                command.Parameters.AddWithValue("@nome", func.Nome);
                command.Parameters.AddWithValue("@status", func.Status);

                var resultado = command.ExecuteNonQuery();



            } catch (MySqlException error)
            {
                throw error;
            }
            finally
            {
                conn.Close();
            }
        }

        public override List<FuncionarioModel> List()
        {

            try
            {
                var lista = new List<FuncionarioModel>();

                var command = conn.Query();
                command.CommandText = "select * from funcionario ";


                
                command.CommandText = "select * from funcionario where(status_func like 'ativo');";

                
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var funcionario = new FuncionarioModel();
                    funcionario.Id = reader.GetInt32("id_func");
                    funcionario.Nome = DAOHelper.GetString(reader, "nome_func");
                    funcionario.Telefone = DAOHelper.GetString(reader, "telefone_func");
                    funcionario.Endereco = DAOHelper.GetString(reader, "endereco_func");
                    funcionario.Cpf = DAOHelper.GetString(reader, "cpf_func");
                    funcionario.Sexo = DAOHelper.GetString(reader, "sexo_func");
                    funcionario.Email = DAOHelper.GetString(reader, "email_func");
                    funcionario.RG = DAOHelper.GetString(reader, "rg_func");
                    funcionario.Funcao = DAOHelper.GetString(reader, "funcao_func");
                    funcionario.Salario = DAOHelper.GetString(reader, "salario_func");
                    funcionario.Status = DAOHelper.GetString(reader, "status_func");

                    lista.Add(funcionario);

                }
                reader.Close();


                return lista;
            } catch (MySqlException ex)
            {
                throw ex;
            }
            
        }

        public override void Update(FuncionarioModel func)
        {

            try
            {
                var command = conn.Query();
                command.CommandText = "update funcionario set nome_func = @nome, telefone_func = @telefone, endereco_func = @endereco, cpf_func = @cpf, " +
                        "sexo_func = @sexo, email_func = @email, rg_func = @rg, funcao_func = @funcao, salario_func = @salario;";


                command.Parameters.AddWithValue("@telefone", func.Telefone);
                command.Parameters.AddWithValue("@endereco", func.Endereco);
                command.Parameters.AddWithValue("@cpf", func.Cpf);
                command.Parameters.AddWithValue("@sexo", func.Sexo);
                command.Parameters.AddWithValue("@email", func.Email);
                command.Parameters.AddWithValue("@rg", func.RG);
                command.Parameters.AddWithValue("@funcao", func.Funcao);
                command.Parameters.AddWithValue("@salario", func.Salario);
                command.Parameters.AddWithValue("@nome", func.Nome);
                command.Parameters.AddWithValue("@status", func.Status);

                var resultado = command.ExecuteNonQuery();


            } catch(MySqlException ex)
            {
                throw ex;
            }
            

        }
    }
}
