﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaRoupa.ViewsModels;


namespace LojaRoupa.DAOs
{
    class VendaDAO : AbstractDAO<VendaModel>
    {
        public override void Delete(VendaModel t)
        {
            throw new NotImplementedException();
        }

        public override void Insert(VendaModel venda)
        {
            try
            {
                var command = conn.Query();

                string data = venda.Data?.ToString("yyyy-MM-dd");
                string hora = venda.Data?.ToString("hh:mm:ss");

                var fkCliente = venda.Cliente == null ? null : venda.Cliente.Id;

                command.CommandText = "insert into venda values (null, @data, @hora, @valor, @status, @funcionario, @cliente)";
                command.Parameters.AddWithValue("@data", data);
                command.Parameters.AddWithValue("@hora", hora);
                command.Parameters.AddWithValue("@valor", venda.Valor);
                command.Parameters.AddWithValue("@status", "Ativo");
                command.Parameters.AddWithValue("@funcionario", venda.Funcionario.Id);
                command.Parameters.AddWithValue("@cliente", fkCliente);

                int resultado = command.ExecuteNonQuery();

                if (resultado != 0)
                {
                    command.CommandText = "SELECT id_ven FROM venda ORDER BY id_ven DESC LIMIT 1";
                    int idVend = Convert.ToInt32(command.ExecuteScalar());

                    foreach(var item in venda.Produto)
                    {

                        var dao = new VendaProdutoDAO();
                        VendaProdutoModel vp = new VendaProdutoModel();

                        vp.VendaId = idVend;
                        vp.ProdutoId = item.Id;
                        vp.Quantidade = item.Quantidade;
                        dao.Insert(vp);

                    }

                }
                else
                {
                    throw new Exception("Erro ao inserir registros no banco de dados");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            
        }

        public override List<VendaModel> List()
        {
            throw new NotImplementedException();
        }

        public override void Update(VendaModel t)
        {
            throw new NotImplementedException();
        }
    }
}
