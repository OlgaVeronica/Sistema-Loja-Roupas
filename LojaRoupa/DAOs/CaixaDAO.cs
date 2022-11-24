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

        public override void Insert(CaixaModel t)
        {
            throw new NotImplementedException();
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
    

        public override void Update(CaixaModel t)
        {
            throw new NotImplementedException();
        }
    }
}
