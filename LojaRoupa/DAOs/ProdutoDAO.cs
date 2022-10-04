using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LojaRoupa.DAOs;
using LojaRoupa.Database;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;
using LojaRoupa.Helpers;
namespace LojaRoupa.DAOs
{
    class ProdutoDAO: AbstractDAO<ProdutoModel>
    {
        public override void Delete(ProdutoModel prod)
        {
            try
            {
                var command = conn.Query();
                command.CommandText = "update roupa set status_roup = 'inativo' where (id_roup = @id)";

                command.Parameters.AddWithValue("@id", prod.Id);

                var resultado = command.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Erro ao deletar funcionário");
                }

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override void Insert(ProdutoModel prod)
        {
            try
            {

                var command = conn.Query();
                command.CommandText = "insert into roupa values(null, @descricao, @tecido, @tipo, @colecao, " +
                    "@tamanho, @estampa, 'ativo');";

                command.Parameters.AddWithValue("@descricao", prod.Descricao);
                command.Parameters.AddWithValue("@tecido", prod.Tecido);
                command.Parameters.AddWithValue("@tipo", prod.Tipo);
                command.Parameters.AddWithValue("@colecao", prod.Colecao);
                command.Parameters.AddWithValue("@tamanho", prod.Tamanho);
                command.Parameters.AddWithValue("@estampa", prod.Estampa);

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

        public override List<ProdutoModel> List()
        {
            try
            {
                var lista = new List<ProdutoModel>();

                var command = conn.Query();

                command.CommandText = "select * from roupa where(status_roup like 'ativo');";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var produto = new ProdutoModel();
                    produto.Id = reader.GetInt32("id_roup");
                    produto.Descricao = DAOHelper.GetString(reader, "descricao_roup");
                    produto.Tecido = DAOHelper.GetString(reader, "material_roup");
                    produto.Tipo = DAOHelper.GetString(reader, "tipo_roup");
                    produto.Colecao = DAOHelper.GetString(reader, "colecao_roup");
                    produto.Estampa = DAOHelper.GetString(reader, "estampa_roup");
                    produto.Status = DAOHelper.GetString(reader, "status_roup");

                    lista.Add(produto);

                }
                reader.Close();


                return lista;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override void Update(ProdutoModel prod)
        {
            try
            {
                var command = conn.Query();
                command.CommandText = "update produto set descricao_roup = @descricao, material_roup = @tecido, tipo_roup = @tipo, " +
                    "colecao_roup = @colecao, tamanho_roup = @tamanho, estampa_roup = @estampa";


                command.Parameters.AddWithValue("@descricao", prod.Descricao);
                command.Parameters.AddWithValue("@tecido", prod.Tecido);
                command.Parameters.AddWithValue("@tipo", prod.Tipo);
                command.Parameters.AddWithValue("@colecao", prod.Colecao);
                command.Parameters.AddWithValue("@tamanho", prod.Tamanho);
                command.Parameters.AddWithValue("@estampa", prod.Estampa);

                var resultado = command.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw ex;
            }


        }
    }
    }


