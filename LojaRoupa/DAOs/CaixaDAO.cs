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
    public class CaixaDAO : AbstractDAO<CaixaModel>
    {
        public override void Delete(CaixaModel t)
        {
            throw new NotImplementedException();
        }

        public override void Insert(CaixaModel caixa)
        {
            try
            {
                var command = conn.Query();
                command.CommandText = "call AbrirCaixa(@saldoInicial);";
                command.Parameters.AddWithValue("@saldoInicial", caixa.SaldoInicial);
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

        public override List<CaixaModel> List()
        {
            try
            {
                var lista = new List<CaixaModel>();

                var command = conn.Query();

                command.CommandText = "select * from Caixa;";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var caixa = new CaixaModel();
                    caixa.Id = reader.GetInt32("id_cai");
                    caixa.DataCaixa = DAOHelper.GetDateTime(reader, "data_cai");
                    caixa.HoraAbertura = DAOHelper.GetString(reader, "hora_abertura_cai");
                    caixa.HoraFechamento = DAOHelper.GetString(reader, "hora_fechamento_cai");
                    caixa.SaldoInicial = DAOHelper.GetDouble(reader, "saldo_inicial_cai");
                    caixa.SaldoFinal = DAOHelper.GetDouble(reader, "saldo_final_cai");
                    caixa.TotalEntrada = DAOHelper.GetDouble(reader, "total_entrada_cai");
                    caixa.TotalSaida = DAOHelper.GetDouble(reader, "total_saida_cai");
                    caixa.Status = DAOHelper.GetString(reader, "status_cai");
                    caixa.Numero = reader.GetInt32("numero_cai");
                    lista.Add(caixa);

                }
                reader.Close();


                return lista;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
        public  List<CaixaModel> List(string tipo)
        {
            try
            {
                var lista = new List<CaixaModel>();

                var command = conn.Query();

                command.CommandText = "select * from Caixa;";

                if(tipo == "Abertos")
                {
                    command.CommandText = "select * from Caixa where status_cai = 'Aberto';";
                }

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var caixa = new CaixaModel();
                    caixa.Id = reader.GetInt32("id_cai");
                    caixa.DataCaixa = DAOHelper.GetDateTime(reader, "data_cai");
                    caixa.HoraAbertura = DAOHelper.GetString(reader, "hora_abertura_cai");
                    caixa.HoraFechamento = DAOHelper.GetString(reader, "hora_fechamento_cai");
                    caixa.SaldoInicial = DAOHelper.GetDouble(reader, "saldo_inicial_cai");
                    caixa.SaldoFinal = DAOHelper.GetDouble(reader, "saldo_final_cai");
                    caixa.TotalEntrada = DAOHelper.GetDouble(reader, "total_entrada_cai");
                    caixa.TotalSaida = DAOHelper.GetDouble(reader, "total_saida_cai");
                    caixa.Status = DAOHelper.GetString(reader, "status_cai");
                    caixa.Numero = reader.GetInt32("numero_cai");
                    lista.Add(caixa);

                }
                reader.Close();


                return lista;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public CaixaModel UltimoCaixa()
        {
            try
            {
                var caixa = new CaixaModel();

                var command = conn.Query();

                command.CommandText = "select * from Caixa order by id_cai desc limit 1;";
                int resultado = command.ExecuteNonQuery();

                if (resultado > 0)
                {

                    MySqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                
                    caixa.Id = reader.GetInt32("id_cai");
                    caixa.Numero = reader.GetInt32("numero_cai");
                    caixa.DataCaixa = DAOHelper.GetDateTime(reader, "data_cai");
                    caixa.HoraAbertura = DAOHelper.GetString(reader, "hora_abertura_cai");
                    caixa.HoraFechamento = DAOHelper.GetString(reader, "hora_fechamento_cai");
                    caixa.SaldoInicial = DAOHelper.GetDouble(reader, "saldo_inicial_cai");
                    caixa.SaldoFinal = DAOHelper.GetDouble(reader, "saldo_final_cai");
                    caixa.TotalEntrada = DAOHelper.GetDouble(reader, "total_entrada_cai");
                    caixa.TotalSaida = DAOHelper.GetDouble(reader, "total_saida_cai");
                    caixa.Status = DAOHelper.GetString(reader, "status_cai");
                


                }
                return caixa;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

       

        public override void Update(CaixaModel t)
        {


        }

        public void UpdateValorCaixa(RecebimentoModel recebimento, string operacao)
        {
            try
            {
                var command = conn.Query();

                if(operacao == "Venda")
                {
                    command.CommandText = "update caixa set total_entrada_cai = total_entrada_cai + @Valor, saldo_final_cai = saldo_inicial_cai + @Valor + total_entrada_cai - total_saida_cai, hora_fechamento_cai = @hora where (@id = id_cai);";

                }
                else
                {
                    command.CommandText = "update caixa set total_saida_cai = total_saida_cai + @Valor, saldo_final_cai = saldo_inicial_cai - @Valor + total_entrada_cai - total_saida_cai, hora_fechamento_cai = @hora where (@id = id_cai);";

                }



                command.Parameters.AddWithValue("@Valor", recebimento.Valor);
                command.Parameters.AddWithValue("@hora", recebimento.Hora);
                command.Parameters.AddWithValue("@id", recebimento.Caixa.Id);


                int resultado = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fecharCaixa(int numero)
        {
            try
            {
                var command = conn.Query();
                command.CommandText = "update caixa set status_cai = 'Fechado' where (numero_cai = @numero);";

                command.Parameters.AddWithValue("@numero", numero);
                int resultado = command.ExecuteNonQuery();

                
            }
            catch
            {

            }
        }
    }
}
