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
                command.CommandText = "select recebimento.*, (select numero_cai from caixa where Caixa.id_cai = Recebimento.id_cai_fk) as caixa, (select nome_cli from cliente where (Venda.id_cli_fk = Cliente.id_cli) and (venda.id_ven = recebimento.id_ven_fk)) as cliente, Venda.id_ven from recebimento, venda where(Venda.id_ven = Recebimento.id_ven_fk);";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DateTime? dataReceb = DAOHelper.GetDateTime(reader, "data_receb");
                    DateTime? dataAbertura = DAOHelper.GetDateTime(reader, "data_abertura");
                    string hora = DAOHelper.GetString(reader, "hora_receb") ?? " ";


                    var recebimento = new RecebimentoModel
                    {
                        Id = reader.GetInt32("id_receb"),
                        Data = dataReceb != null ? dataReceb?.ToString("dd/MM/yyyy") : "",
                        DataAbertura = dataAbertura != null ? dataAbertura?.ToString("dd/MM/yyyy") : "",
                        Valor = DAOHelper.GetDouble(reader, "valor_receb"),
                        Hora = hora,
                        StatusReceb = DAOHelper.GetString(reader, "status_receb"),
                        FormaReceb = DAOHelper.GetString(reader, "forma_recebimento_receb")
                    };
                    recebimento.Cliente.Nome = DAOHelper.GetString(reader, "cliente");
                    recebimento.Caixa.Numero = DAOHelper.GetInt(reader, "caixa");
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

        public override void Update(RecebimentoModel recebimento)
        {
            try
            {
                var command = conn.Query();

                command.CommandText = "update recebimento set status_receb = @status, id_cai_fk = @caixa, data_receb = @data, hora_receb = @hora where (@id = id_receb);";

                
                command.Parameters.AddWithValue("@status", recebimento.StatusReceb);
                command.Parameters.AddWithValue("@Caixa", recebimento.Caixa.Id);
                command.Parameters.AddWithValue("@id", recebimento.Id);
                command.Parameters.AddWithValue("@data", recebimento.Data);
                command.Parameters.AddWithValue("@hora", recebimento.Hora);
               

                int resultado = command.ExecuteNonQuery();

                if(resultado > 0)
                {
                    var dao = new CaixaDAO();
                    dao.UpdateValorCaixa(recebimento, "Venda");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
