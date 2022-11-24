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
        public override void Delete(UsuarioModel t)
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
                    var usuario = new UsuarioModel();


                    {
                        /*Id = reader.GetInt32("id_user"),
                        RazaoSocial = DAOHelper.GetString(reader, "razao_social_forn"),
                        Cnpj = DAOHelper.GetString(reader, "cnpj_forn"),
                        NomeFantasia = DAOHelper.GetString(reader, "nome_fantasia_forn"),
                        Endereco = DAOHelper.GetString(reader, "endereco_forn"),
                        Email = DAOHelper.GetString(reader, "email_forn"),
                        Telefone = DAOHelper.GetString(reader, "telefone_forn"),
                        Status = DAOHelper.GetString(reader, "status_forn")*/
                    };

                    lista.Add(usuario);

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
