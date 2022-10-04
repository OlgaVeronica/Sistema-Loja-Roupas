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
namespace LojaRoupa.DAOs
{
    class ProdutoDAO: AbstractDAO<ProdutoModel>
    {
        public override void Delete(ProdutoModel prod)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override void Update(ProdutoModel prod)
        {
            throw new NotImplementedException();
        }
    }

}
