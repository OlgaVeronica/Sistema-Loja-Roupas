using LojaRoupa.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.DAOs
{
    public class CompraProdutoDAO : AbstractDAO<CompraProdutoModel>
    {
        public override void Delete(CompraProdutoModel t)
        {
            throw new NotImplementedException();
        }

        public override void Insert(CompraProdutoModel compraProduto)
        {
            try
            {
                var command = conn.Query();
                command.CommandText = "insert into compra_roupa values (null, @quantidade, @compraID, @produtoId)";

                command.Parameters.AddWithValue("@quantidade", compraProduto.Quantidade);
                command.Parameters.AddWithValue("@compraID", compraProduto.CompraId);
                command.Parameters.AddWithValue("@produtoId", compraProduto.ProdutoId);

                int resultado = command.ExecuteNonQuery();
                if (resultado == 0)
                {
                    throw new Exception("Erro ao inserir Venda - produto");
                }
            } catch(Exception error)
            {
                throw error;
            }
            finally
            {
                conn.Close();
            }
        }

        public override List<CompraProdutoModel> List()
        {
            throw new NotImplementedException();
        }

        public override void Update(CompraProdutoModel t)
        {
            throw new NotImplementedException();
        }
    }
}
