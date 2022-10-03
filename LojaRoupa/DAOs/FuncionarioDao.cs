using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LojaRoupa.DAOs;
using LojaRoupa.Database;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;

namespace LojaRoupa.DAOs
{
    class FuncionarioDAO : AbstractDAO<FuncionarioModel>
    {
        public override void Delete(FuncionarioModel func)
        {
            throw new NotImplementedException();
        }

        public override void Insert(FuncionarioModel func)
        {
            try
            {

                var command = conn.Query();
                command.CommandText = "insert into funcionario values(null, @nome, @telefone, @endereco, @cpf, " +
                    "@sexo, @email, @rg, @funcao, @salario, 'ativo');";

                command.Parameters.AddWithValue("@telefone", func.Telefone);
                command.Parameters.AddWithValue("@endereco", func.Endereco);
                command.Parameters.AddWithValue("@cpf", func.Cpf);
                command.Parameters.AddWithValue("@sexo", func.Sexo);
                command.Parameters.AddWithValue("@email", func.Email);
                command.Parameters.AddWithValue("@rg", func.RG);
                command.Parameters.AddWithValue("@funcao", func.Funcao);
                command.Parameters.AddWithValue("@salario", func.Salario);
                command.Parameters.AddWithValue("@nome", func.Nome);

                var resultado = command.ExecuteNonQuery();



            } catch (MySqlException error)
            {
                throw new Exception();
            }
            finally
            {
                conn.Close();
            }
        }

        public override List<FuncionarioModel> List()
        {
            throw new NotImplementedException();
        }

        public override void Update(FuncionarioModel func)
        {
            throw new NotImplementedException();
        }
    }
}
