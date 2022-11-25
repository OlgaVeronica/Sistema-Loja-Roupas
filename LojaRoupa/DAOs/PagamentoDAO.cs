﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LojaRoupa.Helpers;
using LojaRoupa.ViewsModels;

namespace LojaRoupa.DAOs
{
    public class PagamentoDAO: AbstractDAO<PagamentoModel>
    {
        public override void Delete(PagamentoModel pagamento)
        {
            
        }

        public override void Insert(PagamentoModel pagamento)
        {
            try
            {
                var command = conn.Query();
                command.CommandText = "insert into Pagamento values(null, @data, @valor, @hora, @formaPag, 'ativo', @fkCaixa, @fkCompra);";

                command.Parameters.AddWithValue("@data", pagamento.Data);
                command.Parameters.AddWithValue("@valor", pagamento.Valor);
                command.Parameters.AddWithValue("@hora", pagamento.Hora);
                command.Parameters.AddWithValue("@formaPag", pagamento.FormaPagamento);
                command.Parameters.AddWithValue("@fkCaixa", null);
                command.Parameters.AddWithValue("@fkCompra", pagamento.Compra.Id);

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

        public override List<PagamentoModel> List()
        {
            try
            {
                var lista = new List<PagamentoModel>();

                var command = conn.Query();
                command.CommandText = "select pagamento.*, (select numero_cai from caixa where Caixa.id_cai = Pagamento.id_cai_fk) as caixa, compra.id_com from compra, pagamento where(Compra.id_com = Pagamento.id_com_fk)";


                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var pagamento = new PagamentoModel();

                    DateTime? data = DAOHelper.GetDateTime(reader, "data_pag");
                    string hora = DAOHelper.GetString(reader, "hora_pag") ?? " ";

                    pagamento.Id = reader.GetInt32("id_pag");
                    pagamento.Data = data?.ToString("dd/MM/yyyy");
                    pagamento.Valor = DAOHelper.GetDouble(reader, "valor_pag");
                    pagamento.Hora = hora;
                    pagamento.FormaPagamento = DAOHelper.GetString(reader, "forma_pag");
                    pagamento.Status = DAOHelper.GetString(reader, "status_pag");

                    pagamento.Caixa.Numero = DAOHelper.GetInt(reader, "caixa");
                    pagamento.Compra.Id = reader.GetInt32("id_com_fk");

                    lista.Add(pagamento);

                }
                reader.Close();


                return lista;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

        }

        public override void Update(PagamentoModel pagamento)
        {
            try
            {

                var command = conn.Query();
                command.CommandText = "update pagamento set data_pag = @data, id_cai_fk = @caixa,valor_pag = @valor, hora_pag = @hora,forma_pag = @formaPag, status_pag = @status where(id_pag = @id)";

                command.Parameters.AddWithValue("@id", pagamento.Id);
                command.Parameters.AddWithValue("@data", pagamento.Data);
                command.Parameters.AddWithValue("@valor", pagamento.Valor);
                command.Parameters.AddWithValue("@hora", pagamento.Hora);
                command.Parameters.AddWithValue("@Caixa", pagamento.Caixa.Id);
                command.Parameters.AddWithValue("@formaPag", pagamento.FormaPagamento);
                command.Parameters.AddWithValue("@status", pagamento.Status);

                var resultado = command.ExecuteNonQuery();

                if (resultado > 0)
                {
                    var dao = new CaixaDAO();
                    dao.UpdateValorCaixa(pagamento, "Compra");
                }

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

    }
    
}
