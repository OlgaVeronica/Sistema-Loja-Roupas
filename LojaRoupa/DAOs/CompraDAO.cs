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
                command.CommandText = "select * from compra ";



                command.CommandText = "select * from compra where(status_comp like 'ativo');";


                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var compra = new CompraModel();
                    /*funcionario.Id = reader.GetInt32("id_func");
                    funcionario.Nome = DAOHelper.GetString(reader, "nome_func");
                    funcionario.Telefone = DAOHelper.GetString(reader, "telefone_func");
                    funcionario.Endereco = DAOHelper.GetString(reader, "endereco_func");
                    funcionario.Cpf = DAOHelper.GetString(reader, "cpf_func");
                    funcionario.Sexo = DAOHelper.GetString(reader, "sexo_func");
                    funcionario.Email = DAOHelper.GetString(reader, "email_func");
                    funcionario.RG = DAOHelper.GetString(reader, "rg_func");
                    funcionario.Funcao = DAOHelper.GetString(reader, "funcao_func");
                    funcionario.Salario = DAOHelper.GetString(reader, "salario_func");
                    funcionario.Status = DAOHelper.GetString(reader, "status_func");

                    lista.Add(funcionario);*/

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
