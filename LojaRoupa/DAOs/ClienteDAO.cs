using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public override void Insert(ClienteModel compra)
        {
        }

        public override void Update(ClienteModel compra)
        {
        }

        public override List<ClienteModel> List()
        {
            return new List<ClienteModel>();
        }

    }
}