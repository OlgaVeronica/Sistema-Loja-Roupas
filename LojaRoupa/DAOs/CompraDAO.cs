using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LojaRoupa.DAOs;
using LojaRoupa.Database;
using LojaRoupa.Helpers;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace LojaRoupa.DAOs
{
    class CompraDAO : AbstractDAO<CompraModel>
    {
        public override void Delete(CompraModel compra)
        {
            try
            {
                var command = conn.Query();
                command.CommandText = "update compra set status_comp = 'inativo' where (id_com = @id)";

                command.Parameters.AddWithValue("@id", compra.Id);

                var resultado = command.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Erro ao deletar compra");
                }

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override void Insert(CompraModel compra)
        {
            try
            {

                var command = conn.Query();
                command.CommandText = "insert into compra values (null, @data, @hora, @valor, @status,  @fornecedor, @funcionario);";

                command.Parameters.AddWithValue("@data", compra.Data);
                command.Parameters.AddWithValue("@hora", compra.Hora);
                command.Parameters.AddWithValue("@valor", compra.Valor);
                command.Parameters.AddWithValue("@status", "Ativo");                
                command.Parameters.AddWithValue("@funcionario", compra.Funcionario.Id);
                command.Parameters.AddWithValue("@fornecedor", compra.Fornecedor.Id);

                int resultado = command.ExecuteNonQuery();

                if(resultado != 0)
                {
                    command.CommandText = "select id_com from compra order by id_com desc limit 1;";

                    int idCompra = Convert.ToInt32((command.ExecuteScalar()));

                    try
                    {
                        var pag = new PagamentoModel();
                        pag.Data = DateTime.Now.ToString("yyyy-MM-dd");
                        pag.Valor = compra.Valor;
                        pag.Hora = null;
                        pag.FormaPagamento = "À vista";
                        pag.Status = "Aberto";
                        pag.Compra.Id = idCompra;
                        pag.Caixa.Id = null;
                        var dao = new PagamentoDAO();
                        dao.Insert(pag);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    foreach (var produto in compra.Produtos)
                    {
                        try
                        {
                            CompraProdutoModel compProd = new CompraProdutoModel
                            {
                                Quantidade = produto.Quantidade,
                                CompraId = idCompra,
                                ProdutoId = produto.Id
                            };
                            var dao = new CompraProdutoDAO();

                            dao.Insert(compProd);
                        }
                        catch
                        {

                        }
                    }
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

        public override void Update(CompraModel compra)
        {
            try
            {
                var command = conn.Query();
                command.CommandText = "update produto set descricao_roup = @descricao, material_roup = @tecido, tipo_roup = @tipo, " +
                    "colecao_roup = @colecao, tamanho_roup = @tamanho, estampa_roup = @estampa";


                /*command.Parameters.AddWithValue("@descricao", prod.Descricao);
                command.Parameters.AddWithValue("@tecido", prod.Tecido);
                command.Parameters.AddWithValue("@tipo", prod.Tipo);
                command.Parameters.AddWithValue("@colecao", prod.Colecao);
                command.Parameters.AddWithValue("@tamanho", prod.Tamanho);
                command.Parameters.AddWithValue("@estampa", prod.Estampa);

                var resultado = command.ExecuteNonQuery();*/

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override List<CompraModel> List()
        {

            try
            {
                var lista = new List<CompraModel>();

                var command = conn.Query();



                command.CommandText = "select compra.*, (select nome_func from Funcionario where compra.id_func_fk = funcionario.id_func) as funcionario,  (select fornecedor.razao_social_forn from Fornecedor where (fornecedor.id_forn = compra.id_forn_fk)) as fornecedor from Compra, Funcionario, Fornecedor  where (fornecedor.id_forn = compra.id_forn_fk) and (funcionario.id_func = compra.id_func_fk) and (status_comp like 'ativo');";


                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var compra = new CompraModel();
                    compra.Id = reader.GetInt32("id_com");
                    compra.Data = DAOHelper.GetString(reader, "data_com");
                    compra.Hora = DAOHelper.GetString(reader, "hora_com");
                    compra.Valor = DAOHelper.GetDouble(reader, "valor_com");
                    compra.Status = DAOHelper.GetString(reader, "status_comp");
                    compra.Fornecedor.RazaoSocial = DAOHelper.GetString(reader, "fornecedor");
                    compra.Funcionario.Nome = DAOHelper.GetString(reader, "funcionario");
                    

                    lista.Add(compra);

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
