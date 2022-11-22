using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;
using LojaRoupa.Helpers;
namespace LojaRoupa.DAOs
{
    public class RecebimentoDAO : AbstractDAO<RecebimentoModel>
    {
        public override void Delete(RecebimentoModel t)
        {
            throw new NotImplementedException();
        }

        public override void Insert(RecebimentoModel recebimento)
        {
            try
            {
                var command = conn.Query();

                command.CommandText = "insert into recebimento values (null, @data, @valor, @hora, @formaR, @status, @fkCai, @fkVen);";

                command.Parameters.AddWithValue("@data", recebimento.Data);
                command.Parameters.AddWithValue("@valor", recebimento.Valor);
                command.Parameters.AddWithValue("@hora", recebimento.Hora);
                command.Parameters.AddWithValue("@formaR", recebimento.FormaReceb);
                command.Parameters.AddWithValue("@status", recebimento.StatusReceb);
                command.Parameters.AddWithValue("@fkCai", recebimento.Caixa.Id);
                command.Parameters.AddWithValue("@fkVen", recebimento.Venda.Id);

                int resultado = command.ExecuteNonQuery();

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<RecebimentoModel> List()
        {
            try
            {
                var lista = new List<RecebimentoModel>();

                var command = conn.Query();

                command.CommandText = "select * from recebimento";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DateTime? data = DAOHelper.GetDateTime(reader, "data_receb");
                    
                    var recebimento = new RecebimentoModel();
                    recebimento.Id = reader.GetInt32("id_receb");
                    recebimento.Data = data?.ToString("dd/MM/yyyy");
                    recebimento.Valor = DAOHelper.GetDouble(reader, "valor_receb");
                    recebimento.Hora = DAOHelper.GetString(reader, "hora_receb");
                    recebimento.StatusReceb = DAOHelper.GetString(reader, "status_receb");
                    recebimento.FormaReceb = DAOHelper.GetString(reader, "forma_recebimento_receb");
                    recebimento.Caixa.Id = reader.GetInt32("id_cai_fk");
                    recebimento.Venda.Id = reader.GetInt32("id_ven_fk");
                    lista.Add(recebimento);

                }
                reader.Close();


                return lista;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override void Update(RecebimentoModel t)
        {
            throw new NotImplementedException();
        }
    }
}
