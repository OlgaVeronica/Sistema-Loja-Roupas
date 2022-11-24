using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaRoupa.DAOs;
using LojaRoupa.Database;
using LojaRoupa.Helpers;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;

namespace LojaRoupa.DAOs
{
    class UsuarioDAO : AbstractDAO<UsuarioModel>
    {
        public override void Delete(UsuarioModel user)
        {
            throw new NotImplementedException();
        }

        public override void Insert(UsuarioModel user)
        {
            try
            {
                var command = conn.Query();
                command.CommandText = "insert into usuario values (null,@nome, @cpf,@senha)";

                command.Parameters.AddWithValue("@nome", user.Nome);
                command.Parameters.AddWithValue("@cpf", user.CPF);
                command.Parameters.AddWithValue("@senha", user.Senha);

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

        public override List<UsuarioModel> List()
        {

            try
            {
                var lista = new List<UsuarioModel>();

                var command = conn.Query();



                command.CommandText = "select * from usuario;";


                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var user = new UsuarioModel
                    {
                        Nome = DAOHelper.GetString(reader,"nome_user"),
                        CPF = DAOHelper.GetString(reader,"cpf_user"),
                        Senha = DAOHelper.GetString(reader,"senha_user")

                    };

                    lista.Add(user);

                }
                reader.Close();


                return lista;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

        }

        public override void Update(UsuarioModel t)
        {
            throw new NotImplementedException();
        }
    }
}
