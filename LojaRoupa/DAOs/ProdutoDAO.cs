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
    class ProdutoDAO : AbstractDAO<ProdutoModel>
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
                    "@tamanho, @estampa, 'ativo', @preco, @id);";



                command.Parameters.AddWithValue("@descricao", prod.Descricao);
                command.Parameters.AddWithValue("@tecido", prod.Tecido);
                command.Parameters.AddWithValue("@tipo", prod.Tipo);
                command.Parameters.AddWithValue("@colecao", prod.Colecao);
                command.Parameters.AddWithValue("@tamanho", prod.Tamanho);
                command.Parameters.AddWithValue("@estampa", prod.Estampa);
                command.Parameters.AddWithValue("@preco", prod.Preco);
                command.Parameters.AddWithValue("@id", prod.Marca.Id);

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

                command.CommandText = "select roupa.*, marca.nome_mar from roupa, marca where(status_roup like 'ativo') and (roupa.id_mar_fk = marca.id_mar);";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var produto = new ProdutoModel();
                    produto.Id = reader.GetInt32("id_roup");
                    produto.Descricao = DAOHelper.GetString(reader, "descricao_roup");
                    produto.Tecido = DAOHelper.GetString(reader, "material_roup");
                    produto.Tipo = DAOHelper.GetString(reader, "tipo_roup");
                    produto.Colecao = DAOHelper.GetString(reader, "colecao_roup");
                    produto.Tamanho = DAOHelper.GetString(reader, "tamanho_roup");
                    produto.Estampa = DAOHelper.GetString(reader, "estampa_roup");
                    produto.Status = DAOHelper.GetString(reader, "status_roup");
                    produto.Marca = new MarcaModel();
                    produto.Preco = reader.GetInt32("valor_roup");
                    produto.Marca.Nome = DAOHelper.GetString(reader, "nome_mar");



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
                command.CommandText = "update roupa set descricao_roup = @descricao, material_roup = @tecido, tipo_roup = @tipo, " +
                    "colecao_roup = @colecao, tamanho_roup = @tamanho, estampa_roup = @estampa, id_mar_fk = @idmar, valor_roup = @valor where (id_roup = @id)";


                command.Parameters.AddWithValue("@id", prod.Id);
                command.Parameters.AddWithValue("@descricao", prod.Descricao);
                command.Parameters.AddWithValue("@tecido", prod.Tecido);
                command.Parameters.AddWithValue("@tipo", prod.Tipo);
                command.Parameters.AddWithValue("@colecao", prod.Colecao);
                command.Parameters.AddWithValue("@tamanho", prod.Tamanho);
                command.Parameters.AddWithValue("@estampa", prod.Estampa);
                command.Parameters.AddWithValue("@idmar", prod.Marca.Id);
                command.Parameters.AddWithValue("@valor", prod.Preco);

                var resultado = command.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw ex;
            }


        }

    }
}


