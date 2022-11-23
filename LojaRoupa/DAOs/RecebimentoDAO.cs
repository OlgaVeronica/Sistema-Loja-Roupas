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

                command.CommandText = "insert into recebimento values (null, @dataAbertura, @dataReceb, @valor, @hora, @formaR, @status, @fkCai, @fkVen);";

                command.Parameters.AddWithValue("@dataAbertura", recebimento.DataAbertura);
                command.Parameters.AddWithValue("@dataReceb", recebimento.Data);
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
                //  COLOCAR NUMERO DO CAIXA 
                command.CommandText = "select recebimento.*, (select id_cai from caixa where Caixa.id_cai = Recebimento.id_cai_fk) as caixa, Venda.id_ven from recebimento, venda where(Venda.id_ven = Recebimento.id_ven_fk);";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DateTime? data = DAOHelper.GetDateTime(reader, "data_receb");
                    string hora = DAOHelper.GetString(reader, "hora_receb") != null ? DAOHelper.GetString(reader, "hora_receb") : " ";
                    

                    var recebimento = new RecebimentoModel();
                    recebimento.Id = reader.GetInt32("id_receb");
                    recebimento.Data = data != null? data?.ToString("dd/MM/yyyy") : "";
                    recebimento.Valor = DAOHelper.GetDouble(reader, "valor_receb");
                    recebimento.Hora = hora;
                    recebimento.StatusReceb = DAOHelper.GetString(reader, "status_receb");
                    recebimento.FormaReceb = DAOHelper.GetString(reader, "forma_recebimento_receb");
                    recebimento.Caixa.Id = DAOHelper.GetInt(reader, "caixa");
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
