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

                

                var fkCliente = venda.Cliente == null ? null : venda.Cliente.Id;

                command.CommandText = "insert into venda values (null, @data, @hora, @valor, @status, @funcionario, @cliente)";
                command.Parameters.AddWithValue("@data", venda.Data);
                command.Parameters.AddWithValue("@hora", venda.Hora);
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
                        try
                        {

                            var dao = new VendaProdutoDAO();
                            VendaProdutoModel vp = new VendaProdutoModel();

                            vp.VendaId = idVend;
                            vp.ProdutoId = item.Id;
                            vp.Quantidade = item.Quantidade;
                            dao.Insert(vp);
                        }
                        catch
                        {

                        }

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
            try
            {
                List<VendaModel> lista = new List<VendaModel>();
                var command = conn.Query();
                command.CommandText = "select id_ven, (select nome_cli from cliente where Venda.id_cli_fk = Cliente.id_cli) as cliente, data_ven, hora_ven, valor_ven,nome_func  from venda,  funcionario where ((Funcionario.id_func = Venda.id_func_fk));";
                //command.CommandText = "select * from venda";

                MySqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    string cliente = DAOHelper.GetString(reader, "cliente") != null ? DAOHelper.GetString(reader, "cliente") : "Não consta";


                    var venda = new VendaModel();
                    venda.Funcionario.Nome = DAOHelper.GetString(reader, "nome_func");
                    venda.Hora = DAOHelper.GetString(reader, "hora_ven");
                    venda.Cliente.Nome = cliente;
                    venda.Id = reader.GetInt32("id_ven");
                    venda.Data = DAOHelper.GetDateTime(reader, "data_ven");
                    venda.Valor = (float)DAOHelper.GetDouble(reader, "valor_ven");
                    lista.Add(venda);
                }
                reader.Close();
                return lista;

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update(VendaModel t)
        {
            throw new NotImplementedException();
        }
    }
}
