using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaRoupa.Helpers;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;

namespace LojaRoupa.DAOs
{
    class ClienteDAO : AbstractDAO<ClienteModel>
    {
        public override void Delete(ClienteModel cliente)
        {
            try
            {
                var command = conn.Query();
                command.CommandText = "update cliente set status_cli = 'inativo' where (id_cli = @id)";

                command.Parameters.AddWithValue("@id", cliente.Id);

                var resultado = command.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Erro ao deletar funcionário");
                }

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override void Insert(ClienteModel cliente)
        {
            try
            {

                var command = conn.Query();
                command.CommandText = "insert into cliente values(null, @nome, @cpf, @telefone, @status)";

                command.Parameters.AddWithValue("@telefone", cliente.Telefone);
                command.Parameters.AddWithValue("@cpf", cliente.Cpf);
                command.Parameters.AddWithValue("@nome", cliente.Nome);
                command.Parameters.AddWithValue("@status", cliente.Status);

                var resultado = command.ExecuteNonQuery();



            }
            catch (MySqlException error)
            {
                throw error;
            }
            finally
            {
                conn.Close();
            }
        }

        public override void Update(ClienteModel cliente)
        {
            
            try
            {

                var command = conn.Query();
                command.CommandText = "update cliente set nome_cli = @nome, cpf_cli = @cpf, telefone_cli = @telefone, status_cli = @status where(id_cli = @id);";

                command.Parameters.AddWithValue("@id", cliente.Id);
                command.Parameters.AddWithValue("@telefone", cliente.Telefone);
                command.Parameters.AddWithValue("@cpf", cliente.Cpf);
                command.Parameters.AddWithValue("@nome", cliente.Nome);
                command.Parameters.AddWithValue("@status", cliente.Status);

                var resultado = command.ExecuteNonQuery();


            }
            catch (MySqlException ex)
            {
                throw ex;
            }

        }

        public override List<ClienteModel> List()
        {

            try
            {
                var lista = new List<ClienteModel>();

                var command = conn.Query();
                //command.CommandText = "select * from cliente";

                command.CommandText = "select * from cliente where(status_cli like 'ativo');";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var cliente = new ClienteModel
                    {
                        Id = reader.GetInt32("id_cli"),
                        Nome = DAOHelper.GetString(reader, "nome_cli"),
                        Cpf = DAOHelper.GetString(reader, "cpf_cli"),
                        Telefone = DAOHelper.GetString(reader, "telefone_cli"),
                        Status = DAOHelper.GetString(reader, "status_cli")
                    };

                    lista.Add(cliente);

                }
                reader.Close();


                return lista;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

    }
}